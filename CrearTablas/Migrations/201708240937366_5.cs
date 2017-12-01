namespace CrearTablas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExternalTransactions",
                c => new
                    {
                        ExternalTransactionID = c.String(nullable: false, maxLength: 128),
                        ExternalTransactionTime = c.DateTime(nullable: false),
                        ExternalTransactionTimeSpecified = c.Boolean(nullable: false),
                        FeeOrCreditAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentOrRefundAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExternalTransactionStatus = c.String(),
                    })
                .PrimaryKey(t => t.ExternalTransactionID);
            
            AddColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionID", c => c.String(maxLength: 128));
            CreateIndex("dbo.EbayOrders", "externalTransaction_ExternalTransactionID");
            AddForeignKey("dbo.EbayOrders", "externalTransaction_ExternalTransactionID", "dbo.ExternalTransactions", "ExternalTransactionID");
            DropColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionID");
            DropColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionTime");
            DropColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionTimeSpecified");
            DropColumn("dbo.EbayOrders", "externalTransactionType_FeeOrCreditAmount");
            DropColumn("dbo.EbayOrders", "externalTransactionType_PaymentOrRefundAmount");
            DropColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionStatus", c => c.String());
            AddColumn("dbo.EbayOrders", "externalTransactionType_PaymentOrRefundAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EbayOrders", "externalTransactionType_FeeOrCreditAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionTimeSpecified", c => c.Boolean(nullable: false));
            AddColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.EbayOrders", "externalTransactionType_ExternalTransactionID", c => c.String());
            DropForeignKey("dbo.EbayOrders", "externalTransaction_ExternalTransactionID", "dbo.ExternalTransactions");
            DropIndex("dbo.EbayOrders", new[] { "externalTransaction_ExternalTransactionID" });
            DropColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionID");
            DropTable("dbo.ExternalTransactions");
        }
    }
}
