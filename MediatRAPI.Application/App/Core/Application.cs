using DDDAPI.Application.App.Interface.Core;

namespace DDDAPI.Application.App.Core
{
    public class Application<TEntity> : IApplication<TEntity> where TEntity : class
    {
        public void Create(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
