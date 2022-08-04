using AutoMapper;
using AutoMapper.QueryableExtensions;
using cqrs.Data;
using cqrs.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs.CQRS.Queries
{
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, Result<PersonDto>>
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;

        public GetPersonQueryHandler(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<PersonDto>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.People
                .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (result == null)
            {
                return Result.NotFound<PersonDto>(request.Id);
            }

            return Result.Ok(result);
        }
    }
}
