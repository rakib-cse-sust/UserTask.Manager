using MediatR;
using UserDetails.Api.Models;

namespace UserDetails.Api.Features.User.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
    }
}