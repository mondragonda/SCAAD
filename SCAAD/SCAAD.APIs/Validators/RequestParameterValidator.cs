using SCAAD.APIs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace SCAAD.APIs.Controllers
{
    public class RequestParameterValidator : IRequestParametersValidator
    {
        public bool RequestsParametersAreInvalid(object fromUriParameter, string regexToValidate)
        {
            if (Regex.IsMatch(fromUriParameter.ToString(), regexToValidate))
                return true;
            else
                return false;

        }

        public bool RequestsParametersAreInvalid(object fromUriParameter, string regexToValidate, ModelStateDictionary modelState)
        {
            if (Regex.IsMatch(fromUriParameter.ToString(), regexToValidate) || !modelState.IsValid)
                return true;
            else
                return false;
        }
    }
}
