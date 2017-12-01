using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyEntityModel.FuncionesEbay;
using MyEntityModel;
using eBay.Service.Core.Soap;
using Gestion_WF.Articulos;
using DevExpress.XtraEditors;
using eBay.Service.Call;
using System.Net;
using System.IO;
using System.Globalization;
using System.Xml;

namespace Gestion_WF.Ebay
{
    public partial class CostosEbayUserControl : UserControl
    {
        public CostosEbayUserControl()
        {
            InitializeComponent();
        }

        List<ArticulosEnEscandallo> articulosEnEscandallo;
        EBAY_SEGUIMIENTO ebay_seguimiento = new EBAY_SEGUIMIENTO();
        ItemType item = new ItemType();
        SiNo tecnologico;
        string codigo;
        decimal costo;
        decimal comisionEbay, comisionPaypal,costoEnvio;

        private void buttonEditVenta_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            decimal precio;
            var result = XtraInputBox.Show("Nuevo precio:", "Cambiar precio de venta (envío NO incluido)",ebay_seguimiento.PRECIO.ToString());
            if (result != "")
            {
                try
                {
                    precio = fnSpreciodprecio(result);
                    ItemType item = new ItemType();
                    item.ItemID = ebay_seguimiento.ARTICULO;
                    CredencialesEbay credencialeebay = new CredencialesEbay();
                    credencialeebay.cuenta = ebay_seguimiento.VENDEDOR;
                    ReviseFixedPriceItemCall reviseFP = new ReviseFixedPriceItemCall(credencialeebay.context);
                    item.StartPrice = new AmountType { currencyID = CurrencyCodeType.EUR, Value = (double)precio };
                    item.ItemID = ebay_seguimiento.ARTICULO;
                    reviseFP.Item = item;
                    try
                    {
                        reviseFP.Execute();
                        FuncionesEbay.fnGrabarErrorEbayArticulo(ebay_seguimiento.ARTICULO, "");
                    }
                    catch (Exception ex)
                    {
                        FuncionesEbay.fnGrabarErrorEbayArticulo(ebay_seguimiento.ARTICULO, ex.Message);
                    }
                    Console.WriteLine(reviseFP.ApiResponse.Ack + " Revised SKU " + reviseFP.ItemID);

                }
                catch
                {
                    XtraMessageBox.Show("Error en el precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonEditCosto_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //decimal costo;
            //var result = XtraInputBox.Show("Nuevo costo:", "Cambiar el costo", ebay_seguimiento.PRECIO.ToString());
            //if (result != "")
            //{
            //    try
            //    {
            //        precio = fnSpreciodprecio(result);
            //        ItemType item = new ItemType();
            //        item.ItemID = ebay_seguimiento.ARTICULO;
            //        CredencialesEbay credencialeebay = new CredencialesEbay();
            //        credencialeebay.cuenta = ebay_seguimiento.VENDEDOR;
            //        ReviseFixedPriceItemCall reviseFP = new ReviseFixedPriceItemCall(credencialeebay.context);
            //        item.StartPrice = new AmountType { currencyID = CurrencyCodeType.EUR, Value = (double)precio };
            //        item.ItemID = ebay_seguimiento.ARTICULO;
            //        reviseFP.Item = item;
            //        try
            //        {
            //            reviseFP.Execute();
            //            FuncionesEbay.fnGrabarErrorEbayArticulo(ebay_seguimiento.ARTICULO, "");
            //        }
            //        catch (Exception ex)
            //        {
            //            FuncionesEbay.fnGrabarErrorEbayArticulo(ebay_seguimiento.ARTICULO, ex.Message);
            //        }
            //        Console.WriteLine(reviseFP.ApiResponse.Ack + " Revised SKU " + reviseFP.ItemID);

            //    }
            //    catch
            //    {
            //        XtraMessageBox.Show("Error en el precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void borrarContenido()
        {
            buttonEditVenta.Invoke((MethodInvoker)(() => buttonEditVenta.Text = ""));
            buttonEditCosto.Invoke((MethodInvoker)(() => buttonEditCosto.Text = ""));
            textEditPeso.Invoke((MethodInvoker)(() => textEditPeso.Text = ""));
            buttonEditShippingProfileName.Invoke((MethodInvoker)(() => buttonEditShippingProfileName.Text = ""));
            textEditCostoEnvio.Invoke((MethodInvoker)(() => textEditCostoEnvio.Text = ""));
            textEditComisionEbay.Invoke((MethodInvoker)(() => textEditComisionEbay.Text = ""));
            textEditcomisionPaypal.Invoke((MethodInvoker)(() => textEditcomisionPaypal.Text = ""));
            textEditBeneficio.Invoke((MethodInvoker)(() => textEditBeneficio.Text = ""));
            textEditunidadesDisponible.Invoke((MethodInvoker)(() => textEditunidadesDisponible.Text = ""));

        }
        public string articuloEbayID
        {
            set
            {
                RepuestosDeMovilesDbContext dbContextRepuestos = new RepuestosDeMovilesDbContext();
                ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
                ebay_seguimiento = dbContextRepuestos.EBAY_SEGUIMIENTO.Where(w => w.ARTICULO == value).FirstOrDefault();
                if (ebay_seguimiento == null)
                {
                    borrarContenido();
                    return;
                }
                   
                EbayProfiles profile =  dbContext.ebayprofiles.Where(w => w.profileId == ebay_seguimiento.ProfileIDShipping).FirstOrDefault();
                if (profile == null)
                {
                    borrarContenido();
                    return;
                }
                articulosEnEscandallo = fnArticulosEnEscandallo(ebay_seguimiento.ARTICULO_MIO.Trim());
                buttonEditVenta.Text = (ebay_seguimiento.PRECIO + ebay_seguimiento.ENVIO).ToString();
                costo = fnCosto(ebay_seguimiento.ARTICULO_MIO.Trim());
                buttonEditCosto.Text = costo.ToString();
                int peso = fnPeso(ebay_seguimiento.ARTICULO_MIO.Trim());
                textEditPeso.Text = peso.ToString();
                buttonEditShippingProfileName.Text = profile.SPI_shippingPolicyName;
                costoEnvio = fnCostoEnvio(peso, profile.SPI_DSPIS_shippingService_0);
                textEditCostoEnvio.Text=costoEnvio.ToString();
                fnNombreCategoria(Convert.ToInt64(ebay_seguimiento.PrimaryCategoryID));
                tecnologico = fnCategoriaTecnologica(Convert.ToInt64(ebay_seguimiento.PrimaryCategoryID));
                textEditComisionEbay.Text = fnComisionEbay((decimal)ebay_seguimiento.PRECIO_VENTA, tecnologico).ToString();
                textEditcomisionPaypal.Text = fnComisionPaypal((decimal)ebay_seguimiento.PRECIO_VENTA+(decimal)ebay_seguimiento.ENVIO).ToString();
                comisionEbay = fnComisionEbay((decimal)ebay_seguimiento.PRECIO_VENTA, tecnologico);
                comisionPaypal = fnComisionPaypal((decimal)ebay_seguimiento.PRECIO_VENTA + (decimal)ebay_seguimiento.ENVIO);
                textEditBeneficio.Text = ((double)ebay_seguimiento.PRECIO_VENTA+(double)ebay_seguimiento.ENVIO -  (double)costo - (double)costoEnvio- (double)comisionEbay-(double)comisionPaypal).ToString();
                textEditunidadesDisponible.Text = ebay_seguimiento.UNIDADES_DISPONIBLE.ToString();
                comboBoxEditRestocking.Text = ebay_seguimiento.restocking;
                codigo = ebay_seguimiento.ARTICULO_MIO.Trim();
            }
        }

        private void simpleButtonEscandallo_Click(object sender, EventArgs e)
        {
            var form = new VerEscandalloPopUP();
            form.codigo = codigo;
            form.Show(this); // if you need non-modal window
             
        }

        #region politicas
        private string LeerPoliticas(string cuenta)
        {
            CredencialesEbay credencialesebay = new CredencialesEbay();
            credencialesebay.cuenta = cuenta;
            string xmlRequest = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                    <getSellerProfilesRequest xmlns=""http://www.ebay.com/marketplace/selling/v1/services"">
                                    <includeDetails>true</includeDetails>
                                    </getSellerProfilesRequest>";

            WebRequest request = WebRequest.Create("https://svcs.ebay.com/services/selling/v1/SellerProfilesManagementService");
            request.ContentType = "text/xml";
            request.Method = "POST";

            request.Headers.Add("X-EBAY-SOA-SERVICE-NAME", "SellerProfilesManagementService");
            request.Headers.Add("X-EBAY-SOA-OPERATION-NAME", "getSellerProfiles");
            request.Headers.Add("X-EBAY-SOA-SERVICE-VERSION", "1.0.0");
            request.Headers.Add("X-EBAY-SOA-GLOBAL-ID", "EBAY-ES");
            request.Headers.Add("X-EBAY-SOA-SECURITY-TOKEN", credencialesebay.context.ApiCredential.eBayToken);
            request.Headers.Add("X-EBAY-SOA-REQUEST-DATA-FORMAT", "XML");

            byte[] byteArray = Encoding.UTF8.GetBytes(xmlRequest);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            dataStream.Dispose();

            WebResponse response = request.GetResponse(); //<-- error here
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string output = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            return output;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            String o;
            CredencialesEbay credencialesebay = new CredencialesEbay();
            foreach (string cuenta in credencialesebay.Cuentas)
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(o = LeerPoliticas(cuenta));
                XmlNodeList elemList = xml.GetElementsByTagName("PaymentProfile");
                foreach (XmlNode elem in elemList)
                {
                    AnadirPolitica(elem, cuenta);
                }
                elemList = xml.GetElementsByTagName("ShippingPolicyProfile");
                foreach (XmlNode elem in elemList)
                {
                    AnadirPolitica(elem, cuenta);
                }
            }





        }

        private void AnadirPolitica(XmlNode elem, string cuenta)
        {
            foreach (XmlNode e in elem)
            {
                var a = e.InnerText;
            }

            string profileType = elem["profileType"].InnerText;

            if (profileType == "PAYMENT")
            {
                GrabarPoliticaPAYMENT(elem, cuenta);
            }
            if (profileType == "SHIPPING")
            {
                GrabarPoliticaSHIPPING(elem, cuenta);
            }
        }

     
        private void GrabarPoliticaSHIPPING(XmlNode elem, string cuenta)
        {
            bool PoliticaNueva = false;
            MyEntityModel.ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
            long PoliticaId = Convert.ToInt64(elem["profileId"].InnerText);
            MyEntityModel.EbayProfiles profile = dbContext.ebayprofiles.Where(w => w.profileId == PoliticaId).FirstOrDefault();
            if (profile == null)
            {
                PoliticaNueva = true;
                profile = new EbayProfiles();
            }
            profile.cuenta = cuenta;
            profile.profileId = PoliticaId;
            profile.profileType = elem["profileType"].InnerText;
            if (elem["profileDesc"] == null)
                profile.profileDesc = "";
            else
                profile.profileDesc = elem["profileDesc"].InnerText;
            profile.siteId = Convert.ToInt16(elem["siteId"].InnerText);
            profile.SPI_shippingPolicyName = elem["shippingPolicyInfo"]["shippingPolicyName"].InnerText;
            profile.SPI_domesticShippingType = elem["shippingPolicyInfo"]["domesticShippingType"].InnerText;
            profile.SPI_intlShippingType = elem["shippingPolicyInfo"]["intlShippingType"].InnerText;
            profile.SPI_dispatchTimeMax = Convert.ToInt16(elem["shippingPolicyInfo"]["dispatchTimeMax"].InnerText);
            profile.SPI_shippingOption = Convert.ToInt16(elem["shippingPolicyInfo"]["shippingOption"].InnerText);

            profile.SPI_SPDI_domesticFlatCalcDiscountProfileId = Convert.ToInt16(elem["shippingPolicyInfo"]["shippingProfileDiscountInfo"]["domesticFlatCalcDiscountProfileId"].InnerText);
            profile.SPI_SPDI_intlFlatCalcDiscountProfileId = Convert.ToInt16(elem["shippingPolicyInfo"]["shippingProfileDiscountInfo"]["intlFlatCalcDiscountProfileId"].InnerText);
            profile.SPI_SPDI_applyDomesticPromoShippingProfile = Convert.ToBoolean(elem["shippingPolicyInfo"]["shippingProfileDiscountInfo"]["applyDomesticPromoShippingProfile"].InnerText);
            profile.SPI_SPDI_applyIntlPromoShippingProfile = Convert.ToBoolean(elem["shippingPolicyInfo"]["shippingProfileDiscountInfo"]["applyIntlPromoShippingProfile"].InnerText);

            XmlNode shippingPolicyInfo = elem["shippingPolicyInfo"];
            XmlNodeList li = shippingPolicyInfo.SelectNodes(".//domesticShippingPolicyInfoService");
            XmlNode domesticShippingPolicyInfoService = shippingPolicyInfo["domesticShippingPolicyInfoService"];

            int ContadordomesticShippingType = 0;
            foreach (XmlNode child in shippingPolicyInfo.ChildNodes)
            {
                if (child.Name == "domesticShippingPolicyInfoService")
                {
                    if (ContadordomesticShippingType == 0)
                    {
                        profile.SPI_DSPIS_shippingService_0 = child["shippingService"].InnerText;
                        profile.SPI_DSPIS_sortOrderId_0 = Convert.ToInt16(child["sortOrderId"].InnerText);
                        profile.SPI_DSPIS_freeShipping_0 = Convert.ToBoolean(child["freeShipping"].InnerText);
                        profile.SPI_DSPIS_fastShipping_0 = Convert.ToBoolean(child["fastShipping"].InnerText);
                        string c = child["shippingServiceAdditionalCost"].InnerText.Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        c = c.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        profile.SPI_DSPIS_shippingServiceAdditionalCost_0 = Convert.ToDecimal(c);
                        c = child["shippingServiceCost"].InnerText.Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        c = c.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        profile.SPI_DSPIS_shippingServiceCost_0 = Convert.ToDecimal(c);
                    }
                    if (ContadordomesticShippingType == 1)
                    {
                        profile.SPI_DSPIS_shippingService_1 = child["shippingService"].InnerText;
                        profile.SPI_DSPIS_sortOrderId_1 = Convert.ToInt16(child["sortOrderId"].InnerText);
                        profile.SPI_DSPIS_freeShipping_1 = Convert.ToBoolean(child["freeShipping"].InnerText);
                        profile.SPI_DSPIS_fastShipping_1 = Convert.ToBoolean(child["fastShipping"].InnerText);
                        string c = child["shippingServiceAdditionalCost"].InnerText.Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        c = c.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        profile.SPI_DSPIS_shippingServiceAdditionalCost_1 = Convert.ToDecimal(c);
                        c = child["shippingServiceCost"].InnerText.Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        c = c.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        profile.SPI_DSPIS_shippingServiceCost_1 = Convert.ToDecimal(c);
                    }
                    if (ContadordomesticShippingType == 2)
                    {
                        profile.SPI_DSPIS_shippingService_2 = child["shippingService"].InnerText;
                        profile.SPI_DSPIS_sortOrderId_2 = Convert.ToInt16(child["sortOrderId"].InnerText);
                        profile.SPI_DSPIS_freeShipping_2 = Convert.ToBoolean(child["freeShipping"].InnerText);
                        profile.SPI_DSPIS_fastShipping_2 = Convert.ToBoolean(child["fastShipping"].InnerText);
                        string c = child["shippingServiceAdditionalCost"].InnerText.Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        c = c.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        profile.SPI_DSPIS_shippingServiceAdditionalCost_2 = Convert.ToDecimal(c);
                        c = child["shippingServiceCost"].InnerText.Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        c = c.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        profile.SPI_DSPIS_shippingServiceCost_2 = Convert.ToDecimal(c);
                    }
                    if (ContadordomesticShippingType == 3)
                    {
                        profile.SPI_DSPIS_shippingService_3 = child["shippingService"].InnerText;
                        profile.SPI_DSPIS_sortOrderId_3 = Convert.ToInt16(child["sortOrderId"].InnerText);
                        profile.SPI_DSPIS_freeShipping_3 = Convert.ToBoolean(child["freeShipping"].InnerText);
                        profile.SPI_DSPIS_fastShipping_3 = Convert.ToBoolean(child["fastShipping"].InnerText);
                        string c = child["shippingServiceAdditionalCost"].InnerText.Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        c = c.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        profile.SPI_DSPIS_shippingServiceAdditionalCost_3 = Convert.ToDecimal(c);
                        c = child["shippingServiceCost"].InnerText.Replace(',', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        c = c.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                        profile.SPI_DSPIS_shippingServiceCost_3 = Convert.ToDecimal(c);
                    }
                    ContadordomesticShippingType++;
                }
            }


            if (PoliticaNueva)
                dbContext.ebayprofiles.Add(profile);
            dbContext.SaveChanges();

        }
        private void GrabarPoliticaPAYMENT(XmlNode elem, string cuenta)
        {
            bool PoliticaNueva = false;
            MyEntityModel.ApplicationDbContextSql dbContext = new ApplicationDbContextSql();
            long PoliticaId = Convert.ToInt64(elem["profileId"].InnerText);
            MyEntityModel.EbayProfiles profile = dbContext.ebayprofiles.Where(w => w.profileId == PoliticaId).FirstOrDefault();
            if (profile == null)
            {
                PoliticaNueva = true;
                profile = new EbayProfiles();
            }
            profile.cuenta = cuenta;
            profile.profileId = PoliticaId;
            profile.profileType = elem["profileType"].InnerText;
            profile.profileDesc = elem["profileDesc"].InnerText;
            profile.siteId = Convert.ToInt16(elem["siteId"].InnerText);
            profile.paypalEmailAddress = elem["paymentInfo"]["paypalEmailAddress"].InnerText;
            if (PoliticaNueva)
                dbContext.ebayprofiles.Add(profile);
            dbContext.SaveChanges();

        }
        #endregion politicas
    }
}
