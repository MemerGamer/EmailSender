using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
//using System.Net.Mail.SmtpClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                UserName = "",
                Password = ""
                }
            };
            

            MailAddress FromEmail = new MailAddress("windoshuni@gmail.com", "Kovacs Balint Hunor");
            MailAddress ToEmail = new MailAddress(emailText.Text, "Someone");
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject=subjectText.Text,
                Body = messageText.Text
            };
            ///messsage sending
            Message.To.Add(ToEmail);
            ///outdated errorcheck solution
            
            /*try{
            Client.Send(Message);
            MessageBox.Show("Sent Successfully", "Done");
            
            }
            catch(Exception ex){
                MessageBox.Show("Something wrong\n" + ex.InnerException.Message, "Error");

            }*/
            Client.SendCompleted += Client_SendCompleted;    
            Client.SendMailAsync(Message);
        }
        /// error checks
        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e) 
        {
            if (e.Error != null) 
            {
                MessageBox.Show("Error Happening \n" + e.Error.Message, "Error");
                return;
            }
            MessageBox.Show("Sent Successfully", "Done");
        }
    }
}
