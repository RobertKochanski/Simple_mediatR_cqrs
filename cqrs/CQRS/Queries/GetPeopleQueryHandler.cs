using AutoMapper;
using AutoMapper.QueryableExtensions;
using cqrs.Data;
using cqrs.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs.CQRS.Queries
{
    public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, Result<List<PersonDto>>>
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;

        public GetPeopleQueryHandler(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<List<PersonDto>>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.People
                .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Result.Ok(result);
        }
    }
}
