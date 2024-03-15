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
using System.Reflection;

namespace _TicariOtomasyon.Formlar
{
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        public void firmalarget()
        {
            SqlDataAdapter dt = new SqlDataAdapter("Execute FirmaBilgileri", bgl.baglanti());
            DataTable dataTable = new DataTable();
            dt.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }

        public void clear()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSektör.Text = "";
            txtYetkili.Text = "";
            txtyetkiligörev.Text = "";
            txtyetkilitc.Text = "";
            txttelefon1.Text = "";
            txttelefon2.Text = "";
            txttelefon3.Text = "";
            txtfax.Text = "";
            txtmail.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            txtVergid.Text = "";
            rchAdres.Text = "";
            txtözelkod1.Text = "";
            txtözelkod2.Text = "";
            txtözelkod3.Text = "";
            rchkod1.Text = "";
            rchkod2.Text = "";
            rchkod3.Text = "";
        }

        public void sehirget()
        {
            SqlCommand komut1 = new SqlCommand("Select sehir From TBL_ILLER", bgl.baglanti());
            SqlDataReader k1 = komut1.ExecuteReader();
            while (k1.Read())
            {
                cmbil.Properties.Items.Add(k1["sehir"]);
            }
            bgl.baglanti().Close();
        }

        public void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 From TBL_KODLAR", bgl.baglanti());
            SqlDataReader k1 = komut.ExecuteReader();
            while (k1.Read())
            {
                rchkod1.Text = k1[0].ToString();
            }
        }

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            firmalarget();
            sehirget();
            carikodaciklamalar();
            clear();
        }

        int i = 0;
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dt = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dt["ID"].ToString();
            txtAd.Text = dt["AD"].ToString();
            txtSektör.Text = dt["SEKTOR"].ToString();
            txtYetkili.Text = dt["YETKILIADSOYAD"].ToString();
            txtyetkiligörev.Text = dt["YETKILISTATU"].ToString();
            txtyetkilitc.Text = dt["YETKILITC"].ToString();
            txttelefon1.Text = dt["TELEFON1"].ToString();
            txttelefon2.Text = dt["TELEFON2"].ToString();
            txttelefon3.Text = dt["TELEFON3"].ToString();
            txtfax.Text = dt["FAX"].ToString();
            txtmail.Text = dt["MAIL"].ToString();
            cmbil.Text = dt["IL"].ToString();
            cmbilce.Text = dt["ILCE"].ToString();
            txtVergid.Text = dt["VERGIDAIRESI"].ToString();
            rchAdres.Text = dt["ADRES"].ToString();
            //txtözelkod1.Text = dt["OZELKOD1"].ToString();
            //txtözelkod2.Text = dt["OZELKOD2"].ToString();
            //txtözelkod3.Text = dt["OZELKOD3"].ToString();
            //rchkod1.Text = dt[18].ToString();
            //rchkod2.Text = dt[19].ToString();
            //rchkod3.Text = dt[20].ToString();
        }

        private void BtnReflesh_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();

            SqlCommand komut1 = new SqlCommand("Select ılce.ilce From TBL_ILCELER ılce inner join TBL_ILLER ıller on ılce.sehir = ıller.id  Where ıller.sehir = @p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", cmbil.Text);
            SqlDataReader rdr = komut1.ExecuteReader();
            while (rdr.Read())
            {
                cmbilce.Properties.Items.Add(rdr[0]);
            }
            bgl.baglanti().Close();
        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut1 = new SqlCommand("insert into TBL_FIRMALAR ( AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2, TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRESI,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", txtAd.Text);
                komut1.Parameters.AddWithValue("@p2", txtyetkiligörev.Text);
                komut1.Parameters.AddWithValue("@p3", txtYetkili.Text);
                komut1.Parameters.AddWithValue("@p4", txtyetkilitc.Text);
                komut1.Parameters.AddWithValue("@p5", txtSektör.Text);
                komut1.Parameters.AddWithValue("@p6", txttelefon1.Text);
                komut1.Parameters.AddWithValue("@p7", txttelefon2.Text);
                komut1.Parameters.AddWithValue("@p8", txttelefon3.Text);
                komut1.Parameters.AddWithValue("@p9", txtmail.Text);
                komut1.Parameters.AddWithValue("@p10", txtfax.Text);
                komut1.Parameters.AddWithValue("@p11", cmbil.Text);
                komut1.Parameters.AddWithValue("@p12", cmbilce.Text);
                komut1.Parameters.AddWithValue("@p13", txtVergid.Text);
                komut1.Parameters.AddWithValue("@p14", rchAdres.Text);
                komut1.Parameters.AddWithValue("@p15", txtözelkod1.Text);
                komut1.Parameters.AddWithValue("@p16", txtözelkod2.Text);
                komut1.Parameters.AddWithValue("@p17", txtözelkod3.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Firma Kaydı Eklenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                firmalarget();
                clear();
            }
            catch (Exception)
            {
                return;
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var karar = MessageBox.Show("Kayıt Silinecek Emin misiniz ?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (karar == DialogResult.Yes)
            {
                SqlCommand komut3 = new SqlCommand("Update TBL_FIRMALAR Set IsActive = 0 Where ID = @p1", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p1", txtId.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Firma Kaydı Silinmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                firmalarget();
                clear();

            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var karar = MessageBox.Show("Kayıt Güncellenecek Emin misiniz ?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (karar == DialogResult.Yes)
                {
                    SqlCommand komut4 = new SqlCommand("Update TBL_FIRMALAR Set AD=@p1,YETKILISTATU=@p2,YETKILIADSOYAD=@p3,YETKILITC=@p4,SEKTOR=@P5,TELEFON1=@p6,TELEFON2=@p7, TELEFON3=@p8,MAIL=@p9,FAX=@p10,IL=@p11,ILCE=@p12,VERGIDAIRESI=@p13,ADRES=@p14,OZELKOD1=@p15,OZELKOD2=@p16,OZELKOD3=@p17 Where ID = @p18", bgl.baglanti());
                    komut4.Parameters.AddWithValue("@p1", txtAd.Text);
                    komut4.Parameters.AddWithValue("@p2", txtyetkiligörev.Text);
                    komut4.Parameters.AddWithValue("@p3", txtYetkili.Text);
                    komut4.Parameters.AddWithValue("@p4", txtyetkilitc.Text);
                    komut4.Parameters.AddWithValue("@p5", txtSektör.Text);
                    komut4.Parameters.AddWithValue("@p6", txttelefon1.Text);
                    komut4.Parameters.AddWithValue("@p7", txttelefon2.Text);
                    komut4.Parameters.AddWithValue("@p8", txttelefon3.Text);
                    komut4.Parameters.AddWithValue("@p9", txtmail.Text);
                    komut4.Parameters.AddWithValue("@p10", txtfax.Text);
                    komut4.Parameters.AddWithValue("@p11", cmbil.Text);
                    komut4.Parameters.AddWithValue("@p12", cmbilce.Text);
                    komut4.Parameters.AddWithValue("@p13", txtVergid.Text);
                    komut4.Parameters.AddWithValue("@p14", rchAdres.Text);
                    komut4.Parameters.AddWithValue("@p15", txtözelkod1.Text);
                    komut4.Parameters.AddWithValue("@p16", txtözelkod2.Text);
                    komut4.Parameters.AddWithValue("@p17", txtözelkod3.Text);
                    komut4.Parameters.AddWithValue("@p18", txtId.Text);
                    komut4.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    firmalarget();
                    clear();
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
