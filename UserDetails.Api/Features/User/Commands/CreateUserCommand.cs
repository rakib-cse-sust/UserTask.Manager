using MediatR;
using UserDetails.Api.Models;
using UserDetails.Api.Models.Entities;

namespace UserDetails.Api.Features.User.Commands
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string UserFullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}