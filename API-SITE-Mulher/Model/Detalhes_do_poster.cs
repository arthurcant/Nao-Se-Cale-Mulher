using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model
{
    public class Detalhes_do_poster
    {
        public int IdPoster { get; set; }
        public int IdCategoriaDePosteres { get; set; }
    }
}
