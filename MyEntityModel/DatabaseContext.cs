using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    public class ApplicationDbContextSql : DbContext
    {


        public ApplicationDbContextSql() : base("DatabaseContext")
        {
            //var adapter = (IObjectContextAdapter)this;
            //var objectContext = adapter.ObjectContext;
            //objectContext.CommandTimeout = 6000;// 10 minutos
            //Database.SetInitializer<ApplicationDbContextSql>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //            Database.SetInitializer<ApplicationDbContextSql>(null);
            //            base.OnModelCreating(modelBuilder);

        }
        private static string ConnectionString()
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = "185.72.2.187";
            sqlBuilder.InitialCatalog = "Gestion";
            sqlBuilder.IntegratedSecurity = false;
            sqlBuilder.UserID = "Pepe";
            sqlBuilder.Password = "Veleoliva2011";
            return sqlBuilder.ToString();
        }

        public bool SiTieneEscandallo(int ArticuloID)
        {
            int a = this.Escandallos.Where(w => w.ArticuloID == ArticuloID).Count();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private decimal _Costo(int ArticuloID)
        {
            decimal a;
            return a = this.Articulos.Where(w => w.ArticuloID == ArticuloID).FirstOrDefault().Costo;
        }
        public decimal fnCosto(int ArticuloID)
        {
            if (SiTieneEscandallo(ArticuloID))
            {
                decimal costo = 0;
                var costos_ = Escandallos.Where(w => w.ArticuloID == ArticuloID).Select(s => new { s.DetalleID, s.Unidades }).ToList();
                foreach (var costo_ in costos_)
                {
                    costo += _Costo(costo_.DetalleID) * costo_.Unidades;
                }
                return costo;
            }
            else
            {
                return _Costo(ArticuloID);
            }
        }

        public decimal fnCosto(string codigo)
        {
            int ArticuloID = this.Articulos.Where(w => w.Codigo == codigo).FirstOrDefault().ArticuloID;
            return fnCosto(ArticuloID);
        }
        public System.Data.Entity.DbSet<MyEntityModel.Articulo> Articulos { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.Iva> Ivas { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.Recargo> Recargos { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.Retencion> Retenciones { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.TipoArticulo> TipoArticulos { get; set; }

        public System.Data.Entity.DbSet<MyEntityModel.Cabecera> Cabeceras { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.Linea> Lineas { get; set; }

        public System.Data.Entity.DbSet<MyEntityModel.Cliente> Clientes { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.Escandallo> Escandallos { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.WebsElectronicaPagina> WebsElectronicaPaginas { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.WebsElectronicaArticulo> WebsElectronicaArticulo { get; set; }

        public System.Data.Entity.DbSet<MyEntityModel.TiendaHugo> TiendasHugo { get; set; }

        public System.Data.Entity.DbSet<MyEntityModel.Viaje> viaje { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.ViajeResources> viajeresources { get; set; }

        public System.Data.Entity.DbSet<MyEntityModel.AmazonOrder> amazonorders { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.AmazonOrderLinea> amazonorderLineas { get; set; }
        public DbSet<AmazonSeguimiento> AmazonSeguimientos { get; set; }
        public DbSet<AmazonFeed> amazonfeeds { get; set; }

 //       public DbSet<EbaySeguimiento> ebayseguimientos { get; set; }
        public DbSet<EbayFormasEnvio> ebayformasEnvio { get; set; }
        public DbSet<Datos> datos { get; set; }
        public DbSet<EbayProfiles> ebayprofiles { get; set; }
        public DbSet<ComisionesEbay> comisionesEbay { get; set; }
        public System.Data.Entity.DbSet<EbayOrder> EbayOrder { get; set; }
        public System.Data.Entity.DbSet<EbayOrderLinea> EbayOrderLinea { get; set; }
        public System.Data.Entity.DbSet<LlamadasApis> LlamadasApis { get; set; }
    }

    public class RepuestosDeMovilesDbContext : DbContext
    {
        public RepuestosDeMovilesDbContext()
           : base("cristalesyfundasEntities")
        {
            Database.SetInitializer<RepuestosDeMovilesDbContext>(null);
            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 5000 * 60; // value in seconds


        }
        public System.Data.Entity.DbSet<MyEntityModel.COSTOS_ENVIOS_NOMBRES> COSTOS_ENVIOS_NOMBRES { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.COSTOS_ENVIOS_PESOS> COSTOS_ENVIOS_PESOS { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.AMAZON_SEGUIMIENTO> AMAZON_SEGUIMIENTO { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.AmazonEnVenta> AmazonEnVenta { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.EBAY_SEGUIMIENTO> EBAY_SEGUIMIENTO { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.L_ENVIOS> L_ENVIOS { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.L_PEDIDOS> L_PEDIDOS { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.EBAY_CATEGORIAS> EBAY_CATEGORIAS { get; set; }
        public AmazonPeso LeerAmazonPeso(int ArticuloID)
        {
            var amazonpeso = new AmazonPeso();
            amazonpeso.ArticuloID = ArticuloID;
            amazonpeso.Peso = ArticuloID + 1;
            return amazonpeso;
        }
        private int Ventas(string codigo, string cuenta, int dias)
        {
            CredencialesEbay credencialesEbay = new CredencialesEbay();
            int ArticuloID = 0;
            int i = credencialesEbay.Cuentas.IndexOf(cuenta);
            if (i < 0)
            {
                Debug.WriteLine("Funcion Ventas Codigo error IndexOf: " + codigo + " CUenta: " + cuenta);
                return 0;
            }
            cuenta = credencialesEbay.InicialesCuentas[i];
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
        public string LeerArticuloEbay(String ArticuloID, string cuenta, string articulo_mio, string codigo)
        {
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
                Item = ap.GetItem(ArticuloID);
            }
            catch (ApiException oApiEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                Console.WriteLine("1 " + oApiEx.Message);
                return oApiEx.Message;
            }
            catch (SdkException oSdkEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                Console.WriteLine("2 " + oSdkEx.Message);
                return oSdkEx.Message;
            }
            catch (Exception oEx)
            {
                // process exception ... pass to caller, implement retry logic here or in caller, whatever you want to do
                Console.WriteLine("3 " + oEx.Message);
                return oEx.Message;
            }
            EBAY_SEGUIMIENTO ebay_seguimiento = new EBAY_SEGUIMIENTO();
            try
            {
                ebay_seguimiento = dbContext.EBAY_SEGUIMIENTO.Where(w => w.ARTICULO == Item.ItemID).FirstOrDefault();
            }
            catch (Exception edb)
            {
                Console.WriteLine("Error en dbContext " + edb);
            }
            if (ebay_seguimiento != null)
            {
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
                ebay_seguimiento.PictureURL = string.Join("\t", Item.PictureDetails.PictureURL.ToArray());
                dbContext.SaveChanges();
                return "";
            }
            else
            {
                ebay_seguimiento = new EBAY_SEGUIMIENTO();
                ebay_seguimiento.VENDEDOR = Item.Seller.UserID;
                ebay_seguimiento.ARTICULO = Item.ItemID;
                ebay_seguimiento.CODIGO = codigo;
                ebay_seguimiento.TITULO = Item.Title;
                ebay_seguimiento.SUBTITULO = Item.SubTitle;
                ebay_seguimiento.Descripcion = Item.Description;
                ebay_seguimiento.DISPONIBLES = Item.Quantity - Item.SellingStatus.QuantitySold;
                ebay_seguimiento.ENVIO = (decimal?)Item.ShippingDetails.ShippingServiceOptions[0].ShippingServiceCost.Value;
                ebay_seguimiento.IMAGEN_EBAY = Item.PictureDetails.PictureURL[0];
                ebay_seguimiento.PRECIO = (decimal?)Item.StartPrice.Value;
                ebay_seguimiento.VENDIDOS = Item.SellingStatus.QuantitySold;
                ebay_seguimiento.VENDIDOS_SEMANA = Ventas(ebay_seguimiento.ARTICULO_MIO, ebay_seguimiento.VENDEDOR, 7);
                ebay_seguimiento.VENDIDOS_MES = Ventas(ebay_seguimiento.ARTICULO_MIO, ebay_seguimiento.VENDEDOR, 30);
                ebay_seguimiento.FECHA = DateTime.Now;
                ebay_seguimiento.PictureURL = string.Join("\t", Item.PictureDetails.PictureURL);
                dbContext.EBAY_SEGUIMIENTO.Add(ebay_seguimiento);
                dbContext.SaveChanges();
            }
            return "";
        }


    }
}
