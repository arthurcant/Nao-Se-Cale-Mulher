using API_SITE_Mulher.Model.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("tb_poster")]
    public class tb_poster : BaseEntity
    {

        [ForeignKey("tb_usuario")]
        [Column("id_usuario")]
        public int? id_usuario { get; set; }

        [Column("url_image_poster")]
        public string? UrlImagePoster { get; set; }

        [Column("data_de_publicacao")]
        public DateTime DataDaPublicacao { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("conteudo")]
        public string Conteudo { get; set; }

        [JsonIgnore]
        public tb_usuario? tbUsuarios { get; set; }

        public ICollection<tb_categoria_de_posteres>? tbCategoriaDePosteres { get; set; } = new List<tb_categoria_de_posteres>();

    }
}
