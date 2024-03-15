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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        public void employeeget()
        {
            SqlDataAdapter dt = new SqlDataAdapter("Select * From TBL_PERSONELLER", bgl.baglanti());
            DataTable dt2 = new DataTable();
            dt.Fill(dt2);
            gridControl1.DataSource = dt2;
        }

        public void clear()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTel1.Text = "";
            txtTC.Text = "";
            txtMail.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
            rchAdres.Text = "";
            txtGörev.Text = "";
        }
        
        public void sehirget()
        {
            SqlCommand cmd = new SqlCommand("Select sehir From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbIl.Properties.Items.Add(dr[0]).ToString();
            }
            bgl.baglanti().Close();
        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            employeeget();

            sehirget();
        }

        int i = 0;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (i < 1)
            {
                clear();
                i += 1;
                return;
            }
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtAd.Text = dr["AD"].ToString();
            txtSoyad.Text = dr["SOYAD"].ToString();
            txtTel1.Text = dr["TELEFON"].ToString();
            txtTC.Text = dr["TC"].ToString();
            txtMail.Text = dr["MAIL"].ToString();
            cmbIl.Text = dr["IL"].ToString();
            cmbIlce.Text = dr["ILCE"].ToString();
            rchAdres.Text = dr["ADRES"].ToString();
            txtGörev.Text = dr["GOREV"].ToString();
        }

        private void BtnReflesh_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut1 = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", txtAd.Text);
                komut1.Parameters.AddWithValue("@p2", txtSoyad.Text);
                komut1.Parameters.AddWithValue("@p3", txtTel1.Text);
                komut1.Parameters.AddWithValue("@p4", txtTC.Text);
                komut1.Parameters.AddWithValue("@p5", txtMail.Text);
                komut1.Parameters.AddWithValue("@p6", cmbIl.Text);
                komut1.Parameters.AddWithValue("@p7", cmbIlce.Text);
                komut1.Parameters.AddWithValue("@p8", rchAdres.Text);
                komut1.Parameters.AddWithValue("@p9", txtGörev.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personel Eklenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                employeeget();
                clear();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var kabul = MessageBox.Show("Personel Silinecek Emin misiniz ?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kabul == DialogResult.Yes)
            {
                SqlCommand komut1 = new SqlCommand("Delete From TBL_PERSONELLER Where ID = @p1", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", txtId.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personel Silinmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                employeeget();
                clear();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var kabul = MessageBox.Show("Personel Güncellenecek Emin misiniz ?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kabul == DialogResult.Yes)
            {
                SqlCommand komut3 = new SqlCommand("Update TBL_PERSONELLER Set  AD = @p1 , SOYAD = @p2 , TELEFON = @p3 , TC = @p5 , MAIL = @p6 , IL = @p7 , ILCE = @p8 , ADRES = @p9 , GOREV = @p10 Where ID = @p11", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p1", txtAd.Text);
                komut3.Parameters.AddWithValue("@p2", txtSoyad.Text);
                komut3.Parameters.AddWithValue("@p3", txtTel1.Text);
                komut3.Parameters.AddWithValue("@p5", txtTC.Text);
                komut3.Parameters.AddWithValue("@p6", txtMail.Text);
                komut3.Parameters.AddWithValue("@p7", cmbIl.Text);
                komut3.Parameters.AddWithValue("@p8", cmbIlce.Text);
                komut3.Parameters.AddWithValue("@p9", rchAdres.Text);
                komut3.Parameters.AddWithValue("@p10", txtGörev.Text);
                komut3.Parameters.AddWithValue("@p11", txtId.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti();
                MessageBox.Show("Personel Güncellenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                employeeget();
                clear();
            }
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();

            SqlCommand komut1 = new SqlCommand("Select ılce.ilce From TBL_ILCELER ılce inner join TBL_ILLER ıller on ılce.sehir = ıller.id  Where ıller.sehir = @p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", cmbIl.Text);
            SqlDataReader rdr = komut1.ExecuteReader();
            while (rdr.Read())
            {
                cmbIlce.Properties.Items.Add(rdr[0]);
            }
            bgl.baglanti().Close();
        }
    }
}