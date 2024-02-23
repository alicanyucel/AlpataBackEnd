using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.WebApi.Abstractions;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NTierArchitecture.WebApi.Controllers
{
    [AllowAnonymous]
    public sealed class MailController : ApiController
    {
        public MailController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail()
        {
            var apiKey = "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";
            var client= new SendGridClient(apiKey);
            var from=new EmailAddress("yucelalican30@gmail.com","aLİ CAN");
            var subject = "uye kaydı";
            var to = new EmailAddress("yucelalican30@gmail.com","uye kaydı");
             var htmlcontext = "<strong>annd";
            var plaintext = "and easy to do anywhere,even with c#</strong>";
           
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plaintext, htmlcontext);
            var response=await client.SendEmailAsync(msg);
            return Ok(new {Message="MAİL GİTTİ"});

        }
    }
}
