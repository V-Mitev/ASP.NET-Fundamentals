namespace DemoAPI.Data.Handlers.Role
{
    using DemoAPI.Data.Commands.Role;
    using DemoAPI.Data.Repository;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddRoleHandler : IRequestHandler<AddRoleCommand, bool>
    {
        private readonly IDemoApiRepository repo;

        public AddRoleHandler(IDemoApiRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            bool isRoleAdded = await repo.AddRole(request.roleName);

            return isRoleAdded;
        }
    }
}
