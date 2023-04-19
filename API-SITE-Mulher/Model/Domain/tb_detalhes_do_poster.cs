using API_SITE_Mulher.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("detalhes_do_poster")]
    public class tb_detalhes_do_poster : BaseEntity
    {
        [ForeignKey("tb_poster")]
        [Column("id_poster")]
        private int _idPoster { get; set; }

        [ForeignKey("tb_categoria_de_posteres")]
        [Column("id_categoria_de_posteres")]
        private int _idCategoriaDePosteres { get; set; }

        public int IdPoster { get { return _idPoster; } set { _idPoster = value; } }

        public int IdCategoriaDePosteres { get { return _idCategoriaDePosteres; } set { _idCategoriaDePosteres = value;  } }

        public ICollection<tb_categoria_de_posteres> tb_Categoria_De_Posteres { get; set; }
        public ICollection<tb_poster> tb_Poster { get; set; }

    }
}
