using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _TicariOtomasyon.Helper;
namespace _TicariOtomasyon.Helper
{
    internal class ProducGet
    {

        SqlBaglantisi bgl = new SqlBaglantisi();
        List<Products> products = new List<Products>();
        public List<Products> productsGet()
        {

            SqlCommand komut1 = new SqlCommand("Select * From TBL_URUNLER", bgl.baglanti());
            SqlDataReader k1 = komut1.ExecuteReader();
            while (k1.Read())
            {
                Products p = new Products();
                p.productId = Convert.ToInt32(k1[0]);
                p.productName = k1[1].ToString();
                p.productMarka = k1[2].ToString();
                p.productModel = k1[3].ToString();
                p.productYıl = k1[4].ToString();
                p.productAdet = Convert.ToInt32(k1[5]);
                p.productAlıs = Convert.ToDouble(k1[6]);
                p.productSatıs = Convert.ToDouble(k1[7]);
                p.productDetay = k1[8].ToString();
                products.Add(p);
            }
            bgl.baglanti().Close();
            return products;
        }
    }
}
