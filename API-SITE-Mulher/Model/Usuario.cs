using API_SITE_Mulher.Enum;
using API_SITE_Mulher.Model.Base;

namespace API_SITE_Mulher.Model
{
    public class Usuario : BaseEntity
    {
        private string NomeCompleto { get; set; }
        private string Email { get; set; }
        private string Senha { get; set; }
        private string Apelido { get; set; }
        private Roles Role { get; set; }
        private string RefreshToken { get; set; }
        private DateTime RefreshTokenExpiryTime { get; set; }
    }
}
