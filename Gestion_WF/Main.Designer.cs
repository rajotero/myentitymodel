namespace Gestion_WF
{
    partial class Main
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemArticulo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemImportarFactura = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLeerPedidosEbay = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonLeerPedidosAmazon = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barStaticItemEstado = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageEbay = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageAmazon = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonStatusBar2 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.ribbonControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // ribbonControl
            // 
            this.ribbonControl.Controls.Add(this.barDockControlLeft);
            this.ribbonControl.Controls.Add(this.barDockControlRight);
            this.ribbonControl.Controls.Add(this.barDockControlBottom);
            this.ribbonControl.Controls.Add(this.barDockControlTop);
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.barStaticItemArticulo,
            this.barButtonItemImportarFactura,
            this.barButtonItemLeerPedidosEbay,
            this.barButtonLeerPedidosAmazon,
            this.barStaticItem1,
            this.barButtonItem1,
            this.barEditItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barCheckItem1,
            this.barStaticItemEstado,
            this.barStaticItem5});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 10;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPageEbay,
            this.ribbonPageAmazon});
            this.ribbonControl.Size = new System.Drawing.Size(1280, 143);
            this.ribbonControl.StatusBar = this.ribbonStatusBar2;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 143);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this.ribbonControl;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem2});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1280, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 143);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1280, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1280, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 143);
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "barStaticItem2";
            this.barStaticItem2.Id = 0;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // barStaticItemArticulo
            // 
            this.barStaticItemArticulo.Caption = "Articulos";
            this.barStaticItemArticulo.Id = 1;
            this.barStaticItemArticulo.Name = "barStaticItemArticulo";
            this.barStaticItemArticulo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItemImportarFactura
            // 
            this.barButtonItemImportarFactura.Caption = "Importar Factuira";
            this.barButtonItemImportarFactura.Id = 2;
            this.barButtonItemImportarFactura.Name = "barButtonItemImportarFactura";
            this.barButtonItemImportarFactura.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemImportarFactura_ItemClick);
            // 
            // barButtonItemLeerPedidosEbay
            // 
            this.barButtonItemLeerPedidosEbay.Caption = "Leer Pedidos";
            this.barButtonItemLeerPedidosEbay.Id = 3;
            this.barButtonItemLeerPedidosEbay.Name = "barButtonItemLeerPedidosEbay";
            this.barButtonItemLeerPedidosEbay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemLeerPedidosEbay_ItemClick);
            // 
            // barButtonLeerPedidosAmazon
            // 
            this.barButtonLeerPedidosAmazon.Caption = "Leer Pedidos";
            this.barButtonLeerPedidosAmazon.Id = 4;
            this.barButtonLeerPedidosAmazon.Name = "barButtonLeerPedidosAmazon";
            this.barButtonLeerPedidosAmazon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonLeerPedidosAmazon_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 6;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemButtonEdit1;
            this.barEditItem1.Id = 2;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 5;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 6;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 7;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // barStaticItemEstado
            // 
            this.barStaticItemEstado.Caption = "barStaticItem4";
            this.barStaticItemEstado.Id = 8;
            this.barStaticItemEstado.Name = "barStaticItemEstado";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Ficheros";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barStaticItemArticulo);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageEbay
            // 
            this.ribbonPageEbay.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPageEbay.Name = "ribbonPageEbay";
            this.ribbonPageEbay.Text = "Ebay";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemImportarFactura);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemLeerPedidosEbay);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPageAmazon
            // 
            this.ribbonPageAmazon.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPageAmazon.Name = "ribbonPageAmazon";
            this.ribbonPageAmazon.Text = "Amazon";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonLeerPedidosAmazon);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(1, 547);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1235, 27);
            // 
            // ribbonStatusBar2
            // 
            this.ribbonStatusBar2.ItemLinks.Add(this.barStaticItemEstado);
            this.ribbonStatusBar2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonStatusBar2.ItemLinks.Add(this.barButtonItem4);
            this.ribbonStatusBar2.ItemLinks.Add(this.barCheckItem1);
            this.ribbonStatusBar2.Location = new System.Drawing.Point(0, 859);
            this.ribbonStatusBar2.Name = "ribbonStatusBar2";
            this.ribbonStatusBar2.Ribbon = this.ribbonControl;
            this.ribbonStatusBar2.Size = new System.Drawing.Size(1280, 27);
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "barStaticItem1";
            this.barStaticItem3.Id = 16;
            this.barStaticItem3.Name = "barStaticItem3";
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.Location = new System.Drawing.Point(0, 143);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.Size = new System.Drawing.Size(1280, 743);
            this.xtraTabControl.TabIndex = 1;
            this.xtraTabControl.CloseButtonClick += new System.EventHandler(this.xtraTabControl_CloseButtonClick);
            // 
            // barStaticItem5
            // 
            this.barStaticItem5.Caption = "barStaticItem5";
            this.barStaticItem5.Id = 9;
            this.barStaticItem5.Name = "barStaticItem5";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 886);
            this.Controls.Add(this.ribbonStatusBar2);
            this.Controls.Add(this.xtraTabControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "Main";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ribbonControl.ResumeLayout(false);
            this.ribbonControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barStaticItemArticulo;
        private DevExpress.XtraBars.BarButtonItem barButtonItemImportarFactura;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageEbay;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLeerPedidosEbay;
        private DevExpress.XtraBars.BarButtonItem barButtonLeerPedidosAmazon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageAmazon;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        public DevExpress.XtraBars.BarStaticItem barStaticItemEstado;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem5;
    }
}

