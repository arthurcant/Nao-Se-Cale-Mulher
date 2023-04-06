using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("tb_categoria_de_posteres")]
    public class tb_categoria_de_posteres
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("name_categoria")]
        public string NomeCategoria { get; set; }

        [Column("nome_tag")]
        public string NomeTag { get; set; }
    }
}
