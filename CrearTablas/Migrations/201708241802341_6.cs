namespace CrearTablas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EbayOrders", "externalTransaction_ExternalTransactionID", "dbo.ExternalTransactions");
            DropIndex("dbo.EbayOrders", new[] { "externalTransaction_ExternalTransactionID" });
            AddColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionTimeSpecified", c => c.Boolean(nullable: false));
            AddColumn("dbo.EbayOrders", "externalTransaction_FeeOrCreditAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EbayOrders", "externalTransaction_PaymentOrRefundAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionStatus", c => c.String());
            DropColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionID");
            DropTable("dbo.ExternalTransactions");
        }
        
        public override void Down()
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
            DropColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionStatus");
            DropColumn("dbo.EbayOrders", "externalTransaction_PaymentOrRefundAmount");
            DropColumn("dbo.EbayOrders", "externalTransaction_FeeOrCreditAmount");
            DropColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionTimeSpecified");
            DropColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionTime");
            CreateIndex("dbo.EbayOrders", "externalTransaction_ExternalTransactionID");
            AddForeignKey("dbo.EbayOrders", "externalTransaction_ExternalTransactionID", "dbo.ExternalTransactions", "ExternalTransactionID");
        }
    }
}
