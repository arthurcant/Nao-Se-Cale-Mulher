using API_SITE_Mulher.Data.Converter.Contract;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;

namespace API_SITE_Mulher.Data.Converter.Implementations
{
    public class CategoriaConverter : IParser<tb_categoria_de_posteres, CategoriasDePosters>, IParser<CategoriasDePosters, tb_categoria_de_posteres>
    {
        public tb_categoria_de_posteres Parse(CategoriasDePosters origin)
        {
            if (origin is null) return null;

            return new tb_categoria_de_posteres
            {
                Id = origin.Id ?? 0,
                NomeCategoria = origin.NomeCategoria,
                NomeTag = origin.NomeTag
            };
        }


        public CategoriasDePosters Parse(tb_categoria_de_posteres origin)
        {
            if (origin is null) return null;

            return new CategoriasDePosters
            {
                Id = origin.Id,
                NomeCategoria = origin.NomeCategoria,
                NomeTag = origin.NomeTag
            };
        }
        public List<tb_categoria_de_posteres> Parse(List<CategoriasDePosters> origin)
        {
            if (origin is null) return null;

            return origin.Select(c => Parse(c)).ToList();
        }

        public List<CategoriasDePosters> Parse(List<tb_categoria_de_posteres> origin)
        {
            if (origin is null) return null;

            return origin.Select(c => Parse(c)).ToList();
        }
    }
}
