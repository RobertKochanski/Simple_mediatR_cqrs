using cqrs.Repositorie;
using MediatR;

namespace cqrs.CQRS.Commends
{
    public class DeletePersonCommandHandler : IRequestHandler<DeleteProductCommand, Result>
    {
        private readonly IPersonRepositorie _personRepositorie;

        public DeletePersonCommandHandler(IPersonRepositorie personRepositorie)
        {
            _personRepositorie = personRepositorie;
        }

        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _personRepositorie.Delete(request.Id, cancellationToken);

            if (result)
            {
                return Result.Ok();
            }

            return Result.NotFound(request.Id);
        }
    }
}
