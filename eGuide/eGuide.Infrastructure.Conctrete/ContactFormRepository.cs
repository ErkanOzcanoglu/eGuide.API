using eGuide.Data.Dto.OutComing.Admin;
using eGuide.Infrastructure.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Interface.IContactFormRepository" />
    public class ContactFormRepository : IContactFormRepository {

        /// <summary>
        /// The collection
        /// </summary>
        private readonly IMongoCollection<Mail> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactFormRepository"/> class.
        /// </summary>
        /// <param name="mongoContext">The mongo context.</param>
        public ContactFormRepository(IMongoDatabase mongoContext) {
            _collection = mongoContext.GetCollection<Mail>("Mails");
        }

        /// <summary>
        /// Deletes the mail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Mail> DeleteMail(Guid id) {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        /// <summary>
        /// Gets all asynchronous mail.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Mail>> GetAllAsyncMail() {
            return await _collection
                .Find(x => true)
        .Sort(Builders<Mail>.Sort
            .Ascending(x => x.IsRead)
            .Descending(x => x.Date))
        .ToListAsync();
        }

        /// <summary>
        /// Gets the unread messages.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Mail>> GetUnreadMessages() {
            return await _collection.Find(x => x.IsRead == false).ToListAsync();
        }

        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="mail">The mail.</param>
        /// <returns></returns>
        public async Task<Mail> SendMail(Mail mail) {
            mail.Id = Guid.NewGuid();
            mail.Date = DateTime.Now;
            mail.IsRead = false;
            await _collection.InsertOneAsync(mail);
            return mail;
        }

        /// <summary>
        /// Updates the mail.
        /// </summary>
        /// <param name="mail">The mail.</param>
        /// <returns></returns>
        public async Task<Mail> UpdateMail(Guid id) {
            var filter = Builders<Mail>.Filter.Eq(x => x.Id, id);
            var update = Builders<Mail>.Update.Set(x => x.IsRead, true);
            return await _collection.FindOneAndUpdateAsync(filter, update);
        }
    }
}
