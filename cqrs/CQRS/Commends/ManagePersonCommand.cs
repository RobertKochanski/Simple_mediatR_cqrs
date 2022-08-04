using MediatR;
using System.Text.Json.Serialization;

namespace cqrs.CQRS.Commends
{
    public class ManagePersonCommand : IRequest<Result<Guid>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
    }
}
