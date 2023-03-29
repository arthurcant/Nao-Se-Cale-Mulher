using Microsoft.EntityFrameworkCore;

namespace API_SITE_Mulher.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {
        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {
        }



    }
}
