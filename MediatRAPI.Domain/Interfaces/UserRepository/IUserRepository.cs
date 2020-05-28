using MediatRAPI.Domain.Interfaces.Core;
using MediatRAPI.Domain.User;

namespace MediatRAPI.Domain.Interfaces.UserRepository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
    }
}
