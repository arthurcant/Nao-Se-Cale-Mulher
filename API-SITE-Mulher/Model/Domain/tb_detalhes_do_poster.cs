using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("detalhes_do_poster")]
    public class tb_detalhes_do_poster
    {
        [Column("id_poster")]
        private int _idPoster { get; set; }

        [Column("id_categoria_de_posteres")]
        private int _idCategoriaDePosteres { get; set; }

        public int IdPoster { get { return _idPoster; } set { _idPoster = value; } }

        public int IdCategoriaDePosteres { get { return _idCategoriaDePosteres; } set { _idCategoriaDePosteres = value;  } }

    }
}
