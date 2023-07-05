using API_SITE_Mulher.Data.Converter.Implementations;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository.Implementations;

namespace API_SITE_Mulher.Business.Implementations
{
    public class UsersBusinessImplementation : IUsersBusiness
    {
        private IRepository<tb_usuario> repository;
        private readonly UsuarioConverter _converter;


        public UsersBusinessImplementation(IRepository<tb_usuario> repository)
        {
            this.repository = repository;
            this._converter = new UsuarioConverter();
        }

        public PagedSearchVO<Usuario> FindWithPagedSearch(string sortDirection, int pageSize, int page, string emailOrNome)
        {
            var sort = (!string.IsNullOrEmpty(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";

            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from tb_usuario u where 1 = 1 ";

            if (!string.IsNullOrEmpty(emailOrNome)) query += $" and (u.nome_completo like \"%{emailOrNome}%\"  or u.email like \"%{emailOrNome}%\" ) ";
            query += $" order by u.nome_completo {sort} limit {size} offset {offset} ";

            string countQuery = @"select count(*) from tb_usuario u where 1 = 1 ";
            if (!string.IsNullOrEmpty(emailOrNome)) countQuery += $"and (u.nome_completo like \"%{emailOrNome}%\"  or u.email like \"%{emailOrNome}%\" ) ";

            var usuarios = repository.FindWithPagedSearch(query);
            var totalResult = repository.GetCount(countQuery);

            return new PagedSearchVO<Usuario>
            {
                CurrentPage = page,
                List = _converter.Parse(usuarios),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResult
            };
        }

        public Usuario ChangePassword(int id, string newPassword)
        {
            var user = repository.FindById(id);

            if (user is null) return null;

            user.Senha = newPassword;

            var newUser = repository.Update(user);

            if (newUser is null) return null;

            return _converter.Parse(newUser);
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public Usuario UpdateRoleUser(int id, int role)
        {
            var user = repository.FindById(id);

            if (user is null) return null;

            user.Role = role;

            var newUser = repository.Update(user);

            if (newUser is null) return null;

            return _converter.Parse(newUser);
        }
    }
}
