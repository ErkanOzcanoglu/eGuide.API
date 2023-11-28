using eGuide.Data.Dto.OutComing.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace eGuide.Service.ClientAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase {
        [HttpPost]
        public IActionResult MailContactForm(MailDto contactForm) {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(contactForm.Email));
            email.To.Add(MailboxAddress.Parse("eguideacnt@gmail.com"));

            email.Subject = contactForm.Name;
    //        < h2 > Contact Form Submission</ h2 >
    //< p >< strong > From:</ strong > { { contactForm.Name} }
    //        &lt;
    //        { { contactForm.Email} }
    //        &gt;</ p >
    //< p >< strong > Message:</ strong > { { contactForm.Message} }</ p >
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                Text = $"<h2>Contact Form Submission</h2><p><strong>From:</strong> {contactForm.Name} &lt;{contactForm.Email}&gt;</p><p><strong>Message:</strong> {contactForm.Message}</p>"
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("crntrim@gmail.com", "yzlijnhvqjrbipwl");

            smtp.Send(email);

            smtp.Disconnect(true);

            return Ok();

        }
    }
}
