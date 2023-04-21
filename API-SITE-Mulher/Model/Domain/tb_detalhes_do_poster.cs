using API_SITE_Mulher.Model.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("detalhes_do_poster")]
    public class tb_detalhes_do_poster : BaseEntity
    {
        [ForeignKey("tb_poster")]
        [Column("id_poster")]
        public int IdPoster { get; set; }

        [ForeignKey("tb_categoria_de_posteres")]
        [Column("id_categoria_de_posteres")]
        public int IdCategoriaDePosteres { get; set; }

        public ICollection<tb_categoria_de_posteres> tb_Categoria_De_Posteres { get; set; }
        public ICollection<tb_poster> tb_Poster { get; set; }

    }
}
