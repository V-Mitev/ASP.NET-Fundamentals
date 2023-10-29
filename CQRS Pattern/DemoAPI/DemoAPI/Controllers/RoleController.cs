namespace DemoAPI.Controllers
{
    using DemoAPI.Data.Models;
    using DemoAPI.Data.Quries;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IMediator mediator;

        public RoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Person>> Get()
        {
            return await mediator.Send(new GetPersonQurery());
        }
    }
}
