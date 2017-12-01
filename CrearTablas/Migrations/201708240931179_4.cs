namespace CrearTablas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionID", c => c.String());
            AddColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionTimeSpecified", c => c.Boolean(nullable: false));
            AddColumn("dbo.EbayOrders", "externalTransactionType_FeeOrCreditAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EbayOrders", "externalTransactionType_PaymentOrRefundAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionStatus");
            DropColumn("dbo.EbayOrders", "externalTransactionType_PaymentOrRefundAmount");
            DropColumn("dbo.EbayOrders", "externalTransactionType_FeeOrCreditAmount");
            DropColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionTimeSpecified");
            DropColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionTime");
            DropColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionID");
        }
    }
}
