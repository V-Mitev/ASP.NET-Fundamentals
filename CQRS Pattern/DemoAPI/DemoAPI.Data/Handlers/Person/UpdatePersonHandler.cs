namespace DemoAPI.Data.Handlers.Person
{
    using DemoAPI.Data.Commands.Person;
    using DemoAPI.Data.Models;
    using DemoAPI.Data.Repository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, Person>
    {
        private readonly IDemoApiRepository repo;

        public UpdatePersonHandler(IDemoApiRepository repo)
        {
            this.repo = repo;
        }

        public Task<Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var personToUpdate = repo.GetPersonById(request.Id);

            if (personToUpdate == null)
            {
                return Task.FromResult<Person>(null);
            }

            repo.UpdatePersonFirstNameById(request.Id, request.FirstName!);

            return Task.FromResult(personToUpdate);
        }
    }
}
