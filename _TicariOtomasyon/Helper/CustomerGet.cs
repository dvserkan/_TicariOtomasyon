using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _TicariOtomasyon.Helper
{
    internal class CustomerGet
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        List<Customers> customers = new List<Customers>();

        public List<Customers> CustomersGet()
        {
            SqlCommand cmd = new SqlCommand("Select * From TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader k1 = cmd.ExecuteReader();
            while (k1.Read())
            {
                Customers c = new Customers();
                c.customerId = Convert.ToInt32(k1[0]);
                c.customerAd = k1[1].ToString();
                c.customerSoyad = k1[2].ToString();
                c.customerTel1 = k1[3].ToString();
                c.customerTel2 = k1[4].ToString();
                c.customerTc = k1[5].ToString();
                c.customerMaıl = k1[6].ToString();
                c.customerIl = k1[7].ToString();
                c.customerIlce = k1[8].ToString();
                c.customerAdres = k1[9].ToString();
                c.customerVergi = k1[10].ToString();
                customers.Add(c);
            }
            bgl.baglanti().Close();
            return customers;
        }

    }
}
