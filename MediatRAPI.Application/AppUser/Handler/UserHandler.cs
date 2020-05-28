using MediatR;
using MediatRAPI.Application.AppUser.Command;
using MediatRAPI.Domain.Interfaces.UserRepository;
using MediatRAPI.Domain.User;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRAPI.Application.AppUser.Handler
{
    public class UserHandler : IRequestHandler<UserCreateCommand, string>, IRequestHandler<UserUpdateCommand, string>, IRequestHandler<UserDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public UserHandler(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new UserEntity(request.Name, request.CPF, request.Email, request.Phone);

            await _userRepository.Create(user);

            return await Task.FromResult("Cliente registrado com sucesso");
        }

        public async Task<string> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = new UserEntity(request.Name, request.CPF, request.Email, request.Phone);

            await _userRepository.Update(request.Id, user);

            _userRepository.SaveChanges();

            return await Task.FromResult("Cliente atualizado com sucesso");
        }

        public async Task<string> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = new UserEntity(request.Id);

            await _userRepository.Delete(request.Id, user);

            _userRepository.SaveChanges();

            return await Task.FromResult("Cliente deletado com sucesso");
        }
    }
}
