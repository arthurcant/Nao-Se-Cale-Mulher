using API_SITE_Mulher.Model.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("tb_poster")]
    public class tb_poster : BaseEntity
    {

        [ForeignKey("tb_usuario")]
        [Column("id_usuario")]
        public int AutorId { get; set; }

        [Column("data_de_publicacao")]
        public DateTime DataDaPublicacao { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("conteudo")]
        public string Conteudo { get; set; }

        public virtual tb_usuario Autor { get; set; }

        public virtual tb_detalhes_do_poster tb_Detalhes_Do_Poster { get; set; }

    }
}
