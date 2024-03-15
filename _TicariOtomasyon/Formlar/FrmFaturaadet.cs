using _TicariOtomasyon.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _TicariOtomasyon.Formlar
{
    public partial class FrmFaturaadet : Form
    {
        public FrmFaturaadet()
        {
            InitializeComponent();
        }

        public FaturaProducts productadets = null;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            productadets = new FaturaProducts();
            productadets.adet = Convert.ToDouble(txtadet.Text);
            this.Close();
        }
    }
}
