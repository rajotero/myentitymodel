using Bukimedia.PrestaSharp.Factories;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  MyEntityModel
{
    public class prestashop
    {
        static string _BaseUrl = "http://www.rajotero.es/tienda/api";
        static string _Account = "JSLJEV1FQYWDQWQ6XSR43WNWH4H6RMCD";
        static string _Password = "";

        public class prestashop_imagenes_byte
        {
            public byte[] imagen { get; set; }
            public long id { get; set; }
        }

        public class prestashop_imagenes_bitmap
        {
            public Image imagen { get; set; }
            public long id { get; set; }
        }

        public static List<prestashop_imagenes_byte> byteArticuloReferencia(string referencia)
        {
            var PF = new ProductFactory(_BaseUrl, _Account, _Password);
            Dictionary<string, string> dtn = new Dictionary<string, string>();
            dtn.Add("reference", referencia);
            var products = PF.GetByFilter(dtn, null, null);
            var IF = new ImageFactory(_BaseUrl, _Account, _Password);
            var id = (long)products.FirstOrDefault().id;
            List<Bukimedia.PrestaSharp.Entities.FilterEntities.declination> IM = new List<Bukimedia.PrestaSharp.Entities.FilterEntities.declination>();
            try
            {
                IM = IF.GetProductImages(id);
            }
            catch { }
            List<prestashop_imagenes_byte> ListaImagenes = new List<prestashop_imagenes_byte>();
            foreach (var I in IM)
            {
                var img = IF.GetProductImage((long)products.FirstOrDefault().id, I.id);
                prestashop_imagenes_byte r = new prestashop_imagenes_byte();
                r.id = I.id;
                r.imagen = img;
                ListaImagenes.Add(r);
            }
            return ListaImagenes;
        }

        public static List<prestashop_imagenes_bitmap> ImageArticuloReferencia(string referencia)
        {
            List<prestashop_imagenes_byte> bytes = byteArticuloReferencia(referencia);
            List<prestashop_imagenes_bitmap> imagenes = new List<prestashop_imagenes_bitmap>();
            foreach (var b in bytes)
            {
                System.IO.MemoryStream stream = new MemoryStream();
                stream.Write(b.imagen, 0, b.imagen.Length);
                Image bitmap = Bitmap.FromStream(stream);
                prestashop_imagenes_bitmap r = new prestashop_imagenes_bitmap();
                r.imagen = bitmap;
                r.id = b.id;
                imagenes.Add(r);
            }
            return imagenes;
        }

        public static void CargarImagenesPrestashopEnSlider(string referencia, ImageSlider slider, List<long> ids)
        {
            List<prestashop_imagenes_bitmap> imagenes = ImageArticuloReferencia(referencia);
            slider.Images.Clear();
            ids.Clear();
            foreach (var img in imagenes)
            {
                slider.Images.Add(img.imagen);
                ids.Add(img.id);
            }
        }

        public static void DescargarImagenesPrestashop(string referencia)
        {
            List<prestashop_imagenes_bitmap> imagenes = ImageArticuloReferencia(referencia);
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ImagenesDeProductos";
            System.IO.Directory.CreateDirectory(path);
            path = path + "\\";
            int i = 1;
            foreach (var img in imagenes)
            {
                img.imagen.Save(path + referencia.Trim() + "_" + i.ToString() + ".jpg");
            }
        }


        public static void AnadirImagen(int product_id, ImageSlider slider, List<long> ids, string file)
        {
            ImageFactory IF = new ImageFactory(_BaseUrl, _Account, _Password);
            IF.AddProductImage((long)product_id, file);
            var ll = IF.GetProductImages((long)product_id);
            var img = IF.GetProductImage((long)product_id, ll.LastOrDefault().id);
            ids.Add(ll.LastOrDefault().id);
            System.IO.MemoryStream stream = new MemoryStream();
            stream.Write(img, 0, img.Length);
            Image bitmap = Bitmap.FromStream(stream);
            slider.Images.Add(bitmap);
            slider.CurrentImageIndex = slider.Images.Count - 1;
        }
        public static void BorrarImagen(int product_id, ImageSlider slider, List<long> ids)
        {
            ImageFactory IF = new ImageFactory(_BaseUrl, _Account, _Password);
            IF.DeleteProductImage(product_id, ids[slider.CurrentImageIndex]);
            int index = slider.CurrentImageIndex;
            slider.Images.RemoveAt(index);
            ids.RemoveAt(index);
        }
        public static Bukimedia.PrestaSharp.Entities.product CargarProductoPrestashopReferencia(string referencia)
        {
            var PF = new ProductFactory(_BaseUrl, _Account, _Password);
            Dictionary<string, string> dtn = new Dictionary<string, string>();
            dtn.Add("reference", referencia);
            var products = PF.GetByFilter(dtn, null, null);
            return products.FirstOrDefault();
        }
    }
}
