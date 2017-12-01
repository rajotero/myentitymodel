using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyEntityModel
{
    public partial class EBAY_SEGUIMIENTO
    {
        public string VENDEDOR { get; set; }
        [Display(Name = "Artículo")]
        [StringLength(20)]
        [Index("ARTICULO", 1, IsUnique = true)]
        public string ARTICULO { get; set; }
        public string ARTICULO_MIO { get; set; }
        public string CODIGO { get; set; }
        [Display(Name = "Título:")]
        public string TITULO { get; set; }
        public string SUBTITULO { get; set; }
        public decimal? PRECIO { get; set; }
        public string CATEGORIA { get; set; }
        public int? VENDIDOS { get; set; }
        public string URL { get; set; }
        public decimal? ENVIO { get; set; }
        public int? VENDIDOS_MES { get; set; }
        public int? VENDIDOS_SEMANA { get; set; }
        public DateTime? FECHA { get; set; }
        public string IMAGEN_EBAY { get; set; }
        public int? CONTADOR { get; set; }
        public int? DISPONIBLES { get; set; }
        [Key]
        public int id { get; set; }
        public DateTime? FECHA_TURBOLISTER { get; set; }
        public decimal? PRECIO_VENTA { get; set; }
        public int? DISPONIBLES_SOLICITADAS { get; set; }
        public DateTime? FECHA_ULTIMA_ACTUALIZACION { get; set; }
        public int? MAX_DISPONIBLES_SOLICITADAS { get; set; }
        public string NO_DISPONIBLE { get; set; }
        public decimal? PRECIO_DISPONIBLE { get; set; }
        public decimal? ENVIO_DISPONIBLE { get; set; }
        public decimal? PRECIO_NO_DISPONIBLE { get; set; }
        public decimal? ENVIO_NO_DISPONIBLE { get; set; }
        public int? UNIDADES_DISPONIBLE { get; set; }
        public int? UNIDADES_NO_DISPONIBLE { get; set; }
        public DateTime? FECHA_OMITIR_SEGUIMIENTO { get; set; }
        public string Nombres_Variaciones { get; set; }
        public decimal? BENEFICIO { get; set; }
        public DateTime? FECHA_BENEFICIO { get; set; }
        public DateTime? FECHA_REVISION_COMPETENCIA { get; set; }
        public string restocking { get; set; }
        public DateTime? FECHA_CREACION { get; set; }
        public Int64? StoreCategoryID { get; set; }
        public Int64? StoreCategory2ID { get; set; }
        public string PrimaryCategoryID { get; set; }
        public string SecondaryCategoryID { get; set; }
        public string PayPal { get; set; }
        public string Finalizado { get; set; }
        public string TextoError { get; set; }
        public string ItemSpecifics { get; set; }
        public DateTime? Fecha_Disponibles { get; set; }
        public DateTime? EndTime { get; set; }
        public string Descripcion { get; set; }
        public string PictureURL { get; set; }
        public long? ProfileIDShipping { get; set; }
        public long? ProfileIDPayment { get; set; }

    }
    public partial class EbayFormasEnvio
    {
        public int EbayFormasEnvioID { get; set; }
        public string Vendedor { get; set; }
        public string Nombre { get; set; }
        [Column(TypeName = "ntext")]
        [MaxLength]
        public string Html { get; set; }
    }

    [Table("EbayProfiles")]
    public partial class EbayProfiles
    {
        [Key]
        public int EbayProfilesID { get; set; }
        public string cuenta { get; set; }
        [Index]
        public long profileId { get; set; }
        public string profileType { get; set; }
        public string profileDesc { get; set; }
        public int siteId { get; set; }
        public string paypalEmailAddress { get; set; }
        public string RPI_description { get; set; }
        public string RPI_paypalEmailAddress { get; set; }
        public string RPI_returnsWithinOption { get; set; }
        public string RPI_returnsAcceptedOption { get; set; }
        public string SPI_shippingPolicyName { get; set; }
        public string SPI_domesticShippingType { get; set; }
        public string SPI_intlShippingType { get; set; }
        public int SPI_dispatchTimeMax { get; set; }
        public int SPI_shippingOption { get; set; }
        //<shippingProfileDiscountInfo>
        public int SPI_SPDI_domesticFlatCalcDiscountProfileId { get; set; }  //<domesticFlatCalcDiscountProfileId>
        public int SPI_SPDI_intlFlatCalcDiscountProfileId { get; set; }  // <intlFlatCalcDiscountProfileId>0</intlFlatCalcDiscountProfileId>
        public bool SPI_SPDI_applyDomesticPromoShippingProfile { get; set; } // <applyDomesticPromoShippingProfile>false</applyDomesticPromoShippingProfile>
        public bool SPI_SPDI_applyIntlPromoShippingProfile { get; set; } // <applyIntlPromoShippingProfile>false</applyIntlPromoShippingProfile>
                                                                         //<domesticShippingPolicyInfoService>
        public string SPI_DSPIS_shippingService_0 { get; set; }  //<shippingService>ES_CartasNacionalesDeMas20</shippingService>
        public int SPI_DSPIS_sortOrderId_0 { get; set; }  //<sortOrderId>1</sortOrderId>
        public bool SPI_DSPIS_freeShipping_0 { get; set; }  //<freeShipping>false</freeShipping>
        public bool SPI_DSPIS_fastShipping_0 { get; set; }  // <fastShipping>false</fastShipping>
        public decimal SPI_DSPIS_shippingServiceAdditionalCost_0 { get; set; } // <shippingServiceAdditionalCost currencyId = "EUR" > 1.0 </ shippingServiceAdditionalCost >
        public decimal SPI_DSPIS_shippingServiceCost_0 { get; set; } // < shippingServiceCost currencyId="EUR">1.0</shippingServiceCost>
        public string SPI_DSPIS_shippingService_1 { get; set; }  //<shippingService>ES_CartasNacionalesDeMas20</shippingService>
        public int SPI_DSPIS_sortOrderId_1 { get; set; }  //<sortOrderId>1</sortOrderId>
        public bool SPI_DSPIS_freeShipping_1 { get; set; }  //<freeShipping>false</freeShipping>
        public bool SPI_DSPIS_fastShipping_1 { get; set; }  // <fastShipping>false</fastShipping>
        public decimal SPI_DSPIS_shippingServiceAdditionalCost_1 { get; set; } // <shippingServiceAdditionalCost currencyId = "EUR" > 1.0 </ shippingServiceAdditionalCost >
        public decimal SPI_DSPIS_shippingServiceCost_1 { get; set; } // < shippingServiceCost currencyId="EUR">1.0</shippingServiceCost>
        public string SPI_DSPIS_shippingService_2 { get; set; }  //<shippingService>ES_CartasNacionalesDeMas20</shippingService>
        public int SPI_DSPIS_sortOrderId_2 { get; set; }  //<sortOrderId>1</sortOrderId>
        public bool SPI_DSPIS_freeShipping_2 { get; set; }  //<freeShipping>false</freeShipping>
        public bool SPI_DSPIS_fastShipping_2 { get; set; }  // <fastShipping>false</fastShipping>
        public decimal SPI_DSPIS_shippingServiceAdditionalCost_2 { get; set; } // <shippingServiceAdditionalCost currencyId = "EUR" > 1.0 </ shippingServiceAdditionalCost >
        public decimal SPI_DSPIS_shippingServiceCost_2 { get; set; } // < shippingServiceCost currencyId="EUR">1.0</shippingServiceCost>
        public string SPI_DSPIS_shippingService_3 { get; set; }  //<shippingService>ES_CartasNacionalesDeMas20</shippingService>
        public int SPI_DSPIS_sortOrderId_3 { get; set; }  //<sortOrderId>1</sortOrderId>
        public bool SPI_DSPIS_freeShipping_3 { get; set; }  //<freeShipping>false</freeShipping>
        public bool SPI_DSPIS_fastShipping_3 { get; set; }  // <fastShipping>false</fastShipping>
        public decimal SPI_DSPIS_shippingServiceAdditionalCost_3 { get; set; } // <shippingServiceAdditionalCost currencyId = "EUR" > 1.0 </ shippingServiceAdditionalCost >
        public decimal SPI_DSPIS_shippingServiceCost_3 { get; set; } // < shippingServiceCost currencyId="EUR">1.0</shippingServiceCost>

    }

    [Table("ComisionesEbay")]
    public partial class ComisionesEbay
    {
        public int ComisionesEbayID { get; set; }
        public string Articulo { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal Precio { get; set; }
        public decimal Comision { get; set; }
        public long Categoria { get; set; }
        public string NombreCategoriaRaiz { get; set; }
        public string Nombre { get; set; }
        public string Cuenta { get; set; }
        public decimal Porcentaje { get; set; }
      }

    [Table("EBAY_CATEGORIAS")]
    public partial class EBAY_CATEGORIAS
    {
        public int Numero { get; set; }
        public string Url { get; set; }
        public string Nombre { get; set; }
        public DateTime? FECHA_ULTIMA_BUSQUEDA { get; set; }
        public int Maestra { get; set; }
        public long CategoryID { get; set; }
        public int CategoryLevel { get; set; }
        public string CategoryName { get; set; }
        public long CategoryParentID { get; set; }
        [Key]
        public int id { get; set; }
        public string Buscar { get; set; }
        public SiNo Tecnologico { get; set; }
    }
 
    public partial class CredencialesEbay
    {
        public string cuenta { get; set; }
 //       public Form FormNotificaciones { get; set; }
        public ApiContext context
        {
            get
            {
                return GetContext(cuenta);
            }
        }

 //       private int UltimaCredencial;

        public List<string> Cuentas
        {
            get
            {
                return new List<string>(new string[] { "ofertasparati", "garfo_es", "rajotero" });
            }
        }
        public List<string> InicialesCuentas
        {
            get
            {
                return new List<string>(new string[] { "EJ", "EG", "EJ" });
            }
        }

        public static ApiContext GetContext(string cuenta)
        {
            if (String.IsNullOrEmpty(cuenta))
                cuenta = "ofertasparati";
            ApiContext context = new ApiContext();
            //set the your credentials
            if (String.Equals("garfo_es", cuenta, StringComparison.OrdinalIgnoreCase))
                context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**VdgWWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AFkYKkCpGEqA2dj6x9nY+seQ**EnwDAA**AAMAAA**CcNW7u+xZTaHfw5LoCboEhnVlgpxnB9sZR74o8hbwWsQAYR2PR6+2duCdMgZIt6x22NWtbJGqijpsee6fDOXBTsQ0F0PMhcLtojm9vDuYMSgoQBUZKcwEi+gnuGBodJT2E1srJe" +
                                                  "eKaUFHFHjsSU3P49xQfVduXfWRK81bD4qWVWQP4m1NdAnlgAdFq9Zo4zOn/c9oNUjdP5uvXRrOenHR7U9bIFTXBYDhjn7RVijewqrPSOet9xLT6JSentEKKeUiw1d1PpSne4sKbnmmABRC+MxdMXxonkOuuYTi8xlJ7niigIQ95imcxL5bE7hQh1exmiFVNHwwTp8nPy1PzsRSOA0MSECpgNmAtw+eVkjNfv2PSfk9fkcMB" +
                                                  "Vxt/+S5/Bzesys7lLjOYCyZMA8k5z+4ht7Lu4qidqHrDJ6Z5bcp3oZEVa1rTQWUFVQwi2GHSNKjr61n00hOfczEJTrXTTjaZofZngcyzcf3ElsdqieEs9VbpMxrzFtsAPhevKgWWt37SROQMmj9t6OfgWcvPcP5oChklqxuLWPYsHZACqZqYI22SOBL/fzLhGYpdMEzLJ4ufKzI98j4hJhxhDgT3M/R54bf+fXBe+VoDplF" +
                                                  "7I9i2p4q347+c+rGgeYiqcgjw1CbEzBrZtHXTgihes0O7GSe0y5LtLycT5TmUo0nz3uLWd8QiQChWIFHq+0f/1r/hPCmDr9Qoz2naXtID7p9y6qBPFQ1lPy1/dOiGH9M3msKPm/8wSl/mHo/+qjpgfHKON6";
            if (String.Equals("ofertasparati", cuenta, StringComparison.OrdinalIgnoreCase))
                context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**yNgWWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wHmIKoDpSDoASdj6x9nY+seQ**EnwDAA**AAMAAA**QeHtNXsJiQlV5YrPRkm4sgQ2IVJJvuk+z79VjiJxL+ofzRLHSQl3S2UykWJv8t5LLCNu2YgFskz6txbK3XBf4ij7iKfNOlFwjQG2yjcIna039UivZkzPdc8ZRw/Eh9ldOSwd/uL" +
                                                  "soqGk9RnToyFniG80rnlmOZC6XTfvsyYj5cRAzH0pJzCDhXoJuWn2pmuGQdmHNYJw2fHrVWoTeBIwXAXNHe2M6Ucoe2ZBaG1dCZEjPP2CbwEuELQy0ptsuQ6reGHDIMOVruagKB2km2UnGpIA8Gwj5sCGahE5EivMd6MHe6Scjf0PXFCV3oz60ilCq77XJPdmrYlhIegLtpL/04OhccXmilOcUSGqHxh2eq5AUKGZ17QyrY" +
                                                  "bg9ZUgkTHnhijVzWtUm9s/DFR2uYYi3lYBOn5AP3IRagYCWYXtS0yfooVxl/QwalUitIUZ6KFfS5Zs8v3yhDNiKwuXn8jwT0j/mK/Ee98OPLUEGGerBkLzh+6Ly/fVFCrdKU3Mt8HwuKcmZePI+ahnC4jhwf9WBWbo8PqAAKUjdfu2NPg/PJ8jenAzpPqFRd+/ERravJOEn4qrntHBjhHslmDxHPk6dyCNPhaZ4cfjSTZgo" +
                                                  "ExWlBaEgiCuRlOB5IglWiFWtpOxrHqD44ZKRhRSCDvdJ2PaL8sENFH4MqjYTi1vvPWaWqEtpq5p4pNGQMw3cA5DlQhx4qNUfjCNufqCjdXdD1h0auIiR9nMTu7xK/b4uRYl+pchmufJFpyXu+nvbYrkLBT3";
            if (String.Equals("rajotero", cuenta, StringComparison.OrdinalIgnoreCase))
                context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**ktgWWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AFkIeiD5WLoQidj6x9nY+seQ**EnwDAA**AAMAAA**mEvFBeGLDRzhvoIZjeCtitoYHzCiaQqTDtuSRlqtL4SZJyTw6ITN25SIdV/nlyJOmdsYKp4Udw8Jn8yDDkY2R24K1dAy9jkqm8o/aT8NK8JS9Rap8lTK2O7+GQkaXm1P" +
                                                    "yUtRI3Jip/a1ZGpwzrkj+c0T91MuNwfv8NCslquhyJY9Ofty30dANFRH8tt50wj1FlojGU+POYxgPEspvx8bkzZ0p7fxLT7X/C9qaSvHGObFm0QQIeoruk/TWgRlqEghyjLfpn91fOeYawHKJR84A8NkC4lVxV1D5JKlKcVuPmQwzvu6k11BEsJc66wnVlUy2nNQZOwTF2bWh48RQ/aN/GMYNnHwiIVJgHCi97Gj" +
                                                    "I5Eu4RCWxkhqmHpvdaFeRTuKMzB0AjuQsgCEqCR1z+iI1OX3LEyaRfSPOpN8+umRUBE0J1sp/xhgdYYYX1Ju+378xCHXv0zoquQ+xnQf5jXSRliDaFKKU6joCfx03+EfHT6XHFAf1BfWQbrov0QXGgnw8m910/olxIEQ2pf2Tspegq4MigNV8XB2+MEcnjjhJ1YIAyealuJTb75lco3mj4I31ATIlM6Nz4aKT967" +
                                                    "QlFNokd+4o8KhI9JocDgSR/1ZbMOZSox9fgbfiIVvzCTFAohiH//rKk/cCag/r+BMnWCSCqymGT8avgugtNO+aPt1Hz/yzxNSE5qvttZ53uzErArht+9Em8IuloQYiog6fxbs6Ax3S5+4v8clh35Mxm/GMATC45sIuM0nVAihcvKazI+";
            context.ApiCredential.ApiAccount.Application = "antoniog-aplicaci-PRD-abffbb311-3e317c6b";
            context.ApiCredential.ApiAccount.Developer = "05759dff-3209-4e96-8701-1f0a8090492b";
            context.ApiCredential.ApiAccount.Certificate = "PRD-bffbb311ca07-b79d-4814-aabe-ee17";



            //if (String.Equals("garfo_es", cuenta, StringComparison.OrdinalIgnoreCase))
            //    context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**SvcOWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AFkYKkCpGEqA2dj6x9nY+seQ**VXoDAA**AAMAAA**FNZK+I1t+bcHwOvZ8r0dUXRSFJzUSz+EzGorKHFUdDe5Xa++Xw1SA/VFb/xJt5fj6dve58c7T4UJHh9vPhDWK4o6Pbzr3mvw3xdfhtlXo2mSxA4hitSCYV9asoA57HGdwlGRVbs" +
            //                                        "PfzV4eIN1YAI2HxHfK668XP7j0c/BK6EWmQMX4XUD1xH7rOEj5lFck+MEjOY6xJROpCl9sXmCGy3Gkygx55XNKxM05QDdg/UQQ82e/5hHO9VvDHUDYJTqgDBd+mP/e0T63SjMbXjTdPXVZvXjYhKrieZd3tW9KM/ff2w0kQHfQJww4Xcq0U389OSv0g2aSGiuEELyZ8DAcjojqiVOT94OYlQjYxEIpZpNcM165dusIhVHaJ" +
            //                                        "9LZddv8HsBcUMr/O3eVTWN8cVz/FM0SEvnlpPT8f9Es9y00KH5rSbmf5suNyCs0gClqqb7lh2qf8kwLtZio2ShVqtHFQkwXI0swI6nQZITAzBeOY5TeAKNVlIHdg/WgwHIcJuhQwRV63YQUmYBPlSpHKCb/yOklseKkBJy4MLBG1Y+rvGzTvkBr1EW7SAoujCNI7pq8vQA0W6If0+Q3WpAlADwq27CG9wfCCg2utKvNIYXY" +
            //                                        "P2jhaLCvQ2M3JaQ0lmMG/2MP0TMlALe23JgoZQ9O87UG3XNJXN5ri4cKAXAxIc//xAYiRkryrW72iwfd4Ma7DmNRX0NdenwYByOPb9/gL76VjnIF1kvGFUo4C087UcUDsY99uNOMgPLv+Deu9YBU3R8hiFV";


            //if (String.Equals("rajotero", cuenta, StringComparison.OrdinalIgnoreCase))
            //    context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**gvcOWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6AFkIeiD5WLoQidj6x9nY+seQ**VXoDAA**AAMAAA**ako5dZhSP1cXFKfqxu25HWRFPGyDgPFPsOIxWdIweVHVtoFgmvkD6oHyeb/7DbR8ICUSygakQSCabEHQETjJ6e82CAgTYLAL+/HiTelADLYDVLc5rNoAu+R3+NhLIwof" +
            //                                        "wFZbzAJDnBJw9K4oheKx2TWly8orO57GLopWxzgVtYbu98g2SZ2mqb1KYSKGURxVgLTJ51X2A5IESVAHD14Pu8unKrb2K7vTVx69jgvpb5aoGzmAOMPGiyruoVabrxRrZHYwe2p7kHUi2suk7Ut+FE6JWr9zks2TqZOD37ESZ1Gt/QoB3J7rQn0gqKwhoVJ4ZyNBLKtHsP+PMnbmvbsJ8+UyHsZZalTUIhgOYDEq" +
            //                                        "xxDzqQujxE61JM9cEbAVOnzCLB+cs26rSYgZVSI+EUkM3EhQF2tlY9FHB0O1t3tukdoqEUglvRgvgE8DHbABdgUga6NXfkp+0bu14a3gBPGW327BETY7Dto3C6JBG5pLlXPRjWg/lqjMzcNC4hvpaFRIGR1YO11l+6x44kPP8agLJKqCVfh7+w+MM1hW7S2iqqXeKzL9g4hZHP5s9f4RlI9fRh4MejOuo+Mj9TSL" +
            //                                        "OBqUhqbFflKhn9kwOU/KJ1LwLdMkVx5jIGTby9NFQASriZsKLo+du5zs7YJjBbuloQtuJ4kBHW7MEi3t5xXYta4YSx2RHNnieTCuMS/dODlXYApVFEG8erGDJU2/POW+6Ex0mp/Gs2K83490PI4Y4rHP7lP6McgbIBenq4LpRcByLCr7";

            //if (String.Equals("ofertasparati", cuenta, StringComparison.OrdinalIgnoreCase))
            //    context.ApiCredential.eBayToken = "AgAAAA**AQAAAA**aAAAAA**svcOWA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wHmIKoDpSDoASdj6x9nY+seQ**VXoDAA**AAMAAA**aqyQWWjoV65R5aLmJuLaUU+53aCc9i0Ei2ueoGwGbocWX0D7wDqHAFrrOsJ4G9Pck+XuKKcMFBB7/UUEEI6PdpRoOcWAmA19jz7F6Jj7zYA6YERw/Va3heEHW5eUvXdYB7Sa2NH" +
            //                                        "9iOLkfmSSToe5+Y32Gbad/GWVgEzcGYI0YuAsCNRaEuLD6n92HQP6q0o78UpMWcixjmMLM3/OldfJXNTTjuVCJ/xLD+c6IdV5DDmpD7i3CW9saYE1yKBn+DUMIj0JPH0+QyuxPF0WlAkgZHh+iqi+QxrXctpaH+3FntHPH3zX9idNxTm/BdClpeH7mBolms7YGB0D3T/e4zLf94cQ54tReE8etmtXZjQ8lD3kSZ3Ezy3Bu2" +
            //                                        "KWsaN53XH4FlOTj/OJiItefLjA0b9RbPdCnimVfSfnLP9n9xz7B0iVPdD05Bk9L6H06aiDIViMwhLzX9CeWpEwYH8FxteXHd7sJfIF7OO4FfF9Aaaioy1HAGpeG2l6MN9Daa0o2cErRr2RcgIZRYjhaXKn6zk3N7++R8o6kIW+7OIqFiyWGKH7MqU8y56yR4p+U1bWYITZ/H5yGK1D2E3ZYyRKfjUTd/SS7HeGJmI/MfgPH" +
            //                                        "Q4ocWI+XB0ygLscm3wcIRtH4UsnZmYxNhvnuoO1B1ze/K7e8hHPbfCeHvPMIWyfmXNbeAQoxEkvqoQcY8NtOtuXtJXsKFFIM22cgbxVd2acTEbUDuI2p3Y9dAjzRRp/KIYzWIerETgDkvkZRArpYTZPN2FU";


            //context.ApiCredential.ApiAccount.Application = "Antoniog-aplicaci-PRD-6bffbb311-ad590b91";
            //context.ApiCredential.ApiAccount.Certificate = "PRD-bffbb31175c2-2c3a-40dd-8bca-5e26";
            //context.ApiCredential.ApiAccount.Developer = "fb30edde-186c-4f61-81e6-6c2768dcb5c6";

            context.SoapApiServerUrl = "https://api.ebay.com/wsapi";
            context.Version = "1003";
            return context;
        }

    }

    public class CheckoutStatus
    {
        public DateTime? LastModifiedTime { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }

    public class ShippingAddress
    {
        public string AddressID { get; set; }
        public string CityName { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string CountryName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string PostalCode { get; set; }
        public string StateOrProvince { get; set; }
        public string Street { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
    }

    public class ShippingDetails
    {
        public int? SellingManagerSalesRecordNumber	{get;set;}

    }

    public class ShippingServiceSelected
    {
        public bool ExpeditedService { get; set; }
        public bool FreeShipping { get; set; }
        public string ShippingService { get; set; }
        public decimal ShippingServiceAdditionalCost { get; set; }
        public decimal ShippingServiceCost { get; set; }
    }
    //
    public class ExternalTransaction
    {
        public DateTime? ExternalTransactionTime { get; set; }
        public bool? ExternalTransactionTimeSpecified { get; set; }
        public decimal? FeeOrCreditAmount { get; set; }
        public decimal? PaymentOrRefundAmount { get; set; }
        public string ExternalTransactionStatus { get; set; }
    }

    [Table("EbayOrders")]
    public partial class EbayOrder
    {
        [Key]
        public int EbayOrdersID { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountSaved { get; set; }
        public string BuyerCheckoutMessage { get; set; }
        public string BuyerUserID { get; set; }
        public string CancelStatus { get; set; }
        public CheckoutStatus checkoutStatus { get; set; }
        public DateTime? CreatedTime { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Index]
        public string OrderID { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? PaidTime { get; set; }
        public string PaymentHoldStatus { get; set; }
        public string SellerUserID { get; set; }
        public DateTime? ShippedTime { get; set; }
        public ShippingAddress shippingAddress { get; set; }
        public ShippingDetails shippingDetails { get; set; }
        public ShippingServiceSelected shippingServiceSelected { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Total { get; set; }
        public ExternalTransaction externalTransaction { get; set; }
        public IEnumerable<EbayOrderLinea> EbayOrderLinea { get; set; }
    }

    public class Buyer
    {
        public string Email { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }

    [Table("EbayOrdersLineas")]
    public partial class EbayOrderLinea
    {
        [Key]
        public int EbayOrdersLineasID { get; set; }
        public string BuyerCheckoutMessage { get; set; }
        public string BuyerMessage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ExtendedOrderID { get; set; }
        public int QuantityPurchased { get; set; }
        public string ItemID { get; set; }
        public string Titulo { get; set; }
        public decimal TransactionPrice{get;set;}
        public string PaymentHoldStatus { get; set; }
        public decimal EbayFee { get; set; }
        public int SellingManagerSalesRecordNumber { get; set; }

}

    [Table("EbayItem")]
    public partial class EbayItem
    {
        public bool MechanicalCheckAccepted { get; set; }
        public bool UpdateSellerInfo { get; set; }
        public bool UpdateReturnPolicy { get; set; }
        public ItemPolicyViolationType ItemPolicyViolation { get; set; }
        public StringCollection CrossBorderTrade { get; set; }
        public BusinessSellerDetailsType BusinessSellerDetails { get; set; }
        public AmountType BuyerGuaranteePrice { get; set; }
        public BuyerRequirementDetailsType BuyerRequirementDetails { get; set; }
        public ReturnPolicyType ReturnPolicy { get; set; }
        public SiteCodeTypeCollection PaymentAllowedSite { get; set; }
        public InventoryTrackingMethodCodeType InventoryTrackingMethod { get; set; }
        public bool InventoryTrackingMethodSpecified { get; set; }
        public bool IntegratedMerchantCreditCardEnabled { get; set; }
        public bool IntegratedMerchantCreditCardEnabledSpecified { get; set; }
        public VariationsType Variations { get; set; }
        public ItemCompatibilityListType ItemCompatibilityList { get; set; }
        public int ItemCompatibilityCount { get; set; }
        public int ConditionID { get; set; }
        public ListingSubtypeCodeType ListingSubtype2 { get; set; }
        public BuyerProtectionDetailsType ApplyBuyerProtection { get; set; }
        public bool SkypeEnabledSpecified { get; set; }
        public string SkypeID { get; set; }
        public SkypeContactOptionCodeTypeCollection SkypeContactOption { get; set; }
        public bool BestOfferEnabled { get; set; }
        public bool LocalListing { get; set; }
        public bool ThirdPartyCheckoutIntegration { get; set; }
        public ListingCheckoutRedirectPreferenceType ListingCheckoutRedirectPreference { get; set; }
        public AddressType SellerContactDetails { get; set; }
        public string ConditionDescription { get; set; }
        public long TotalQuestionCount { get; set; }
        public bool ProxyItem { get; set; }
        public ExtendedContactDetailsType ExtendedSellerContactDetails { get; set; }
        public int LeadCount { get; set; }
        public int NewLeadCount { get; set; }
        public NameValueListTypeCollection ItemSpecifics { get; set; }
        public string GroupCategoryID { get; set; }
        public AmountType ClassifiedAdPayPerLeadFee { get; set; }
        public bool BidGroupItem { get; set; }
        public bool TotalQuestionCountSpecified { get; set; }
        public string ConditionDisplayName { get; set; }
        public string TaxCategory { get; set; }
        public QuantityAvailableHintCodeType QuantityAvailableHint { get; set; }
        public bool HideFromSearch { get; set; }
        public ReasonHideFromSearchCodeType ReasonHideFromSearch { get; set; }
        public bool IncludeRecommendations { get; set; }
        public PickupInStoreDetailsType PickupInStoreDetails { get; set; }
        public bool eBayNowEligible { get; set; }
        public bool eBayNowAvailable { get; set; }
        public bool IgnoreQuantity { get; set; }
        public string ConditionDefinition { get; set; }
        public bool EligibleForPickupDropOff { get; set; }
        public bool LiveAuction { get; set; }
        public DigitalGoodInfoType DigitalGoodInfo { get; set; }
        public bool eBayPlus { get; set; }
        public bool eBayPlusEligible { get; set; }
        public bool eMailDeliveryAvailable { get; set; }
        public bool AvailableForPickupDropOff { get; set; }
        public bool SkypeEnabled { get; set; }
        public bool RelistParentIDSpecified { get; set; }
        public UnitInfoType UnitInfo { get; set; }
        public bool QuantityAvailableHintSpecified { get; set; }
        public int QuantityThreshold { get; set; }
        public bool PostCheckoutExperienceEnabled { get; set; }
        public DiscountPriceInfoType DiscountPriceInfo { get; set; }
        public bool UseRecommendedProduct { get; set; }
        public string SellerProvidedTitle { get; set; }
        public string VIN { get; set; }
        public string VINLink { get; set; }
        public string VRM { get; set; }
        public long RelistParentID { get; set; }
        public string VRMLink { get; set; }
        public SellerProfilesType SellerProfiles { get; set; }
        public ShippingServiceCostOverrideListType ShippingServiceCostOverrideList { get; set; }
        public ShippingOverrideType ShippingOverride { get; set; }
        public ShipPackageDetailsType ShippingPackageDetails { get; set; }
        public bool TopRatedListing { get; set; }
        public QuantityRestrictionPerBuyerInfoType QuantityRestrictionPerBuyer { get; set; }
        public AmountType FloorPrice { get; set; }
        public AmountType CeilingPrice { get; set; }
        public bool IsIntermediatedShippingEligible { get; set; }
        public QuantityInfoType QuantityInfo { get; set; }
        public PictureDetailsType PictureDetails { get; set; }
        public bool HitCounterSpecified { get; set; }
        public string ItemID { get; set; }
        public ListingDetailsType ListingDetails { get; set; }
        public ListingDesignerType ListingDesigner { get; set; }
        public string ListingDuration { get; set; }
        public ListingEnhancementsCodeTypeCollection ListingEnhancement { get; set; }
        public ListingTypeCodeType ListingType { get; set; }
        public string Location { get; set; }
        public int LotSize { get; set; }
        public string PartnerCode { get; set; }
        public string PartnerName { get; set; }
        public BuyerPaymentMethodCodeTypeCollection PaymentMethods { get; set; }
        public string PayPalEmailAddress { get; set; }
        public CategoryType PrimaryCategory { get; set; }
        public bool PrivateListing { get; set; }
        public ProductListingDetailsType ProductListingDetails { get; set; }
        public int Quantity { get; set; }
        public string PrivateNotes { get; set; }
        public string RegionID { get; set; }
        public HitCounterCodeType HitCounter { get; set; }
        public GiftServicesCodeTypeCollection GiftServices { get; set; }
        public int GiftIcon { get; set; }
        public string ApplicationData { get; set; }
        public AttributeSetTypeCollection AttributeSetArray { get; set; }
        public AttributeTypeCollection AttributeArray { get; set; }
        public LookupAttributeTypeCollection LookupAttributeArray { get; set; }
        public bool AutoPay { get; set; }
        public PaymentDetailsType PaymentDetails { get; set; }
        public BiddingDetailsType BiddingDetails { get; set; }
        public bool MotorsGermanySearchable { get; set; }
        public bool MotorsGermanySearchableSpecified { get; set; }
        public BuyerProtectionCodeType BuyerProtection { get; set; }
        public bool RelistLink { get; set; }
        public bool CategoryMappingAllowed { get; set; }
        public CharityType Charity { get; set; }
        public CountryCodeType Country { get; set; }
        public CrossPromotionsType CrossPromotion { get; set; }
        public CurrencyCodeType Currency { get; set; }
        public bool CurrencySpecified { get; set; }
        public string Description { get; set; }
        public DescriptionReviseModeCodeType DescriptionReviseMode { get; set; }
        public bool DescriptionReviseModeSpecified { get; set; }
        public DistanceType Distance { get; set; }
        public AmountType BuyItNowPrice { get; set; }
        public bool RelistLinkSpecified { get; set; }
        public AmountType ReservePrice { get; set; }
        public ReviseStatusType ReviseStatus { get; set; }
        public bool ThirdPartyCheckoutSpecified { get; set; }
        public bool UseTaxTable { get; set; }
        public bool GetItFast { get; set; }
        public bool BuyerResponsibleForShipping { get; set; }
        public bool LimitedWarrantyEligible { get; set; }
        public string eBayNotes { get; set; }
        public long QuestionCount { get; set; }
        public bool ThirdPartyCheckout { get; set; }
        public bool RelistedSpecified { get; set; }
        public int QuantityAvailable { get; set; }
        public string SKU { get; set; }
        public bool CategoryBasedAttributesPrefill { get; set; }
        public SearchDetailsType SearchDetails { get; set; }
        public string PostalCode { get; set; }
        public bool ShippingTermsInDescription { get; set; }
        public ExternalProductIDType ExternalProductID { get; set; }
        public string SellerInventoryID { get; set; }
        public bool Relisted { get; set; }
        public int DispatchTimeMax { get; set; }
        public BestOfferDetailsType BestOfferDetails { get; set; }
        public DateTime ScheduleTime { get; set; }
        public CategoryType SecondaryCategory { get; set; }
        public CategoryType FreeAddedCategory { get; set; }
        public UserType Seller { get; set; }
        public SellingStatusType SellingStatus { get; set; }
        public ShippingDetailsType ShippingDetails { get; set; }
        public StringCollection ShipToLocations { get; set; }
        public SiteCodeType Site { get; set; }
        public AmountType StartPrice { get; set; }
        public bool LocationDefaulted { get; set; }
        public StorefrontType Storefront { get; set; }
        public string TimeLeft { get; set; }
        public string Title { get; set; }
        public string UUID { get; set; }
        public VATDetailsType VATDetails { get; set; }
        public string SellerVacationNote { get; set; }
        public long WatchCount { get; set; }
        public long HitCount { get; set; }
        public bool DisableBuyerRequirements { get; set; }
        public string SubTitle { get; set; }
    }

    [Table("LlamadasApis")]
    public partial class LlamadasApis
    {
        [Key]
        public int LlamadasApiID { get; set; }
        public DateTime Fecha { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(17)]
        [Index]
        public string Aplicacion { get; set; }
    }
}
