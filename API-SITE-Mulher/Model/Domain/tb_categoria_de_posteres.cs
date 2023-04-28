using API_SITE_Mulher.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("tb_categoria_de_posteres")]
    public class tb_categoria_de_posteres : BaseEntity
    {
        [Column("name_categoria")]
        public string NomeCategoria { get; set; }

        [Column("nome_tag")]
        public string NomeTag { get; set; }

        [JsonIgnore]
        public ICollection<tb_poster>? tbPosters { get; set; }
    }
}
