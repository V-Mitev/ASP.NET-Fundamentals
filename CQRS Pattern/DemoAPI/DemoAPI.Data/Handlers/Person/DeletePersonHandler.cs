namespace DemoAPI.Data.Handlers.Person
{
    using DemoAPI.Data.Commands.Person;
    using DemoAPI.Data.Repository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IDemoApiRepository repo;

        public DeletePersonHandler(IDemoApiRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var result = await repo.DeletePersonAsync(request.id);

            return result;
        }
    }
}
