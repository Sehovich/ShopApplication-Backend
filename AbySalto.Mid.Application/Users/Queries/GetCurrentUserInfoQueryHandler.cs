using MediatR;
using AbySalto.Mid.Domain.Interfaces;
using AbySalto.Mid.Application.Contracts.User;

namespace AbySalto.Mid.Application.Users.Queries;

public class GetCurrentUserInfoQueryHandler : IRequestHandler<GetCurrentUserInfoQuery, UserInfoDto>
{
    private readonly IUserRepository _userRepository;

    public GetCurrentUserInfoQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserInfoDto> Handle(GetCurrentUserInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);



        if (user == null)
            throw new Exception("User not found");

        return new UserInfoDto
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username
        };
    }
}

