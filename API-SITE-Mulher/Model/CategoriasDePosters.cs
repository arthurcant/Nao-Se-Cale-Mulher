using System.Security.Cryptography;

namespace API_SITE_Mulher.Model
{
    public class CategoriasDePosters
    {
        public int Id { get; set; }
        public string NomeCategoria { get; set; }
        public string NomeTag { get; set; }
        //public string LinkPage { get { return $"{NomeTag}"; } set { LinkPage = value; } }

    }
}