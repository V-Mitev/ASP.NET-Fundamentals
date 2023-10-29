namespace DemoAPI.Data.Commands.Person
{
    using DemoAPI.Data.Models;
    using MediatR;

    public record UpdatePersonCommand(int Id, string FirstName) : IRequest<Person>;
}
