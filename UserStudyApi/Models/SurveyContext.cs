using Microsoft.EntityFrameworkCore;

namespace UserStudyApi.Models
{
    public class SurveyContext : DbContext
    {
        public SurveyContext(DbContextOptions<SurveyContext> options)
            : base(options)
        {

        }

        public DbSet<Survey> SurveyItems { get; set; }
    }
}
