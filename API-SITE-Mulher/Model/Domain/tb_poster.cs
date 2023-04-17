using API_SITE_Mulher.Model.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("tb_poster")]
    public class tb_poster : BaseEntity
    {

        [Column("id_usuario")]
        private int _id_usuario { get; set; }

        [Column("data_de_publicacao")]
        private DateTime _datadapublicacao { get; set; }

        [Column("titulo")]
        private string _titulo { get; set; }

        [Column("descricao")]
        private string _descricao { get; set; }

        [Column("conteudo")]
        private string _conteudo { get; set; }

        public tb_usuario Autor { get; set; }

        
        public tb_detalhes_do_poster tb_Detalhes_Do_Poster { get; set; }


        public int Id_usuario { get { return Id_usuario; } set { Id_usuario = value; } }

        public DateTime DataDaPublicacao { get { return _datadapublicacao; } set { _datadapublicacao = value; } }

        public string Titulo { get { return _titulo; } set { _titulo = value; } }

        public string Descricao { get { return _descricao; } set { _descricao = value; } }

        public string Conteudo { get { return _conteudo; } set { _conteudo = value; } }

    }
}
