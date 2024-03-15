using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace _TicariOtomasyon.Formlar
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        public string mail;

        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtMail.Text = mail;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(rchmsj.Text))
                {
                    MailMessage mesajim = new MailMessage();
                    SmtpClient istemci = new SmtpClient();
                    istemci.Credentials = new System.Net.NetworkCredential("serkancakirr28@gmail.com", "nebw wkzw crkf qwvo");
                    istemci.Port = 587;
                    istemci.Host = "smtp.gmail.com";
                    istemci.EnableSsl = true;
                    mesajim.To.Add(txtMail.Text);                                  // HANGİ MAİL ADRESİNE GÖNDERİLECEĞİ
                    mesajim.From = new MailAddress("serkancakirr28@gmail.com");    // HANGİ MAİL ADRESİNDEN GÖNDERİLECEĞİ
                    mesajim.Subject = txtkonu.Text;                                // MAİL KONUSU
                    mesajim.Body = rchmsj.Text;                                    // MAİL İÇERİĞİ 
                    istemci.Send(mesajim);
                    MessageBox.Show("Mail Gönderilmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mesaj Değeri Boş Gönderilemez", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Mail Gönderiminde Hata Oluşmuştur.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        }
    }
}
