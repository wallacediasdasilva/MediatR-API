using MediatRAPI.Domain.Interfaces.Core;
using MediatRAPI.Persistence.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRAPI.Persistence.EFCore.Repository.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MediatRContext _mediatRContext;

        public Repository(MediatRContext mediatRContext)
        {
            _mediatRContext = mediatRContext;
        }

        public async Task Create(TEntity entity)
        {
            _mediatRContext.Add(entity);
            SaveChanges();
        }

        public async Task Delete(int id, TEntity entity)
        {
            var entities = GetById(id);

            if (entities != null)
            {
                await Task.Run(() => _mediatRContext.Set<TEntity>().Remove(entity));
            }
            SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Task.FromResult(_mediatRContext.Set<TEntity>().ToList());
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Task.FromResult(_mediatRContext.Set<TEntity>().Find(id));
        }

        public async Task Update(int id, TEntity entity)
        {
            var entities = GetById(id);

            if (entities != null)
            {
                await Task.Run(() => _mediatRContext.Entry(entity).State = EntityState.Modified);
            }
            SaveChanges();
        }

        public void SaveChanges()
        {
            _mediatRContext.SaveChangesByUser();
        }
    }
}
