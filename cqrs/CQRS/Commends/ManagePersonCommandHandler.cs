using AutoMapper;
using cqrs.Entities;
using cqrs.Repositorie;
using MediatR;

namespace cqrs.CQRS.Commends
{
    public class ManagePersonCommandHandler : IRequestHandler<ManagePersonCommand, Result<Guid>>
    {
        private readonly IPersonRepositorie _personRepositorie;
        private readonly IMapper _mapper;

        public ManagePersonCommandHandler(IPersonRepositorie personRepositorie, IMapper mapper)
        {
            _personRepositorie = personRepositorie;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(ManagePersonCommand request, CancellationToken cancellationToken)
        {
            var isAdding = request.Id == Guid.Empty;
            Person? person = null;

            if (isAdding)
            {
                person = new Person();
            }
            else
            {
                person = await _personRepositorie.GetById(request.Id, cancellationToken);
            }

            person = _mapper.Map(request, person);

            if (isAdding)
            {
                await _personRepositorie.Create(person, cancellationToken);
            }
            else
            {
                await _personRepositorie.Update(person, cancellationToken);
            }

            return Result.Ok(request.Id);
        }
    }
}
