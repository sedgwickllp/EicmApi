namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removejointocontractcommentstable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Vendors.ContractComments", "ContractId", "Vendors.Contracts");
            DropIndex("Vendors.ContractComments", new[] { "ContractId" });
        }
        
        public override void Down()
        {
            CreateIndex("Vendors.ContractComments", "ContractId");
            AddForeignKey("Vendors.ContractComments", "ContractId", "Vendors.Contracts", "Id", cascadeDelete: true);
        }
    }
}
