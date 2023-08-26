using X.Yönetim.Domain.Common;
using X.Yönetim.Domain.Repositories;
using X.Yönetim.Domain.UWork;
using X.Yönetim.Persistence.Context;
using X.Yönetim.Persistence.Repositories;

namespace X.Yönetim.Persistence.UWork
{
    public class UWork : IUWork
    {
        private readonly Dictionary<Type, object> _repositories;
        private readonly XContext _context;

        public UWork(XContext context)
        {
            _repositories = new Dictionary<Type, object>();
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            var result = false;
            
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = true;
                }
                catch
                {  // hata durumunda işlemi geri al
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            return result;
        }  


        public IRepository<T> GetRepository<T>() where T : BaseEntity
        
        {
            
            //repository daha önceden oluşturulmuş mu kontrol et
            if (_repositories.ContainsKey(typeof(IRepository<T>)))
            {
                return (IRepository<T>)_repositories[typeof(IRepository<T>)];
            }
            // oluşturulmamışssa oluştur

            var repository = new Repository<T>(_context);
            _repositories.Add(typeof(IRepository<T>), repository);
            return repository;
        }

        #region Dispose
        bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                //.Net objelerini kaldır.
                _context.Dispose();
            }

          

            _disposed = true;
        }

            #endregion


    }
}
