using API_SITE_Mulher.Enum;

namespace API_SITE_Mulher.Data.VO
{
    public class UsuarioAutorVO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string? Apelido { get; set; }
        public Roles Role { get; set; }
    }
}
