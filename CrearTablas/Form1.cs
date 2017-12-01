using MyEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrearTablas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
  
    }


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

        public System.Data.Entity.DbSet<EbayOrder> EbayOrder { get; set; }
        public System.Data.Entity.DbSet<EbayOrderLinea> EbayOrderLinea { get; set; }


    }

}
