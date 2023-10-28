namespace DemoAPI.Data.Commands
{
    using MediatR;

    public record DeletePersonCommand(int id) : IRequest<bool>;
}
