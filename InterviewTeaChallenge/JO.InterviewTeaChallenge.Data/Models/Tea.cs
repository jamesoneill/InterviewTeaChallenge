using System;
using System.Collections.Generic;
using System.Text;

namespace JO.InterviewTeaChallenge.Data.Models
{
    public class Tea : BaseEntity
    {
        public string Name { get; set; }
        public bool RequiresMilk { get; set; }
    }
}
