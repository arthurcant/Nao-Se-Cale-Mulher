using API_SITE_Mulher.Model.Base;

namespace API_SITE_Mulher.Model
{
    public class Poster
    {
        public Poster()
        {
        }

        public Poster(int id, int id_usuario, Usuario autor, DateTime dataDaPublicacao, string titulo, string? descricao, string conteudo, List<CategoriasDePosters> tags)
        {
            Id = id;
            Id_usuario = id_usuario;
            Autor = autor;
            DataDaPublicacao = dataDaPublicacao;
            Titulo = titulo;
            Descricao = descricao;
            Conteudo = conteudo;
            Tags = tags;
        }

        public int Id { get; set; }
        public int Id_usuario { get; set; }
        public Usuario Autor { get; set; }
        public DateTime DataDaPublicacao { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public string Conteudo { get; set; }
        public List<CategoriasDePosters> Tags { get; set; }
    }
}
