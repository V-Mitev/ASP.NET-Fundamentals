namespace DemoAPI.Data.Repository
{
    using DemoAPI.Data.Models;

    public interface IDemoApiRepository
    {
        public List<Person> GetAllPersons();

        public Person GetPersonById(int id);

        public Task AddPersonAsync(Person person);

        public Task<bool> DeletePersonAsync(int id);

        public Person UpdatePersonFirstNameById(int id, string newFirstName);
    }
}
