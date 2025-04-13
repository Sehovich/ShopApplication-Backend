using MediatR;
using AbySalto.Mid.Application.Contracts.User;

namespace AbySalto.Mid.Application.Users.Queries;

public class GetCurrentUserInfoQuery : IRequest<UserInfoDto>
{
    public Guid UserId { get; set; }
}
