namespace DemoAPI.Data.Handlers.Role
{
    using DemoAPI.Data.Models;
    using DemoAPI.Data.Quries.Role;
    using DemoAPI.Data.Repository;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, List<ApplicationRole>>
    {
        private readonly IDemoApiRepository repo;

        public GetAllRolesHandler(IDemoApiRepository repo)
        {
            this.repo = repo;
        }

        public Task<List<ApplicationRole>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repo.GetAllRoles());
        }
    }
}
