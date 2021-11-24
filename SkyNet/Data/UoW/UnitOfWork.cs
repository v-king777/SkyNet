using Microsoft.EntityFrameworkCore.Infrastructure;
using SkyNet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private SkyNetDbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(SkyNetDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            if (hasCustomRepository)
            {
                var customRepo = _context.GetService<IRepository<TEntity>>();

                if (customRepo != null)
                {
                    return customRepo;
                }
            }

            var type = typeof(TEntity);

            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public int SaveChanges(bool ensureAutoHistory = false)
        {
            throw new NotImplementedException();
        }
    }
}
