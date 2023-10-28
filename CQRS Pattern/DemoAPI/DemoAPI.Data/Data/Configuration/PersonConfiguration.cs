namespace DemoAPI.Data.Data.Configuration
{
    using DemoAPI.Data.Commands;
    using DemoAPI.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(AddPerson());
        }

        private Person AddPerson()
        {
            Person person = new Person()
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov"
            };

            return person;
        }
    }
}
