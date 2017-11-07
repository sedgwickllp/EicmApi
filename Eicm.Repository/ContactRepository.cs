using Eicm.Core.Extensions;
using Eicm.DataLayer;
using Eicm.DataLayer.Entities.Vendors;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Eicm.DataLayer.Entities.Assets;

namespace Eicm.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private readonly ICoreDbContext _coreDbContext;
        public ContactRepository(ICoreDbContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }
        public async Task<ICommonResult<Contact>> GetContactByIdAsync(int id)
        {
            try
            {
                var foundContact = await _coreDbContext.Contacts.SingleAsync(c => c.Id == id);
                return new CommonResult<Contact>(foundContact, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<Contact>(null, ResultCode.Failure, ex.Message);
            }
        }
       
        public async Task<ICommonResult<int>> AddContactAsync(Contact contact)
        {
            try { 
                _coreDbContext.Contacts.Add(contact);
                await _coreDbContext.SaveChangesAsync();

                
                return new CommonResult<int>(contact.Id, ResultCode.Success);
            }
            catch (Exception ex)
            {
                _log.Error(ex.GetBaseException());
                return new CommonResult<int>(-1, ResultCode.Failure, ex.Message);
            }
        }

        
    }
}
