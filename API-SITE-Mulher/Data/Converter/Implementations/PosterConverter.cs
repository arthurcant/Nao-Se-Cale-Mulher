using API_SITE_Mulher.Data.Converter.Contract;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository;
using API_SITE_Mulher.Repository.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace API_SITE_Mulher.Data.Converter.Implementations
{
    public class PosterConverter : ControllerBase , IParser<tb_poster, Poster>, IParser<Poster, tb_poster>
    {
        private IUsersRepository _repository;
        private UsuarioConverter _usuarioConverter;

        public PosterConverter()
        {
        }

        public PosterConverter(IUsersRepository repository)
        {
            _repository = repository;
            _usuarioConverter = new UsuarioConverter();
        }

        public tb_poster Parse(Poster origin)
        {
            if (origin is null) return null;

            tb_poster tbPoster = new tb_poster();
            tbPoster.Titulo = origin.Titulo;
            tbPoster.Descricao = origin.Descricao;
            tbPoster.Conteudo = origin.Conteudo;
            tbPoster.DataDaPublicacao = DateTime.Now;
            var email = User.Identity.Name;
            tbPoster.Autor = _repository.ValidateCredentials(email);
            tbPoster.Id_usuario = tbPoster.Autor.Id;

            // TODO: Debito tecnico fazer uma converção usando PosterConverter.
            tb_categoria_de_posteres tbCategoriaDePosteres = new tb_categoria_de_posteres();
            foreach (var item in origin.Tags)
            {

                tbCategoriaDePosteres.Id = item.Id;
                tbCategoriaDePosteres.NomeCategoria = item.NomeCategoria;
                tbCategoriaDePosteres.NomeTag = item.NomeTag;

                tbPoster.tb_Detalhes_Do_Poster.tb_Categoria_De_Posteres.Add(tbCategoriaDePosteres);
            }

            return tbPoster;
        }

        public Poster Parse(tb_poster origin)
        {
            if (origin is null) return null;

            Poster poster = new Poster();
            poster.Titulo = origin.Titulo;
            poster.Descricao = origin.Descricao;
            poster.Conteudo = origin.Conteudo;
            poster.DataDaPublicacao = DateTime.Now;
            var email = User.Identity.Name;
            poster.Autor = _usuarioConverter.Parse(_repository.ValidateCredentials(email));
            poster.Id_usuario = poster.Autor.Id;

            CategoriasDePosters categoriasDePosters = new CategoriasDePosters();
            foreach (var item in origin.tb_Detalhes_Do_Poster.tb_Categoria_De_Posteres)
            {
                categoriasDePosters.Id = item.Id;
                categoriasDePosters.NomeCategoria = item.NomeCategoria;
                categoriasDePosters.NomeTag = item.NomeTag;

                poster.Tags.Add(categoriasDePosters);
            }

            return poster;
        }

        public List<Poster> Parse(List<tb_poster> origin)
        {
            if (origin is null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public List<tb_poster> Parse(List<Poster> origin)
        {
            if (origin is null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
