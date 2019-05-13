using FluentValidation;
using System.Collections.Generic;
using Blog.Core.ViewModel.Articles;

namespace Blog.Core.ViewModel.Validation

{
    //使用FluentValidation进行Model-ViewModel之间的属性验证
    public class ArticleViewModelValidation:AbstractValidator<ArticleViewModel>
    {
        public ArticleViewModelValidation()
        {
            var a = new Dictionary<int, int>();

            RuleFor(x => x.Auther).NotNull().WithName("作者").WithMessage("{PropertyName}是必须的").MaximumLength(50).WithMessage("{PropertyName}最大长度为50");
        }
    }
}
