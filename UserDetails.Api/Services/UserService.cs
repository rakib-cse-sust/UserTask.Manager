using MediatR;
using UserDetails.Api.Features.User.Commands;
using UserDetails.Api.Features.User.Queries;
using UserDetails.Api.Models;
using UserDetails.Api.Models.Entities;
using UserDetails.Api.Repositories;

namespace UserDetails.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public UserService(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var userDetails = await _mediator.Send(new GetAllUsersQuery());
            return userDetails;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                UserFullName = user.UserFullName
            };
        }

        public async Task<UserDto> CreateUser(UserDto userDetails)
        {
            var user = await _mediator.Send(new CreateUserCommand()
            {
                Email = userDetails.Email,
                Password = userDetails.Password,
                UserFullName = userDetails.UserFullName
            });

            return user;            
        }

        public async Task<int> UpdateUser(UserDto userDetails)
        {
            var user = new User
            {
                Id = userDetails.Id,
                Email = userDetails.Email,
                UserFullName = userDetails.UserFullName
            };

            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}