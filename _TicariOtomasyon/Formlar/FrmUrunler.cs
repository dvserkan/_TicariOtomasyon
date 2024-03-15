using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _TicariOtomasyon.Helper;
using DevExpress.Utils;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.Utils.MVVM;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraGrid.Views.Grid;
namespace _TicariOtomasyon.Formlar
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        public void list()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        public void clear()
        {
            Txtıd.Text = "";
            Txtad.Text = "";
            Txtmarka.Text = "";
            Txtmodel.Text = "";
            Txtyıl.Text = "";
            Nudadet.Value = 0;
            Txtsatıs.Text = "";
            Txtfiyat.Text = "";
            Rchdetay.Text = "";
            Txtad.Focus();
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            list();
            clear();
        }

        //Products products = new Products();
        List<Products> prList = new List<Products>();
        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                prList = new ProducGet().productsGet();

                if (prList.Where(x => x.productModel == Txtmodel.Text).Count() > 0)
                {
                    MessageBox.Show("Aynı Model ile Veritabanında Kayıt Bulunmaktadır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand komut1 = new SqlCommand("insert into TBL_URUNLER (URUNAD , MARKA , MODEL , YIL , ADET , ALISFIYAT , SATISFIYAT , DETAY) Values (@p1 , @p2 ,@p3 , @p4 ,  @p5 , @p6 , @p7 , @p8)", bgl.baglanti());
                    komut1.Parameters.AddWithValue("@p1", Txtad.Text);
                    komut1.Parameters.AddWithValue("@p2", Txtmarka.Text);
                    komut1.Parameters.AddWithValue("@p3", Txtmodel.Text);
                    komut1.Parameters.AddWithValue("@p4", Txtyıl.Text);
                    komut1.Parameters.AddWithValue("@p5", Convert.ToInt32(Nudadet.Value).ToString());
                    komut1.Parameters.AddWithValue("@p6", Convert.ToDouble(Txtsatıs.Text));
                    komut1.Parameters.AddWithValue("@p7", Convert.ToDouble(Txtfiyat.Text));
                    komut1.Parameters.AddWithValue("@p8", Rchdetay.Text);
                    komut1.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Ürün Eklenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    list();
                    clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Değerler Doldurulmadan Kayıt İşlemi Yapılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Txtıd.Text))
            {
                var kabul = MessageBox.Show("Kayıt Silinecek Emin minisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (kabul == DialogResult.Yes)
                {
                    SqlCommand komut2 = new SqlCommand("Delete From TBL_URUNLER Where ID = @p1", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p1", Txtıd.Text);
                    komut2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Kayıt Silinmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    list();
                    clear();
                }
            }
            else
            {
                MessageBox.Show("Kayıt Seçilmeden Silme İşlemi Yapılamaz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnReflesh_Click(object sender, EventArgs e)
        {
            clear();
        }

        int i = 0;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            double satıs, fiyat;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtıd.Text = dr["ID"].ToString();
            Txtad.Text = dr["URUNAD"].ToString();
            Txtmarka.Text = dr["MARKA"].ToString();
            Txtmodel.Text = dr["MODEL"].ToString();
            Txtyıl.Text = dr["YIL"].ToString();
            Nudadet.Value = Convert.ToInt32(dr["ADET"].ToString());
            satıs = Convert.ToDouble(dr["ALISFIYAT"].ToString());
            fiyat = Convert.ToDouble(dr["SATISFIYAT"].ToString());
            Txtsatıs.Text = satıs.ToString("n2");
            Txtfiyat.Text = fiyat.ToString("n2");

            Rchdetay.Text = dr["DETAY"].ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Txtıd.Text))
                {
                    var kabul = MessageBox.Show("Kayıt Güncelenecek Emin misiniz ?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (kabul == DialogResult.Yes)
                    {
                        SqlCommand komut3 = new SqlCommand("Update TBL_URUNLER Set URUNAD = @P1 , MARKA = @P2 , MODEL = @P3 , YIL = @P4 , ADET = @P5 , ALISFIYAT = @P6 , SATISFIYAT = @P7 , DETAY = @P8 Where ID = @P9", bgl.baglanti());
                        komut3.Parameters.AddWithValue("@P1", Txtad.Text);
                        komut3.Parameters.AddWithValue("@P2", Txtmarka.Text);
                        komut3.Parameters.AddWithValue("@P3", Txtmodel.Text);
                        komut3.Parameters.AddWithValue("@P4", Txtyıl.Text);
                        komut3.Parameters.AddWithValue("@P5", Nudadet.Text);
                        komut3.Parameters.AddWithValue("@P6", Convert.ToDouble(Txtsatıs.Text));
                        komut3.Parameters.AddWithValue("@P7", Convert.ToDouble(Txtfiyat.Text));
                        komut3.Parameters.AddWithValue("@P8", Rchdetay.Text);
                        komut3.Parameters.AddWithValue("@P9", Txtıd.Text);
                        komut3.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Kayıt Güncellenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        list();
                        clear();

                    }
                }
                else
                {
                    MessageBox.Show("Bilgiler Doldurulmadan Güncelleme işlemi Yapılamaz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

    }
}
