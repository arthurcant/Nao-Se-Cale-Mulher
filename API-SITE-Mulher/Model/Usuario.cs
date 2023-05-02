using API_SITE_Mulher.Enum;
using System.Text.Json.Serialization;

namespace API_SITE_Mulher.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Senha { get; set; }
        public string? Apelido { get; set; }
        public Roles Role { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
