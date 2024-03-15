using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using _TicariOtomasyon.Helper;
using System.Data.SqlClient;
namespace _TicariOtomasyon.Formlar
{
    public partial class Frmrehber : Form
    {
        public Frmrehber()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void Frmrehber_Load(object sender, EventArgs e)
        {
            //MÜŞTERİ BİLGİLERİ
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,SOYAD,TELEFON,TELEFON2,MAIL From TBL_MUSTERILER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt; 

            //FİRMA BİLGİLERİ
            DataTable dt2 = new DataTable();
            SqlDataAdapter dv2 = new SqlDataAdapter("Select AD,YETKILIADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX From TBL_FIRMALAR", bgl.baglanti());
            dv2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }

        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                frm.mail = dr["MAIL"].ToString();
            }
            frm.ShowDialog();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["MAIL"].ToString();
            }
            frm.ShowDialog();

        }
    }
}
