namespace DemoAPI.Data.Quries.Person
{
    using DemoAPI.Data.Models;
    using MediatR;

    public record GetPersonByIdQuery(int Id) : IRequest<Person>;
}
