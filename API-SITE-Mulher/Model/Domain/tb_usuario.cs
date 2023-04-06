using API_SITE_Mulher.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model.Domain
{

    [Table("person")]
    public class tb_usuario
    {
        [Column("id")]
        private int _id { get; set; }

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

        public tb_poster ProsteresDoUsuario { get; set; }



        public int Id { get { return _id; } set { _id = value; } }

        public string Nomecompleto { get { return Nomecompleto; } set { Nomecompleto = value; } }

        public string Email { get { return Email; } set { Email = value; } }

        public string Senha { get { return Senha; } set { Senha = value; } }

        public string Apelido { get { return Apelido; } set { Apelido = value; } }

        public int Role { get { return Role; } set { Role = value; } }

        public string Refreshtoken { get { return Refreshtoken; } set { Refreshtoken = value; } }

        public DateTime Refreshtokenexpirytime { get { return Refreshtokenexpirytime; } set { Refreshtokenexpirytime = value; } }
    }
}
}
