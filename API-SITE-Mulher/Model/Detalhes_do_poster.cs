using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model
{
    public class Detalhes_do_poster
    {
        private int _idPoster { get; set; }
        private int _idCategoriaDePosteres { get; set; }

        public int IdPoster { get { return _idPoster; } set { _idPoster = value; } }
        public int IdCategoriaDePosteres { get { return _idCategoriaDePosteres; } set { _idCategoriaDePosteres = value; } }
    }
}
