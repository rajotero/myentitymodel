using Borland.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    public class FuncionesInterbase
    {
        public static string connectionstringInterbase = "DriverName=Interbase;Database=" + "192.168.1.250:/datos/2007.gdb" + ";User_Name=" + "SYSDBA" + ";Password=" + "masterkey" +
                                                            ";SQLDialect=3;MetaDataAssemblyLoader=Borland.Data.TDBXInterbaseMetaDataCommandFactory,Borland.Data.DbxReadOnlyMetaData,Version=11.0.5000.0,Culture=neutral," +
                                                            "PublicKeyToken=91d62ebb5b0d1b1b;GetDriverFunc=getSQLDriverINTERBASE;LibraryName=dbxint30.dll;VendorLib=GDS32.DLL";
        public DbConnection getConnection()
        {
            DbConnection c = new TAdoDbxInterBaseConnection();
            c.ConnectionString = "Database=192.168.1.250:\\datos\\2007.gdb;User_Name=sysdba;Password=masterkey";
            return c;
        }

        public void conectar()
        {
            DbConnection conn = getConnection();
            var dbconn = (TAdoDbxConnection)TAdoDbxInterBaseProviderFactory.Instance.CreateConnection();
            dbconn.ConnectionString = connectionstringInterbase; 
            dbconn.Open();
            string sql = "update concepto set Activo = 'NO' where codigo = '4873'";
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine("Updated {0} rows.", rows);

        }

    }
}
