using API_SITE_Mulher.Controllers;
using API_SITE_Mulher.Data.Converter.Contract;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository;
using API_SITE_Mulher.Repository.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace API_SITE_Mulher.Data.Converter.Implementations
{
    public class PosterConverter : IParserPosteres<tb_poster, Poster>, IParserPosteres<Poster, tb_poster>
    {
        private readonly IUsersRepository _repository;
        private UsuarioConverter _usuarioConverter = new UsuarioConverter();

        public PosterConverter()
        {
        }

        public PosterConverter(IUsersRepository repository)
        {
            _repository = repository;
        }

        // TODO: Refatora essa a classe PosterConverter

        public tb_poster Parse(Poster origin, tb_usuario tbUsuario)
        {
            if (origin is null) return null;

            tb_poster tbPoster = new tb_poster();
            tbPoster.Titulo = origin.Titulo;
            tbPoster.Descricao = origin.Descricao;
            tbPoster.Conteudo = origin.Conteudo;
            tbPoster.DataDaPublicacao = DateTime.Now;
            tbPoster.tbUsuarios = tbUsuario;
            //tbPoster.id_usuario = tbPoster.tb_usuarioAutor.Id;

            if (!(origin.Tags is null))
            {
                tb_categoria_de_posteres categoria_De_Posteres = new tb_categoria_de_posteres();
                foreach (var item in origin.Tags)
                {
                    categoria_De_Posteres.Id = item.Id;
                    categoria_De_Posteres.NomeCategoria = item.NomeCategoria;
                    categoria_De_Posteres.NomeTag = item.NomeTag;
                    tbPoster.tbCategoriaDePosteres.Add(categoria_De_Posteres);
                }
            }

            return tbPoster;
        }

        public Poster Parse(tb_poster origin, tb_usuario tbUsuario)
        {
            if (origin is null) return null;

            Poster poster = new Poster();
            poster.Titulo = origin.Titulo;
            poster.Descricao = origin.Descricao;
            poster.Conteudo = origin.Conteudo;
            poster.DataDaPublicacao = DateTime.Now;
            poster.UsuarioAutor = _usuarioConverter.Parse(tbUsuario);
            poster.Id_usuario = poster.UsuarioAutor.Id;

            if(!(origin.tbCategoriaDePosteres is null))
            {
                CategoriasDePosters categoria_De_Posteres = new CategoriasDePosters();
                foreach (var item in origin.tbCategoriaDePosteres)
                {
                    categoria_De_Posteres.Id = item.Id;
                    categoria_De_Posteres.NomeCategoria = item.NomeCategoria;
                    categoria_De_Posteres.NomeTag = item.NomeTag;
                    poster.Tags.Add(categoria_De_Posteres);
                }
            }

            return poster;
        }

        public List<Poster> Parse(List<tb_poster> origin, tb_usuario tbUsuario)
        {
            if (origin is null) return null;

            return origin.Select(item => Parse(item, tbUsuario)).ToList();
        }

        public List<tb_poster> Parse(List<Poster> origin, tb_usuario tbUsuario)
        {
            if (origin is null) return null;

            return origin.Select(item => Parse(item, tbUsuario)).ToList();
        }
    }
}
