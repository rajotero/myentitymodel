using DevExpress.XtraBars;
using MarketplaceWebServiceOrders;
using MarketplaceWebServiceOrders.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEntityModel
{
    public class AmazonOrder
    {
        [Key]
        public string AmazonOrderID { get; set; }
        public string SellerOrderID { get; set; }
        public DateTime? purchaseDate { get; set; }
        public DateTime? lastUpdateDate { get; set; }
        public string orderStatus { get; set; }
        public string fulfillmentChannel { get; set; }
        public string salesChannel { get; set; }
        public string orderChannel { get; set; }
        public string shipServiceLevel { get; set; }
        public string ShippingAddressName { get; set; }
        public string ShippingAddressAddressLine1 { get; set; }
        public string ShippingAddressAddressLine2 { get; set; }
        public string ShippingAddressAddressLine3 { get; set; }
        public string ShippingAddressCity { get; set; }
        public string ShippingAddressDistrict { get; set; }
        public string ShippingAddressStateOrRegion { get; set; }
        public string ShippingAddressPostalCode { get; set; }
        public string ShippingAddressCountryCode { get; set; }
        public string ShippingAddressPhone { get; set; }
        public string OrderTotalCurrencyCode { get; set; }
        [Column(TypeName = "Money")]
        public decimal OrderTotalAmount { get; set; }
        public decimal NumberOfItemsShipped { get; set; }
        public decimal NumberOfItemsUnshipped { get; set; }
        public DateTime? LatestShipDate { get; set; }
        public string OrderType { get; set; }
        public string BuyerEmail { get; set; }
        public bool ShippedByAmazonTFM { get; set; }
        public DateTime? LatestDeliveryDate { get; set; }
        public string BuyerName { get; set; }
        public DateTime? EarliestDeliveryDate { get; set; }
        public bool IsPremiumOrder { get; set; }
        public DateTime? EarliestShipDate { get; set; }
        public string MarketplaceId { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsPrime { get; set; }
        public string ShipmentServiceLevelCategory { get; set; }
        public string Cuenta { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Creacion")]
        public DateTime? FechaCreacion { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Actualización")]
        public DateTime? FechaModificacion { get; set; }
        public virtual ICollection<AmazonOrderLinea> AmazonOrderLineas { get; set; }

    }

    public class AmazonOrderLinea
    {
        [Key]
        public string AmazonOrderLineaID { get; set; }
        public string AmazonOrderID { get; set; }
        public string Cuenta { get; set; }
        public string Asin { get; set; }
        public string SellerSKU { get; set; }
        public string OrderItemId { get; set; }
        public string Title { get; set; }
        public decimal? QuantityOrdered { get; set; }
        public decimal? QuantityShipped { get; set; }
        public string ItemPriceCurrencyCode { get; set; }
        [Column(TypeName = "Money")]
        public decimal ItemPriceAmount { get; set; }
        public string ShippingPriceCurrencyCode { get; set; }
        [Column(TypeName = "Money")]
        public decimal ShippingPriceAmount { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Creacion")]
        public DateTime? FechaCreacion { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Actualización")]
        public DateTime? FechaModificacion { get; set; }
        public bool? StockAmazonProcesado { get; set; }
    }

    [Table("AmazonFeed")]
    public class AmazonFeed
    {
        [Key]
        public int AmazonFeedID { get; set; }
        public string FeedSubmissionId { get; set; }
        public string FeedType { get; set; }
        public string SubmittedDate { get; set; }
        public string FeedProcessingStatus { get; set; }
        public DateTime? StartedProcessingDate { get; set; }
        public DateTime? CompletedProcessingDate { get; set; }
        public string RequestId { get; set; }
        public string ResponseContext { get; set; }
        public string Timestamp { get; set; }
        public string exMessage { get; set; }
        public int? exStatusCode { get; set; }
        public string exErrorCode { get; set; }
        public string exErrorType { get; set; }
        public string exRequestId { get; set; }
        public string exXML { get; set; }
        public string feed { get; set; }
        public string Cuenta { get; set; }
    }
    [Table("AmazonSeguimiento")]
    public class AmazonSeguimiento
    {
        [Key]
        public int AmazonSeguimientoID { get; set; }
        [Index("ArticuloID")]
        public int? ArticuloID { get; set; }
        public string codigo { get; set; }
        public string Cuenta { get; set; }
        public string item_name { get; set; }
        public string item_description { get; set; }
        public string item_description_org { get; set; }
        public string listing_id { get; set; }
        [Index("seller_sku")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string seller_sku { get; set; }
        public decimal? price { get; set; }
        public int? quantity { get; set; }
        public string open_date { get; set; }
        public string image_url { get; set; }
        public string item_is_marketplace { get; set; }
        public string product_id_type { get; set; }
        public string zshop_shipping_fee { get; set; }
        public string item_note { get; set; }
        public string item_condition { get; set; }
        public string zshop_category1 { get; set; }
        public string zshop_browse_path { get; set; }
        public string zshop_storefront_feature { get; set; }
        public string asin1 { get; set; }
        public string asin2 { get; set; }
        public string asin3 { get; set; }
        public string will_ship_internationally { get; set; }
        public string expedited_shipping { get; set; }
        public string zshop_boldface { get; set; }
        public string product_id { get; set; }
        public string bid_for_featured_placement { get; set; }
        public string add_delete { get; set; }
        public string pending_quantity { get; set; }
        public string fulfillment_channel { get; set; }
        public string vendedor { get; set; }
        public string merchant_shipping_group { get; set; }
        public decimal? comision { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        public string restocking { get; set; }
        public int? unidades_disponibles { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha_Descripcion { get; set; }
        public string Finalizado { get; set; }
        public DateTime? Fecha_Fologar { get; set; }

    }

    public class EventosAmazon
    {
        public int pagina;
        public int linea;
        public int retardo;
        public string error;
    }


    public class Amazon
    {
        public string AWS_ACCESS_KEY_ID;
        public string AWS_SECRET_ACCESS_KEY;	 
        public string MERCHANT_ID;
        public string MARKETPLACE_ID;
        public string ServiceUrl ;

        public delegate void EventAntesPagina(EventosAmazon e);
        public event EventAntesPagina eventAntesPagina;
        public delegate void EventDespuesPagina(EventosAmazon e);
        public event EventAntesPagina eventDespuesPagina;

        public delegate void EventAntesRetardoTroleo(EventosAmazon e);
        public event EventAntesRetardoTroleo eventAntesRetardoTroleo;

        public delegate void EventDespuesRetardoTroleo(EventosAmazon e);
        public event EventDespuesRetardoTroleo eventDespuesRetardoTroleo;

        public delegate void EventAntesLinea(EventosAmazon e);
        public event EventAntesPagina eventAntesLinea;
        public delegate void EventDespuesLinea(EventosAmazon e);
        public event EventAntesPagina eventDespuesLinea;

        public delegate void EventAntesRetardoTroleoLinea(EventosAmazon e);
        public event EventAntesRetardoTroleoLinea eventAntesRetardoTroleoLinea;

        public delegate void EventDespuesRetardoTroleoLinea(EventosAmazon e);
        public event EventDespuesRetardoTroleoLinea eventDespuesRetardoTroleoLinea;


        public delegate void EventError(EventosAmazon e);
        public event EventError eventError;
        public string Cuenta
        {
            get
            {
                return this.Cuenta;
            }
            set
            {
                if (value == "Red_Planet")
                {
                    AWS_ACCESS_KEY_ID = "AKIAIH62F6QK2DZYQHKA";
                    AWS_SECRET_ACCESS_KEY = "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";	 
                    MERCHANT_ID = "A1A94E00UJ9A5S";
                    MARKETPLACE_ID = "A1RKKUPIHCS9HS";
                    ServiceUrl =  "https://mws.amazonservices.es/Orders/2013-09-01";
                }
            }
        }


        public void LeerLineasPedido(Order order,int pagina,int numero)
        {
            ListOrderItemsRequest request = new ListOrderItemsRequest();
            request.SellerId = MERCHANT_ID;
            request.AmazonOrderId = order.AmazonOrderId;
            MarketplaceWebServiceOrdersConfig config = new MarketplaceWebServiceOrdersConfig
            {
                ServiceURL = "https://mws.amazonservices.es/Orders/2013-09-01"
            };
            MarketplaceWebServiceOrdersClient client = new MarketplaceWebServiceOrdersClient(AWS_ACCESS_KEY_ID, AWS_SECRET_ACCESS_KEY, "AppName", "0.0", config);
            bool retryRequest = true;
            while (retryRequest == true)
            {
                retryRequest = false;
                try
                {
 //                   Debug.WriteLine(string.Format("{0} Leyendo Linea {1} de la pagina {2} ", DateTime.Now.ToString("f"),numero,pagina));
                    eventAntesLinea?.Invoke(new EventosAmazon { pagina = pagina, linea = numero, retardo = 0 });
                    var a = client.ListOrderItems(request);
                    System.Threading.Thread.Sleep(2000);
                    //                   Debug.WriteLine(string.Format("{0} Linea Leida {1} de la pagina {2} ", DateTime.Now.ToString("f"), numero, pagina));
                    GrabarOrderItems(a.ListOrderItemsResult.OrderItems,order);
 //                   eventDespuesLinea?.Invoke(new EventosAmazon { pagina = pagina, linea = numero, retardo = 0 });
                }
                catch (MarketplaceWebServiceOrdersException ex)
                {
                    if (ex.ErrorCode.Contains("RequestThrottled"))
                    {
                        int retardo = 60000;
                        retryRequest = true;
  //                      Debug.WriteLine(string.Format("{0} Inicio Troleado {1} de la pagina {2} ", DateTime.Now.ToString("f"), numero, pagina));
                        eventAntesRetardoTroleoLinea?.Invoke(new EventosAmazon { pagina = pagina, linea = numero, retardo = retardo });
                        System.Threading.Thread.Sleep(retardo);
                        eventDespuesRetardoTroleoLinea?.Invoke(new EventosAmazon { pagina = pagina, linea = numero, retardo = retardo });
 //                       Debug.WriteLine(string.Format("{0} Fin Troleado {1} de la pagina {2} ", DateTime.Now.ToString("f"), numero, pagina));
                    }
                    else
                    {
                        eventError?.Invoke(new EventosAmazon { pagina = pagina, linea = numero, retardo = 0, error = ex.Detail });
                    }
                }
            }

        }
        
        public void LeerPedidos(DateTime FechInicial,string cuenta,string OrderStatus)
        {
            int pagina = 1;
            this.Cuenta=cuenta;
            ListOrdersRequest request = new ListOrdersRequest();

            request.SellerId = MERCHANT_ID;

            string format = "MMM d, yyyy h:mm:ss tt PDT";
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime now = DateTime.Now.Add(new TimeSpan(0, -10, 0));
            DateTime createdAfter = DateTime.ParseExact("Aug 10, 2017 2:42:18 PM PDT", format, provider);
            request.CreatedAfter = createdAfter;
            request.CreatedBefore = now;


            List<string> orderStatus = new List<string>();
            orderStatus.Add(OrderStatus);
            request.OrderStatus = orderStatus;


            List<string> marketplaceId = new List<string>();
            marketplaceId.Add(MARKETPLACE_ID);
            request.MarketplaceId = marketplaceId;

            //List<string> fulfillmentChannel = new List<string>();
            //request.FulfillmentChannel = fulfillmentChannel;
            //List<string> paymentMethod = new List<string>();
            //request.PaymentMethod = paymentMethod;
            //string buyerEmail = "example";
            //request.BuyerEmail = buyerEmail;
            //string sellerOrderId = "example";
            //request.SellerOrderId = sellerOrderId;
            //decimal maxResultsPerPage = 1;
            //request.MaxResultsPerPage = maxResultsPerPage;
            //List<string> tfmShipmentStatus = new List<string>();
            //request.TFMShipmentStatus = tfmShipmentStatus;
            MarketplaceWebServiceOrdersConfig config = new MarketplaceWebServiceOrdersConfig
            {
                ServiceURL = "https://mws.amazonservices.es/Orders/2013-09-01"
            };
            MarketplaceWebServiceOrdersClient client = new MarketplaceWebServiceOrdersClient(AWS_ACCESS_KEY_ID, AWS_SECRET_ACCESS_KEY, "AppName", "0.0", config);
            ListOrdersResponse a = new ListOrdersResponse();
            bool retryRequest = true;
            while (retryRequest == true)
            {
                retryRequest = false;
                try
                {
                    eventAntesPagina(new EventosAmazon { pagina = pagina, linea = 0, retardo = 0 });
                    a = client.ListOrders(request);
                    eventDespuesPagina(new EventosAmazon { pagina = pagina, linea = 0, retardo = 0 });
                }
                catch (MarketplaceWebServiceOrdersException ex)
                {
                    if (ex.ErrorCode.Contains("RequestThrottled"))
                    {
                        int retardo = 60000;
                        retryRequest = true;
                        eventAntesRetardoTroleo(new EventosAmazon { pagina = pagina, linea = 0, retardo = retardo });
                        System.Threading.Thread.Sleep(retardo);
                        eventDespuesRetardoTroleo?.Invoke(new EventosAmazon { pagina = pagina, linea = 0, retardo = retardo });
                    }
                    else
                    {
                        eventError?.Invoke(new EventosAmazon { pagina = pagina, linea = 0, retardo = 0,error = ex.Detail });
                    }
                }
            }


            //            foreach (Order order in a.ListOrdersResult.Orders)
            //                GrabarOrder(order, cuenta);
            Task t = new Task(
                           () =>
                           {
                               Parallel.ForEach(a.ListOrdersResult.Orders, new ParallelOptions { MaxDegreeOfParallelism = 2 },
                               order =>
                                {
                                    int numero = a.ListOrdersResult.Orders.IndexOf(order);
                                    LeerLineasPedido(order, pagina, numero);
                                    GrabarOrder(order, cuenta);
                                });
                           });
            t.Start();
            while (!t.IsCompleted)
                Application.DoEvents();
            string NextToken = a.ListOrdersResult.NextToken;
//            return;
            while (!string.IsNullOrEmpty(NextToken))
            {
                pagina++;
                ListOrdersByNextTokenRequest nextRequest = new ListOrdersByNextTokenRequest();
                nextRequest.NextToken = NextToken;
                nextRequest.SellerId = request.SellerId;
                retryRequest = true;
                ListOrdersByNextTokenResponse b = new ListOrdersByNextTokenResponse();
                while (retryRequest == true)
                {
                    retryRequest = false;
                    try
                    {
                        eventAntesPagina(new EventosAmazon { pagina = pagina, linea = 0, retardo = 0 });
                        b = client.ListOrdersByNextToken(nextRequest);
                        eventDespuesPagina(new EventosAmazon { pagina = pagina, linea = 0, retardo = 0 });
                        Task tn = new Task(
                        () =>
                        {
                            Parallel.ForEach(b.ListOrdersByNextTokenResult.Orders, new ParallelOptions { MaxDegreeOfParallelism = 2 }, order =>
                            {
                                int numero = b.ListOrdersByNextTokenResult.Orders.IndexOf(order);
                                LeerLineasPedido(order, pagina, numero);
                                GrabarOrder(order, cuenta);
                            });
                        });
                        tn.Start();
                        while (!tn.IsCompleted)
                            Application.DoEvents();
                    }
                    catch (MarketplaceWebServiceOrdersException ex)
                    {
                        //The ListOrders and ListOrdersByNextToken operations together share a maximum request quota of six and a restore rate of one request every minute.
                        //                  Request quota
                        //                          The number of requests that you can submit at one time without throttling.The request quota decreases with every request you submit.The request quota increases at the restore rate.
                        //                  Restore rate
                        //                          The rate at which your request quota increases over time, up to the maximum request quota.
                        //                  Maximum request quota
                        //                          The maximum size that the request quota can reach.
                        if (ex.ErrorCode.Contains("RequestThrottled"))
                        {
                            int retardo = 60000;
                            retryRequest = true;
                            eventAntesRetardoTroleo(new EventosAmazon { pagina = pagina, linea = 0, retardo = retardo });
                            System.Threading.Thread.Sleep(retardo);
                            eventDespuesRetardoTroleo?.Invoke(new EventosAmazon { pagina = pagina, linea = 0, retardo = retardo });
                        }
                    }
                    if (b.IsSetListOrdersByNextTokenResult())
                        NextToken = b.ListOrdersByNextTokenResult.NextToken;
                    else
                        break;
                }
            }
        }

        private void GrabarOrder(Order order,string cuenta)
        {
            bool nuevo = false;
 //           return;
            ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
            var transaction = dbContext.Database.BeginTransaction(IsolationLevel.RepeatableRead);
            AmazonOrder amazonOrder =  dbContext.amazonorders.Where(w => w.AmazonOrderID == order.AmazonOrderId).FirstOrDefault();

            if (amazonOrder == null)
            {
                amazonOrder = new AmazonOrder();
                nuevo = true;
            }
            amazonOrder.AmazonOrderID = order.AmazonOrderId;
            if (order.IsSetBuyerEmail())
                amazonOrder.BuyerEmail = order.BuyerEmail;
            if (order.IsSetBuyerName())
                amazonOrder.BuyerName = order.BuyerName;
            amazonOrder.Cuenta = cuenta;
            if (order.IsSetEarliestDeliveryDate())
                amazonOrder.EarliestDeliveryDate = order.EarliestDeliveryDate;
            if (order.IsSetEarliestShipDate())
                amazonOrder.EarliestShipDate = order.EarliestShipDate;
            if (order.IsSetFulfillmentChannel())
                amazonOrder.fulfillmentChannel = order.FulfillmentChannel;
            if (order.IsSetIsPremiumOrder())
                amazonOrder.IsPremiumOrder = order.IsPremiumOrder;
            if (order.IsSetIsPrime())
                amazonOrder.IsPrime = order.IsPrime;
            if (order.IsSetLastUpdateDate())
                amazonOrder.lastUpdateDate = order.LastUpdateDate;
            if (order.IsSetLatestDeliveryDate())
                amazonOrder.LatestDeliveryDate = order.LatestDeliveryDate;
            if (order.IsSetLatestShipDate())
                amazonOrder.LatestShipDate = order.LatestShipDate;
            if (order.IsSetMarketplaceId())
                amazonOrder.MarketplaceId = order.MarketplaceId;
            if (order.IsSetNumberOfItemsShipped())
                amazonOrder.NumberOfItemsShipped = order.NumberOfItemsShipped;
            if (order.IsSetNumberOfItemsUnshipped())
                amazonOrder.NumberOfItemsUnshipped = order.NumberOfItemsUnshipped;
            if (order.IsSetOrderChannel())
                amazonOrder.orderChannel = order.OrderChannel;
            if (order.IsSetOrderTotal())
            {
                amazonOrder.OrderTotalAmount = FuncionesEbay.fnSpreciodprecio(order.OrderTotal.Amount);
                amazonOrder.OrderTotalCurrencyCode = order.OrderTotal.CurrencyCode;
            }
            if (order.IsSetOrderType())
                amazonOrder.OrderType = order.OrderType;
            if (order.IsSetPaymentMethod())
                amazonOrder.PaymentMethod = order.PaymentMethod;
            if (order.IsSetPurchaseDate())
                amazonOrder.purchaseDate = order.PurchaseDate;
            if (order.IsSetOrderChannel())
                amazonOrder.salesChannel = order.SalesChannel;
            if (order.IsSetSellerOrderId())
              amazonOrder.SellerOrderID = order.SellerOrderId;
            if (order.IsSetShipmentServiceLevelCategory())
                amazonOrder.ShipmentServiceLevelCategory = order.ShipmentServiceLevelCategory;
            if (order.IsSetShippedByAmazonTFM())
                amazonOrder.ShippedByAmazonTFM = order.ShippedByAmazonTFM;
            if (order.IsSetShippingAddress())
            {
                amazonOrder.ShippingAddressAddressLine1 = order.ShippingAddress.AddressLine1;
                amazonOrder.ShippingAddressAddressLine2 = order.ShippingAddress.AddressLine2;
                amazonOrder.ShippingAddressAddressLine3 = order.ShippingAddress.AddressLine3;
                amazonOrder.ShippingAddressCity = order.ShippingAddress.City;
                amazonOrder.ShippingAddressCountryCode = order.ShippingAddress.CountryCode;
                amazonOrder.ShippingAddressDistrict = order.ShippingAddress.District;
                amazonOrder.ShippingAddressName = order.ShippingAddress.Name;
                amazonOrder.ShippingAddressPhone = order.ShippingAddress.Phone;
                amazonOrder.ShippingAddressPostalCode = order.ShippingAddress.PostalCode;
                amazonOrder.ShippingAddressStateOrRegion = order.ShippingAddress.StateOrRegion;
            }
            if (order.IsSetShipServiceLevel())
                amazonOrder.shipServiceLevel = order.ShipServiceLevel;

            if (nuevo)
                dbContext.amazonorders.Add(amazonOrder);
  
            dbContext.SaveChanges();
            transaction.Commit();
            dbContext.Dispose();
        }

        private void GrabarOrderItems(List<OrderItem> orderItems,Order order)
        {
            bool nuevo;
//            return;
            ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
            var transaction = dbContext.Database.BeginTransaction(IsolationLevel.RepeatableRead);
            foreach (OrderItem item in orderItems)
            {
                AmazonOrderLinea amazonOrderLinea = dbContext.amazonorderLineas.Where(w => w.AmazonOrderLineaID == item.OrderItemId).FirstOrDefault();
                if (amazonOrderLinea == null)
                {
                    nuevo = true;
                    amazonOrderLinea = new AmazonOrderLinea();
                }
                else
                    nuevo = false;
                amazonOrderLinea.OrderItemId = item.OrderItemId;
                amazonOrderLinea.AmazonOrderID = order.AmazonOrderId;
                amazonOrderLinea.AmazonOrderLineaID = item.OrderItemId;
                if (item.IsSetASIN())
                    amazonOrderLinea.Asin = item.ASIN;
                amazonOrderLinea.Cuenta = order.SellerOrderId;
                if (item.IsSetItemPrice())
                {
                    amazonOrderLinea.ItemPriceAmount = FuncionesEbay.fnSpreciodprecio(item.ItemPrice.Amount);
                    amazonOrderLinea.ItemPriceCurrencyCode = item.ItemPrice.CurrencyCode;
                }
                if (item.IsSetQuantityOrdered())
                    amazonOrderLinea.QuantityOrdered = item.QuantityOrdered;
                if (item.IsSetQuantityShipped())
                    amazonOrderLinea.QuantityShipped = item.QuantityShipped;
                if (item.IsSetSellerSKU())
                    amazonOrderLinea.SellerSKU = item.SellerSKU;
                if (item.IsSetShippingPrice())
                {
                    amazonOrderLinea.ShippingPriceAmount = FuncionesEbay.fnSpreciodprecio(item.ShippingPrice.Amount);
                    amazonOrderLinea.ShippingPriceCurrencyCode = item.ShippingPrice.CurrencyCode;
                }
                if (item.IsSetTitle())
                    amazonOrderLinea.Title = item.Title;

                if (nuevo)
                    dbContext.amazonorderLineas.Add(amazonOrderLinea);
  

            }
            try
            {
                dbContext.SaveChanges();
                transaction.Commit();
                dbContext.Dispose();
            }
            catch (Exception e)
            {

            }
        }
    }
}
