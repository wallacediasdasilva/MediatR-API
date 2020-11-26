using DDDAPI.Domain.Interfaces.Core;
using DDDAPI.Persistence.EFCore.Context;

namespace DDDAPI.Persistence.EFCore.Repository.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MediatRContext _mediatRContext;

        public Repository(MediatRContext mediatRContext)
        {
            _mediatRContext = mediatRContext;
        }

        public void Create(TEntity entity)
        {
            _mediatRContext.Add(entity);
            SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _mediatRContext.Remove(entity);
            
            SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _mediatRContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _mediatRContext.Update(entity);

            SaveChanges();
        }

        public void SaveChanges()
        {
            _mediatRContext.SaveChangesByTeam();
        }
    }
}
