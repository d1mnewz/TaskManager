using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            Refresh_Grid();
            //MessageBox.Show("Percents", "lol" + GetCpuUsage());

        }
        public int GetCpuUsage()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", Process.GetCurrentProcess().MachineName);
            cpuCounter.NextValue();
            Thread.Sleep(1000);
            return (int)cpuCounter.NextValue();
        }

        private void Refresh_Grid()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = ProcessToView.GetProcesses();
            this.progressBar1.Value = GetCpuUsage();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F5))
            {
                Refresh_Grid();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh_Grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pizzapizza1
            MailMessage mail = new MailMessage("pizzaland.is.real@gmail.com", "info@pizza-celentano.rv.ua");
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.googlemail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("pizzaland.is.real@gmail.com", "pizzapizza1");
            mail.Subject = "Pizza plz, homies";
            mail.Body = "hello my little pizza friend\nim going to build a pizzaland & i need your help brah\ngive me few slices so you will help me to reach my destiny! \nPizza-Land is real ! Go for it!"  ;
            client.Send(mail);
            MessageBox.Show("Pizza inc my lord", "wow such pizza");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
