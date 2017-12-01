using MyEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_WF.Articulos
{
    public partial class VerEscandalloPopUP : Form
    {
        List<EscandalloPintar> escandalloPintar = new List<EscandalloPintar>();
        public string codigo
        { set
            {
                ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
                int articuloID = dbContext.Articulos.Where(w => w.Codigo == value).FirstOrDefault().ArticuloID;
                List<Escandallo> escandallos = dbContext.Escandallos.Where(w => w.ArticuloID == articuloID).ToList();
                foreach (Escandallo escandallo in escandallos)
                {
                    Articulo articulo = dbContext.Articulos.Where(w => w.ArticuloID == escandallo.DetalleID).FirstOrDefault();
                    escandalloPintar.Add(new EscandalloPintar { codigo = articulo.Codigo.Trim(), ArticuloID = articulo.ArticuloID, unidades = escandallo.Unidades, nombre = articulo.Nombre, costo = articulo.Costo, peso = articulo.PesoNeto ,stock = (int)articulo.comprados-(int)articulo.Vendidos});
                }
                gridControlEscandallo.DataSource = escandalloPintar.ToList();
            }
        }
        public VerEscandalloPopUP()
        {
            InitializeComponent();
          
         }

        private void gridViewEscandallo_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            EscandalloPintar row = (EscandalloPintar)gridViewEscandallo.GetRow(e.RowHandle);
            RepuestosDeMovilesDbContext dbContextRepuestos = new RepuestosDeMovilesDbContext();
            List<L_ENVIOS> l_envios = dbContextRepuestos.L_ENVIOS.Where(w => w.ARTICULO == row.codigo).OrderByDescending(o => o.CABECERA).ToList();
            gridControlEnvios.DataSource = l_envios;
        }
    }
    class EscandalloPintar
    {
        public string codigo { get; set; }
        public int ArticuloID { get; set; }
        public int unidades {get;set;}
        public string nombre { get; set; }
        public decimal costo { get; set; }
        public int peso { get; set; }
        public int stock { get; set; }
    }
    
}
