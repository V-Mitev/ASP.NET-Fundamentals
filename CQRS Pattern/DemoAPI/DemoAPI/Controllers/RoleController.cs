namespace DemoAPI.Controllers
{
    using DemoAPI.Data.Commands.Role;
    using DemoAPI.Data.Models;
    using DemoAPI.Data.Quries.Role;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IMediator mediator;

        public RoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ApplicationRole>> GetAllRoles()
        {
            return await mediator.Send(new GetAllRolesQuery());
        }

        [HttpPost]
        public async Task AddRole(string roleName)
        {
            await mediator.Send(new AddRoleCommand(roleName));
        }
    }
}
