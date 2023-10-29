namespace DemoAPI.Data.Handlers.Person
{
    using DemoAPI.Data.Models;
    using DemoAPI.Data.Quries;
    using DemoAPI.Data.Repository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly IDemoApiRepository repo;

        public GetPersonByIdHandler(IDemoApiRepository repo)
        {
            this.repo = repo;
        }

        public Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repo.GetPersonById(request.Id));
        }
    }
}
