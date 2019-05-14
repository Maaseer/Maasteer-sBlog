using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.ViewModel.Validation
{
    public class ValidationErrorEntity
    {
        public ValidationErrorEntity(string vaildatoKey, string message="")
        {
            VaildatoKey = vaildatoKey;
            Message = message;
        }

        public string VaildatoKey { get; set; }
        public string Message { get; set; }
    }
}
