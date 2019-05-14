using FluentValidation;
using Blog.Core.ViewModel.Articles;

namespace Blog.Core.ViewModel.Validation

{
    //使用FluentValidation进行Model-ViewModel之间的属性验证
    public class ArticleAddViewModelValidation:AbstractValidator<ArticleAddOrUpdateViewModel>
    {
        public ArticleAddViewModelValidation()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .WithName("标题")
                .WithMessage("require|{PropertyName}是必须的")
                .MaximumLength(50)
                .WithMessage("maxLength|{PropertyName}的最大长度是{MaxLength}");
            RuleFor(x => x.Context)
                .NotNull()
                .WithName("正文")
                .WithMessage("require|{PropertyName}是必须的")
                .MinimumLength(50)
                .WithMessage("minLength|{PropertyName}最小长度为{MinLength}");
        }
    }
}
