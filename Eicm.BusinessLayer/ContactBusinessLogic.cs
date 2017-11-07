using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Assets;
using Eicm.DataLayer.Entities.Vendors;
using Eicm.Repository;
using NLog;

namespace Eicm.BusinessLogic
{
    public class ContactBusinessLogic : IContactBusinessLogic
    {
        private readonly IContactRepository _contactRepository;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ContactBusinessLogic(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<ICommonResult<ContactDTO>> GetContactByIdAsync(int id)
        {
            _logger.Info("Retrieving contact with id: " + id);
            var dbContact = await _contactRepository.GetContactByIdAsync(id);

            if (dbContact.ResultCode && dbContact.Payload == null)
            {
                _logger.Info("No contact returned for id: " + id);
                return new CommonResult<ContactDTO>(null, dbContact.ResultCode);
            }
            if (!dbContact.ResultCode)
            {
                _logger.Info("getContactByIdAsync returned failed from repo");
                return new CommonResult<ContactDTO>(null, dbContact.ResultCode, dbContact.Message);
            }
            _logger.Info("Contact retrieved");


            var contact = new ContactDTO()
            {
                Name = dbContact.Payload.Name,
                Email = dbContact.Payload.Email,
                Phone = dbContact.Payload.Phone,
                Id = dbContact.Payload.Id
            };
            return new CommonResult<ContactDTO>(contact, true); 
        }

       
         public async Task<ICommonResult<int>> AddContactAsync(ContactDTO contact)
         {         
            var dbcontact = new Contact()
            {
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone
            };
            var newContact = await _contactRepository.AddContactAsync(dbcontact);
             return new CommonResult<int>(newContact.Payload, newContact.ResultCode);
         }

        
       
    }
}
