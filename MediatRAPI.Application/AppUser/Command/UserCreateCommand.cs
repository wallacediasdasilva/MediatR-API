using MediatR;
using System;

namespace MediatRAPI.Application.AppUser.Command
{
    public class UserCreateCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
