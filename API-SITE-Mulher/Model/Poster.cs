using API_SITE_Mulher.Model.Base;

namespace API_SITE_Mulher.Model
{
    public class Poster : BaseEntity
    {
        private int _id_usuario { get; set; }
        private List<int?> _ids_tags { get; set; }
        private Usuario _autor { get; set; }
        private DateTime _datadapublicacao { get; set; }
        private string _titulo { get; set; }
        private string _descricao { get; set; }
        private string _conteudo { get; set; }
        private List<CategoriasDePosters> _tags { get; set; }


        public int Id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public List<int?> Ids_Tags { get { return _ids_tags; } set { _ids_tags = value; } }
        public Usuario Autor { get { return _autor; } set { _autor = value; } }
        public DateTime DataDaPublicacao { get { return _datadapublicacao; } set { _datadapublicacao = value; } }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string Descricao { get { return _descricao; } set { _descricao = value; } }
        public string Conteudo { get { return _conteudo; } set { _conteudo = value; } }
        public List<CategoriasDePosters> Tags { get { return _tags; } set { _tags = value; } }
    }
}
