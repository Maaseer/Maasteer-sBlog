using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Core.ViewModel.Validation
{
    public class VaildationErrorDictionary : Dictionary<string, IEnumerable<ValidationErrorEntity>>
    {
        public VaildationErrorDictionary(ModelStateDictionary modelState)
        {
            foreach (var item in modelState)
            {
                var errors = new List<ValidationErrorEntity>();
                var errorsSources = item.Value.Errors;
                foreach (var errorsSource in errorsSources)
                {
                    var messages = errorsSource.ErrorMessage.Split('|');
                    if (messages.Count() > 2)
                        throw new Exception("验证错误信息出错");
                    errors.Add(new ValidationErrorEntity(messages[0], messages[1]));
                }
                this.Add(item.Key,errors);
            }
        }
    }
}
