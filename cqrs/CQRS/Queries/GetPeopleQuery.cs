using MediatR;
using cqrs.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using cqrs.Dto;

namespace cqrs.CQRS.Queries
{
    public class GetPeopleQuery : IRequest<Result<List<PersonDto>>>
    {
    }
}
