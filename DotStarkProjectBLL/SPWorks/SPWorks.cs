using Insight.Database;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DotStarkProjectBLL.SPWorks
{
    public class SPWorks : ISPWorks
    {
        private readonly IConfiguration _configuration;
        public SPWorks(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DateTime SP_GetTime()
        {
            DateTime dt = new DateTime();
            try
            {
                using (var cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dt = cn.QuerySql<DateTime>("select GetUtcDate() as DbTime").FirstOrDefault();
                }
            }
            catch (Exception)
            {

            }
            return dt;
        }
    }
}
