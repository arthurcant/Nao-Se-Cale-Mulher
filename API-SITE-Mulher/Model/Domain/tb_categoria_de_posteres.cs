using API_SITE_Mulher.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("tb_categoria_de_posteres")]
    public class tb_categoria_de_posteres : BaseEntity
    {
        [Column("name_categoria")]
        public string NomeCategoria { get; set; }

        [Column("nome_tag")]
        public string NomeTag { get; set; }

        public tb_detalhes_do_poster tb_Detalhes_Do_Poster { get; set; }

    }
}
