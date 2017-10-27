namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkassetstocontracts : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Vendors.ContractAssets", "ContractId");
            AddForeignKey("Vendors.ContractAssets", "ContractId", "Vendors.Contracts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Vendors.ContractAssets", "ContractId", "Vendors.Contracts");
            DropIndex("Vendors.ContractAssets", new[] { "ContractId" });
        }
    }
}
