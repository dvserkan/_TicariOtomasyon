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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        public void customerget()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dt1 = new SqlDataAdapter("Select * from TBL_MUSTERILER", bgl.baglanti());
            dt1.Fill(dt);
            gridControl1.DataSource = dt;
        }
        public void sehirget()
        {
            SqlCommand komut = new SqlCommand("Select SEHİR From TBL_ILLER", bgl.baglanti());
            SqlDataReader k1 = komut.ExecuteReader();
            while (k1.Read())
            {
                cmbIl.Properties.Items.Add(k1[0]);
            }
            bgl.baglanti().Close();
        }

        public void clear()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTel1.Text = "";
            txtTel2.Text = "";
            txtTC.Text = "";
            txtMail.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
            txtVergid.Text = "";
            rchAdres.Text = "";
            txtAd.Focus();
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            customerget();
            sehirget();
            clear();
        }

        Customers customers = new Customers();
        List<Customers> crListc = new List<Customers>();
        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                crListc = new CustomerGet().CustomersGet();

                if (crListc.Where(x => x.customerTc == txtTC.Text).Count() > 0)
                {
                    MessageBox.Show("Aynı TC ile Veritabanında Kayıt Bulunmaktadır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand komut1 = new SqlCommand("Insert Into TBL_MUSTERILER ( AD , SOYAD , TELEFON , TELEFON2 , TC , MAIL , IL , ILCE , ADRES , VERGIDAIRE) Values (@p1 , @p2 , @p3 , @p4 , @p5 , @p6 , @p7 , @p8 , @p9 , @p10)", bgl.baglanti());
                    komut1.Parameters.AddWithValue("@p1", txtAd.Text);
                    komut1.Parameters.AddWithValue("@p2", txtSoyad.Text);
                    komut1.Parameters.AddWithValue("@p3", txtTel1.Text);
                    komut1.Parameters.AddWithValue("@p4", txtTel2.Text);
                    komut1.Parameters.AddWithValue("@p5", txtTC.Text);
                    komut1.Parameters.AddWithValue("@p6", txtMail.Text);
                    komut1.Parameters.AddWithValue("@p7", cmbIl.Text);
                    komut1.Parameters.AddWithValue("@p8", cmbIlce.Text);
                    komut1.Parameters.AddWithValue("@p9", rchAdres.Text);
                    komut1.Parameters.AddWithValue("@p10", txtVergid.Text);
                    komut1.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Müşteri Eklenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    customerget();
                    clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Değerler Doldurulmadan Kayıt İşlemi Yapılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnReflesh_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtId.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                txtTel1.Text = dr["TELEFON"].ToString();
                txtTel2.Text = dr["TELEFON2"].ToString();
                txtTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                cmbIl.Text = dr["IL"].ToString();
                cmbIlce.Text = dr["ILCE"].ToString();
                rchAdres.Text = dr["ADRES"].ToString();
                txtVergid.Text = dr["VERGIDAIRE"].ToString();
            }
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();

            SqlCommand komut2 = new SqlCommand("Select ılce.ilce From TBL_ILCELER ılce inner join TBL_ILLER ıller on ılce.sehir = ıller.id  Where ıller.sehir = @p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", cmbIl.Text);
            SqlDataReader k2 = komut2.ExecuteReader();
            while (k2.Read())
            {
                cmbIlce.Properties.Items.Add(k2[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var kabul = MessageBox.Show("Kayıt Silinecek Emin misiniz ?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (kabul == DialogResult.Yes)
            {
                SqlCommand komut3 = new SqlCommand("Delete From TBL_MUSTERILER Where ID = @P1", bgl.baglanti());
                komut3.Parameters.AddWithValue("@P1", txtId.Text);
                komut3.ExecuteNonQuery();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var kabul = MessageBox.Show("Kayıt Güncellenecek Emin misiniz ?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (kabul == DialogResult.Yes)
            {
                SqlCommand komut3 = new SqlCommand("Update TBL_MUSTERILER Set  AD = @p1 , SOYAD = @p2 , TELEFON = @p3 , TELEFON2 = @p4 , TC = @p5 , MAIL = @p6 , IL = @p7 , ILCE = @p8 , ADRES = @p9 , VERGIDAIRE = @p10 Where ID = @p11", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p1", txtAd.Text);
                komut3.Parameters.AddWithValue("@p2", txtSoyad.Text);
                komut3.Parameters.AddWithValue("@p3", txtTel1.Text);
                komut3.Parameters.AddWithValue("@p4", txtTel2.Text);
                komut3.Parameters.AddWithValue("@p5", txtTC.Text);
                komut3.Parameters.AddWithValue("@p6", txtMail.Text);
                komut3.Parameters.AddWithValue("@p7", cmbIl.Text);
                komut3.Parameters.AddWithValue("@p8", cmbIlce.Text);
                komut3.Parameters.AddWithValue("@p9", rchAdres.Text);
                komut3.Parameters.AddWithValue("@p10", txtVergid.Text);
                komut3.Parameters.AddWithValue("@p11", txtId.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti();
                MessageBox.Show("Müşteri Güncellenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                customerget();
                clear();
            }
        }
    }
}
