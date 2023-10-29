namespace DemoAPI.Data.Commands.Person
{
    using MediatR;

    public record DeletePersonCommand(int id) : IRequest<bool>;
}
