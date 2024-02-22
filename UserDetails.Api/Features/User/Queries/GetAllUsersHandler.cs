using AutoMapper;
using MediatR;
using UserDetails.Api.Models;
using UserDetails.Api.Repositories;

namespace UserDetails.Api.Features.User.Queries
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersAsync();

            var userDetails = _mapper.Map<List<UserDto>>(users);

            return userDetails ?? new List<UserDto>();
        }
    }
}