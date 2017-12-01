using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

namespace Gestion_WF.Ebay
{
    public partial class ImportarFacturaEbayUserControl : UserControl
    {

        List<MyEntityModel.EBAY_SEGUIMIENTO> ebay_seguimiento_lista = new List<MyEntityModel.EBAY_SEGUIMIENTO>();
        List<Categorias> categorias_lista = new List<Categorias>();

        public ImportarFacturaEbayUserControl()
        {
            InitializeComponent();
        }
        private void leer()
        {
            MyEntityModel.ApplicationDbContextSql dbContext = new MyEntityModel.ApplicationDbContextSql();
            MyEntityModel.RepuestosDeMovilesDbContext dbcontextRepuestos = new MyEntityModel.RepuestosDeMovilesDbContext();

            TextFieldParser parser = new TextFieldParser(buttonEditFichero.Text, Encoding.Default);
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            string articuloID = "";
            string sprecio = "";
            string concepto;
            decimal comision;
            DateTime fecha;
            decimal precio;
            string sfecha, nombreCategoriaRaiz, nombre;
            long categoria;


            string[] fields;

            while (!parser.EndOfData)
            {
                fields = parser.ReadFields();
                if (fields.Count() == 8)        // linea
                {
                    precio = 0;

                    var values = fields[1].Split(';');
                    if (values.Count() == 2)     // Linea de venta
                    {
                        simpleButtonImportar.Text = articuloID;
                        Application.DoEvents();
                        articuloID = nombreCategoriaRaiz = "";
                        categoria = 0;
                        nombre = fields[1];
                        var values2 = values[1].Split(' ');
                        sprecio = values2[3];
                        precio = MyEntityModel.FuncionesEbay.fnSpreciodprecio(sprecio);
                        concepto = fields[3];
                        comision = MyEntityModel.FuncionesEbay.fnSpreciodprecio(fields[4].Split(' ')[0]);
                        articuloID = fields[2];
                        sfecha = fields[0].Replace("PDT", "");
                        DateTime.TryParseExact(sfecha.Trim(), "dd-MMM-yy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha);

                        MyEntityModel.EBAY_SEGUIMIENTO ebay_seguimiento = ebay_seguimiento_lista.Where(w => w.ARTICULO == articuloID).FirstOrDefault();
                        if (ebay_seguimiento == null)
                        {
                            ebay_seguimiento = dbcontextRepuestos.EBAY_SEGUIMIENTO.Where(w => w.ARTICULO == articuloID).FirstOrDefault();
                            if (ebay_seguimiento != null)
                            {
                                ebay_seguimiento_lista.Add(ebay_seguimiento);
                            }
                        }

                        if (ebay_seguimiento != null)
                        {
                            categoria = Convert.ToInt64(ebay_seguimiento.PrimaryCategoryID);
                            Categorias categoria_lista = categorias_lista.Where(w => w.categoriaID == categoria).FirstOrDefault();
                            if (categoria_lista == null)
                            {
                                nombreCategoriaRaiz = MyEntityModel.FuncionesEbay.fnNombreCategoriaRaiz(categoria);
                                categorias_lista.Add(new Categorias { categoriaID = categoria, NombreRaiz = nombreCategoriaRaiz });
                            }
                            else
                            {
                                nombreCategoriaRaiz = categoria_lista.NombreRaiz;
                            }

                        }

                        MyEntityModel.ComisionesEbay comisionesEbay = new MyEntityModel.ComisionesEbay();
                        try
                        {
                            comisionesEbay.Articulo = articuloID;
                            comisionesEbay.Categoria = categoria;
                            comisionesEbay.Comision = comision;
                            comisionesEbay.Cuenta = "ofertasparati";
                            comisionesEbay.Fecha = fecha;
                            comisionesEbay.Nombre = nombre;
                            comisionesEbay.NombreCategoriaRaiz = nombreCategoriaRaiz;
                            comisionesEbay.Precio = precio;
                            if (precio != 0)
                            {
                                comisionesEbay.Porcentaje = decimal.Multiply(100, comision);
                                comisionesEbay.Porcentaje = decimal.Divide(comisionesEbay.Porcentaje, precio);
                                dbContext.comisionesEbay.Add(comisionesEbay);
                                dbContext.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                }
            }

            parser.Close();

            return;

        }
        private void simpleButtonImportar_Click(object sender, EventArgs e)
        {
            foreach (string linea in memoEdit1.Lines)
            {
                buttonEditFichero.Text = linea;
                Application.DoEvents();
                leer();
            }

  
        }

        private void buttonEditFichero_EditValueChanged(object sender, EventArgs e)
        {

        }

        private class Categorias
        {
            public Int64 categoriaID { get; set; }
            public string NombreRaiz { get; set; }
        }
    }

    
}
