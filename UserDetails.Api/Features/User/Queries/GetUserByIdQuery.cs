using MediatR;
using UserDetails.Api.Models;

namespace UserDetails.Api.Features.User.Queries
{
    public class GetUserByIdQuery : IRequest<List<UserDto>>
    {
        public int Id { get; set; }
    }
}