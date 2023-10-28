namespace DemoAPI.Data.Handlers
{
    using DemoAPI.Data.Models;
    using DemoAPI.Data.Quries;
    using DemoAPI.Data.Repository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetPersonHandler : IRequestHandler<GetPersonQurery, List<Person>>
    {
        private readonly IDemoApiRepository repo;

        public GetPersonHandler(IDemoApiRepository repo)
        {
            this.repo = repo;
        }

        public Task<List<Person>> Handle(GetPersonQurery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repo.GetAllPersons());
        }
    }
}
