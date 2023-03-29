namespace API_SITE_Mulher.Model
{
    public class Poster
    {
        private int Id { get; set; }
        private int Id_usuario { get; set; }
        private List<int?> Ids_Tags { get; set; }
        private Usuario Autor { get; set; }
        private DateTime DataDaPublicacao { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private string Conteudo { get; set; }
        private List<CategoriasDePosters> Tags { get; set; }
    }
}
