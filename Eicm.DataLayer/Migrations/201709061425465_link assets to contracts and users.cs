namespace Eicm.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkassetstocontractsandusers : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("Assets.Assets", "ContractAsset_Id", "Vendors.ContractAssets");
            DropIndex("Assets.Assets", new[] { "ContractAsset_Id" });
            AddColumn("Users.UserAssets", "User_Id", c => c.Int());
            CreateIndex("Vendors.ContactAddresses", "ContactId");
            CreateIndex("Vendors.ContactAddresses", "AddressId");
            CreateIndex("Vendors.ContractAssets", "AssetId");
            CreateIndex("Users.UserAssets", "AssetId");
            CreateIndex("Users.UserAssets", "User_Id");
            AddForeignKey("Vendors.ContactAddresses", "AddressId", "Core.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("Vendors.ContactAddresses", "ContactId", "Vendors.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("Vendors.ContractAssets", "AssetId", "Assets.Assets", "Id", cascadeDelete: true);
            AddForeignKey("Users.UserAssets", "AssetId", "Assets.Assets", "Id", cascadeDelete: true);
            AddForeignKey("Users.UserAssets", "User_Id", "Users.Users", "Id");
           // DropColumn("Assets.Assets", "ContractAsset_Id");
        }
        
        public override void Down()
        {
            //AddColumn("Assets.Assets", "ContractAsset_Id", c => c.Int());
            DropForeignKey("Users.UserAssets", "User_Id", "Users.Users");
            DropForeignKey("Users.UserAssets", "AssetId", "Assets.Assets");
            DropForeignKey("Vendors.ContractAssets", "AssetId", "Assets.Assets");
            DropForeignKey("Vendors.ContactAddresses", "ContactId", "Vendors.Contacts");
            DropForeignKey("Vendors.ContactAddresses", "AddressId", "Core.Addresses");
            DropIndex("Users.UserAssets", new[] { "User_Id" });
            DropIndex("Users.UserAssets", new[] { "AssetId" });
            DropIndex("Vendors.ContractAssets", new[] { "AssetId" });
            DropIndex("Vendors.ContactAddresses", new[] { "AddressId" });
            DropIndex("Vendors.ContactAddresses", new[] { "ContactId" });
            DropColumn("Users.UserAssets", "User_Id");
            CreateIndex("Assets.Assets", "ContractAsset_Id");
            //AddForeignKey("Assets.Assets", "ContractAsset_Id", "Vendors.ContractAssets", "Id");
        }
    }
}
