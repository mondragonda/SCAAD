using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace SCAAD.APIs.Validators
{
    public interface IRequestParametersValidator
    {
        bool RequestsParametersAreInvalid(object fromUriParameter, string regexToValidate, ModelStateDictionary modelState);
        bool RequestsParametersAreInvalid(object fromUriParameter, string regexToValidate);
    }
}
