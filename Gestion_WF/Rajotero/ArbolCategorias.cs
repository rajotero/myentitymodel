using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DevExpress.XtraTreeList.Columns;
using MyEntityModel;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace Gestion_WF.Rajotero
{
    public partial class RajoteroArbolCategorias : UserControl
    {
        string categorias = "";

        public Bukimedia.PrestaSharp.Entities.product product
        {
            set
            {
                categorias = "A";
                categorias = "";

                if (value.id_category_default != 0)
                {
                    categorias = string.Format("-{0}-", value.id_category_default.ToString());
                    TreeListNode myNode = treeList.FindNodeByFieldValue("id_category", value.id_category_default);
                    myNode.Checked = true;
                    myNode.Expanded = true;
                    RajoteroDbContext RajoteroDbcontext = new MyEntityModel.RajoteroDbContext();
                    var model = RajoteroDbcontext.ps_category_product.Where(w => w.id_product == value.id).ToList();
                    foreach (var m in model)
                    {
                        myNode = treeList.FindNodeByFieldValue("id_category", m.id_category);
                        myNode.Checked = true;
                        myNode.Expanded = true;
                        categorias += string.Format("-{0}-", m.id_category);
                    }
                    GetCheckedNodesOperation.ExpandCheckedNodes(treeList);
                }

            }
        }
        public RajoteroArbolCategorias()
        {
            InitializeComponent();
            treeList.DataSource = MyEntityModel.RajoteroController.ArbolCategorias(1);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MyEntityModel.RajoteroDbContext dbContext = new MyEntityModel.RajoteroDbContext();
            var categorias = dbContext.ps_category.ToList();

        }

        private void treeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            //            var a = e.Node.GetValue(treeListColumnID);
        }
    }

    public class GetCheckedNodesOperation : TreeListOperation
    {
        public List<TreeListNode> CheckedNodes = new List<TreeListNode>();

        public override void Execute(TreeListNode node)
        {
            if (node.Checked)
                CheckedNodes.Add(node);
        }

        public static void ExpandCheckedNodes(TreeList tl)
        {
            tl.BeginUpdate();
            GetCheckedNodesOperation operation = new GetCheckedNodesOperation();
            tl.NodesIterator.DoOperation(operation);
            ExpandCheckedNodesCore(operation.CheckedNodes);
            tl.EndUpdate();
        }
        private static void ExpandCheckedNodesCore(List<TreeListNode> checkedNodes)
        {
            foreach (TreeListNode node in checkedNodes)
                ExpandNodeCore(node);
        }

        private static void ExpandNodeCore(TreeListNode node)
        {
            node.TreeList.MakeNodeVisible(node);
            node.Expanded = true;
        }
    }


}