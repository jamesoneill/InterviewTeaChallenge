using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JO.InterviewTeaChallenge.WebApi.Controllers
{
    public abstract class BaseController : Controller
    {
        internal List<string> GetErrors(Exception ex, List<string> errors)
        {            
            errors.Add(ex.Message);

            if (ex.InnerException != null)
            {
                return GetErrors(ex.InnerException, errors);
            }

            return errors;
        }
    }
}
