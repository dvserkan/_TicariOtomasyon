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
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraEditors;
using System.Reflection.Emit;

namespace _TicariOtomasyon.Formlar
{
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        public void invoiceget()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dt1 = new SqlDataAdapter("Execute FaturaBilgileri", bgl.baglanti());
            dt1.Fill(dt);
            gridControl1.DataSource = dt;
        }

        public void clear()
        {
            txtId.Text = "";
            txtserino.Text = "";
            txtsırano.Text = "";
            txttarih.Text = "";
            txtsaat.Text = "";
            txtvergidairesi.Text = "";
            txtvergino.Text = "";
            txtalıcı.Text = "";
            txtteslimeden.Text = "";
            txtteslimalan.Text = "";
            txtalıcı.Text = "";
            txtürünadı.Text = "";
            txtadet.Text = "";
            txtfiyat.Text = "";
            txttutar.Text = "";
            lookfirmaıd.Text = "";
            lookfirmaıd.EditValue = "";

        }

        public void firmaget()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dt1 = new SqlDataAdapter("Select ID,AD From TBL_FIRMALAR", bgl.baglanti());
            dt1.Fill(dt);
            lookfirmaıd.Properties.NullText = "Lütfen Firma Seçiniz.";
            lookfirmaıd.Properties.ValueMember = "ID";
            lookfirmaıd.Properties.DisplayMember = "AD";
            lookfirmaıd.Properties.DataSource = dt;
        }

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            invoiceget();
            firmaget();
            clear();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                faturakey.Text = dr["FATURAKEY"].ToString();
                FrmFaturaDetay invoice = new FrmFaturaDetay();
                invoice.faturakey = faturakey.Text;
                invoice.ıd = Convert.ToInt32(txtId.Text);
                invoice.seri = txtserino.Text;
                invoice.sıra = txtsırano.Text;
                invoice.tarih = txttarih.Text;
                invoice.saat = txtsaat.Text;
                invoice.vergidaire = txtvergidairesi.Text;
                invoice.vergino = txtvergino.Text;
                invoice.alıcı = txtalıcı.Text;
                invoice.teslimeden = txtteslimeden.Text;
                invoice.teslimalan = txtteslimalan.Text;
                invoice.firma = lookfirmaıd.Text;
                invoice.Show();
            }
        }

        private void BtnReflesh_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["FATURABILGIID"].ToString();
            txtserino.Text = dr["SERI"].ToString();
            txtsırano.Text = dr["SIRANO"].ToString();
            txttarih.Text = dr["TARIH"].ToString();
            txtsaat.Text = dr["SAAT"].ToString();
            txtvergidairesi.Text = dr["VERGIDAIRE"].ToString();
            txtvergino.Text = dr["VERGINO"].ToString();
            txtteslimeden.Text = dr["TESLIMEDEN"].ToString();
            txtalıcı.Text = dr["ALICI"].ToString();
            txtteslimalan.Text = dr["TESLIMALAN"].ToString();
            lookfirmaıd.Text = dr["AD"].ToString();
            faturakey.Text = dr["FATURAKEY"].ToString();
        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            // FATURA KESİLECEK FİRMAYI EKLEME //
            string GuidKey = Guid.NewGuid().ToString();

            SqlCommand komut1 = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,VERGINO,ALICI,TESLIMEDEN,TESLIMALAN,FATURAKEY,FIRMA) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", txtserino.Text);
            komut1.Parameters.AddWithValue("@p2", txtsırano.Text);
            komut1.Parameters.AddWithValue("@p3", txttarih.Text);
            komut1.Parameters.AddWithValue("@p4", txtsaat.Text);
            komut1.Parameters.AddWithValue("@p5", txtvergidairesi.Text);
            komut1.Parameters.AddWithValue("@p6", txtvergino.Text);
            komut1.Parameters.AddWithValue("@p7", txtalıcı.Text);
            komut1.Parameters.AddWithValue("@p8", txtteslimeden.Text);
            komut1.Parameters.AddWithValue("@p9", txtteslimalan.Text);
            komut1.Parameters.AddWithValue("@p10", GuidKey);
            komut1.Parameters.AddWithValue("@p11", lookfirmaıd.EditValue);
            komut1.ExecuteNonQuery();

            // FATURA İÇERİSİNDE BULUNAN ÜRÜNLERİ EKLEME //

            SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY(URUN,MIKTAR,FIYAT,TUTAR,FATURAKEY) Values (@p1,@p2,@p3,@p4,@p6)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtürünadı.Text);
            komut2.Parameters.AddWithValue("@p2", txtadet.Text);
            komut2.Parameters.AddWithValue("@p3", Convert.ToDouble(txtfiyat.Text));
            komut2.Parameters.AddWithValue("@p4", Convert.ToDouble(txttutar.Text));
            komut2.Parameters.AddWithValue("@p6", GuidKey);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            invoiceget();
            clear();
            MessageBox.Show("Fatura Sisteme Kayıt Edilmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtvergino_EditValueChanged(object sender, EventArgs e)
        {
            txtvergino.Properties.MaxLength = 11;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                double adet, tutar, toplam;

                FrmFaturaÜrün frmürün = new FrmFaturaÜrün();
                frmürün.ShowDialog();
                if (frmürün.pro != null)
                {
                    txtürünadı.Text = frmürün.pro.name.ToString();
                    txtfiyat.Text = Math.Round(frmürün.pro.fiyat,2).ToString("n2");
                    txtadet.Text = frmürün.pro.adet.ToString();

                    adet = Convert.ToDouble(txtadet.Text);
                    tutar = Convert.ToDouble(txtfiyat.Text);
                    toplam = adet * tutar;
                    txttutar.Text = Math.Round(toplam,2).ToString("n2");
                }
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
                SqlCommand komut1 = new SqlCommand("Delete From TBL_FATURABILGI Where FATURAKEY=@p1 Delete From TBL_FATURADETAY Where FATURAKEY=@p1", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", faturakey.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Kaydı Silinmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                invoiceget();
                clear();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var karar = MessageBox.Show("Ürün Eklenecek Emin misiniz ?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (karar == DialogResult.Yes)
            {
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY(URUN,MIKTAR,FIYAT,TUTAR,FATURAKEY) Values (@p1,@p2,@p3,@p4,@p6)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtürünadı.Text);
                komut2.Parameters.AddWithValue("@p2", txtadet.Text);
                komut2.Parameters.AddWithValue("@p3", Convert.ToDouble(txtfiyat.Text));
                komut2.Parameters.AddWithValue("@p4", Convert.ToDouble(txttutar.Text));
                komut2.Parameters.AddWithValue("@p6", faturakey.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                invoiceget();
                clear();
                MessageBox.Show("Ürünler Faturaya İlave Edilmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var karar = MessageBox.Show($"Fatura Kaydı Güncellenecek Emin misiniz ?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (karar == DialogResult.Yes)
            {
                SqlCommand komut2 = new SqlCommand("Update TBL_FATURABILGI Set SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,VERGINO=@P6,ALICI=@P7,TESLIMEDEN=@P8,TESLIMALAN=@P9,FIRMA=@P10 Where FATURABILGIID=@P11", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtserino.Text);
                komut2.Parameters.AddWithValue("@p2", txtsırano.Text);
                komut2.Parameters.AddWithValue("@p3", txttarih.Text);
                komut2.Parameters.AddWithValue("@p4", txtsaat.Text);
                komut2.Parameters.AddWithValue("@p5", txtvergidairesi.Text);
                komut2.Parameters.AddWithValue("@p6", txtvergino.Text);
                komut2.Parameters.AddWithValue("@p7", txtalıcı.Text);
                komut2.Parameters.AddWithValue("@p8", txtteslimeden.Text);
                komut2.Parameters.AddWithValue("@p9", txtteslimalan.Text);
                komut2.Parameters.AddWithValue("@p10", lookfirmaıd.EditValue);
                komut2.Parameters.AddWithValue("@p11", txtId.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Kaydı Güncellenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                invoiceget();
                clear();
            }
        }

        private void txtfiyat_EditValueChanged(object sender, EventArgs e)
        {
            if (txtfiyat.Text == "0.00")
            {
                txttutar.Text = txtfiyat.Text.Replace(".", ",");
            }
         
        }

        private void txttutar_EditValueChanged(object sender, EventArgs e)
        {

            txttutar.Text = txttutar.Text.Replace(".", ",");
        }
    }
}