using eGuide.Business.Interface;
using eGuide.Common.SignalR;
using eGuide.Data.Dto.OutComing.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MimeKit;

namespace eGuide.Service.ClientAPI.Controllers {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IContactFormBusiness _business;

        private readonly IHubContext<BroadCastHub, IHubClient> _hubContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactFormController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        public ContactFormController(IContactFormBusiness business, IHubContext<BroadCastHub, IHubClient> hubContext) {
            _business = business;
            _hubContext = hubContext;
        }

        /// <summary>
        /// Mails the contact form.
        /// </summary>
        /// <param name="contactForm">The contact form.</param>
        /// <returns></returns>
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
            smtp.Authenticate("eguideacnt@gmail.com", "xcnbnfhndthxnosz");

            smtp.Send(email);

            smtp.Disconnect(true);

            return Ok();

        }

        [HttpPost("reply-mail")]
        public IActionResult ReplayMail(MailDto contactForm) {
            var replyEmail = new MimeMessage();
            replyEmail.From.Add(MailboxAddress.Parse("eguideacnt@gmail.com"));
            replyEmail.To.Add(MailboxAddress.Parse(contactForm.Email));

            replyEmail.Subject = $"Re: {contactForm.Name}";
            replyEmail.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                Text = $"Dear {contactForm.Name},<br/><br/>Thank you for your message. We have received your inquiry and will get back to you as soon as possible.<br/><br/>Best regards,<br/>eGuide"
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("eguideacnt@gmail.com", "xcnbnfhndthxnosz");

            smtp.Send(replyEmail);

            smtp.Disconnect(true);

            return Ok();
        }

        [HttpPost("send")]
        public async Task<IActionResult> Post(Mail contactForm) {
            await _hubContext.Clients.All.BroadcastMessage();
            await _business.SendMail(contactForm);
            return Ok();
        }
    }
}
