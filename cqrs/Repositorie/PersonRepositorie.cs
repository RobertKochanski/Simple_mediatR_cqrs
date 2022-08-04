using cqrs.Data;
using cqrs.Entities;

namespace cqrs.Repositorie
{
    public class PersonRepositorie : BaseRepositorie<Person>, IPersonRepositorie
    {
        public PersonRepositorie(DataContext db) : base(db)
        {
        }
    }

    public interface IPersonRepositorie
    {
        Task<Person> Create(Person model, CancellationToken cancellationToken);
        Task<Person> Update(Person model, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<Person> GetById(Guid id, CancellationToken cancellationToken);
    }
}
