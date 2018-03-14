using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
    public class SurveyResult
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public int VoteCount { get; set; }
    }
}