namespace DemoAPI.Controllers
{
    using DemoAPI.Data.Commands.Person;
    using DemoAPI.Data.Models;
    using DemoAPI.Data.Quries;
    using DemoAPI.Data.Quries.Person;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Person>> Get()
        {
            return await mediator.Send(new GetPersonQurery());
        }

        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await mediator.Send(new GetPersonByIdQuery(id));
        }

        [HttpPost]
        public async Task<Person> Post([FromBody] Person p)
        {
            return await mediator.Send(new PersonAddCommand(p.FirstName, p.LastName));
        }
        
        [HttpPut("{id}")]
        public async Task<Person> Put(int id, [FromBody] string firstName)
        {
            return await mediator.Send(new UpdatePersonCommand(id, firstName));
        }
        
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await mediator.Send(new DeletePersonCommand(id));
        }
    }
}
