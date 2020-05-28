using MediatR;

namespace MediatRAPI.Application.AppUser.Command
{
    public class UserDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
