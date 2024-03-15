using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _TicariOtomasyon.Helper
{
    internal class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=.\POSSQL;Initial Catalog=DboTicariOtomasyon;User ID=sa ; Password=sql123_;");
            baglan.Open();
            return baglan;
        }
    }
}
