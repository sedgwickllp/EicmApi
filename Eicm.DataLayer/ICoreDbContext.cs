using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Eicm.DataLayer.Entities.Assets;
using Eicm.DataLayer.Entities.Core;
using Eicm.DataLayer.Entities.Tickets;
using Eicm.DataLayer.Entities.TypeCodes;
using Eicm.DataLayer.Entities.Users;
using Eicm.DataLayer.Entities.Vendors;

namespace Eicm.DataLayer
{
    public interface ICoreDbContext : IDisposable
    {
        DbSet<Asset> Assets { get; set; }
        DbSet<AssetType> AssetTypes { get; set; }

        DbSet<Address> Addresses { get; set; }
        DbSet<AddressType> AddressTypes { get; set; }


        DbSet<Ticket> Tickets { get; set; }
        DbSet<TicketActivity> TicketActivities { get; set; }
        DbSet<TicketComment> TicketComments { get; set; }
        DbSet<TicketCommentHistory> TicketCommentHistories { get; set; }
        DbSet<TicketHistory> TicketHistories { get; set; }

        DbSet<Activity> Activities { get; set; }
        DbSet<Capability> Capabilities { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Cause> Causes { get; set; }
        DbSet<ContactCode> ContactCodes { get; set; }
        DbSet<ContractGlobalStatus> ContractGlobalStatuses { get; set; }
        DbSet<ContractStatus> ContractStatuses { get; set; }
        DbSet<DataStatus> DataStatuses { get; set; }
        DbSet<DollarThreshold> DollarThresholds { get; set; }
        DbSet<License> Licenses { get; set; }
        DbSet<LineOfBusiness> LineOfBusinesses { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Origin> Origins { get; set; }
        DbSet<Priority> Priorities { get; set; }
        DbSet<PricingMethod> PricingMethods { get; set; }
        DbSet<ProductDisposition> ProductDispositions { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<SubCategory> SubCategories { get; set; }
        DbSet<TicketProperty> TicketProperties { get; set; }
        DbSet<VendorCode> VendorCodes { get; set; }

        DbSet<Group> Groups { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserAsset> UserAssets { get; set; }
        DbSet<UserGroup> UserGroups { get; set; }
        DbSet<UserLocation> UserLocations { get; set; }
        DbSet<UserProfile> UserProfiles { get; set; }

        DbSet<Account> Accounts { get; set; }
        DbSet<AccountContact> AccountContacts { get; set; }
        DbSet<AccountContract> AccountContracts { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<ContactAddress> ContactAddresses { get; set; }
        DbSet<Contract> Contracts { get; set; }
        DbSet<ContractAsset> ContractAssets { get; set; }
        DbSet<ContractComment> ContractComments { get; set; }
        DbSet<Vendor> Vendors { get; set; }
        DbSet<VendorAccount> VendorAccounts { get; set; }
        DbSet<VendorAddress> VendorAddresses { get; set; }
        DbSet<VendorContract> VendorContracts { get; set; }
        DbSet<VendorContact> VendorContacts { get; set; }
        Task<int> SaveChangesAsync();
    }
}