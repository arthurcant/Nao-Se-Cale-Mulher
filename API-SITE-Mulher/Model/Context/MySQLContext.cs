using API_SITE_Mulher.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace API_SITE_Mulher.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<tb_usuario> tb_usuarios { get; set; }
        public DbSet<tb_poster> tb_posters { get; set; }
        public DbSet<tb_categoria_de_posteres> tb_Categoria_De_Posteres { get; set; }



    }
}
