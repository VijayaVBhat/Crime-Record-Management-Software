using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Security.Cryptography;

namespace CRMS
{
    public partial class NewAcc : Form
    {
        String Chosen_File = "";
        public NewAcc()
        {
            InitializeComponent();
        }

        private void NewAcc_Load(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            const string message = "Are you sure that you would like to close?";
            const string caption = "Close Form";
            var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            e.Cancel = (result == DialogResult.No);
        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double x = Double.Parse(textBox3.Text);
                errorProvider1.SetError(textBox3, "");

            }
            catch
            {
                errorProvider1.SetError(textBox3, "Enter digits only");
            }

        }




        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double x = Double.Parse(textBox4.Text);
                errorProvider1.SetError(textBox4, "");
                if(textBox3.Text==textBox4.Text)
                    errorProvider1.SetError(textBox4, "Contact numbers cannot be the same");

            }
            catch
            {
                errorProvider1.SetError(textBox4, "Enter digits only");
                
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var boxes = Controls.OfType<TextBox>();
                var rad = Controls.OfType<RadioButton>();

                foreach (var box in boxes)
                {
                    if (string.IsNullOrWhiteSpace(box.Text))
                    {
                        errorProvider1.SetError(box, "Please fill the required field");
                    }
                }

                foreach (var box1 in rad)
                {
                    if (string.IsNullOrWhiteSpace(box1.Text))
                    {
                        errorProvider1.SetError(box1, "Please fill the required field");
                    }
                }

                try
                {

                    Image img = Image.FromFile(Chosen_File);
                }
                catch
                {

                }

                

               
                DateTime check;
                bool checker = false;
                if (DateTime.TryParse(dateTimePicker1.Text, out check) && check >= DateTime.Now)
                {
                     checker = true;
                     MessageBox.Show("Date of birth is today!");
                }


             

                bool go = true;
                string gender = "";
                string prv = "";
                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else if (radioButton2.Checked)
                {
                    gender = "Female";
                }
                if (radioButton3.Checked)
                {
                    prv = "Admin";
                }
                else if (radioButton4.Checked)
                {
                    prv = "Officer";
                }
                if (gender.Equals(""))
                {
                    MessageBox.Show(groupBox1, "Select Gender");
                }
                if (prv.Equals(""))
                {
                   MessageBox.Show(groupBox2, "Select Privilege");
                }
                if (comboBox1.SelectedItem == null)
                {
                    go = false;
                    MessageBox.Show("Select Rank");
                }
                if (!textBox6.Text.Equals(textBox7.Text))
                {
                    go = false;
                    MessageBox.Show("Re-type password");
                }

                String email = textBox5.Text;

                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                System.Text.RegularExpressions.Match match = regex.Match(email);
                if (match.Success)
                { }
                else
                    errorProvider1.SetError(textBox5, "Re-type email");

                if (go)
                {


                    try
                    {

                        String clearText = textBox6.Text;;
                        
                        String pass=Encrypt(clearText);



                        byte[] byteImg = null;
                        try
                        {
                            
                            FileStream fs = new FileStream(this.textBoximgpath.Text, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);
                            byteImg = br.ReadBytes((int)fs.Length);
                        }
                        catch
                        {
                           
                        }
                        string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
                        SqlConnection cn2 = new SqlConnection(connectionString);

                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = cn2;
                        cn2.Open();
                        cmd2.CommandText = "select accessp from Officer";

                        SqlDataReader accesspRdr;

                        accesspRdr = cmd2.ExecuteReader();
                        String accessp = "";
                        int i=0;
                       if (accesspRdr.HasRows)
                        {
                            while (accesspRdr.Read())
                            {
                                

                                    accessp = accesspRdr["accessp"].ToString();
                                   
                                        if (accessp.Equals("Admin") && prv.Equals("Admin"))
                                            MessageBox.Show("There cannot be more than one Admin!!");
                                    }
                                }
                            

                        
                       
                        cn2.Close();
                        

                        
                        SqlConnection cn1 = new SqlConnection(connectionString);

                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = cn1;
                        cn1.Open();
                        cmd1.CommandText = "select officerID from Officer";

                        SqlDataReader usernameRdr1;

                        usernameRdr1 = cmd1.ExecuteReader();
                        string username11 = "";

                        if (usernameRdr1.HasRows)
                        {
                            while (usernameRdr1.Read())
                            {
                                username11 = usernameRdr1["officerID"].ToString();
                            }
                        }
                        int id = 1;

                        String str = textBox1.Text;
                        String name = "";
                        string[] output = str.Split(' ');
                        foreach (string s in output)
                        {
                            name = name + s[0];
                        }

                        string originalString = username11;
                        string letters = string.Empty;
                        string numbers = string.Empty;

                        foreach (char c in originalString)
                        {
                            if (Char.IsLetter(c))
                            {
                                letters += c;
                            }
                            if (Char.IsNumber(c))
                            {
                                numbers += c;
                            }
                        }
                        String nw=""+DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year+id ;
                        String ID = name + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                        if (username11 == ID||nw==numbers)
                            id++;
                        String OID = name + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                        cn1.Close();


                        SqlConnection cn = new SqlConnection(connectionString);

                        cn.Open();


                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                        {
                            const string message = "Are you sure that you want to submit?";
                            const string caption = "Confirm Submission";
                             DialogResult result = MessageBox.Show(message, caption,
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question); ;
                             if (result.Equals(DialogResult.OK))
                             {
                                 cmd.CommandText = "insert into Officer values(@officerID,@name,@gender,@dob,@address,@contactno1,@contactno2,@emailID,@doj,@rank,@password,@accessp,@photo)";

                                 cmd.Parameters.AddWithValue("@officerID", OID);
                                 cmd.Parameters.AddWithValue("@name", textBox1.Text);
                                 cmd.Parameters.AddWithValue("@gender", gender);
                                 cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value.ToShortDateString());

                                 cmd.Parameters.AddWithValue("@address", textBox2.Text);
                                 cmd.Parameters.AddWithValue("@contactno1", textBox3.Text);
                                 cmd.Parameters.AddWithValue("@contactno2", textBox4.Text);
                                 cmd.Parameters.AddWithValue("@emailID", textBox5.Text);
                                 cmd.Parameters.AddWithValue("@doj", dateTimePicker2.Value.ToShortDateString());
                                 cmd.Parameters.AddWithValue("@rank", comboBox1.SelectedItem.ToString());
                                 cmd.Parameters.AddWithValue("@accessp", prv);
                                 cmd.Parameters.AddWithValue("@password", pass);
                                 cmd.Parameters.AddWithValue("@photo", byteImg);


                                 cmd.ExecuteNonQuery();

                                 cn.Close();

                                 MessageBox.Show("Data added successfully! ID is " + OID, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 this.Controls.Clear();
                                 this.InitializeComponent();

                             }
                             else
                             { }
                        
                        }

                        
                        else
                        {
                            MessageBox.Show("Please fill the fields!");
                        }
                            /*cmd.CommandText = "insert into Officer(officerID,name,gender,dob,address,contactno1,doj,rank,password,accessp,photo) values(@officerID,@name,@gender,@dob,@address,@contactno1,@doj,@rank,@password,@accessp,@photo)";

                            cmd.Parameters.AddWithValue("@officerID", OID);
                            cmd.Parameters.AddWithValue("@name", textBox1.Text);
                            cmd.Parameters.AddWithValue("@gender", gender);
                            cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value.ToShortDateString());

                            cmd.Parameters.AddWithValue("@address", textBox2.Text);
                            cmd.Parameters.AddWithValue("@contactno1", textBox3.Text);
                           
                            cmd.Parameters.AddWithValue("@doj", dateTimePicker2.Value.ToShortDateString());
                            cmd.Parameters.AddWithValue("@rank", comboBox1.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@accessp", prv);
                            cmd.Parameters.AddWithValue("@password", textBox6.Text);
                            cmd.Parameters.AddWithValue("@photo", byteImg);


                            cmd.ExecuteNonQuery();

                            cn.Close();

                            MessageBox.Show("Data added successfully!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Controls.Clear();
                            this.InitializeComponent();*/
                        

                        
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }




            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";


            if (open.ShowDialog() == DialogResult.OK)
            {
              
                    Chosen_File = open.FileName.ToString();
                    textBoximgpath.Text = Chosen_File;

                    pictureBox1.ImageLocation = Chosen_File;
               
                
                
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
               && !char.IsDigit(e.KeyChar)
               && e.KeyChar != '.' || e.KeyChar == 8)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }


        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }

}






















