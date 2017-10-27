using System.Data.Entity;
using Eicm.DataLayer.Entities.Assets;
using Eicm.DataLayer.Entities.Core;
using Eicm.DataLayer.Entities.Tickets;
using Eicm.DataLayer.Entities.TypeCodes;
using Eicm.DataLayer.Entities.Users;
using Eicm.DataLayer.Entities.Vendors;

namespace Eicm.DataLayer
{
    public class CoreDbContext : DbContext, ICoreDbContext
    {
        public CoreDbContext(): base("name=CoreDbContext")
        {
        }

        
        public virtual DbSet<Asset> Assets { get; set; }       
        public virtual DbSet<AssetType> AssetTypes { get; set; }

        public virtual DbSet<TicketActivity> TicketActivities { get; set; }       
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketHistory> TicketHistories { get; set; }
        public virtual DbSet<TicketComment> TicketComments { get; set; }
        public virtual DbSet<TicketCommentHistory> TicketCommentHistories { get; set; }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Capability> Capabilities { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cause> Causes { get; set; }
        public virtual DbSet<ContactCode> ContactCodes { get; set; }
        public virtual DbSet<ContractGlobalStatus> ContractGlobalStatuses { get; set; }
        public virtual DbSet<ContractStatus> ContractStatuses { get; set; }
        public virtual DbSet<DataStatus> DataStatuses { get; set; }
        public virtual DbSet<DollarThreshold> DollarThresholds { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<LineOfBusiness> LineOfBusinesses { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<PricingMethod> PricingMethods { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<ProductDisposition> ProductDispositions { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }      
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<TicketProperty> TicketProperties { get; set; }
        public virtual DbSet<VendorCode> VendorCodes { get; set; }        

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAsset> UserAssets { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserLocation> UserLocations { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountContact> AccountContacts { get; set; }
        public virtual DbSet<AccountContract> AccountContracts { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactAddress> ContactAddresses { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractAsset> ContractAssets { get; set; }
        public virtual DbSet<ContractComment> ContractComments { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorAccount> VendorAccounts { get; set; }
        public virtual DbSet<VendorAddress> VendorAddresses { get; set; }
        public virtual DbSet<VendorContract> VendorContracts { get; set; }
        public virtual DbSet<VendorContact> VendorContacts { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}