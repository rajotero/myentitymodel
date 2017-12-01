namespace Gestion_WF.Rajotero
{
    partial class RajoteroArtiulo
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEditReferencia = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemReferencia = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.textEditTitulo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItemTitulo = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButtonGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.memoEditDescripction = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItemdescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.memoEditDescripction_short = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItemDescripction_short = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditReferencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemReferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTitulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDescripction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemdescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDescripction_short.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDescripction_short)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.memoEditDescripction_short);
            this.layoutControl1.Controls.Add(this.memoEditDescripction);
            this.layoutControl1.Controls.Add(this.simpleButtonGrabar);
            this.layoutControl1.Controls.Add(this.textEditTitulo);
            this.layoutControl1.Controls.Add(this.textEditReferencia);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1427, 292, 450, 400);
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(859, 808);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // textEditReferencia
            // 
            this.textEditReferencia.Location = new System.Drawing.Point(104, 15);
            this.textEditReferencia.Name = "textEditReferencia";
            this.textEditReferencia.Properties.ReadOnly = true;
            this.textEditReferencia.Size = new System.Drawing.Size(320, 20);
            this.textEditReferencia.StyleController = this.layoutControl1;
            this.textEditReferencia.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemReferencia,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItemTitulo,
            this.layoutControlItem1,
            this.layoutControlItemdescription,
            this.layoutControlItemDescripction_short,
            this.splitterItem1,
            this.splitterItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(859, 808);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItemReferencia
            // 
            this.layoutControlItemReferencia.Control = this.textEditReferencia;
            this.layoutControlItemReferencia.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemReferencia.Name = "layoutControlItemReferencia";
            this.layoutControlItemReferencia.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItemReferencia.Size = new System.Drawing.Size(419, 30);
            this.layoutControlItemReferencia.Text = "Referencia:";
            this.layoutControlItemReferencia.TextSize = new System.Drawing.Size(86, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(419, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(420, 30);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 146);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(839, 616);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // textEditTitulo
            // 
            this.textEditTitulo.Location = new System.Drawing.Point(104, 45);
            this.textEditTitulo.Name = "textEditTitulo";
            this.textEditTitulo.Size = new System.Drawing.Size(740, 20);
            this.textEditTitulo.StyleController = this.layoutControl1;
            this.textEditTitulo.TabIndex = 5;
            // 
            // layoutControlItemTitulo
            // 
            this.layoutControlItemTitulo.Control = this.textEditTitulo;
            this.layoutControlItemTitulo.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItemTitulo.Name = "layoutControlItemTitulo";
            this.layoutControlItemTitulo.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItemTitulo.Size = new System.Drawing.Size(839, 30);
            this.layoutControlItemTitulo.Text = "Título:";
            this.layoutControlItemTitulo.TextSize = new System.Drawing.Size(86, 13);
            // 
            // simpleButtonGrabar
            // 
            this.simpleButtonGrabar.Location = new System.Drawing.Point(12, 774);
            this.simpleButtonGrabar.Name = "simpleButtonGrabar";
            this.simpleButtonGrabar.Size = new System.Drawing.Size(835, 22);
            this.simpleButtonGrabar.StyleController = this.layoutControl1;
            this.simpleButtonGrabar.TabIndex = 6;
            this.simpleButtonGrabar.Text = "simpleButton1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButtonGrabar;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 762);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(839, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // memoEditDescripction
            // 
            this.memoEditDescripction.EditValue = "1\r\n2\r\n3\r\n4";
            this.memoEditDescripction.Location = new System.Drawing.Point(104, 75);
            this.memoEditDescripction.Name = "memoEditDescripction";
            this.memoEditDescripction.Size = new System.Drawing.Size(740, 40);
            this.memoEditDescripction.StyleController = this.layoutControl1;
            this.memoEditDescripction.TabIndex = 7;
            // 
            // layoutControlItemdescription
            // 
            this.layoutControlItemdescription.Control = this.memoEditDescripction;
            this.layoutControlItemdescription.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItemdescription.MaxSize = new System.Drawing.Size(0, 500);
            this.layoutControlItemdescription.MinSize = new System.Drawing.Size(109, 50);
            this.layoutControlItemdescription.Name = "layoutControlItemdescription";
            this.layoutControlItemdescription.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItemdescription.Size = new System.Drawing.Size(839, 50);
            this.layoutControlItemdescription.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemdescription.Text = "Descripción:";
            this.layoutControlItemdescription.TextSize = new System.Drawing.Size(86, 13);
            // 
            // memoEditDescripction_short
            // 
            this.memoEditDescripction_short.Location = new System.Drawing.Point(104, 130);
            this.memoEditDescripction_short.Name = "memoEditDescripction_short";
            this.memoEditDescripction_short.Properties.LinesCount = 3;
            this.memoEditDescripction_short.Size = new System.Drawing.Size(740, 16);
            this.memoEditDescripction_short.StyleController = this.layoutControl1;
            this.memoEditDescripction_short.TabIndex = 8;
            this.memoEditDescripction_short.EditValueChanged += new System.EventHandler(this.memoEditDescripction_short_EditValueChanged);
            // 
            // layoutControlItemDescripction_short
            // 
            this.layoutControlItemDescripction_short.Control = this.memoEditDescripction_short;
            this.layoutControlItemDescripction_short.Location = new System.Drawing.Point(0, 115);
            this.layoutControlItemDescripction_short.Name = "layoutControlItemDescripction_short";
            this.layoutControlItemDescripction_short.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItemDescripction_short.Size = new System.Drawing.Size(839, 26);
            this.layoutControlItemDescripction_short.Text = "Descripcion corta:";
            this.layoutControlItemDescripction_short.TextSize = new System.Drawing.Size(86, 13);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(0, 110);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(839, 5);
            // 
            // splitterItem2
            // 
            this.splitterItem2.AllowHotTrack = true;
            this.splitterItem2.Location = new System.Drawing.Point(0, 141);
            this.splitterItem2.Name = "splitterItem2";
            this.splitterItem2.Size = new System.Drawing.Size(839, 5);
            // 
            // RajoteroArtiulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "RajoteroArtiulo";
            this.Size = new System.Drawing.Size(859, 808);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditReferencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemReferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTitulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDescripction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemdescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditDescripction_short.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDescripction_short)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit textEditReferencia;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemReferencia;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.TextEdit textEditTitulo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemTitulo;
        private DevExpress.XtraEditors.SimpleButton simpleButtonGrabar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.MemoEdit memoEditDescripction_short;
        private DevExpress.XtraEditors.MemoEdit memoEditDescripction;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemdescription;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemDescripction_short;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.SplitterItem splitterItem2;
    }
}
