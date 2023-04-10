using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        private int _id { get; set; }

        public int Id { get { return _id; } set { _id = value; } }

    }
}
