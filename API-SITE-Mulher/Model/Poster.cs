using API_SITE_Mulher.Model.Base;

namespace API_SITE_Mulher.Model
{
    public class Poster
    {
        public int Id { get; set; }
        public int Id_usuario { get; set; }
        public Usuario Autor { get; set; }
        public DateTime DataDaPublicacao { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }
        public List<CategoriasDePosters> Tags { get; set; }
    }
}
