using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Speech.Synthesis;
using System.IO;
using System.Data.Common;
using System.Configuration;
using System.Security.Cryptography;
using CRMS;


namespace E_Justice
{
    public partial class Form1 : Form
    {
        StreamWriter sw = new StreamWriter("Logs.txt",true);
        public Form1()
        {
            InitializeComponent();
            SpeechSynthesizer s = new SpeechSynthesizer();
            s.Speak("Hello. Welcome to E-Justice. Please login.");
            
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            const string message = "Are you sure that you would like to close?";
            const string caption = "Close Window";
            var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            e.Cancel = (result == DialogResult.No);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRMS.NewAcc acc = new CRMS.NewAcc();
           acc.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
     
            try
            {
                if (textBox1.Text == "" && textBox2.Text == "" || textBox1.Text == "" || textBox2.Text == "")
                {
                    SpeechSynthesizer se = new SpeechSynthesizer();
                    se.Speak("Please provide your details.");
                }
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "Select officerID,accessp,password from Officer";
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (radioButton1.Checked)
                    {
                        if (reader["accessp"].Equals("Admin"))
                        {

                           
                            if (textBox1.Text == (reader["officerID"].ToString()) ) 
                            {
                                 string cipherText = reader["password"].ToString();
                                 string pass = Decrypt(cipherText);

                                 if (textBox2.Text == (pass))
                                 {
                                     sw.WriteLine("ID:" + textBox1.Text + "Login time:" + DateTime.Now.ToString());
                                     sw.Close();
                                     SpeechSynthesizer st1 = new SpeechSynthesizer();

                                     st1.Speak("Hello administrator you are now logged in");
                                     st1.Speak("Remember justice is for everyone");
                                     AdminForm af = new AdminForm();
                                     af.Show();
                                 }
                            }
                           

                        }
                        else
                        {
                            SpeechSynthesizer st2 = new SpeechSynthesizer();
                            st2.Speak("Please provide correct information");


                        }

                    }
                   
                    
                    if (radioButton2.Checked)
                    {
                        if (reader["accessp"].Equals("Officer"))
                        {
                            

                            if (textBox1.Text == (reader["officerID"].ToString()))
                            {
                                string cipherText = reader["password"].ToString();
                                string pass = Decrypt(cipherText);
                                if (textBox2.Text == (pass))
                                {
                                    sw.WriteLine("ID:" + textBox1.Text + "Login time:" + DateTime.Now.ToString());
                                    sw.Close();
                                    SpeechSynthesizer st3 = new SpeechSynthesizer();

                                    st3.Speak("Hello officer you are now logged in");
                                    st3.Speak("Remember justice is for everyone");
                                     MainForm mf = new MainForm();
                                     mf.Show();
                                }
                            }
                        
                           

                        }
                        else
                        {
                            SpeechSynthesizer st4 = new SpeechSynthesizer();
                            st4.Speak("Please provide correct information");
                        }
                    }

                   
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 

        }


        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText.Replace(" ","+"));
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
       
    }
}
