using API_SITE_Mulher.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("tb_categoria_de_posteres")]
    public class tb_categoria_de_posteres : BaseEntity
    {
        [Column("name_categoria")]
        public string _nomeCategoria { get; set; }

        [Column("name_categoria")]
        public string _nomeTag { get; set; }

        [Column("nome_tag")]
        public string _linkPage { get; set; }

        public string NomeCategoria { get { return _nomeCategoria; } set { _nomeCategoria = value; } }
        public string NomeTag { get { return _nomeTag; } set { _nomeTag = value; } }
        public string LinkPage { get { return _linkPage; } set { _linkPage = value; } }
    }
}
