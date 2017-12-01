namespace Gestion_WF.Ebay
{
    partial class GetOrdersUserControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.gridControlOrders = new DevExpress.XtraGrid.GridControl();
            this.ebayOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSellerUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colshippingDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEbayOrdersID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmountPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmountSaved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuyerCheckoutMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuyerUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCancelStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkoutStatus_LastModifiedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkoutStatus_PaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkoutStatus_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaidTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentHoldStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShippedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colshippingAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colshippingServiceSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubtotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.externalTransaction_ExternalTransactionStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.externalTransaction_FeeOrCreditAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.externalTransaction_PaymentOrRefundAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonLeer = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditDesde = new DevExpress.XtraEditors.DateEdit();
            this.checkedListBoxControlCuentas = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemDesdeLaFecha = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebayOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControlCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDesdeLaFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.gridControlOrders);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.simpleButtonLeer);
            this.layoutControl1.Controls.Add(this.dateEditDesde);
            this.layoutControl1.Controls.Add(this.checkedListBoxControlCuentas);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.LayoutVersion = "4";
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1755, 359, 450, 400);
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1251, 592);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            this.layoutControl1.LayoutUpgrade += new DevExpress.Utils.LayoutUpgradeEventHandler(this.layoutControl1_LayoutUpgrade);
            this.layoutControl1.BeforeLoadLayout += new DevExpress.Utils.LayoutAllowEventHandler(this.layoutControl1_BeforeLoadLayout);
            this.layoutControl1.LayoutUpdate += new System.EventHandler(this.layoutControl1_LayoutUpdate);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(108, 473);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(56, 20);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 9;
            // 
            // gridControlOrders
            // 
            this.gridControlOrders.DataSource = this.ebayOrderBindingSource;
            this.gridControlOrders.Location = new System.Drawing.Point(12, 12);
            this.gridControlOrders.MainView = this.gridViewOrders;
            this.gridControlOrders.Name = "gridControlOrders";
            this.gridControlOrders.Size = new System.Drawing.Size(1212, 347);
            this.gridControlOrders.TabIndex = 8;
            this.gridControlOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOrders});
            // 
            // ebayOrderBindingSource
            // 
            this.ebayOrderBindingSource.DataSource = typeof(MyEntityModel.EbayOrder);
            // 
            // gridViewOrders
            // 
            this.gridViewOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSellerUserID,
            this.colshippingDetails,
            this.colEbayOrdersID,
            this.colAmountPaid,
            this.colAmountSaved,
            this.colBuyerCheckoutMessage,
            this.colBuyerUserID,
            this.colCancelStatus,
            this.checkoutStatus_LastModifiedTime,
            this.checkoutStatus_PaymentMethod,
            this.checkoutStatus_Status,
            this.colCreatedTime,
            this.colOrderID,
            this.colOrderStatus,
            this.colPaidTime,
            this.colPaymentHoldStatus,
            this.colShippedTime,
            this.colshippingAddress,
            this.colshippingServiceSelected,
            this.colSubtotal,
            this.colTotal,
            this.externalTransaction_ExternalTransactionStatus,
            this.externalTransaction_FeeOrCreditAmount,
            this.externalTransaction_PaymentOrRefundAmount});
            this.gridViewOrders.GridControl = this.gridControlOrders;
            this.gridViewOrders.Name = "gridViewOrders";
            this.gridViewOrders.OptionsBehavior.Editable = false;
            this.gridViewOrders.OptionsLayout.LayoutVersion = "6";
            this.gridViewOrders.BeforeLoadLayout += new DevExpress.Utils.LayoutAllowEventHandler(this.gridViewOrders_BeforeLoadLayout);
            // 
            // colSellerUserID
            // 
            this.colSellerUserID.FieldName = "SellerUserID";
            this.colSellerUserID.Name = "colSellerUserID";
            this.colSellerUserID.Visible = true;
            this.colSellerUserID.VisibleIndex = 14;
            // 
            // colshippingDetails
            // 
            this.colshippingDetails.Caption = "SalesNumb.";
            this.colshippingDetails.FieldName = "shippingDetails.SellingManagerSalesRecordNumber";
            this.colshippingDetails.Name = "colshippingDetails";
            this.colshippingDetails.Visible = true;
            this.colshippingDetails.VisibleIndex = 17;
            // 
            // colEbayOrdersID
            // 
            this.colEbayOrdersID.FieldName = "EbayOrdersID";
            this.colEbayOrdersID.Name = "colEbayOrdersID";
            this.colEbayOrdersID.Visible = true;
            this.colEbayOrdersID.VisibleIndex = 0;
            // 
            // colAmountPaid
            // 
            this.colAmountPaid.FieldName = "AmountPaid";
            this.colAmountPaid.Name = "colAmountPaid";
            this.colAmountPaid.Visible = true;
            this.colAmountPaid.VisibleIndex = 1;
            // 
            // colAmountSaved
            // 
            this.colAmountSaved.FieldName = "AmountSaved";
            this.colAmountSaved.Name = "colAmountSaved";
            this.colAmountSaved.Visible = true;
            this.colAmountSaved.VisibleIndex = 2;
            // 
            // colBuyerCheckoutMessage
            // 
            this.colBuyerCheckoutMessage.FieldName = "BuyerCheckoutMessage";
            this.colBuyerCheckoutMessage.Name = "colBuyerCheckoutMessage";
            this.colBuyerCheckoutMessage.Visible = true;
            this.colBuyerCheckoutMessage.VisibleIndex = 3;
            // 
            // colBuyerUserID
            // 
            this.colBuyerUserID.FieldName = "BuyerUserID";
            this.colBuyerUserID.Name = "colBuyerUserID";
            this.colBuyerUserID.Visible = true;
            this.colBuyerUserID.VisibleIndex = 4;
            // 
            // colCancelStatus
            // 
            this.colCancelStatus.FieldName = "CancelStatus";
            this.colCancelStatus.Name = "colCancelStatus";
            this.colCancelStatus.Visible = true;
            this.colCancelStatus.VisibleIndex = 5;
            // 
            // checkoutStatus_LastModifiedTime
            // 
            this.checkoutStatus_LastModifiedTime.Caption = "checkoutStatus.LastModifiedTime";
            this.checkoutStatus_LastModifiedTime.DisplayFormat.FormatString = "g";
            this.checkoutStatus_LastModifiedTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.checkoutStatus_LastModifiedTime.FieldName = "checkoutStatus.LastModifiedTime";
            this.checkoutStatus_LastModifiedTime.Name = "checkoutStatus_LastModifiedTime";
            this.checkoutStatus_LastModifiedTime.Visible = true;
            this.checkoutStatus_LastModifiedTime.VisibleIndex = 7;
            // 
            // checkoutStatus_PaymentMethod
            // 
            this.checkoutStatus_PaymentMethod.Caption = "checkoutStatus.PaymentMethod";
            this.checkoutStatus_PaymentMethod.FieldName = "checkoutStatus.PaymentMethod";
            this.checkoutStatus_PaymentMethod.Name = "checkoutStatus_PaymentMethod";
            this.checkoutStatus_PaymentMethod.Visible = true;
            this.checkoutStatus_PaymentMethod.VisibleIndex = 6;
            // 
            // checkoutStatus_Status
            // 
            this.checkoutStatus_Status.Caption = "checkoutStatus.Status";
            this.checkoutStatus_Status.FieldName = "checkoutStatus.Status";
            this.checkoutStatus_Status.Name = "checkoutStatus_Status";
            this.checkoutStatus_Status.Visible = true;
            this.checkoutStatus_Status.VisibleIndex = 8;
            // 
            // colCreatedTime
            // 
            this.colCreatedTime.DisplayFormat.FormatString = "g";
            this.colCreatedTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreatedTime.FieldName = "CreatedTime";
            this.colCreatedTime.Name = "colCreatedTime";
            this.colCreatedTime.Visible = true;
            this.colCreatedTime.VisibleIndex = 9;
            // 
            // colOrderID
            // 
            this.colOrderID.FieldName = "OrderID";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.Visible = true;
            this.colOrderID.VisibleIndex = 10;
            // 
            // colOrderStatus
            // 
            this.colOrderStatus.FieldName = "OrderStatus";
            this.colOrderStatus.Name = "colOrderStatus";
            this.colOrderStatus.Visible = true;
            this.colOrderStatus.VisibleIndex = 11;
            // 
            // colPaidTime
            // 
            this.colPaidTime.DisplayFormat.FormatString = "g";
            this.colPaidTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPaidTime.FieldName = "PaidTime";
            this.colPaidTime.Name = "colPaidTime";
            this.colPaidTime.Visible = true;
            this.colPaidTime.VisibleIndex = 12;
            // 
            // colPaymentHoldStatus
            // 
            this.colPaymentHoldStatus.FieldName = "PaymentHoldStatus";
            this.colPaymentHoldStatus.Name = "colPaymentHoldStatus";
            this.colPaymentHoldStatus.Visible = true;
            this.colPaymentHoldStatus.VisibleIndex = 13;
            // 
            // colShippedTime
            // 
            this.colShippedTime.DisplayFormat.FormatString = "g";
            this.colShippedTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colShippedTime.FieldName = "ShippedTime";
            this.colShippedTime.Name = "colShippedTime";
            this.colShippedTime.Visible = true;
            this.colShippedTime.VisibleIndex = 15;
            // 
            // colshippingAddress
            // 
            this.colshippingAddress.FieldName = "shippingAddress";
            this.colshippingAddress.Name = "colshippingAddress";
            this.colshippingAddress.Visible = true;
            this.colshippingAddress.VisibleIndex = 16;
            // 
            // colshippingServiceSelected
            // 
            this.colshippingServiceSelected.FieldName = "shippingServiceSelected.ShippingService";
            this.colshippingServiceSelected.Name = "colshippingServiceSelected";
            this.colshippingServiceSelected.Visible = true;
            this.colshippingServiceSelected.VisibleIndex = 18;
            // 
            // colSubtotal
            // 
            this.colSubtotal.FieldName = "Subtotal";
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.Visible = true;
            this.colSubtotal.VisibleIndex = 19;
            // 
            // colTotal
            // 
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 20;
            // 
            // externalTransaction_ExternalTransactionStatus
            // 
            this.externalTransaction_ExternalTransactionStatus.Caption = "externalTransaction.ExternalTransactionStatus";
            this.externalTransaction_ExternalTransactionStatus.FieldName = "externalTransaction.ExternalTransactionStatus";
            this.externalTransaction_ExternalTransactionStatus.Name = "externalTransaction_ExternalTransactionStatus";
            this.externalTransaction_ExternalTransactionStatus.Visible = true;
            this.externalTransaction_ExternalTransactionStatus.VisibleIndex = 21;
            // 
            // externalTransaction_FeeOrCreditAmount
            // 
            this.externalTransaction_FeeOrCreditAmount.Caption = "externalTransaction.FeeOrCreditAmount";
            this.externalTransaction_FeeOrCreditAmount.FieldName = "externalTransaction.FeeOrCreditAmount";
            this.externalTransaction_FeeOrCreditAmount.Name = "externalTransaction_FeeOrCreditAmount";
            this.externalTransaction_FeeOrCreditAmount.Visible = true;
            this.externalTransaction_FeeOrCreditAmount.VisibleIndex = 22;
            // 
            // externalTransaction_PaymentOrRefundAmount
            // 
            this.externalTransaction_PaymentOrRefundAmount.Caption = "externalTransaction.PaymentOrRefundAmount";
            this.externalTransaction_PaymentOrRefundAmount.FieldName = "shippingDetails";
            this.externalTransaction_PaymentOrRefundAmount.Name = "externalTransaction_PaymentOrRefundAmount";
            this.externalTransaction_PaymentOrRefundAmount.Visible = true;
            this.externalTransaction_PaymentOrRefundAmount.VisibleIndex = 23;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(12, 547);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(152, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButtonLeer
            // 
            this.simpleButtonLeer.Location = new System.Drawing.Point(12, 521);
            this.simpleButtonLeer.Name = "simpleButtonLeer";
            this.simpleButtonLeer.Size = new System.Drawing.Size(152, 22);
            this.simpleButtonLeer.StyleController = this.layoutControl1;
            this.simpleButtonLeer.TabIndex = 6;
            this.simpleButtonLeer.Text = "Leer";
            this.simpleButtonLeer.Click += new System.EventHandler(this.simpleButtonLeer_Click);
            // 
            // dateEditDesde
            // 
            this.dateEditDesde.EditValue = null;
            this.dateEditDesde.Location = new System.Drawing.Point(108, 497);
            this.dateEditDesde.Name = "dateEditDesde";
            this.dateEditDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDesde.Properties.DisplayFormat.FormatString = "g";
            this.dateEditDesde.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDesde.Properties.EditFormat.FormatString = "g";
            this.dateEditDesde.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDesde.Size = new System.Drawing.Size(56, 20);
            this.dateEditDesde.StyleController = this.layoutControl1;
            this.dateEditDesde.TabIndex = 5;
            // 
            // checkedListBoxControlCuentas
            // 
            this.checkedListBoxControlCuentas.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkedListBoxControlCuentas.Location = new System.Drawing.Point(12, 363);
            this.checkedListBoxControlCuentas.Name = "checkedListBoxControlCuentas";
            this.checkedListBoxControlCuentas.Size = new System.Drawing.Size(152, 106);
            this.checkedListBoxControlCuentas.StyleController = this.layoutControl1;
            this.checkedListBoxControlCuentas.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItemDesdeLaFecha,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.splitterItem1,
            this.emptySpaceItem3,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1251, 592);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.checkedListBoxControlCuentas;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 351);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(156, 110);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItemDesdeLaFecha
            // 
            this.layoutControlItemDesdeLaFecha.Control = this.dateEditDesde;
            this.layoutControlItemDesdeLaFecha.Location = new System.Drawing.Point(0, 485);
            this.layoutControlItemDesdeLaFecha.Name = "layoutControlItemDesdeLaFecha";
            this.layoutControlItemDesdeLaFecha.Size = new System.Drawing.Size(156, 24);
            this.layoutControlItemDesdeLaFecha.Text = "Desde la fecha:";
            this.layoutControlItemDesdeLaFecha.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButtonLeer;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 509);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(156, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 535);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(156, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(156, 351);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1075, 221);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 561);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(156, 11);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControlOrders;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1216, 351);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(1216, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 351);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(1221, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(10, 351);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.textEdit1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 461);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(156, 24);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(93, 13);
            // 
            // GetOrdersUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "GetOrdersUserControl";
            this.Size = new System.Drawing.Size(1251, 592);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ebayOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControlCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDesdeLaFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControlCuentas;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit dateEditDesde;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemDesdeLaFecha;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLeer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.BindingSource ebayOrderBindingSource;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl gridControlOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOrders;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colEbayOrdersID;
        private DevExpress.XtraGrid.Columns.GridColumn colAmountPaid;
        private DevExpress.XtraGrid.Columns.GridColumn colAmountSaved;
        private DevExpress.XtraGrid.Columns.GridColumn colBuyerCheckoutMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colBuyerUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colCancelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn checkoutStatus_LastModifiedTime;
        private DevExpress.XtraGrid.Columns.GridColumn checkoutStatus_PaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn checkoutStatus_Status;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedTime;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderID;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPaidTime;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentHoldStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colSellerUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colShippedTime;
        private DevExpress.XtraGrid.Columns.GridColumn colshippingAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colshippingDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colshippingServiceSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colSubtotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn externalTransaction_ExternalTransactionStatus;
        private DevExpress.XtraGrid.Columns.GridColumn externalTransaction_FeeOrCreditAmount;
        private DevExpress.XtraGrid.Columns.GridColumn externalTransaction_PaymentOrRefundAmount;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
