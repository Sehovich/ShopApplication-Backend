namespace AbySalto.Mid.Application.Contracts.Authentication;

public class LoginRequest
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
