namespace DemoAPI.Data.Repository
{
    using DemoAPI.Data.Data;
    using DemoAPI.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class DemoApiRepository : IDemoApiRepository
    {
        private readonly DemoApiDbContext dbContext;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DemoApiRepository(DemoApiDbContext dbContext, RoleManager<ApplicationRole> roleManager)
        {
            this.dbContext = dbContext;
            _roleManager = roleManager;
        }

        public async Task AddPersonAsync(Person person)
        {
            await dbContext.AddAsync(person);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> AddRole(string roleName)
        {
            var role = new ApplicationRole { Name = roleName };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            var personToDelete = await dbContext.Persons.FirstOrDefaultAsync(p => p.Id == id);

            if (personToDelete != null)
            {
                dbContext.Persons.Remove(personToDelete!);
                await dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public List<Person> GetAllPersons()
        {
            var list = dbContext.Persons.ToList();

            return list;
        }

        public List<ApplicationRole> GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();

            return roles;
        }

        public Person GetPersonById(int id)
        {
            return dbContext.Persons.FirstOrDefault(p => p.Id == id)!;
        }

        public Person UpdatePersonFirstNameById(int id, string newFirstName)
        {
            var personToUpdate = GetPersonById(id);

            if (personToUpdate != null)
            {
                personToUpdate.FirstName = newFirstName;

                return personToUpdate;
            }

            return null;
        }
    }
}
