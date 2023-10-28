namespace DemoAPI.Data.Commands
{
    using DemoAPI.Data.Models;
    using MediatR;

    public record UpdatePersonCommand(int Id, string FirstName) : IRequest<Person>;
}
