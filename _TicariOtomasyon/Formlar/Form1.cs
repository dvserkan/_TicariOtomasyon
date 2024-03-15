using _TicariOtomasyon.Formlar;
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

namespace _TicariOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        FrmUrunler fr;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null)
            {
                fr = new FrmUrunler();
                fr.MdiParent = this;
                fr.Show();
            }
        }
        FrmMusteriler fr2;
        private void BtnMusterıler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr2 == null)
            {
                fr2 = new FrmMusteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        FrmFirmalar fr3;
        private void BtnFırmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null)
            {
                fr3 = new FrmFirmalar();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }
        FrmPersoneller fr4;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null)
            {
                fr4 = new FrmPersoneller(); 
                fr4.MdiParent = this;
                fr4.Show();
            }
        }
        Frmrehber fr5;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null)
            {
                fr5 = new Frmrehber();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }
        FrmBankalar fr6;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null)
            {
                fr6 = new FrmBankalar();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }
        Frmgiderler fr7;
        private void BtnGıderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null)
            {
                fr7 = new Frmgiderler();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }
        FrmFaturalar fr8;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null)
            {
                fr8 = new FrmFaturalar();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }

        FrmNotlar fr9;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null)
            {
                fr9 = new FrmNotlar();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }
    }
}
