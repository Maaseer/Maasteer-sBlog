using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
//自定义验证属性Result
namespace Blog.Core.ViewModel.Validation
{
    public class ValidationErrorResult : UnprocessableEntityObjectResult
    {
        public ValidationErrorResult(ModelStateDictionary ModelState) : base(new VaildationErrorDictionary(ModelState))
        {
            if (ModelState == null)
                throw new ArgumentException(nameof(ModelState));
            StatusCode = 422;
        }
    }
}
