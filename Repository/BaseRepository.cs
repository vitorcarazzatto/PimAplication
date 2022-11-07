using PimAplication.Data;
using PimAplication.Repository.Interface;

namespace PimAplication.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly PimContext _context;

        public BaseRepository(PimContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
