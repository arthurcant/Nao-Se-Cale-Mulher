using API_SITE_Mulher.Model.Base;

namespace API_SITE_Mulher.Repository.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        public T Create(T item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> FindWithPagedSearch(string query)
        {
            throw new NotImplementedException();
        }

        public int GetCount(string query)
        {
            throw new NotImplementedException();
        }

        public T Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
