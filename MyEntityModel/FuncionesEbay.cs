using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEntityModel
{
    public class FuncionesEbay
    {

        static void fnNotificacion(string texto)
        {
            return;
            var notification = new NotifyIcon()
            {
                Visible = true,
                Icon = SystemIcons.Information,
                // optional - BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
                // optional - BalloonTipTitle = "My Title",
                BalloonTipText = texto,
            };

            // Display for 5 seconds.
            notification.ShowBalloonTip(100);

            // This will let the balloon close after it's 5 second timeout
            // for demonstration purposes. Comment this out to see what happens
            // when dispose is called while a balloon is still visible.
            Thread.Sleep(200);

            // The notification should be disposed when you don't need it anymore,
            // but doing so will immediately close the balloon if it's visible.
            notification.Dispose();
        }

        public static ItemType LeerArticuloEbay(String ArticuloID)
        {
            MyEntityModel.RepuestosDeMovilesDbContext dbContext = new MyEntityModel.RepuestosDeMovilesDbContext();
            EBAY_SEGUIMIENTO es = dbContext.EBAY_SEGUIMIENTO.Where(w => w.ARTICULO == ArticuloID).FirstOrDefault();
            if (es != null)
            {
                return LeerArticuloEbay(ArticuloID, es.VENDEDOR);
            }
            return null;
        }
        public static ItemType LeerArticuloEbay(String ArticuloID, string cuenta)
        {
            new Thread(delegate () {
                fnNotificacion(" Leyendo " + ArticuloID);
            }).Start();
            
            MyEntityModel.RepuestosDeMovilesDbContext dbContext = new MyEntityModel.RepuestosDeMovilesDbContext();
            MyEntityModel.ApplicationDbContextSql dbContextSql = new MyEntityModel.ApplicationDbContextSql();
            CredencialesEbay credencialeebay = new CredencialesEbay();
            credencialeebay.cuenta = cuenta;
            ItemType Item;
            GetItemCall ap = new GetItemCall(credencialeebay.context);
            ap.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
            ap.IncludeItemSpecifics = true;

            try
            {
                Notificacion(ArticuloID, 1);
                Item = ap.GetItem(ArticuloID);
            }
            catch (ApiException oApiEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                Debug.WriteLine("1 " + oApiEx.Message);
                fnGrabarErrorEbayArticulo(ArticuloID, oApiEx.Message);
                return null;
            }
            catch (SdkException oSdkEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                Debug.WriteLine("2 " + oSdkEx.Message);
                fnGrabarErrorEbayArticulo(ArticuloID, oSdkEx.Message);
                return null;
            }
            catch (Exception oEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                Debug.WriteLine("3 " + oEx.Message);
                fnGrabarErrorEbayArticulo(ArticuloID, oEx.Message);
                return null;
            }
            EBAY_SEGUIMIENTO ebay_seguimiento = new EBAY_SEGUIMIENTO();
            try
            {
                ebay_seguimiento = dbContext.EBAY_SEGUIMIENTO.Where(w => w.ARTICULO == Item.ItemID).FirstOrDefault();
            }
            catch (Exception edb)
            {
                Debug.WriteLine("Error en dbContext " + edb);
            }
            if (ebay_seguimiento != null)
            {
                Debug.WriteLine("Articulo " + ArticuloID + " Leido");
                fnCopiarArticuloEbaySeguimiento(Item, ebay_seguimiento);
                try
                {
                    dbContext.SaveChanges();
                    Debug.WriteLine("Articulo " + ArticuloID + " Grabado");
                }
                catch
                {
                    Debug.WriteLine("Articulo " + ArticuloID + " ****** ERROR AL GRABAR ******");
                }
            }
            return Item;
        }

        public static void fnCopiarArticuloEbaySeguimiento(ItemType Item,EBAY_SEGUIMIENTO ebay_seguimiento)
        {
            ebay_seguimiento.ARTICULO = Item.ItemID;
            ebay_seguimiento.Descripcion = Item.Description;
            ebay_seguimiento.DISPONIBLES = Item.Quantity - Item.SellingStatus.QuantitySold;
            ebay_seguimiento.ENVIO = (decimal?)Item.ShippingDetails.ShippingServiceOptions[0].ShippingServiceCost.Value;
            ebay_seguimiento.IMAGEN_EBAY = Item.PictureDetails.PictureURL[0];
            ebay_seguimiento.PRECIO = (decimal?)Item.StartPrice.Value;
            ebay_seguimiento.SUBTITULO = Item.SubTitle;
            ebay_seguimiento.TITULO = Item.Title;
            ebay_seguimiento.VENDIDOS = Item.SellingStatus.QuantitySold;
            ebay_seguimiento.VENDIDOS_SEMANA = Ventas(ebay_seguimiento.ARTICULO_MIO, ebay_seguimiento.VENDEDOR, 7);
            ebay_seguimiento.VENDIDOS_MES = Ventas(ebay_seguimiento.ARTICULO_MIO, ebay_seguimiento.VENDEDOR, 30);
            ebay_seguimiento.FECHA = DateTime.Now;
            ebay_seguimiento.VENDEDOR = Item.Seller.UserID;
            ebay_seguimiento.PRECIO_VENTA = ebay_seguimiento.PRECIO + ebay_seguimiento.ENVIO;
            ebay_seguimiento.StoreCategoryID = Item.Storefront.StoreCategoryID;
            ebay_seguimiento.StoreCategory2ID = Item.Storefront.StoreCategory2ID;
            ebay_seguimiento.PrimaryCategoryID=Item.PrimaryCategory.CategoryID.ToString();
            if (Item.SecondaryCategory != null)
                ebay_seguimiento.SecondaryCategoryID = Item.SecondaryCategory.CategoryID.ToString();
            if (Item.SellerProfiles != null)
            {
                if (Item.SellerProfiles.SellerPaymentProfile != null)
                    ebay_seguimiento.ProfileIDPayment = Item.SellerProfiles.SellerPaymentProfile.PaymentProfileID;
                if (Item.SellerProfiles.SellerShippingProfile != null)
                    ebay_seguimiento.ProfileIDShipping = Item.SellerProfiles.SellerShippingProfile.ShippingProfileID;
            }
            ebay_seguimiento.TextoError = "";
        }


        public static void fnAnadirCompetenciaSeguimiento(ItemType item,string codigoActual)
        {
            EBAY_SEGUIMIENTO ebay_seguimiento = new EBAY_SEGUIMIENTO();
            fnCopiarArticuloEbaySeguimiento(item, ebay_seguimiento);
            ebay_seguimiento.CODIGO = codigoActual;
            RepuestosDeMovilesDbContext dbcontext = new RepuestosDeMovilesDbContext();
            dbcontext.EBAY_SEGUIMIENTO.Add(ebay_seguimiento);
            dbcontext.SaveChanges();
        }
        public static int Ventas(string codigo, string cuenta, int dias)
        {
            CredencialesEbay credencialeebay = new CredencialesEbay();
            int ArticuloID = 0;
            int i = credencialeebay.Cuentas.IndexOf(cuenta);
            if (i < 0)
            {
                Debug.WriteLine("Funcion Ventas Codigo error IndexOf: " + codigo + " CUenta: " + cuenta);
                return 0;
            }
            cuenta = credencialeebay.InicialesCuentas[i];
            DateTime today = DateTime.Now;
            DateTime semana = today.AddDays(-1 * dias);
            try
            {
                MyEntityModel.ApplicationDbContextSql dbContextSql = new MyEntityModel.ApplicationDbContextSql();
                ArticuloID = dbContextSql.Articulos.Where(w => w.Codigo == codigo).FirstOrDefault().ArticuloID;
            }
            catch (Exception e)
            {
                Console.WriteLine("B" + e.Message + " " + e.InnerException);
            }

            var SiEscandalloDbcontext = new MyEntityModel.ApplicationDbContextSql();
            bool SiEscandallo = SiEscandalloDbcontext.SiTieneEscandallo(ArticuloID);
            int vendidos = 0;
            if (SiEscandallo == false)
            {
                try
                {
                    MyEntityModel.ApplicationDbContextSql dbContextSql = new MyEntityModel.ApplicationDbContextSql();
                    vendidos = dbContextSql.Lineas.Where(w => w.ArticuloID == ArticuloID && w.Fecha >= semana && w.Historial.StartsWith(cuenta) && w.Unidades > 0).Sum(s => (int?)s.Unidades) ?? 0;
                }
                catch (Exception e)
                {
                    Console.WriteLine("C " + e.Message + " " + e.InnerException);
                }
                return vendidos;
            }                        // Si Escandallo == true
            else
            {
                try
                {
                    MyEntityModel.ApplicationDbContextSql dbContextSql = new MyEntityModel.ApplicationDbContextSql();
                    vendidos = dbContextSql.Lineas.Where(w => w.ArticuloCompradoID == ArticuloID && w.Fecha >= semana && w.Historial.StartsWith(cuenta) && w.Unidades > 0).Sum(s => (int?)s.UnidadesArticuloComprado) ?? 0;
                }
                catch (Exception e)
                {
                    Console.WriteLine("C " + e.Message + " " + e.InnerException);
                }
                return vendidos;
            }
        }

        private static void Notificacion(string texto, int segundos)
        {
        //    new Thread(() =>
        //    {
        //        Thread.CurrentThread.IsBackground = true;
        //        var notification = new System.Windows.Forms.NotifyIcon()
        //        {
        //            Visible = true,
        //            Icon = System.Drawing.SystemIcons.Information,
        //            BalloonTipText = texto,
        //            BalloonTipTitle = "Leyendo el art.:"
        //        };
        //        notification.ShowBalloonTip(segundos * 1000);
        //        Thread.Sleep(100);
        //        Thread.Sleep(segundos * 1000);
        //        notification.Dispose();
        //    }).Start();


        }

        public static int fnArticuloID(string codigo)
        {
            MyEntityModel.ApplicationDbContextSql dbContextSQL = new MyEntityModel.ApplicationDbContextSql();
            return dbContextSQL.Articulos.Where(w => w.Codigo == codigo).FirstOrDefault().ArticuloID;
        }
        public static void fnCodigosEsteMaestro(string codigo, List<string> ListaCodigos)
        {
            IList<MyEntityModel.Escandallo> Escandallos;
            MyEntityModel.ApplicationDbContextSql dbContextSQL = new MyEntityModel.ApplicationDbContextSql();

            int ArticuloID = FuncionesEbay.fnArticuloID(codigo);
            if (ArticuloID != 0)
            {
                Escandallos = dbContextSQL.Escandallos.Where(w => w.ArticuloID == ArticuloID).ToList();
                foreach (var escandallo in Escandallos)
                {
                    string c = dbContextSQL.Articulos.Where(w => w.ArticuloID == escandallo.DetalleID).FirstOrDefault().Codigo;
                    ListaCodigos.Add(c.Trim());
                }
            }
        }
        public static void fnCodigosEsteDetalle(string codigo, List<string> ListaCodigos)
        {
            IList<MyEntityModel.Escandallo> Escandallos;
            MyEntityModel.ApplicationDbContextSql dbContextSQL = new MyEntityModel.ApplicationDbContextSql();

            // primero busco todos los escandallos en los que este artículo es detalle
            int ArticuloID = FuncionesEbay.fnArticuloID(codigo);
            if (ArticuloID != 0)
            {
                Escandallos = dbContextSQL.Escandallos.Where(w => w.DetalleID == ArticuloID).ToList();
                foreach (var escandallo in Escandallos)
                {
                    string c = dbContextSQL.Articulos.Where(w => w.ArticuloID == escandallo.ArticuloID).FirstOrDefault().Codigo;
                    ListaCodigos.Add(c.Trim());
                }
            }
        }

        public static List<string> fnListaCodigos(string codigo)
        {
            List<string> ListaCodigos = new List<string>();
            ListaCodigos.Add(codigo.Trim());
            FuncionesEbay.fnCodigosEsteDetalle(codigo, ListaCodigos); // todos los codigos en el que este es detalle
            FuncionesEbay.fnCodigosEsteMaestro(codigo, ListaCodigos);

            List<string> LC = new List<string>();
            LC = ListaCodigos.ToList();
            foreach (string c in LC)
            {
                FuncionesEbay.fnCodigosEsteDetalle(codigo, ListaCodigos);
                FuncionesEbay.fnCodigosEsteMaestro(codigo, ListaCodigos);
            }
            ListaCodigos = ListaCodigos.Distinct().ToList();
            return (ListaCodigos);
        }

        public static void fnGrabarErrorEbayArticulo(string articulo, string error)
        {
            MyEntityModel.RepuestosDeMovilesDbContext dbContext = new MyEntityModel.RepuestosDeMovilesDbContext();
            EBAY_SEGUIMIENTO ebay_seguimiento = new EBAY_SEGUIMIENTO();
            try
            {
                ebay_seguimiento = dbContext.EBAY_SEGUIMIENTO.Where(w => w.ARTICULO == articulo).FirstOrDefault();
            }
            catch (Exception edb)
            {
                Console.WriteLine("Error en dbContext " + edb);
                return;
            }
            if (ebay_seguimiento == null)
                return;
            ebay_seguimiento.TextoError = error;
            try
            {
                dbContext.SaveChanges();
            }
            catch
            {

            }
        }

        public class ArticulosEnEscandallo
        {
            public string Nombre { get; set; }
            public int ArticuloId { get; set; }
            public string Codigo { get; set; }
            public int PesoNeto { get; set; }
            public int PesoBruto { get; set; }
            public decimal Costo { get; set; }
            public SiNo Imprimir { get; set; }
            public SiNo Precio { get; set; }
            public int Unidades { get; set; }

        }
        public static List<ArticulosEnEscandallo> fnArticulosEnEscandallo(int articuloID)
        {
            List<ArticulosEnEscandallo> articulosEnEscandallo = new List<ArticulosEnEscandallo>();
            ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
            List<Escandallo> escandallos = dbContext.Escandallos.Where(w => w.ArticuloID == articuloID).ToList();
            foreach (Escandallo escandallo in escandallos)
            {
                try
                {
                    Articulo articulo = dbContext.Articulos.Where(w => w.ArticuloID == escandallo.DetalleID).FirstOrDefault();
                    articulosEnEscandallo.Add(new ArticulosEnEscandallo
                    {
                        Nombre = articulo.Nombre,
                        ArticuloId = escandallo.DetalleID,
                        Codigo = articulo.Codigo.Trim(),
                        PesoNeto = articulo.PesoNeto,
                        PesoBruto = articulo.PesoBruto,
                        Costo = articulo.Costo,
                        Imprimir = escandallo.Imprimir,
                        Precio = escandallo.Precio,
                        Unidades = escandallo.Unidades
                    });
                }
                catch
                {
                    Debug.WriteLine("Error en el escandallo del artículoID " + articuloID.ToString());
                }
            }
            if (articulosEnEscandallo.Count == 0)
            {
                Articulo articulo = dbContext.Articulos.Where(w => w.ArticuloID == articuloID).FirstOrDefault(); 
                articulosEnEscandallo.Add(new ArticulosEnEscandallo
                {
                    Nombre = articulo.Nombre,
                    ArticuloId = articuloID,
                    Codigo = articulo.Codigo.Trim(),
                    PesoNeto = articulo.PesoNeto,
                    PesoBruto = articulo.PesoBruto,
                    Costo = articulo.Costo,
                    Imprimir = SiNo.Si,
                    Precio = SiNo.Si,
                    Unidades = 1
                });
            }
            return articulosEnEscandallo;
        }
        public static List<ArticulosEnEscandallo> fnArticulosEnEscandallo(string codigo)
        {
            ApplicationDbContextSql dbContextSQL = new ApplicationDbContextSql();
            int articuloID = dbContextSQL.Articulos.Where(w => w.Codigo == codigo.Trim()).FirstOrDefault().ArticuloID;
            return fnArticulosEnEscandallo(articuloID);
        }
        public static List<ArticulosEnEscandallo> fnArticulosEnEscandalloEbay(string articuloEbayID)
        {
            int articuloID = 0;
            try
            {
                RepuestosDeMovilesDbContext dbContext = new RepuestosDeMovilesDbContext();
                string codigo = dbContext.EBAY_SEGUIMIENTO.Where(w => w.ARTICULO == articuloEbayID).FirstOrDefault().ARTICULO_MIO.Trim();
                ApplicationDbContextSql dbContextSQL = new ApplicationDbContextSql();
                articuloID = dbContextSQL.Articulos.Where(w => w.Codigo == codigo).FirstOrDefault().ArticuloID;
            }
            catch
            { }
            if (articuloID > 0)
            {
                return fnArticulosEnEscandallo(articuloID);
            }
            else
            {
                return null;
            }

        }
        public static decimal fnCosto(string codigo)
        {
            decimal costo = 0;
            foreach (ArticulosEnEscandallo a in fnArticulosEnEscandallo(codigo))
            {
                costo += a.Costo * a.Unidades;
            }
            return costo;
        }

        public static int fnPeso(string codigo)
        {
            int peso = 0;
            foreach (ArticulosEnEscandallo a in fnArticulosEnEscandallo(codigo))
            {
                peso += a.PesoNeto * a.Unidades;
            }
            return peso;
        }
        public static decimal fnCostoEnvio(int peso,string nombre)
        {
            decimal costo = 0;
            string sql = "Select id from COSTOS_ENVIOS_NOMBRES where nombres like '%" + nombre + "%'";
            RepuestosDeMovilesDbContext dbContext = new RepuestosDeMovilesDbContext();
            int id = dbContext.Database.SqlQuery<int>(sql).FirstOrDefault();
            if (id > 0)
            {
                sql = "Select precio from COSTOS_ENVIOS_PESOS where "+ peso.ToString() +" >= peso_inicial  and peso_final >= " + peso.ToString() + " and id_nombre = " + id.ToString();
                costo = dbContext.Database.SqlQuery<decimal>(sql).FirstOrDefault();
            }
            return costo;
        }


        public static string fnNombreCategoriaRaiz(long categoria)
        {
            string nombre = "";
            RepuestosDeMovilesDbContext dbcontext = new RepuestosDeMovilesDbContext();
            EBAY_CATEGORIAS ebay_categorias = dbcontext.EBAY_CATEGORIAS.Where(w => w.CategoryID == categoria).FirstOrDefault();
            if (ebay_categorias == null)
            {
                Debug.WriteLine("No encuentro la categoria");
                return "";
            }
            nombre = ebay_categorias.CategoryName;
            while (ebay_categorias.CategoryLevel > 1)
            {
                ebay_categorias = dbcontext.EBAY_CATEGORIAS.Where(w => w.CategoryID == ebay_categorias.CategoryParentID).FirstOrDefault();
                if (ebay_categorias == null)
                {
                    Debug.WriteLine("No encuentro la categoria padre");
                    return "";
                }
                nombre =  ebay_categorias.CategoryName;
            }
            return nombre;
        }
        public static string fnNombreCategoria(long categoria)
        {
            string nombre = "";
            RepuestosDeMovilesDbContext dbcontext = new RepuestosDeMovilesDbContext();
            EBAY_CATEGORIAS ebay_categorias = dbcontext.EBAY_CATEGORIAS.Where(w => w.CategoryID == categoria).FirstOrDefault();
            if (ebay_categorias == null)
            {
                Debug.WriteLine("No encuentro la categoria");
                return "";
            }
            nombre = ebay_categorias.CategoryName;
            while (ebay_categorias.CategoryLevel > 1)
            {
                ebay_categorias = dbcontext.EBAY_CATEGORIAS.Where(w => w.CategoryID == ebay_categorias.CategoryParentID).FirstOrDefault();
                if (ebay_categorias == null)
                {
                    Debug.WriteLine("No encuentro la categoria padre");
                    return "";
                }
                nombre += "->" + ebay_categorias.CategoryName;
            }

            return nombre;
        }

        public static SiNo fnCategoriaTecnologica(long categoria)
        {
            RepuestosDeMovilesDbContext dbcontext = new RepuestosDeMovilesDbContext();
            EBAY_CATEGORIAS ebay_categorias = dbcontext.EBAY_CATEGORIAS.Where(w => w.CategoryID == categoria).FirstOrDefault();
            if (ebay_categorias == null)
            {
                Debug.WriteLine("No encuentro la categoria");
                return SiNo.No;
            }
            while (ebay_categorias.CategoryLevel > 1)
            {
                ebay_categorias = dbcontext.EBAY_CATEGORIAS.Where(w => w.CategoryID == ebay_categorias.CategoryParentID).FirstOrDefault();
                if (ebay_categorias == null)
                {
                    Debug.WriteLine("No encuentro la categoria padre");
                    return SiNo.No;
                }
            }
            return ebay_categorias.Tecnologico;
        }

        public static decimal fnComisionEbay(decimal Importe, SiNo Tecnologico)
        {
            if (Tecnologico == SiNo.No)
                return Decimal.Divide(Decimal.Multiply((decimal)7.26,Importe),100);
            else
                return Decimal.Multiply((decimal)3.63, Importe) / 100;
        }
        public static decimal fnComisionPaypal(decimal Importe)
        {
            decimal comision = (decimal)2.9;
            return (decimal)0.35 + (Decimal.Divide(Decimal.Multiply(Importe,comision),100));
        }

        public static decimal fnSpreciodprecio(string snumero)
        {
            snumero=snumero.Replace('.', Convert.ToChar(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator));
            snumero=snumero.Replace(',', Convert.ToChar(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator));
            try
            {
                return Convert.ToDecimal(snumero);
            }
            catch
            {
                throw;
            }
        }
    }
}
