using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JO.InterviewTeaChallenge.WebApi.Responses
{
    public abstract class BaseResponse
    {
        public List<string> Errors { get; set; } = new List<string>();
        public bool IsSuccess { get; set; } = true;
    }
}
