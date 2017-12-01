namespace CrearTablas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EbayOrdersLineas", "EbayOrder_EbayOrdersID", "dbo.EbayOrders");
            DropIndex("dbo.EbayOrdersLineas", new[] { "EbayOrder_EbayOrdersID" });
            AddColumn("dbo.EbayOrdersLineas", "Titulo", c => c.String());
            AddColumn("dbo.EbayOrdersLineas", "PaymentHoldStatus", c => c.String());
            DropColumn("dbo.EbayOrdersLineas", "buyer_Email");
            DropColumn("dbo.EbayOrdersLineas", "buyer_UserFirstName");
            DropColumn("dbo.EbayOrdersLineas", "buyer_UserLastName");
            DropColumn("dbo.EbayOrdersLineas", "EbayOrder_EbayOrdersID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EbayOrdersLineas", "EbayOrder_EbayOrdersID", c => c.Int());
            AddColumn("dbo.EbayOrdersLineas", "buyer_UserLastName", c => c.String());
            AddColumn("dbo.EbayOrdersLineas", "buyer_UserFirstName", c => c.String());
            AddColumn("dbo.EbayOrdersLineas", "buyer_Email", c => c.String());
            DropColumn("dbo.EbayOrdersLineas", "PaymentHoldStatus");
            DropColumn("dbo.EbayOrdersLineas", "Titulo");
            CreateIndex("dbo.EbayOrdersLineas", "EbayOrder_EbayOrdersID");
            AddForeignKey("dbo.EbayOrdersLineas", "EbayOrder_EbayOrdersID", "dbo.EbayOrders", "EbayOrdersID");
        }
    }
}
