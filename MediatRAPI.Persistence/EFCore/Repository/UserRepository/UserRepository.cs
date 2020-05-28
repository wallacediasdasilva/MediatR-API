using MediatRAPI.Domain.Interfaces.UserRepository;
using MediatRAPI.Domain.User;
using MediatRAPI.Persistence.EFCore.Context;
using MediatRAPI.Persistence.EFCore.Repository.Core;

namespace MediatRAPI.Persistence.EFCore.Repository.UserRepository
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(MediatRContext mediatRContext) : base(mediatRContext)
        {
        }
    }
}
