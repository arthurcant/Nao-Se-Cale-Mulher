using API_SITE_Mulher.Enum;
using API_SITE_Mulher.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model.Domain
{

    [Table("tb_usuario")]
    public class tb_usuario : BaseEntity
    {
        public tb_usuario()
        {
        }

        [Column("nome_completo")]
        public string NomeCompleto { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senhar")]
        public string Senha { get; set; }

        [Column("apelido")]
        public string? Apelido { get; set; }

        [Column("roles")]
        public int Role { get; set; }

        [Column("refresh_token")]
        public string? RefreshToken { get; set; }

        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }

        public ICollection<tb_poster>? PosteresDoUsuario { get; set; }


    }
}

