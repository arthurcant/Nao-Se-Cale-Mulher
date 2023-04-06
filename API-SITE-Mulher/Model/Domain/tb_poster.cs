using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace API_SITE_Mulher.Model.Domain
{
    [Table("tb_poster")]
    public class tb_poster
    {
        [Column("id")]
        private int _id { get; set; }

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


        public int Id { get { return _id; } set { _id = value; } }

        public int Id_usuario { get { return Id_usuario; } set { Id_usuario = value; } }

        public DateTime DataDaPublicacao { get { return DataDaPublicacao; } set { DataDaPublicacao = value; } }

        public string Titulo { get { return Titulo; } set { Titulo = value; } }

        public string Descricao { get { return Descricao; } set { Descricao = value; } }

        public string Conteudo { get { return Conteudo; } set { Conteudo = value; } }

    }
}
