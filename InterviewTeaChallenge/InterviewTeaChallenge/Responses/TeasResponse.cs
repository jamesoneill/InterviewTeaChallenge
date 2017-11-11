using JO.InterviewTeaChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JO.InterviewTeaChallenge.WebApi.Responses
{
    public class TeasResponse : BaseResponse
    {
        public IReadOnlyCollection<Tea> Teas { get; set; }
    }
}
