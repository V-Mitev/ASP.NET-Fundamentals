namespace DemoAPI.Data.Commands.Person
{
    using DemoAPI.Data.Models;
    using MediatR;

    public record PersonAddCommand(string FirstName, string LastName) : IRequest<Person>;
}
