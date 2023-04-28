using API_SITE_Mulher.Model.Domain;

namespace API_SITE_Mulher.Data.Converter.Contract
{
    public interface IParserPosteres<O, D>
    {
        D Parse(O origin, tb_usuario tbUsuario);
        List<D> Parse(List<O> origin, tb_usuario tbUsuario);
    }
}
