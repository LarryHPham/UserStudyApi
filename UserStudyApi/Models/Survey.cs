using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStudyApi.Models
{
    public class User
    {
        public string UserId { get; set; }
    }
    public class Survey
    {
        public long Id { get; set;  }
        public string SurveyId { get; set; }
        public long Answer { get; set; }
        public string UserId { get; set; }
    }

    public class ModifiedSurvey
    {
        public int Count { get; set; }
        public List<string> UserIds { get; set; }
    }

}
