using API_SITE_Mulher.Enum;
using API_SITE_Mulher.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model.Domain
{

    [Table("tb_usuario")]
    public class tb_usuario : BaseEntity
    {
        [Column("nome_completo")]
        private string _nomecompleto { get; set; }

        [Column("email")]
        private string _email { get; set; }

        [Column("senhar")]
        private string _senha { get; set; }

        [Column("apelido")]
        private string _apelido { get; set; }

        [Column("roles")]
        private int _role { get; set; }

        [Column("refresh_token")]
        private string _refreshtoken { get; set; }

        [Column("refresh_token_expiry_time")]
        private DateTime _refreshtokenexpirytime { get; set; }

        public virtual ICollection<tb_poster> PosteresDoUsuario { get; set; }



        public string NomeCompleto { get { return _nomecompleto; } set { _nomecompleto = value; } }

        public string Email { get { return _email; } set { _email = value; } }

        public string Senha { get { return _senha; } set { _senha = value; } }

        public string Apelido { get { return _apelido; } set { _apelido = value; } }

        public int Role { get { return _role; } set { _role = value; } }

        public string RefreshToken { get { return _refreshtoken; } set { _refreshtoken = value; } }

        public DateTime RefreshTokenExpiryTime { get { return _refreshtokenexpirytime; } set { _refreshtokenexpirytime = value; } }
    }
}

