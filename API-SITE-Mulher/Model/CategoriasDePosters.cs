using System.Security.Cryptography;

namespace API_SITE_Mulher.Model
{
    public class CategoriasDePosters
    {
        private string _nome { get; set; }
        private string _nomeTag { get; set; }
        private string _linkPage { get; set; }


        public string Nome { get { return _nome; } set { _nome = value; } }
        public string NomeTag { get { return _nomeTag; } set { _nomeTag = value; } }
        public string LinkPage { get { return _linkPage; } set { _linkPage = value; } }

    }
}