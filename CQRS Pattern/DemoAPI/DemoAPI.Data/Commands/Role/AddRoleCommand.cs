namespace DemoAPI.Data.Commands.Role
{
    using MediatR;

    public record AddRoleCommand(string roleName) : IRequest<bool>;
}
