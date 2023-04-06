using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("detalhes_do_poster")]
    public class tb_detalhes_do_poster
    {
        [Column("id_poster")]
        private int IdPoster { get; set; }

        [Column("id_categoria_de_posteres")]
        private int IdCategoriaDePosteres { get; set; }


    }
}
