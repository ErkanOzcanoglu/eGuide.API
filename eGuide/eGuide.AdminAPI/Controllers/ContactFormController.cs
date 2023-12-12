using eGuide.Business.Interface;
using eGuide.Common.SignalR;
using eGuide.Data.Dto.OutComing.Admin;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MimeKit;

namespace eGuide.Service.AdminAPI.Controllers {
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

        /// <summary>
        /// The hub context
        /// </summary>
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
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() {
            await _hubContext.Clients.All.BroadcastMessage();
            var mails = await _business.GetAllAsyncMail();
            return Ok(mails);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            await _business.DeleteMail(id);
            return Ok();
        }

        /// <summary>
        /// Posts the specified contact form.
        /// </summary>
        /// <param name="contactForm">The contact form.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Mail contactForm) {
            await _hubContext.Clients.All.BroadcastMessage();
            await _business.SendMail(contactForm);
            return Ok();
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(Guid id) {
            await _business.UpdateMail(id);
            return Ok();
        }

        [HttpGet("unread")]
        public async Task<IActionResult> GetUnread() {
            var mails = await _business.GetUnreadMessages();
            return Ok(mails);
        }

        

        [HttpPost("reply-to")]
        public IActionResult ReplyTo(ReplyMail contactForm) {
            var replyEmail = new MimeMessage();
            replyEmail.From.Add(MailboxAddress.Parse(contactForm.AdminMail));
            replyEmail.To.Add(MailboxAddress.Parse(contactForm.Email));

            replyEmail.Subject = $"Re: {contactForm.Name}";
            replyEmail.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                Text = $"Dear {contactForm.Name},<br/><br/>{contactForm.Message}<br/><br/>Best regards,<br/>eGuide"
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("crntrim@gmail.com", "yzlijnhvqjrbipwl");

            smtp.Send(replyEmail);

            smtp.Disconnect(true);

            return Ok();
        }

    }
}
