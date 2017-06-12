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
    }
}
