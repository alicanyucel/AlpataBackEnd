using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Auth.Login;
using NTierArchitecture.Business.Features.Auth.Register;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.WebApi.Abstractions;

namespace NTierArchitecture.WebApi.Controllers;

[AllowAnonymous]
public sealed class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }
    // DENEM COMİİT
    [HttpPost]
    public async Task<IActionResult> Register([FromForm]RegisterCommand request, CancellationToken cancellationToken)
    {
   
            await _mediator.Send(request, cancellationToken);
            return NoContent();
    }
    [HttpPost]
    public async Task<IActionResult> AddFile(IFormFile file)
    {
        if (file.Length > 0)
        {
            var fileName = Guid.NewGuid().ToString() + ".jpeg";
            var filePath = $"{Directory.GetCurrentDirectory()}/Content/{fileName}";
            using (FileStream stream = System.IO.File.Create(filePath))
            {
                file.CopyTo(stream);
                stream.Flush();
            }
            var result = await _mediator.Send(file);
            return Ok(result);
        }
        return BadRequest("Dosya secimi yapmadiniz");
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
