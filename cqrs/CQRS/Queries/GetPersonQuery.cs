using AutoMapper;
using AutoMapper.QueryableExtensions;
using cqrs.Data;
using cqrs.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs.CQRS.Queries
{
    public class GetPersonQuery : IRequest<Result<PersonDto>>
    {
        public Guid Id { get; set; }

        public GetPersonQuery(Guid id)
        {
            Id = id;
        }
    }
}
