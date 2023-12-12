using eGuide.Data.Dto.OutComing.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {

    /// <summary>
    /// 
    /// </summary>
    public interface IContactFormBusiness {

        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="mail">The mail.</param>
        /// <returns></returns>
        Task<Mail> SendMail(Mail mail);

        /// <summary>
        /// Gets all asynchronous mail.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Mail>> GetAllAsyncMail();

        /// <summary>
        /// Gets the unread messages.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Mail>> GetUnreadMessages();

        /// <summary>
        /// Deletes the mail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Mail> DeleteMail(Guid id);

        /// <summary>
        /// Updates the mail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Mail> UpdateMail(Guid id);
    }
}
