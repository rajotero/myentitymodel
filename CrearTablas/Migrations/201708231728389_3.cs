namespace CrearTablas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EbayOrdersLineas", "EbayFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EbayOrdersLineas", "SellingManagerSalesRecordNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EbayOrdersLineas", "SellingManagerSalesRecordNumber");
            DropColumn("dbo.EbayOrdersLineas", "EbayFee");
        }
    }
}
