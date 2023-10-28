namespace DemoAPI.Data.Quries
{
    using DemoAPI.Data.Models;
    using MediatR;

    public record GetPersonByIdQuery(int Id) : IRequest<Person>;
}
