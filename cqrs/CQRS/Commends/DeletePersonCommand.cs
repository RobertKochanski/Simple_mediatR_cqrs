using MediatR;

namespace cqrs.CQRS.Commends
{
    public class DeleteProductCommand : IRequest<Result>
    {
        public Guid Id { get; set; }

        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
