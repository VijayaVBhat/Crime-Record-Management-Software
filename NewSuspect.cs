using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace CRMS
{
    public partial class NewSuspect : Form
    {
        String Chosen_File = "";
        public NewSuspect()
        {
            InitializeComponent();
        }

        private void NewSuspect_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'crmsDataSet1.Officer' table. You can move, or remove it, as needed.
            this.officerTableAdapter1.Fill(this.crmsDataSet1.Officer);
            // TODO: This line of code loads data into the '_C__PROGRAM_FILES_MICROSOFT_SQL_SERVER_MSSQL10_50_SQLEXPRESS_MSSQL_DATA_CRMS_MDFDataSet1.Officer' table. You can move, or remove it, as needed.
            BindData1();
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

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] byteImg1 = null;
            byte[] byteImg2 = null;
            String go = "";
            try
            {
                var boxes = Controls.OfType<TextBox>();
                var rad = Controls.OfType<RadioButton>();
                var comb = Controls.OfType<ComboBox>();
                var rch = Controls.OfType<RichTextBox>();

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

                foreach (var box2 in comb)
                {
                    if (string.IsNullOrWhiteSpace(box2.Text))
                    {
                        errorProvider1.SetError(box2, "Please fill the required field");
                    }
                }

                foreach (var box3 in rch)
                {
                    if (string.IsNullOrWhiteSpace(box3.Text))
                    {
                        errorProvider1.SetError(box3, "Please fill the required field");
                    }
                }
            }
            catch { }
            string imagename1 = pictureBox1.ImageLocation;
            string imagename2 = pictureBox2.ImageLocation;
            
            try
            {
                if (textBox8.Text == "" && textBox9.Text=="")
                {
                    MessageBox.Show("Add photographs!");
                    go = "false";
                }
                    
                    try
                    {

                        FileStream fs = new FileStream(this.textBox8.Text, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        byteImg1 = br.ReadBytes((int)fs.Length);
                    }
                    catch
                    {


                    }
                
                
                    
                    try
                    {

                        FileStream fs = new FileStream(this.textBox9.Text, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        byteImg2 = br.ReadBytes((int)fs.Length);
                    }
                    catch
                    {

                    }
                
               
                string height=comboBox2.Text + comboBox3.Text;
                

                string gender = "";
                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else if (radioButton2.Checked)
                {
                    gender = "Female";
                }
                if (gender.Equals(""))
                {
                    MessageBox.Show(groupBox1, "Select Gender");
                }

                string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
                SqlConnection cn = new SqlConnection(connectionString);

                SqlConnection cn1 = new SqlConnection(connectionString);

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = cn1;
                cn1.Open();
                cmd1.CommandText = "select suspectID from Suspect";

                SqlDataReader usernameRdr;

                usernameRdr = cmd1.ExecuteReader();
                string username11 = "";

                if (usernameRdr.HasRows)
                {
                    while (usernameRdr.Read())
                    {
                        username11 = usernameRdr["suspectID"].ToString();
                    }
                }
                int id = 1;

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
                String nw = "" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                String ID = "S" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                if (username11 == ID || nw == numbers)
                    id++;
                String OID = "S" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                cn1.Close();

                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (textBox1.Text != "" && textBox2.Text != "" && richTextBox1.Text != "" && richTextBox2.Text != "" && comboBox2.SelectedItem != null && comboBox4.SelectedItem != null && go!="false")
                {
                    try
                    { const string message = "Are you sure that you want to submit?";
                            const string caption = "Confirm Submission";
                             DialogResult result = MessageBox.Show(message, caption,
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question); ;
                             if (result.Equals(DialogResult.OK))
                             {
                                 cmd.CommandText = "insert into Suspect(suspectID,officerID,name,gender,age,height,bodysign,othsuspects,complaintdetails,alias,address,image1,image2,status) values(@suspectID,@officerID,@name,@gender,@age,@height,@bodysign,@othsuspects,@complaintdetails,@alias,@address,@image1,@image2,@status)";

                                 cmd.Parameters.AddWithValue("@suspectID", OID);
                                 cmd.Parameters.AddWithValue("@officerID", comboBox1.Text);
                                 cmd.Parameters.AddWithValue("@name", textBox1.Text);
                                 cmd.Parameters.AddWithValue("@gender", gender);
                                 cmd.Parameters.AddWithValue("@age", textBox3.Text);
                                 cmd.Parameters.AddWithValue("@height", height);
                                 cmd.Parameters.AddWithValue("@bodysign", textBox4.Text);
                                 cmd.Parameters.AddWithValue("@othsuspects", textBox5.Text + "," + textBox6.Text + "," + textBox7.Text);
                                 cmd.Parameters.AddWithValue("@complaintdetails", richTextBox1.Text);
                                 cmd.Parameters.AddWithValue("@alias", textBox2.Text);
                                 cmd.Parameters.AddWithValue("@address", richTextBox2.Text);
                                 cmd.Parameters.AddWithValue("@image1", byteImg1);
                                 cmd.Parameters.AddWithValue("@image2", byteImg2);



                                 cmd.Parameters.AddWithValue("@status", comboBox4.Text);

                                 try
                                 {
                                     cmd.ExecuteNonQuery();
                                 }
                                 catch { }
                                 cn.Close();

                                 MessageBox.Show("Data added successfully! ID is " + OID, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                 this.Controls.Clear();
                                 this.InitializeComponent();
                                 BindData1();
                             }
                             else
                             { }
                    }
                    catch { }

                }
                else
                {
                    MessageBox.Show("Please fill the fields");
                }
            }

            catch (Exception ex)
            {



                MessageBox.Show(ex.Message);



            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
            openFileDialog1.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
            openFileDialog2.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox2.ImageLocation = openFileDialog2.FileName;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int x = Int32.Parse(textBox3.Text);
                errorProvider1.SetError(textBox3, "");

            }
            catch
            {
                errorProvider1.SetError(textBox3, "Enter integer value");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String x = (textBox2.Text);
                errorProvider1.SetError(textBox2, "");

            }
            catch
            {
                errorProvider1.SetError(textBox2, "Enter Suspect Alias");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String x = (textBox2.Text);
                errorProvider1.SetError(textBox2, "");

            }
            catch
            {
                errorProvider1.SetError(textBox2, "Enter Other Suspects");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";


            if (open.ShowDialog() == DialogResult.OK)
            {

                Chosen_File = open.FileName.ToString();
                textBox8.Text = Chosen_File;

                pictureBox1.ImageLocation = Chosen_File;



            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";


            if (open.ShowDialog() == DialogResult.OK)
            {

                Chosen_File = open.FileName.ToString();
                textBox9.Text = Chosen_File;

                pictureBox2.ImageLocation = Chosen_File;



            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    errorProvider1.SetError(textBox1, "Enter integer value");
                    MessageBox.Show("Enter Suspect name!");

                }
            }
            catch
            {
                errorProvider1.SetError(textBox3, "Enter integer value");
            }
        }


        private void BindData1()
        {
            try
            {
                string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";


                SqlConnection cn2 = new SqlConnection(connectionString);
                cn2.Open();



                SqlCommand scm = new SqlCommand("select officerID from Officer", cn2);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                scm.ExecuteNonQuery();
                cn2.Close();

                comboBox1.DisplayMember = "officerID";
                comboBox1.ValueMember = "officerID";
                comboBox1.DataSource = table;

                comboBox1.Enabled = true;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
