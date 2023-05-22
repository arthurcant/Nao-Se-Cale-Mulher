using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;

namespace API_SITE_Mulher.Data.VO
{
    public class PosterVO
    {

        public string Titulo { get; set; }
        public string? UrlImagePoster { get; set; }
        public string? Descricao { get; set; }
        public string Conteudo { get; set; }
        public List<int>? Tags { get; set; }
    }
}
