namespace DemoAPI.Data.Repository
{
    using DemoAPI.Data.Data;
    using DemoAPI.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class DemoApiRepository : IDemoApiRepository
    {
        private readonly DemoApiDbContext dbContext;

        public DemoApiRepository(DemoApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPersonAsync(Person person)
        {
            await dbContext.AddAsync(person);
            await dbContext.SaveChangesAsync();
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
