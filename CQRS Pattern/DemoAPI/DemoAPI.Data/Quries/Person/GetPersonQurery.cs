namespace DemoAPI.Data.Quries.Person
{
    using DemoAPI.Data.Models;
    using MediatR;
    using System.Collections.Generic;

    public record GetPersonQurery : IRequest<List<Person>>;
}
