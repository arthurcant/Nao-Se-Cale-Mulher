using API_SITE_Mulher.Model.Base;
using API_SITE_Mulher.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace API_SITE_Mulher.Repository.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected MySQLContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return item;
        }

        public void DeleteById(int id)
        {
            var result = dataset.FirstOrDefault((t) => t.Id == id);

            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public T FindById(int id)
        {
            var result = dataset.FirstOrDefault((t) => t.Id == id);

            if (result == null) return null;

            return result;

        }

        public List<T> FindWithPagedSearch(string query)
        {
            return dataset.FromSqlRaw(query).ToList();
        }

        public int GetCount(string countQuery)
        {
            var result = "";
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = countQuery;
                    result = command.ExecuteScalar().ToString();
                }
            }
            return int.Parse(result);
        }

        public T Update(T item)
        {
            var element = dataset.SingleOrDefault((t) => t.Id.Equals(item.Id));
            if (element != null)
            {
                try
                {
                    _context.Entry(element).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return item;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return item;
        }

    }
}
