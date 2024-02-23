using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Meets.CreateMeets;
using NTierArchitecture.Business.Features.Meets.GetMeets;
using NTierArchitecture.Business.Features.Meets.RemoveMeetsById;
using NTierArchitecture.Business.Features.Meets.UpdateMeets;
using NTierArchitecture.DataAccess.Authorization;
using NTierArchitecture.WebApi.Abstractions;
using System.Threading;

namespace NTierArchitecture.WebApi.Controllers
{
    public sealed class MeetsController : ApiController
    {
        public MeetsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [RoleFilter("Meet.Add")]
        public async Task<IActionResult> Add(CreateMeetCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            if (response.IsError)
            {
                return BadRequest(response.FirstError);
            }

            return NoContent();
        }

        [HttpPut]
        [RoleFilter("Meet.Update")]
        public async Task<IActionResult> Update(UpdateMeetCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(id);
            return Ok(result);
          
           
        }
        [HttpDelete]
        [RoleFilter("Meet.Remove")]
        public async Task<IActionResult> RemoveById(RemoveMeetsByIdCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }

        [HttpGet]
        [RoleFilter("Meet.GetAll")]
        public async Task<IActionResult> GetAll(GetMeetsQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}