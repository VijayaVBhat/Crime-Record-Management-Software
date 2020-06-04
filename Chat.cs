
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace E_Justice
{
    public partial class Chat : Form
    {
        private delegate void UpdateStatusCallback(string strMessage);
        public Chat()
        {
            InitializeComponent();
          
        }
       
        private void btnListen_Click_1(object sender, EventArgs e)
        {
            IPAddress ipAddr = IPAddress.Parse(txtIp.Text);
            ChatServer mainServer = new ChatServer(ipAddr);
            ChatServer.StatusChanged += new StatusChangedEventHandler(mainServer_StatusChanged);
            mainServer.StartListening();
            btnListen.Enabled = false;
            txtIp.Enabled = false;
            Name1.Start();
            MessageBox.Show("Default Administrative Username and password is. Username: Admin, Password: 123987", "Default Admin Username/Pass");
        }
        public void mainServer_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            this.Invoke(new UpdateStatusCallback(this.UpdateStatus), new object[] { e.EventMessage });
        }
        private void UpdateStatus(string strMessage)
        {
            txtLog.AppendText(strMessage + "\r\n");
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            this.Text = "Chat Server";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ChatServer.SendAdminMessage(textBox1.Text);
            textBox1.Clear();
            textBox1.Text = "";
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            AdminTools.muteUser(textBox3.Text, "Server");
            textBox3.Clear(); textBox3.Text = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            AdminTools.unMuteUser(textBox4.Text, "Server");
            textBox4.Clear(); textBox4.Text = "";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AdminTools.disconnectUser(textBox5.Text, null);
            textBox5.Clear(); textBox5.Text = "";
        }

      

    

        private void Name1_Tick_1(object sender, EventArgs e)
        {
            this.Text = "Running...";
            Name2.Start();
            Name1.Stop();
        }

        private void Name2_Tick_1(object sender, EventArgs e)
        {
            this.Text = "Services Hosted By: " + txtIp.Text;
            Name3.Start();
            Name2.Stop();
        }

        private void Name3_Tick_3(object sender, EventArgs e)
        {
            this.Text = "Running..." + txtIp.Text;
            Name1.Start();
            Name3.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

     

     

       

    }
}
