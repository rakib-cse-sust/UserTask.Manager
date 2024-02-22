using AutoMapper;
using Masstransit.Shared;
using MassTransit;
using MediatR;
using UserDetails.Api.Models;
using UserDetails.Api.Repositories;

namespace UserDetails.Api.Features.User.Commands
{
    public class CreateUsersHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateUsersHandler(IUserRepository userRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.CreateUserAsync(new Models.Entities.User
            {
                Email = request.Email,
                UserFullName = request.UserFullName,
                Password = request.Password
            });

            await _publishEndpoint.Publish<UserCreatedEvent>(new
            {
                user.Id,
                user.Email,
                DateTime.Now
            }, cancellationToken);

            var userDetails = _mapper.Map<UserDto>(user);

            return userDetails ?? new UserDto();
        }
    }
}