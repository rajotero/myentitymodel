namespace CrearTablas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EbayOrders",
                c => new
                    {
                        EbayOrdersID = c.Int(nullable: false, identity: true),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountSaved = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyerCheckoutMessage = c.String(),
                        BuyerUserID = c.String(),
                        CancelStatus = c.String(),
                        checkoutStatus_LastModifiedTime = c.DateTime(),
                        checkoutStatus_PaymentMethod = c.String(),
                        checkoutStatus_Status = c.String(),
                        CreatedTime = c.DateTime(),
                        OrderID = c.String(maxLength: 50, unicode: false),
                        OrderStatus = c.String(),
                        PaidTime = c.DateTime(),
                        PaymentHoldStatus = c.String(),
                        SellerUserID = c.String(),
                        ShippedTime = c.DateTime(),
                        shippingAddress_AddressID = c.String(),
                        shippingAddress_CityName = c.String(),
                        shippingAddress_CompanyName = c.String(),
                        shippingAddress_Country = c.String(),
                        shippingAddress_CountryName = c.String(),
                        shippingAddress_FirstName = c.String(),
                        shippingAddress_LastName = c.String(),
                        shippingAddress_Name = c.String(),
                        shippingAddress_Phone = c.String(),
                        shippingAddress_Phone2 = c.String(),
                        shippingAddress_PostalCode = c.String(),
                        shippingAddress_StateOrProvince = c.String(),
                        shippingAddress_Street = c.String(),
                        shippingAddress_Street1 = c.String(),
                        shippingAddress_Street2 = c.String(),
                        shippingDetails_SellingManagerSalesRecordNumber = c.Int(),
                        shippingServiceSelected_ExpeditedService = c.Boolean(nullable: false),
                        shippingServiceSelected_FreeShipping = c.Boolean(nullable: false),
                        shippingServiceSelected_ShippingService = c.String(),
                        shippingServiceSelected_ShippingServiceAdditionalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        shippingServiceSelected_ShippingServiceCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Subtotal = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EbayOrdersID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.EbayOrdersLineas",
                c => new
                    {
                        EbayOrdersLineasID = c.Int(nullable: false, identity: true),
                        buyer_Email = c.String(),
                        buyer_UserFirstName = c.String(),
                        buyer_UserLastName = c.String(),
                        BuyerCheckoutMessage = c.String(),
                        BuyerMessage = c.String(),
                        CreatedDate = c.DateTime(),
                        ExtendedOrderID = c.String(),
                        QuantityPurchased = c.Int(nullable: false),
                        ItemID = c.String(),
                        TransactionPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EbayOrder_EbayOrdersID = c.Int(),
                    })
                .PrimaryKey(t => t.EbayOrdersLineasID)
                .ForeignKey("dbo.EbayOrders", t => t.EbayOrder_EbayOrdersID)
                .Index(t => t.EbayOrder_EbayOrdersID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EbayOrdersLineas", "EbayOrder_EbayOrdersID", "dbo.EbayOrders");
            DropIndex("dbo.EbayOrdersLineas", new[] { "EbayOrder_EbayOrdersID" });
            DropIndex("dbo.EbayOrders", new[] { "OrderID" });
            DropTable("dbo.EbayOrdersLineas");
            DropTable("dbo.EbayOrders");
        }
    }
}
