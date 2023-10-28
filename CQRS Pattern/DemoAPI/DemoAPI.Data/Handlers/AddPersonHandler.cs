namespace DemoAPI.Data.Handlers
{
    using MediatR;
    using DemoAPI.Data.Commands;
    using DemoAPI.Data.Models;
    using DemoAPI.Data.Repository;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddPersonHandler : IRequestHandler<PersonAddCommand, Person>
    {
        private readonly IDemoApiRepository repo;

        public AddPersonHandler(IDemoApiRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Person> Handle(PersonAddCommand request, CancellationToken cancellationToken)
        {
            var newPerson = new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            await repo.AddPersonAsync(newPerson);

            return newPerson;
        }
    }
}