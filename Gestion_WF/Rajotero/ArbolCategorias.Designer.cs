namespace Gestion_WF.Rajotero
{
    partial class RajoteroArbolCategorias
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
            this.categorytreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pscategorylangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pscategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.colname = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.categorytreeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pscategorylangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pscategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.SuspendLayout();
            // 
            // categorytreeBindingSource
            // 
            this.categorytreeBindingSource.DataSource = typeof(MyEntityModel.category_tree);
            // 
            // pscategorylangBindingSource
            // 
            this.pscategorylangBindingSource.DataSource = typeof(MyEntityModel.ps_category_lang);
            // 
            // pscategoryBindingSource
            // 
            this.pscategoryBindingSource.DataSource = typeof(MyEntityModel.ps_category);
            // 
            // treeList
            // 
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colname,
            this.treeListColumnID});
            this.treeList.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList.DataSource = this.categorytreeBindingSource;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.KeyFieldName = "id_category";
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Name = "treeList";
            this.treeList.OptionsView.ShowCheckBoxes = true;
            this.treeList.ParentFieldName = "id_parent";
            this.treeList.Size = new System.Drawing.Size(497, 922);
            this.treeList.TabIndex = 2;
            // 
            // colname
            // 
            this.colname.FieldName = "name";
            this.colname.MinWidth = 34;
            this.colname.Name = "colname";
            this.colname.OptionsColumn.ReadOnly = true;
            this.colname.Visible = true;
            this.colname.VisibleIndex = 0;
            this.colname.Width = 62;
            // 
            // treeListColumnID
            // 
            this.treeListColumnID.Caption = "treeListColumn1";
            this.treeListColumnID.FieldName = "id_category";
            this.treeListColumnID.Name = "treeListColumnID";
            // 
            // ArbolCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList);
            this.Name = "ArbolCategorias";
            this.Size = new System.Drawing.Size(497, 922);
            ((System.ComponentModel.ISupportInitialize)(this.categorytreeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pscategorylangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pscategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource categorytreeBindingSource;
        private System.Windows.Forms.BindingSource pscategorylangBindingSource;
        private System.Windows.Forms.BindingSource pscategoryBindingSource;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colname;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnID;
    }
}
