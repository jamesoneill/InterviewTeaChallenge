using JO.InterviewTeaChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JO.InterviewTeaChallenge.WebApi.Responses
{
    public class TeaResponse : BaseResponse
    {
        public Tea Tea { get; set; }
    }
}
