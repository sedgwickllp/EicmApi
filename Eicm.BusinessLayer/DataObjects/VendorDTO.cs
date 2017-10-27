using Eicm.DataLayer.Entities.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eicm.Core;
using Eicm.Core.Enums;
using Eicm.DataLayer.Entities.TypeCodes;

namespace Eicm.BusinessLogic.DataObjects
{
    public class VendorDTO
    {
        public VendorDetailModel VendorDetail;
        //public List<VendorAccountsModel> VendorAccounts;
    }
    public class VendorDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VendorDetailModel() {}
        public List<VendorContactModel> Contacts { get; set; }
        public List<ContractDTO> VendorContracts { get; set; }

        public VendorDetailModel(Vendor vendor)
        {
            Id = vendor.Id;
            Name = vendor.Name;
        }

    }

    public class VendorAccountsModel
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public List<AccountContactModel> Contacts { get; set; }
        
        public VendorAccountsModel() { }

        public VendorAccountsModel(Account account)
        {
            Id = account.Id;
            AccountNumber = account.AccountNumber;
            Contacts = account.AccountContacts.Select(x => new AccountContactModel(x.Contact)).ToList();
            //Contracts = account.AccountContracts.Select(x => new ContractModel(x.Contract)).ToList();
            //ticket.Comments.Select(n => (TicketNoteModel)n).ToList();
        }
    }

    public class AccountContactModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactType { get; set; }


        public AccountContactModel() {}

        public AccountContactModel(Contact contact)
        {
            Name = contact.Name;
            Phone = contact.Phone;
            Email = contact.Email;
        }
    }

    public class VendorContactModel
    {
        public int VendorId { get; set; }
        public int ContactId { get; set; }
        //public string Email { get; set; }
        public string ContactType { get; set; }
        public Contact Contact { get; set; }

        public VendorContactModel() { }

       
    }

    public class VendorContractModel
    {
        public int VendorId { get; set; }
        public int ContractId { get; set; }
        public List<ContractAsset> ContractAssets { get; set; }
        public VendorContractModel(VendorContract vendorContract)
        {
            VendorId = vendorContract.VendorId;
            ContractId = vendorContract.ContractId;
            //ContractAssets = vendorContract.ContractAssets.Select(x => new ContractAsset(x.Contract)).ToList();
            //Contracts = account.AccountContracts.Select(x => new ContractModel(x.Contract)).ToList();
            //ticket.Comments.Select(n => (TicketNoteModel)n).ToList();
        }
    }


    public class VendorUpdateModel
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifedByUserId { get; set; }
        public bool IsActive { get; set; }
    }

  

}
