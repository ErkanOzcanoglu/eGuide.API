using eGuide.Business.Interface;
using eGuide.Data.Dto.OutComing.Admin;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Business.Interface.IContactFormBusiness" />
    public class ContactFormBusiness : IContactFormBusiness {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IContactFormRepository _repository;

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactFormBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public ContactFormBusiness(IContactFormRepository repository, IUnitOfWork unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Deletes the mail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Mail> DeleteMail(Guid id) {
            return await _repository.DeleteMail(id);
        }

        /// <summary>
        /// Gets all asynchronous mail.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Mail>> GetAllAsyncMail() {
            return await _repository.GetAllAsyncMail();
        }

        public async Task<IEnumerable<Mail>> GetUnreadMessages() {
            return await _repository.GetUnreadMessages();
        }

        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="mail">The mail.</param>
        /// <returns></returns>
        public async Task<Mail> SendMail(Mail mail) {
            return await _repository.SendMail(mail);
        }

        /// <summary>
        /// Updates the mail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Mail> UpdateMail(Guid id) {
            return await _repository.UpdateMail(id);
        }
    }
}
