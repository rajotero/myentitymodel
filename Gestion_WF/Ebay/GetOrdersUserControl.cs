using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyEntityModel;
using eBay.Service.Call;
using DevExpress.XtraEditors.Controls;
using eBay.Service.Core.Soap;
using System.Diagnostics;
using System.IO;
using CustomSerialization;

namespace Gestion_WF.Ebay
{
    public partial class GetOrdersUserControl : UserControl
    {
        CredencialesEbay credencialesEbay = new CredencialesEbay();
        public GetOrdersUserControl()
        {
            InitializeComponent();
            ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
            this.Dock = DockStyle.Fill;
            this.HandleDestroyed += handleDestroyed;
            checkedListBoxControlCuentas.Items.Clear();
            foreach (string cuenta in credencialesEbay.Cuentas)
            {
                checkedListBoxControlCuentas.Items.Add(cuenta, true);
            }
          
            DateTime CreateTimeFromPrev = DateTime.Now.AddDays(-5).ToUniversalTime();
            try
            {
                CreateTimeFromPrev = (DateTime)dbContext.datos.FirstOrDefault().FechaActualizacionEbay;
            }
            catch { }
            dateEditDesde.DateTime = CreateTimeFromPrev;

            if (File.Exists("Layouts\\EbayGetOrders\\gridViewOrders.xml"))
            {
                gridViewOrders.RestoreLayoutFromXml("Layouts\\EbayGetOrders\\gridViewOrders.xml");
            }
            if (File.Exists("Layouts\\EbayGetOrders\\layout.xml"))
            {
                layoutControl1.RestoreLayoutFromXml("Layouts\\EbayGetOrders\\layout.xml");
                string filePath = "Layouts\\EbayGetOrders\\layout.xml";
                layoutControl1.RestoreLayoutExFromXml(filePath, new List<string> {  "checkedListBoxControlCuentas",
                                                                                    "gridControlOrders",
                                                                                    "gridViewOrders",
                                                                                    "simpleButtonLeer" });
            }

            gridControlOrders.DataSource = dbContext.EbayOrder.OrderByDescending(o => o.EbayOrdersID).ToList();
        }

        private void handleDestroyed(object sender, EventArgs e)
        {
            gridViewOrders.SaveLayoutToXml("Layouts\\EbayGetOrders\\gridViewOrders.xml"); 
            layoutControl1.SaveLayoutToXml("Layouts\\EbayGetOrders\\layout.xml");
            string filePath = "Layouts\\EbayGetOrders\\layout.xml";
            layoutControl1.SaveLayoutExToXml(filePath);
        }
        private void fnGrabarOrderLinea(TransactionType orderLinea)
        {
            bool nuevo = false;
            ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
            EbayOrderLinea ebayOrderLinea;
            ebayOrderLinea = dbContext.EbayOrderLinea.Where(w => w.ExtendedOrderID == orderLinea.ExtendedOrderID).FirstOrDefault();
            if (ebayOrderLinea == null)
            {
                ebayOrderLinea = new EbayOrderLinea();
                nuevo = true;
            }

            Debug.WriteLine(orderLinea.ExtendedOrderID);
            ebayOrderLinea.ExtendedOrderID = orderLinea.ExtendedOrderID;
            ebayOrderLinea.BuyerMessage = orderLinea.BuyerMessage;
            ebayOrderLinea.BuyerCheckoutMessage = orderLinea.BuyerCheckoutMessage;
            ebayOrderLinea.CreatedDate = orderLinea.CreatedDate;
            ebayOrderLinea.ItemID = orderLinea.Item.ItemID;
            ebayOrderLinea.Titulo = orderLinea.Item.Title;
            ebayOrderLinea.QuantityPurchased = orderLinea.QuantityPurchased;
            ebayOrderLinea.TransactionPrice = (decimal)orderLinea.TransactionPrice.Value;
            if(orderLinea.FinalValueFee != null)
                ebayOrderLinea.EbayFee = (decimal)orderLinea.FinalValueFee.Value;
            if (orderLinea.ShippingDetails.SellingManagerSalesRecordNumberSpecified)
               ebayOrderLinea.SellingManagerSalesRecordNumber = orderLinea.ShippingDetails.SellingManagerSalesRecordNumber;
            if(orderLinea.Status.PaymentHoldStatusSpecified)
                ebayOrderLinea.PaymentHoldStatus = orderLinea.Status.PaymentHoldStatus.ToString();
            
            if (nuevo)
                dbContext.EbayOrderLinea.Add(ebayOrderLinea);

            dbContext.SaveChanges();
        }
        private void fnGrabarOrder(OrderType order)
        {
            bool nuevo = false;
            ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
            EbayOrder ebayOrder;
            ebayOrder = dbContext.EbayOrder.Where(w => w.OrderID == order.OrderID).FirstOrDefault();
            if (ebayOrder == null)
            {
                ebayOrder = new EbayOrder();
                nuevo = true;
            }

            Debug.WriteLine(order.BuyerUserID);

            ebayOrder.AmountPaid = (decimal)order.AmountPaid.Value;
            ebayOrder.AmountSaved = (decimal)order.AmountSaved.Value;
            ebayOrder.BuyerCheckoutMessage = order.BuyerCheckoutMessage;
            ebayOrder.BuyerUserID = order.BuyerUserID;
            if (order.CancelStatusSpecified)
                ebayOrder.CancelStatus = order.CancelStatus.ToString();
            ebayOrder.checkoutStatus = new CheckoutStatus();
            if (order.CheckoutStatus.LastModifiedTimeSpecified)
            {
                  ebayOrder.checkoutStatus.LastModifiedTime = order.CheckoutStatus.LastModifiedTime;
            }
            if (order.CheckoutStatus.PaymentMethodSpecified)
                ebayOrder.checkoutStatus.PaymentMethod = order.CheckoutStatus.PaymentMethod.ToString();
            if (order.CheckoutStatus.StatusSpecified)
                ebayOrder.checkoutStatus.Status = order.CheckoutStatus.Status.ToString();
            if (order.CreatedTimeSpecified)
                ebayOrder.CreatedTime = order.CreatedTime;
            ebayOrder.OrderID = order.OrderID;
            if (order.OrderStatusSpecified)
                ebayOrder.OrderStatus = order.OrderStatus.ToString();
            if (order.PaidTimeSpecified)
                ebayOrder.PaidTime = order.PaidTime;
            if (order.PaymentHoldStatusSpecified)
                ebayOrder.PaymentHoldStatus = order.PaymentHoldStatus.ToString();
            ebayOrder.SellerUserID = order.SellerUserID;
            if (order.ShippedTimeSpecified)
                ebayOrder.ShippedTime = order.ShippedTime;
            ebayOrder.shippingAddress = new ShippingAddress();
            ebayOrder.shippingAddress.AddressID = order.ShippingAddress.AddressID;
            ebayOrder.shippingAddress.CityName = order.ShippingAddress.CityName;
            ebayOrder.shippingAddress.CompanyName = order.ShippingAddress.CompanyName;
            ebayOrder.shippingAddress.Country = order.ShippingAddress.Country.ToString();
            ebayOrder.shippingAddress.CountryName = order.ShippingAddress.CountryName;
            ebayOrder.shippingAddress.FirstName = order.ShippingAddress.FirstName;
            ebayOrder.shippingAddress.LastName = order.ShippingAddress.LastName;
            ebayOrder.shippingAddress.Name = order.ShippingAddress.Name;
            ebayOrder.shippingAddress.Phone = order.ShippingAddress.Phone;
            ebayOrder.shippingAddress.Phone2 = order.ShippingAddress.Phone2;
            ebayOrder.shippingAddress.PostalCode = order.ShippingAddress.PostalCode;
            ebayOrder.shippingAddress.StateOrProvince = order.ShippingAddress.StateOrProvince;
            ebayOrder.shippingAddress.Street = order.ShippingAddress.Street;
            ebayOrder.shippingAddress.Street1 = order.ShippingAddress.Street1;
            ebayOrder.shippingAddress.Street2 = order.ShippingAddress.Street2;
            ebayOrder.shippingDetails = new ShippingDetails();
            ebayOrder.shippingDetails.SellingManagerSalesRecordNumber = order.ShippingDetails.SellingManagerSalesRecordNumber;
            ebayOrder.shippingServiceSelected = new ShippingServiceSelected();
            if (order.ShippingServiceSelected.ExpeditedServiceSpecified)
                ebayOrder.shippingServiceSelected.ExpeditedService = order.ShippingServiceSelected.ExpeditedService;
            if (order.ShippingServiceSelected.FreeShippingSpecified)
                ebayOrder.shippingServiceSelected.FreeShipping = order.ShippingServiceSelected.FreeShipping;
            ebayOrder.shippingServiceSelected.ShippingService = order.ShippingServiceSelected.ShippingService;
            if (order.ShippingServiceSelected.ShippingServiceAdditionalCost != null)
              ebayOrder.shippingServiceSelected.ShippingServiceAdditionalCost = (decimal)order.ShippingServiceSelected.ShippingServiceAdditionalCost.Value;
            if (order.ShippingServiceSelected.ShippingServiceCost != null)
                ebayOrder.shippingServiceSelected.ShippingServiceCost = (decimal)order.ShippingServiceSelected.ShippingServiceCost.Value;

                ebayOrder.Subtotal = (decimal)order.Subtotal.Value;

            ebayOrder.Total = (decimal)order.Total.Value;

            //           ebayOrder.externalTransaction.ExternalTransactionID = order.ExternalTransaction[0].ExternalTransactionID;
            ebayOrder.externalTransaction = new ExternalTransaction();
            if (order.ExternalTransaction.Count > 0)
            {
                ebayOrder.externalTransaction.ExternalTransactionStatus = order.ExternalTransaction[0].ExternalTransactionStatus.ToString();
                ebayOrder.externalTransaction.ExternalTransactionTime = order.ExternalTransaction[0].ExternalTransactionTime;
                ebayOrder.externalTransaction.FeeOrCreditAmount = (decimal)order.ExternalTransaction[0].FeeOrCreditAmount.Value;
                ebayOrder.externalTransaction.PaymentOrRefundAmount = (decimal)order.ExternalTransaction[0].PaymentOrRefundAmount.Value;
            }
            if (nuevo)
                dbContext.EbayOrder.Add(ebayOrder);
            dbContext.SaveChanges();
//            { "No se puede convertir un objeto de tipo 'eBay.Service.Core.Soap.TransactionType' al tipo 'MyEntityModel.EbayOrderLinea'."}
            foreach (TransactionType ebayOrderLinea in order.TransactionArray)
            {
                fnGrabarOrderLinea(ebayOrderLinea);
            }

        }
        private void simpleButtonLeer_Click(object sender, EventArgs e)
        {
            int pageNumber = 1;
            List<OrderType> orderType = new List<OrderType>();
            foreach (CheckedListBoxItem cuenta in checkedListBoxControlCuentas.CheckedItems)
            {
                credencialesEbay.cuenta = cuenta.Value.ToString();
                pageNumber = 1;
                while (true)
                {
                    GetOrdersCall getOrdersCall = new GetOrdersCall(credencialesEbay.context);
                    getOrdersCall.DetailLevelList = new DetailLevelCodeTypeCollection();
                    getOrdersCall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
                    getOrdersCall.CreateTimeTo = DateTime.Now.ToUniversalTime();
                    getOrdersCall.CreateTimeFrom = dateEditDesde.DateTime;
                    getOrdersCall.IncludeFinalValueFee = true;
                    PaginationType pagination = new PaginationType();
                    pagination.EntriesPerPage = 100;
                    pagination.EntriesPerPageSpecified = true;
                    pagination.PageNumber = pageNumber;
                    pagination.PageNumberSpecified = true;
                    getOrdersCall.Execute();
                    int total = 999;
                    try
                    {
                        total = getOrdersCall.PaginationResult.TotalNumberOfPages;
                    }
                    catch
                    { }
                    simpleButtonLeer.Text = credencialesEbay.cuenta + string.Format(" {0} de {1}",pageNumber,total);
                    Application.DoEvents();
                    var b = getOrdersCall.ApiResponse.Any.ToString();
                    for(int i = 0; i < getOrdersCall.ApiResponse.OrderArray.Count; i++)
                        orderType.Add(getOrdersCall.ApiResponse.OrderArray[i]);
                    Parallel.ForEach(orderType, new ParallelOptions { MaxDegreeOfParallelism = 4 }, webpage => 
                    {
                         fnGrabarOrder(webpage);

                    });
                    orderType.Clear();
                    var a = getOrdersCall.ApiResponse.OrderArray[0];
                    if (pageNumber < getOrdersCall.PaginationResult.TotalNumberOfPages)
                        pageNumber++;
                    else
                        break;
                }
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            credencialesEbay.cuenta = "ofertasparati";
            GetItemCall getItemcall = new GetItemCall(credencialesEbay.context);
            getItemcall.ItemID = "272416907107";
            getItemcall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
            getItemcall.IncludeItemSpecifics = true;
            getItemcall.Execute();
            ItemType item = getItemcall.ApiResponse.Item;
            NameValueListType i = item.Variations.VariationSpecificsSet.ItemAt(0);
            //item.SKU = "pepe";
            //ReviseItemCall RIC = new ReviseItemCall(credencialesEbay.context);
            //RIC.Item = item;
            //RIC.Execute();
            //ReviseFixedPriceItemCall RI = new ReviseFixedPriceItemCall(credencialesEbay.context);
            //RI.Item = item;
            //RI.Execute();
        }

        private void layoutControl1_LayoutUpgrade(object sender, DevExpress.Utils.LayoutUpgradeEventArgs e)
        {
      
        }

        private void layoutControl1_LayoutUpdate(object sender, EventArgs e)
        {
            
        }

        private void layoutControl1_BeforeLoadLayout(object sender, DevExpress.Utils.LayoutAllowEventArgs e)
        {
            if (e.PreviousVersion != layoutControl1.LayoutVersion)
                e.Allow = false;
            else
                e.Allow = true;
        }

        private void gridViewOrders_BeforeLoadLayout(object sender, DevExpress.Utils.LayoutAllowEventArgs e)
        {
            if (e.PreviousVersion != gridViewOrders.OptionsLayout.LayoutVersion)
                e.Allow = false;
            else
                e.Allow = true;
        }
    }
}
