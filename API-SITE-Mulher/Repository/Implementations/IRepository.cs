using API_SITE_Mulher.Model.Base;

namespace API_SITE_Mulher.Repository.Implementations
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        void DeleteById(int id);
        T FindById(int id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string countQuery);
    }
}
