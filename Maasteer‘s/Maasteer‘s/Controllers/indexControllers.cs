using AutoMapper;
using Blog.Core.Database.Pagination;
using Blog.Core.Repository;
using Blog.Core.UnitOfWork;
using Blog.Core.ViewModel.Articles;
using Blog.Core.ViewModel.Link;
using Blog.Core.ViewModel.Validation;
using Blog.infrastructure.Model;
using Blog.infrastructure.Service.ResourceShaping;
using Blog.infrastructure.Service.TypeHelp;
using Blog.Service.infrastructure.Service;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    //标记该控制器需要授权
    //[Authorize]
    [Route("api/Index")]
    public class IndexControllers:Controller
    {

        public IndexControllers(IUnitForWork unitForWork,
            IArticleRepository repository,
            ILogger<IndexControllers> logger,
            IMapper mapper,
            ITypehelper typeHelper,
            IPropertyMappingContainer propertyMappingContainer)
        {
            UnitForWork = unitForWork;
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            TypeHelper = typeHelper;
            PropertyMappingContainer = propertyMappingContainer;
        }

        public IUnitForWork UnitForWork { get; }
        public IArticleRepository Repository { get; }
        public ILogger<IndexControllers> Logger { get; }
        public IMapper Mapper { get; }
        public ITypehelper TypeHelper { get; }
        public IPropertyMappingContainer PropertyMappingContainer { get; }

        [HttpGet(Name = "GetArticles")]
        public async Task<IActionResult> Get(ArticlePrameters articlePrameters)
        {
            //验证排序字符串
            if(!PropertyMappingContainer.ValidateMappingExistsFor<ArticleViewModel,Article>(articlePrameters.OrderBy))
            {
                return BadRequest("排序的属性不存在！");
            }
            //验证资源塑形字符串
            if (!TypeHelper.TypeHasProperties<ArticleViewModel>(articlePrameters.Fields))
                return BadRequest("请求的属性不存在!");
            var ArticlesList = await Repository.GetAllArticleAsync(articlePrameters);
            
            //将Article映射到ArticleModel
            var ArticlesResource = Mapper.Map<IEnumerable<Article>,IEnumerable<ArticleViewModel>>(ArticlesList);
            //根据fields进行资源塑形
            var ArticlesAfterShaping = ArticlesResource.ToDynamicIEnumerable(articlePrameters.Fields);

            //为每一个资源添加links属性
            ArticlesAfterShaping =  ArticlesAfterShaping.Select(x => 
            {
                x.TryAdd("links", CreateHateoasLinks((int)x.Where(y => y.Key == "Id").FirstOrDefault().Value,articlePrameters.Fields));
                return x;
            });

            //新建匿名类存放翻页元数据
            var page = new
            {
                ArticlesList.PageSize,
                ArticlesList.PageIndex,
                ArticlesList.TotalItemsCount,
                ArticlesList.PageCount
            };
            //为资源创建前后页链接
            var links = CreateHateoasLinksForPages(articlePrameters, ArticlesList.HasNext, ArticlesList.HasPrevious);
            var reslut = new
            {
                links,
                value =  ArticlesAfterShaping
            };
            //将page类转化为Json，并写入HTTP请求头中
            Response.Headers.Add("Pagination", JsonConvert.SerializeObject(page, new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver() //将变量首字母改为小写
            }));

            return Ok(reslut);

        }
        [HttpGet("{id}",Name ="GetSingleArticle")]
        public async Task<IActionResult>Get(int id,string fields = null)
        {
            if(!TypeHelper.TypeHasProperties<ArticleViewModel>(fields))
            {
                return BadRequest("请求的资源不存在！");
            }
            var article = await Repository.FindArticleByIdAsync(id);
            if (article == null)
                return NotFound();
            var result = Mapper.Map<Article, ArticleViewModel>(article).ToDynamic(fields);
            var links = CreateHateoasLinks(id, fields);
            result.TryAdd("links", links);
            return Ok(result);
            
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ArticleAddOrUpdateViewModel articleAddResource)
        {
            if (articleAddResource == null)
                return BadRequest();
            //使用FluentValidation验证属性
            if(!ModelState.IsValid)
            {
                
                return new ValidationErrorResult(ModelState);
            }

            var article = Mapper.Map<ArticleAddOrUpdateViewModel,Article>(articleAddResource);
            article.Auther = "admin";
            article.Date = DateTime.Now;


            Repository.PostArticle(article);
            if (!await UnitForWork.SaveAsync())
                throw new Exception("保存失败！");

            var resultViewModel = Mapper.Map<Article, ArticleViewModel>(article).ToDynamic();
            var resultViewModelId = resultViewModel.Where(s => s.Key == "Id").FirstOrDefault().Value;
            resultViewModel.TryAdd("links", CreateHateoasLinks((int)resultViewModelId));

            return CreatedAtRoute("GetSingleArticle", new { id = resultViewModelId},resultViewModel);
        }
  


        [HttpPut("{id}",Name ="UpdateArticle")]
        public async Task<IActionResult> Put(int id,[FromBody]ArticleAddOrUpdateViewModel article)
        {
     
            if (article == null)
                return BadRequest();
            //使用FluentValidation验证属性
            if (!ModelState.IsValid)
                return new ValidationErrorResult(ModelState);

            var result = await Repository.FindArticleByIdAsync(id);
            if (result == null)
                return BadRequest("找不到该文章");

            Mapper.Map(article,result);
            result.LastModify = DateTime.Now;

            if (!await UnitForWork.SaveAsync())
                return BadRequest("Save Error!");

            return NoContent();
    
        }
        [HttpPatch("{id}",Name="PatchArticle")]
        public async Task<IActionResult> Patch(int id,[FromBody]JsonPatchDocument<ArticleAddOrUpdateViewModel> jsonPatch)
        {
            //验证传入的属性是否存在
            if (jsonPatch == null)
                return BadRequest();
            var article = await Repository.FindArticleByIdAsync(id);
            if (article == null)
                return NotFound();

            //将jsonPatchDocument解析到一个ArticleAddOrUpdateViewModel，并验证其正确性
            var articleToPatch = Mapper.Map<ArticleAddOrUpdateViewModel>(article);
            jsonPatch.ApplyTo(articleToPatch, ModelState);
            TryValidateModel(articleToPatch);
            if(!ModelState.IsValid)
                return new ValidationErrorResult(ModelState);

            //将修改后的Article映射回原对象，并修改修改时间
            Mapper.Map(articleToPatch, article);
            article.LastModify = DateTime.Now;

            
            if(!await UnitForWork.SaveAsync())
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("{Id}",Name ="DeleteArticle")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var article = await Repository.FindArticleByIdAsync(Id);
                if (article == null)
                    return NotFound();

                Repository.DeleteArticle(article);
                await UnitForWork.SaveAsync();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        //创建分页的url
        private string CreateArticleUrl(ArticlePrameters articlePrameters,PaginationUrlType paginationUrlType)
        {
            switch (paginationUrlType)
            {
                case PaginationUrlType.PreviousPage:
                    var CurrentPrameter = new ArticlePrameters
                    {
                        PageIndex = articlePrameters.PageIndex - 1,
                        PageSize = articlePrameters.PageSize,
                        OrderBy = articlePrameters.OrderBy,
                        Fields = articlePrameters.Fields
                    };
                    return Url.Link("GetArticles", CurrentPrameter);

                case PaginationUrlType.NextPage:
                    var NextPrameter = new ArticlePrameters
                    {
                        PageIndex = articlePrameters.PageIndex + 1,
                        PageSize = articlePrameters.PageSize,
                        OrderBy = articlePrameters.OrderBy,
                        Fields = articlePrameters.Fields
                    };
                    return Url.Link("GetArticles", NextPrameter);

                default:
                    var PreviousPrameter = new ArticlePrameters
                    {
                        PageIndex = articlePrameters.PageIndex,
                        PageSize = articlePrameters.PageSize,
                        OrderBy = articlePrameters.OrderBy,
                        Fields = articlePrameters.Fields
                    };
                    return Url.Link("GetArticles", PreviousPrameter);
            }
        }

        //创建单个资源的links
        public  IEnumerable<LinkViewModel> CreateHateoasLinks(int id, string fields = null)
        {
            var links = new List<LinkViewModel>();
            //添加deleteLink
            links.Add(new LinkViewModel(Url.Link("DeleteArticle", new { id }), "delete_self", "Delete"));
            links.Add(new LinkViewModel(Url.Link("UpdateArticle", new { id }), "update_self", "Put"));

            //判断是否有资源塑形，添加不同的getLink
            if (fields == null)
                links.Add(new LinkViewModel(Url.Link("GetSingleArticle", new { id }), "self", "Get"));
            else
                links.Add(new LinkViewModel(Url.Link("GetSingleArticle", new {id,fields} ), "self", "Get"));

            return links;
        }
        //创建页面的links
        public IEnumerable<LinkViewModel> CreateHateoasLinksForPages(ArticlePrameters articlePrameters,bool hasNextPage,bool hasLastPage)
        {
            var links = new List<LinkViewModel>();
            //添加selfLink
            links.Add(new LinkViewModel(CreateArticleUrl(articlePrameters,PaginationUrlType.CurrentPage), "self", "Get"));

            //判断是否有前一页/后一页 并加入links
            if (hasNextPage)
                links.Add(new LinkViewModel(CreateArticleUrl(articlePrameters,PaginationUrlType.NextPage),"nextPage", "Get"));
            if(hasLastPage)
                links.Add(new LinkViewModel(CreateArticleUrl(articlePrameters,PaginationUrlType.PreviousPage), "lastPage", "Get"));

            return links;
        }
    }
}
