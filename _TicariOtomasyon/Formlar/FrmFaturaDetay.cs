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

namespace _TicariOtomasyon.Formlar
{
    public partial class FrmFaturaDetay : Form
    {
        public FrmFaturaDetay()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        public string faturakey;
        public int ıd;
        public string seri;
        public string sıra;
        public string tarih;
        public string saat;
        public string vergidaire;
        public string vergino;
        public string alıcı;
        public string teslimeden;
        public string teslimalan;
        public string firma;

        public void detayget()
        {
            SqlDataAdapter dt1 = new SqlDataAdapter("SELECT FATURAURUNID,URUN,MIKTAR,ROUND(FIYAT,2) AS FIYAT,ROUND(TUTAR,2) AS TUTAR FROM TBL_FATURADETAY Where FATURAKEY='" + faturakey + "'", bgl.baglanti());
            DataTable dt = new DataTable();
            dt1.Fill(dt);
            gridControl1.DataSource = dt;
            txtId.Text = ıd.ToString();
            txtserino.Text = seri.ToString();
            txtsırano.Text = sıra.ToString();
            txttarih.Text = tarih.ToString();
            txtsaat.Text = saat.ToString();
            txtvergidaire.Text = vergidaire.ToString();
            txtvergino.Text = vergino.ToString();
            txtalıcı.Text = alıcı.ToString();
            txtteslimeden.Text = teslimeden.ToString();
            txtteslimalan.Text = teslimalan.ToString();
            txtfirma.Text = firma.ToString();
        }

        private void FrmFaturaDetay_Load(object sender, EventArgs e)
        {
            detayget();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gridControl1.ExportToPdf(@"C:\\Users\\gulde\\Desktop\\test1.Pdf");
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridControl1.Print();
        }
    }
}
