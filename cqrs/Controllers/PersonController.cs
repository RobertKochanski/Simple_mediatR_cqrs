using cqrs.CQRS.Commends;
using cqrs.CQRS.Queries;
using cqrs.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cqrs.Controllers
{
    [Route("api")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("people")]
        public async Task<IActionResult> Get([FromQuery] GetPeopleQuery query)
        {
            return await _mediator.Send(query).Process();
        }

        [HttpGet("person/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await _mediator.Send(new GetPersonQuery(id)).Process();
        }

        [HttpPost("person")]
        public async Task<IActionResult> Post(ManagePersonCommand command)
        {
            return await _mediator.Send(command).Process();
        }

        [HttpPut("person/{id}")]
        public async Task<IActionResult> Put(Guid id, ManagePersonCommand command)
        {
            command.Id = id;
            return await _mediator.Send(command).Process();
        }

        [HttpDelete("api/person/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteProductCommand(id)).Process();
        }
    }
}
