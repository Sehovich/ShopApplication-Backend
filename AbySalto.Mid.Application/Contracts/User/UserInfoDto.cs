namespace AbySalto.Mid.Application.Contracts.User;


public class UserInfoDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
}
