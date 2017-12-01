namespace CrearTablas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionTime", c => c.DateTime());
            AlterColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionTimeSpecified", c => c.Boolean());
            AlterColumn("dbo.EbayOrders", "externalTransaction_FeeOrCreditAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.EbayOrders", "externalTransaction_PaymentOrRefundAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EbayOrders", "externalTransaction_PaymentOrRefundAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.EbayOrders", "externalTransaction_FeeOrCreditAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionTimeSpecified", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EbayOrders", "externalTransaction_ExternalTransactionTime", c => c.DateTime(nullable: false));
        }
    }
}
