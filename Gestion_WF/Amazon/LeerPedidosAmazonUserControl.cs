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
using System.IO;
using CustomSerialization;
using System.Diagnostics;
using System.Threading;

namespace Gestion_WF.Amazon
{
    public partial class LeerPedidosAmazonUserControl : UserControl
    {
        public Main main;
        public LeerPedidosAmazonUserControl()
        {
            InitializeComponent();
            this.HandleDestroyed += handleDestroyed;
            this.Dock = DockStyle.Fill;
            if (File.Exists("Layouts\\LeerPedidosAmazon\\gridViewOrders.xml"))
            {
                gridViewOrders.RestoreLayoutFromXml("Layouts\\LeerPedidosAmazon\\gridViewOrders.xml");
            }
            if (File.Exists("Layouts\\LeerPedidosAmazon\\gridViewLineas.xml"))
            {
                gridViewOrders.RestoreLayoutFromXml("Layouts\\LeerPedidosAmazon\\gridViewLineas.xml");
            }
            if (File.Exists("Layouts\\LeerPedidosAmazon\\layout.xml"))
            {
                layoutControl1.RestoreLayoutExFromXml("Layouts\\LeerPedidosAmazon\\layout.xml",new List<string> {   "comboBoxEditFecha",
                                                                                                                    "simpleButtonActualizar",
                                                                                                                    "simpleButtonLeerPedidos",
                                                                                                                    "gridControlOrders","gridViewOrders",
                                                                                                                    "gridControlLineas","gridViewLineas",
                                                                                                                    "memoEdit1",
                                                                                                                    "simpleButton1"});
            }
        }

        private void handleDestroyed(object sender, EventArgs e)
        {
            gridViewOrders.SaveLayoutToXml("Layouts\\LeerPedidosAmazon\\gridViewOrders.xml");
            gridViewLineas.SaveLayoutToXml("Layouts\\LeerPedidosAmazon\\gridViewLineas.xml");
            layoutControl1.SaveLayoutExToXml("Layouts\\LeerPedidosAmazon\\layout.xml");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime inicio = DateTime.Now;
            MyEntityModel.Amazon amazon = new MyEntityModel.Amazon();
            amazon.eventAntesPagina += Amazon_eventAntesPagina;
            amazon.eventDespuesPagina += Amazon_eventDespuesPagina;
            amazon.eventAntesRetardoTroleo += Amazon_eventAntesRetardoTroleo;
            amazon.eventError += Amazon_eventError;
            amazon.eventAntesRetardoTroleoLinea += Amazon_eventAntesRetardoTroleoLinea;
            amazon.eventDespuesRetardoTroleoLinea += Amazon_eventDespuesRetardoTroleoLinea;
            amazon.eventAntesLinea += Amazon_eventAntesLinea;
            memoEdit1.Text += string.Format("Empezando {0}" + Environment.NewLine, inicio.ToString("f"));
            amazon.LeerPedidos(DateTime.Now, "Red_Planet","");
            memoEdit1.Text += string.Format("Terminado {0}" + Environment.NewLine, DateTime.Now.ToString("f"));
            TimeSpan span = (DateTime.Now - inicio);
            memoEdit1.Text += string.Format("Tiempo empleado {0} days, {1} hours, {2} minutes, {3} seconds" + Environment.NewLine, span.Days, span.Hours, span.Minutes, span.Seconds);
        }

        private void Amazon_eventAntesRetardoTroleoLinea(EventosAmazon e)
        {
            string texto = string.Format("{0} Troleado en la Linea {2} de la pagina {3} Esperando {1} segundos" + Environment.NewLine, DateTime.Now.ToString("f"), e.retardo / 1000, e.linea, e.pagina);
            Debug.WriteLine(texto);
            memoEdit1.Invoke((MethodInvoker)(() => memoEdit1.Text += texto));
            Application.DoEvents();
        }

        private void Amazon_eventAntesLinea(EventosAmazon e)
        {
            string texto = string.Format("{0} Leyendo Linea {1} de la pagina {2} " + Environment.NewLine, DateTime.Now.ToString("f"), e.linea, e.pagina);
            Debug.WriteLine(texto);
            memoEdit1.Invoke((Action)delegate
            {
                memoEdit1.Text += texto;
            });
            Application.DoEvents();
        }

        private void Amazon_eventDespuesRetardoTroleoLinea(EventosAmazon e)
        {
            string texto = string.Format("{0} Troleado en la Linea {2} de la pagina {3} Esperando {1} segundos" + Environment.NewLine, DateTime.Now.ToString("f"), e.retardo / 1000, e.linea, e.pagina);
            Debug.WriteLine(texto);
            memoEdit1.Invoke((MethodInvoker)(() => memoEdit1.Text += texto));
            Application.DoEvents();
        }

        private void Amazon_eventError(EventosAmazon e)
        {
            memoEdit1.Invoke((MethodInvoker)(() => memoEdit1.Text += string.Format("Error {0}" + Environment.NewLine, e.error)));
        }

        private void Amazon_eventAntesPagina(EventosAmazon e)
        {
            memoEdit1.Invoke((MethodInvoker)(() => memoEdit1.Text += string.Format("Leyendo Página {0}" + Environment.NewLine,e.pagina)));
            Application.DoEvents();
        }
        private void Amazon_eventDespuesPagina(EventosAmazon e)
        {
//            main.barStaticItemEstado.Caption = "Leida Página: " + e.pagina.ToString();
            Application.DoEvents();
        }
        private void Amazon_eventAntesRetardoTroleo(EventosAmazon e)
        {
            //            main.barStaticItemEstado.Caption = "Troleado" + e.pagina.ToString();
            memoEdit1.Invoke((MethodInvoker)(() => memoEdit1.Text += string.Format("{0} Troleado en la página {2} Esperando {1} segundos"+ Environment.NewLine,DateTime.Now.ToString("f"),e.retardo/1000,e.pagina)));
            Application.DoEvents();
        }

        private void simpleButtonActualizar_Click(object sender, EventArgs e)
        {
            ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
            gridControlOrders.DataSource=dbContext.amazonorders.OrderByDescending(o => o.purchaseDate).ToList();
        }

        private void layoutControl1_BeforeLoadLayout(object sender, DevExpress.Utils.LayoutAllowEventArgs e)
        {
            if (e.PreviousVersion != layoutControl1.LayoutVersion)
                e.Allow = false;
            else
                e.Allow = true;
        }

        private void gridViewOrders_Click(object sender, EventArgs e)
        {
            ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
            string amazonOrderID = (string)gridViewOrders.GetRowCellValue(gridViewOrders.FocusedRowHandle, colAmazonOrderID);
            gridControlLineas.DataSource = dbContext.amazonorderLineas.Where(w => w.AmazonOrderID == amazonOrderID).ToList();
        }

        private void memoEdit1_TextChanged(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                SetSelection();
            }));
        }
        private void SetSelection()
        {
            memoEdit1.SelectionStart = memoEdit1.Text.Length;
            memoEdit1.ScrollToCaret();
        }

        private void probar (int i)
        {
            //            memoEdit1.Invoke((MethodInvoker)(() => memoEdit1.Text += string.Format("numero: {0}" + Environment.NewLine, i)));
            //            memoEdit1.Invoke((MethodInvoker)(() => memoEdit1.Lines.ToList().Add("a")));

            simpleButton1.Invoke((Action)delegate
            {
                simpleButton1.Text = i.ToString();
                Application.DoEvents();
            });
        }
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            List<int> lista = new List<int>();
            for (int i = 0; i < 50000; i++)
            {
                lista.Add(i);
            }
            Task t = new Task(
                () =>
                {
                    Parallel.ForEach(lista, new ParallelOptions { MaxDegreeOfParallelism = 4 }, i =>
                    {

                        probar(i);
                    });
                    Debug.WriteLine("terminado");
                    simpleButtonActualizar.Invoke((Action)delegate
                    {
                        simpleButtonActualizar.Text ="Terminado";
 //                       Application.DoEvents();
                    });
                });
            t.Start();
     
        }
    }
}
