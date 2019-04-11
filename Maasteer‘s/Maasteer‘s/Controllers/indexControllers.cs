using Blog.infrastructure.Interface;
using Blog.infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maasteer_s.Controllers
{
    [Route("api/Index")]
    public class IndexControllers:Controller
    {

        public IndexControllers(IUnitForWork unitForWork, IRepository repository)
        {
            UnitForWork = unitForWork;
            Repository = repository;
        }

        public IUnitForWork UnitForWork { get; }
        public IRepository Repository { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await Repository.GetAllArticleAsync();

                return Ok(result);
            }
            catch
            {
                return BadRequest();

            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult>Get(int Id)
        {
            try
            {
                var result = await Repository.FindArticleByIdAsync(Id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Article article)
        {
            try
            {
                article.Date = DateTime.Now;
                Repository.PostArticle(article);
                await UnitForWork.SaveAsync();
                return Ok();

            }
            catch
            {
                return BadRequest("添加失败");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Article article)
        {
            try
            {
                Repository.PutArticle(article);
                await UnitForWork.SaveAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                Repository.DeleteArticle(Id);
                await UnitForWork.SaveAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
