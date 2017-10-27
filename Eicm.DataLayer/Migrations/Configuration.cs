using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using Eicm.Core;
using Eicm.Core.Attributes;
using Eicm.Core.Enums;
using Eicm.DataLayer.Entities.TypeCodes;

namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            SeedCategoryCodes(context);
            SeedSubCategoryCodes(context);
            SeedPriorityCodes(context);
            SeedOriginCodes(context);
            SeedCauseCodes(context);
            SeedStatusCodes(context);
            SeedActivityCodes(context);
            SeedTicketPropertyCodes(context);
            //SeedCapabilityCodes(context);
            //SeedContactCodes(context);
            //SeedContractGloabalStatusCodes(context);
            //SeedContractStatusCodes(context);
            //SeedDataStatusCodes(context);
            //SeedDollarThresholdCodes(context);
            //SeedLicenseCodes(context);
            //SeedLineOfBusinessCodes(context);
            //SeedProductDispositionCodes(context);
            //SeedVendorCodes(context);

        }

        private static void SeedActivityCodes(CoreDbContext context)
        {
            var activityTypeCodes = (ActivityType[])Enum.GetValues(typeof(ActivityType));
            context.Activities.AddOrUpdate(
                a => a.Id,
                activityTypeCodes.Select(actCode => new Activity
                {
                    Id = actCode.GetHashCode(),
                    Name = actCode.GetType().GetTypeInfo().GetDeclaredField(actCode.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = actCode.GetType().GetTypeInfo().GetDeclaredField(actCode.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }


        private static void SeedTicketPropertyCodes(CoreDbContext context)
        {
            var propertyTypeCodes = (TicketPropertyType[]) Enum.GetValues(typeof(TicketPropertyType));
            context.TicketProperties.AddOrUpdate(
                tp => tp.Id,
                propertyTypeCodes.Select(tpCode => new TicketProperty
                {
                    Id = tpCode.GetHashCode(),
                    Name = tpCode.GetType().GetTypeInfo().GetDeclaredField(tpCode.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = tpCode.GetType().GetTypeInfo().GetDeclaredField(tpCode.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedCategoryCodes(CoreDbContext context)
        {
            var categoryTypeCodes = (CategoryType[])Enum.GetValues(typeof(CategoryType));
            context.Categories.AddOrUpdate(
                cat => cat.Id,
                categoryTypeCodes.Select(catCode => new Category
                {
                    Id = catCode.GetHashCode(),
                    Name = catCode.GetType().GetTypeInfo().GetDeclaredField(catCode.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = catCode.GetType().GetTypeInfo().GetDeclaredField(catCode.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedSubCategoryCodes(CoreDbContext context)
        {
            var subcategoryTypeCodes = (SubCategoryType[])Enum.GetValues(typeof(SubCategoryType));
            context.SubCategories.AddOrUpdate(
                sc => sc.Id,
                subcategoryTypeCodes.Select(stc => new SubCategory
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value,
                    CategoryId = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ParentIdAttribute>().Value
                }).ToArray());
        }

        private static void SeedPriorityCodes(CoreDbContext context)
        {
            var priorityTypeCodes = (PriorityType[])Enum.GetValues(typeof(PriorityType));
            context.Priorities.AddOrUpdate(
                p => p.Id,
                priorityTypeCodes.Select(ptc => new Priority
                {
                    Id = ptc.GetHashCode(),
                    Name = ptc.GetType().GetTypeInfo().GetDeclaredField(ptc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = ptc.GetType().GetTypeInfo().GetDeclaredField(ptc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedOriginCodes(CoreDbContext context)
        {
            var originTypeCodes = (OriginType[])Enum.GetValues(typeof(OriginType));
            context.Origins.AddOrUpdate(
                o => o.Id,
                originTypeCodes.Select(otc => new Origin
                {
                    Id = otc.GetHashCode(),
                    Name = otc.GetType().GetTypeInfo().GetDeclaredField(otc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = otc.GetType().GetTypeInfo().GetDeclaredField(otc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedCauseCodes(CoreDbContext context)
        {
            var causeTypeCodes = (CauseType[])Enum.GetValues(typeof(CauseType));
            context.Causes.AddOrUpdate(
                c => c.Id,
                causeTypeCodes.Select(ctc => new Cause
                {
                    Id = ctc.GetHashCode(),
                    Name = ctc.GetType().GetTypeInfo().GetDeclaredField(ctc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = ctc.GetType().GetTypeInfo().GetDeclaredField(ctc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedStatusCodes(CoreDbContext context)
        {
            var statusTypeCodes = (StatusType[])Enum.GetValues(typeof(StatusType));
            context.Statuses.AddOrUpdate(
                s => s.Id,
                statusTypeCodes.Select(stc => new Status
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedCapabilityCodes(CoreDbContext context)
        {
            var capabilityTypeCodes = (CapabilityType[])Enum.GetValues(typeof(CapabilityType));
            context.Capabilities.AddOrUpdate(
                s => s.Id,
                capabilityTypeCodes.Select(stc => new Capability
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedContactCodes(CoreDbContext context)
        {
            var contactTypeCodes = (ContactType[])Enum.GetValues(typeof(ContactType));
            context.ContactCodes.AddOrUpdate(
                s => s.Id,
                contactTypeCodes.Select(stc => new ContactCode
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedContractGloabalStatusCodes(CoreDbContext context)
        {
            var contractGlobalStatusTypeCodes = (ContractGlobalStatusType[])Enum.GetValues(typeof(ContractGlobalStatusType));
            context.ContractGlobalStatuses.AddOrUpdate(
                s => s.Id,
                contractGlobalStatusTypeCodes.Select(stc => new ContractGlobalStatus
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedContractStatusCodes(CoreDbContext context)
        {
            var contractStatusTypeCodes = (ContractStatusType[])Enum.GetValues(typeof(ContractStatusType));
            context.ContractStatuses.AddOrUpdate(
                s => s.Id,
                contractStatusTypeCodes.Select(stc => new ContractStatus
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedDataStatusCodes(CoreDbContext context)
        {
            var dataStatusTypeCodes = (DataStatusType[])Enum.GetValues(typeof(DataStatusType));
            context.DataStatuses.AddOrUpdate(
                s => s.Id,
                dataStatusTypeCodes.Select(stc => new DataStatus
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedDollarThresholdCodes(CoreDbContext context)
        {
            var dollarThresholdTypeCodes = (DollarThresholdType[])Enum.GetValues(typeof(DollarThresholdType));
            context.DollarThresholds.AddOrUpdate(
                s => s.Id,
                dollarThresholdTypeCodes.Select(stc => new DollarThreshold
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedLicenseCodes(CoreDbContext context)
        {
            var licenseTypeCodes = (LicenseType[])Enum.GetValues(typeof(LicenseType));
            context.Licenses.AddOrUpdate(
                s => s.Id,
                licenseTypeCodes.Select(stc => new License
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedLineOfBusinessCodes(CoreDbContext context)
        {
            var lineOfBusinessTypeCodes = (LineOfBusinessType[])Enum.GetValues(typeof(LineOfBusinessType));
            context.LineOfBusinesses.AddOrUpdate(
                s => s.Id,
                lineOfBusinessTypeCodes.Select(stc => new LineOfBusiness
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedProductDispositionCodes(CoreDbContext context)
        {
            var productDispositionTypeCodes = (ProductDispositionType[])Enum.GetValues(typeof(ProductDispositionType));
            context.ProductDispositions.AddOrUpdate(
                s => s.Id,
                productDispositionTypeCodes.Select(stc => new ProductDisposition
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedVendorCodes(CoreDbContext context)
        {
            var vendorTypeCodes = (VendorType[])Enum.GetValues(typeof(VendorType));
            context.VendorCodes.AddOrUpdate(
                s => s.Id,
                vendorTypeCodes.Select(stc => new VendorCode()
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }

        private static void SeedLocationCodes(CoreDbContext context)
        {
            var locationTypeCodes = (LocationType[])Enum.GetValues(typeof(LocationType));
            context.Locations.AddOrUpdate(
                s => s.Id,
                locationTypeCodes.Select(stc => new Location()
                {
                    Id = stc.GetHashCode(),
                    Name = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Active = stc.GetType().GetTypeInfo().GetDeclaredField(stc.ToString()).GetCustomAttribute<ActiveAttribute>().Value
                }).ToArray());
        }
    }
}
