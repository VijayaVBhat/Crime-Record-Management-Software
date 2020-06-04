using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRMS
{
    public partial class NewComplainant : Form
    {
        public NewComplainant()
        {
            InitializeComponent();
        }

        private void NewComplainant_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'crmsDataSet1.Officer' table. You can move, or remove it, as needed.
            this.officerTableAdapter.Fill(this.crmsDataSet1.Officer);
            // TODO: This line of code loads data into the 'crmsDataSet1._Non_Cognizable' table. You can move, or remove it, as needed.
            
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





                bool go = true;
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

                if (comboBox1.SelectedItem == null)
                {

                    MessageBox.Show("Select Officer");
                }


                String email = textBox7.Text;

                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                System.Text.RegularExpressions.Match match = regex.Match(email);
                if (match.Success)
                { }
                else
                    errorProvider1.SetError(textBox7, "Re-type email");

                if (go)
                {
                    try
                    {

                        string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";


                        SqlConnection cn1 = new SqlConnection(connectionString);

                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = cn1;
                        cn1.Open();
                        cmd1.CommandText = "select complainantID from Complainant";

                        SqlDataReader usernameRdr1;

                        usernameRdr1 = cmd1.ExecuteReader();
                        string username11 = "";

                        if (usernameRdr1.HasRows)
                        {
                            while (usernameRdr1.Read())
                            {
                                try
                                {
                                    username11 = usernameRdr1["complainantID"].ToString();
                                }
                                catch { }
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
                        String ID = "C" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                        //textBox2.Text = ID;
                        int cmp = nw.CompareTo(numbers);
                        if (username11 == ID || cmp <= 0)
                            id++;

                        String OID = "C" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                        // textBox2.Text = OID;

                        cn1.Close();


                        SqlConnection cn = new SqlConnection(connectionString);

                        cn.Open();


                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;


                        if (textBox4.Text != "" && textBox6.Text != "" && textBox1.Text != "" && textBox2.Text != "" && gender != "")
                        { const string message = "Are you sure that you want to submit?";
                            const string caption = "Confirm Submission";
                             DialogResult result = MessageBox.Show(message, caption,
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question); ;
                             if (result.Equals(DialogResult.OK))
                             {
                                 cmd.CommandText = "insert into Complainant (complainantID,officerID,aadharno,name,gender,nationality,occupation,passportno,contactno,emailID,address,complaintdate)values(@complainantID,@officerID,@aadharno,@name,@gender,@nationality,@occupation,@passportno,@contactno,@emailID,@address,@complaintdate)";

                                 cmd.Parameters.AddWithValue("@complainantID", OID);
                                 cmd.Parameters.AddWithValue("@officerID", comboBox1.Text);
                                 cmd.Parameters.AddWithValue("@aadharno", textBox3.Text);
                                 cmd.Parameters.AddWithValue("@name", textBox1.Text);
                                 cmd.Parameters.AddWithValue("@gender", gender);
                                 cmd.Parameters.AddWithValue("@nationality", textBox2.Text);
                                 cmd.Parameters.AddWithValue("@occupation", textBox4.Text);
                                 cmd.Parameters.AddWithValue("@passportno", textBox5.Text);
                                 cmd.Parameters.AddWithValue("@contactno", textBox6.Text);
                                 cmd.Parameters.AddWithValue("@emailID", textBox7.Text);
                                 cmd.Parameters.AddWithValue("@address", richTextBox1.Text.ToString());
                                 cmd.Parameters.AddWithValue("@complaintdate", dateTimePicker1.Value.ToShortDateString());


                                 try
                                 {

                                     cmd.ExecuteNonQuery();
                                 }
                                 catch { }

                                 cn.Close();

                                 MessageBox.Show("Data added successfully! ID is " + OID, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 this.Controls.Clear();


                                 /* 
                                      cmd.CommandText = "insert into Complainant (complainantID,officerID,aadharno,name,gender,nationality,occupation,passportno,contactno,emailID,address,complaintdate)values(@complainantID,@officerID,@aadharno,@name,@gender,@nationality,@occupation,@passportno,@contactno,@emailID,@address,@complaintdate)";

                                       cmd.Parameters.AddWithValue("@complainantID", OID);
                                       cmd.Parameters.AddWithValue("@officerID", comboBox1.Text);
                                       cmd.Parameters.AddWithValue("@aadharno", textBox3.Text);
                                       cmd.Parameters.AddWithValue("@name", textBox1.Text);
                                       cmd.Parameters.AddWithValue("@gender", gender);
                                       cmd.Parameters.AddWithValue("@nationality", textBox2.Text);
                          
                                       cmd.Parameters.AddWithValue("@contactno",  textBox6.Text);
                           
                                       cmd.Parameters.AddWithValue("@address", richTextBox1.Text.ToString());
                                       cmd.Parameters.AddWithValue("@complaintdate", dateTimePicker1.Value.ToShortDateString());
                          

                                       try
                                       {
                                       cmd.ExecuteNonQuery();
                                       }
                                       catch{}
                                       cn.Close();

                                       MessageBox.Show("Data added successfully!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                       this.Controls.Clear();*/
                                 this.InitializeComponent();
                             }
                             else
                             { }
                        }
                        else
                        {
                            MessageBox.Show("Please fill the details");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }






            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          
        }















        private void textBox1_Validating(object sender, CancelEventArgs e)
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

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int x = Int32.Parse(textBox5.Text);
                errorProvider1.SetError(textBox5, "");

            }
            catch
            {
                errorProvider1.SetError(textBox5, "Enter integer value");
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int x = Int32.Parse(textBox6.Text);
                errorProvider1.SetError(textBox6, "");

            }
            catch
            {
                errorProvider1.SetError(textBox6, "Enter integer value");
            }
        
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String x = textBox3.Text;
                errorProvider1.SetError(textBox3, "");

            }
            catch
            {
                errorProvider1.SetError(textBox3, "Enter Aadhaar No.");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String x = textBox4.Text;
                errorProvider1.SetError(textBox4, "");

            }
            catch
            {
                errorProvider1.SetError(textBox4, "Enter Occupation");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String x = textBox5.Text;
                errorProvider1.SetError(textBox5, "");

            }
            catch
            {
                errorProvider1.SetError(textBox5, "Enter Passport No.");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String x = textBox7.Text;
                errorProvider1.SetError(textBox7, "");

            }
            catch
            {
                errorProvider1.SetError(textBox7, "Enter Email ID");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String x = richTextBox1.Text;
                errorProvider1.SetError(richTextBox1, "");

            }
            catch
            {
                errorProvider1.SetError(richTextBox1, "Enter Address");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
            try
            {
                double x = Double.Parse(textBox6.Text);
                errorProvider1.SetError(textBox6, "");
                

            }
            catch
            {
                errorProvider1.SetError(textBox6, "Enter digits only");
            }
        
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.MinDate = DateTime.Now;
                dateTimePicker1.MaxDate = DateTime.Now;
            }
            catch 
            {
                
            }
        }


        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }


        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text=="")
                MessageBox.Show("Select Officer ID");
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


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.'||e.KeyChar==8)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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


        private void BindData1()
        {
            try
            {
                string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";


                SqlConnection cn2 = new SqlConnection(connectionString);
                cn2.Open();
               


                SqlCommand scm = new SqlCommand("select officerID from Officer",cn2);
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
        
    }
}
