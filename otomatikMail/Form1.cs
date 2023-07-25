using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace otomatikMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mesaj = new MailMessage();
            mesaj.From = new MailAddress("kendi_email_adresiniz");
            mesaj.To.Add(textBox1.Text);
            mesaj.Subject = textBox2.Text;
            mesaj.Body = richTextBox1.Text;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("kendi_email_adresiniz", "e_mail_sifreniz");
            smtp.Port = 587;
            smtp.Host = "smtp.office365.com";                                    //  "smtp.live.com";     //"smtp.gmail.com";
            smtp.EnableSsl = true;
            object userState = mesaj;

            try
            {
                smtp.SendAsync(mesaj, (object)mesaj);
                MessageBox.Show("Mail Gönderilmiştir");
                
            }
            catch (SmtpException ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message,"Mail Gönderme Sırasında bir hata oluştu.");
            }


        }
    }
}
