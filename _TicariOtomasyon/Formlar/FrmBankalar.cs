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
using DevExpress.Data.Linq.Helpers;
namespace _TicariOtomasyon.Formlar
{
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        public void bankget()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dt1 = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti()); //PROSEDÜR İLE VERİ ÇEKME
            dt1.Fill(dt);
            gridControl1.DataSource = dt;
        }

        public void clear()
        {
            txtId.Text = "";
            txtAd.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
            txtsube.Text = "";
            txtiban.Text = "";
            txthesapno.Text = "";
            txtyetkili.Text = "";
            txttel.Text = "";
            txttarih.Text = "";
            txthesaptürü.Text = "";
            lookUpEdit1.Text = "";
            lookUpEdit1.EditValue = "";

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

        public void firmaget()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dt1 = new SqlDataAdapter("Select ID,AD From TBL_FIRMALAR", bgl.baglanti());
            dt1.Fill(dt);
            lookUpEdit1.Properties.NullText = "Lütfen Bir Firma Seçiniz";
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AD";
            lookUpEdit1.Properties.DataSource = dt;
        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            bankget();
            sehirget();
            firmaget();
            clear();
        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("insert into TBL_BANKALAR (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", txtAd.Text);
            komut1.Parameters.AddWithValue("@p2", cmbIl.Text);
            komut1.Parameters.AddWithValue("@p3", cmbIlce.Text);
            komut1.Parameters.AddWithValue("@p4", txtsube.Text);
            komut1.Parameters.AddWithValue("@p5", txtiban.Text);
            komut1.Parameters.AddWithValue("@p6", txthesapno.Text);
            komut1.Parameters.AddWithValue("@p7", txtyetkili.Text);
            komut1.Parameters.AddWithValue("@p8", txttel.Text);
            komut1.Parameters.AddWithValue("@p9", txttarih.Text);
            komut1.Parameters.AddWithValue("@p10", txthesaptürü.Text);
            komut1.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgileri Eklenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bankget();
            clear();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Delete From TBL_BANKALAR Where ID = @p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtId.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgileri Silinmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bankget();
            clear();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("UPDATE TBL_BANKALAR  Set BANKAADI =@p1, IL = @p2 ,ILCE = @p3, SUBE = @p4, IBAN = @p5, HESAPNO = @p6, YETKILI = @p7, TELEFON = @p8,TARIH = @p9, HESAPTURU = @p10, FIRMAID=@p11 WHERE ID = @p12", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", txtAd.Text);
            komut3.Parameters.AddWithValue("@p2", cmbIl.Text);
            komut3.Parameters.AddWithValue("@p3", cmbIlce.Text);
            komut3.Parameters.AddWithValue("@p4", txtsube.Text);
            komut3.Parameters.AddWithValue("@p5", txtiban.Text);
            komut3.Parameters.AddWithValue("@p6", txthesapno.Text);
            komut3.Parameters.AddWithValue("@p7", txtyetkili.Text);
            komut3.Parameters.AddWithValue("@p8", txttel.Text);
            komut3.Parameters.AddWithValue("@p9", txttarih.Text);
            komut3.Parameters.AddWithValue("@p10", txthesaptürü.Text);
            komut3.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue);
            komut3.Parameters.AddWithValue("@p12", txtId.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgileri Güncellenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bankget();
            clear();
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            txtId.Text = dr["ID"].ToString();
            txtAd.Text = dr["BANKAADI"].ToString();
            cmbIl.Text = dr["IL"].ToString();
            cmbIlce.Text = dr["ILCE"].ToString();
            txtsube.Text = dr["SUBE"].ToString();
            txtiban.Text = dr["IBAN"].ToString();
            txthesapno.Text = dr["HESAPNO"].ToString();
            txtyetkili.Text = dr["YETKILI"].ToString();
            txttel.Text = dr["TELEFON"].ToString();
            txttarih.Text = dr["TARIH"].ToString();
            txthesaptürü.Text = dr["HESAPTURU"].ToString();
            lookUpEdit1.Text = dr["AD"].ToString();
        }

        private void BtnReflesh_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
