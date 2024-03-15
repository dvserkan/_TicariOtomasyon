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
    public partial class Frmgiderler : Form
    {
        public Frmgiderler()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        public void giderlerget()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dt1 = new SqlDataAdapter("Select * From TBL_GIDERLER",bgl.baglanti());
            dt1.Fill(dt);
            gridControl1.DataSource = dt;
        }

        public void clear()
        {
            txtId.Text = "";
            cmbAy.Text = "";
            cmbYıl.Text = "";
            txtElektrik.Text = "";
            txtSu.Text = "";
            txtDogal.Text = "";
            txtinter.Text = "";
            txtmaas.Text = "";
            txtekstra.Text = "";
            rchNotlar.Text = "";
        }

        private void Frmgiderler_Load(object sender, EventArgs e)
        {
            giderlerget();
            clear();
        }
        
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            txtId.Text = dr["ID"].ToString();
            cmbAy.Text = dr["AY"].ToString();
            cmbYıl.Text = dr["YIL"].ToString();
            txtElektrik.Text = dr["ELEKTRIK"].ToString();
            txtSu.Text = dr["SU"].ToString();
            txtDogal.Text = dr["DOGALGAZ"].ToString();
            txtinter.Text = dr["INTERNET"].ToString();
            txtmaas.Text = dr["MAASLAR"].ToString();
            txtekstra.Text = dr["EKSTRA"].ToString();
            rchNotlar.Text = dr["NOTLAR"].ToString();
        }

        private void BtnReflesh_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut1 = new SqlCommand("insert into TBL_GIDERLER (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) Values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", cmbAy.Text);
                komut1.Parameters.AddWithValue("@p2", cmbYıl.Text);
                komut1.Parameters.AddWithValue("@p3", Convert.ToDouble(txtElektrik.Text));
                komut1.Parameters.AddWithValue("@p4", Convert.ToDouble(txtSu.Text));
                komut1.Parameters.AddWithValue("@p5", Convert.ToDouble(txtDogal.Text));
                komut1.Parameters.AddWithValue("@p6", Convert.ToDouble(txtinter.Text));
                komut1.Parameters.AddWithValue("@p7", Convert.ToDouble(txtmaas.Text));
                komut1.Parameters.AddWithValue("@p8", Convert.ToDouble(txtekstra.Text));
                komut1.Parameters.AddWithValue("@p9", rchNotlar.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Gider Eklenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                giderlerget();
                clear();
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                var kabul = MessageBox.Show("Kayıt Silinecek Emin misiniz ?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (kabul == DialogResult.Yes)
                {
                    SqlCommand komut2 = new SqlCommand("Delete From TBL_GIDERLER Where ID = @p1", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p1", txtId.Text);
                    komut2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Gider Silinmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    giderlerget();
                    clear();
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var kabul = MessageBox.Show("Kayıt Güncellenecek Emin misiniz ?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (kabul == DialogResult.Yes)
                {
                    SqlCommand komut3 = new SqlCommand("Update TBL_GIDERLER Set AY=@p1,YIL=@P2, ELEKTRIK=@P3,SU=@P4,DOGALGAZ=@P5,INTERNET=@P6,MAASLAR=@P7,EKSTRA=@P8,NOTLAR=@P9 Where ID=@p10", bgl.baglanti());
                    komut3.Parameters.AddWithValue("@p1", cmbAy.Text);
                    komut3.Parameters.AddWithValue("@p2", cmbYıl.Text);
                    komut3.Parameters.AddWithValue("@p3", Convert.ToDouble(txtElektrik.Text));
                    komut3.Parameters.AddWithValue("@p4", Convert.ToDouble(txtSu.Text));
                    komut3.Parameters.AddWithValue("@p5", Convert.ToDouble(txtDogal.Text));
                    komut3.Parameters.AddWithValue("@p6", Convert.ToDouble(txtinter.Text));
                    komut3.Parameters.AddWithValue("@p7", Convert.ToDouble(txtmaas.Text));
                    komut3.Parameters.AddWithValue("@p8", Convert.ToDouble(txtekstra.Text));
                    komut3.Parameters.AddWithValue("@p9", rchNotlar.Text);
                    komut3.Parameters.AddWithValue("@p10", txtId.Text);
                    komut3.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Gider Güncellenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    giderlerget();
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
