using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using _TicariOtomasyon.Helper;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
namespace _TicariOtomasyon.Formlar
{
    public partial class FrmFaturaÜrün : Form
    {
        public FrmFaturaÜrün()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        public FaturaProducts pro = null;

        public void productget()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dt1 = new SqlDataAdapter("Select * From TBL_URUNLER", bgl.baglanti());
            dt1.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmFaturaÜrün_Load(object sender, EventArgs e)
        {
            productget();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            pro = new FaturaProducts();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                pro.name = dr["URUNAD"].ToString();
                pro.fiyat = Convert.ToDouble(dr["SATISFIYAT"].ToString());
                FrmFaturaadet adet = new FrmFaturaadet();
                adet.ShowDialog();
                if (adet.productadets != null)
                {
                    pro.adet = adet.productadets.adet;
                    this.Close();
                }
            }
        }
    }
}