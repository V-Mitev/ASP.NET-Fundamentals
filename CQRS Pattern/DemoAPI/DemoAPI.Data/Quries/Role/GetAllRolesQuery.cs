namespace DemoAPI.Data.Quries.Role
{
    using DemoAPI.Data.Models;
    using MediatR;

    public record GetAllRolesQuery : IRequest<List<ApplicationRole>>;
}
