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
    public partial class NewCase : Form
    {
        public NewCase()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewCase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'crmsDataSet1.Suspect' table. You can move, or remove it, as needed.
            //this.suspectTableAdapter.Fill(this.crmsDataSet1.Suspect);
            // TODO: This line of code loads data into the 'crmsDataSet1._Non_Cognizable' table. You can move, or remove it, as needed.
            this.non_CognizableTableAdapter.Fill(this.crmsDataSet1._Non_Cognizable);
            // TODO: This line of code loads data into the 'crmsDataSet1.FIR' table. You can move, or remove it, as needed.
            //this.fIRTableAdapter.Fill(this.crmsDataSet1.FIR);
            // TODO: This line of code loads data into the 'crmsDataSet1.Officer' table. You can move, or remove it, as needed.
            this.officerTableAdapter.Fill(this.crmsDataSet1.Officer);
            BindData1();
            BindData2();
            BindData3();
            BindData4();
           
           
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
                bool go=true;

                if (comboBox2.SelectedItem != "" && comboBox3.SelectedItem != "")
                {
                    MessageBox.Show("Please select either FIR ID or Non-Cognizable ID but not both");
                }

                if (comboBox2.SelectedItem == "" && comboBox3.SelectedItem == "")
                {
                    MessageBox.Show("Please select either FIR ID or Non-Cognizable ID");
                }

                if (comboBox3.SelectedItem!="")
                {
                    if (comboBox1.SelectedItem == null)
                    {
                        
                        go = false;
                        MessageBox.Show("Select District");
                    }

                    else if (comboBox4.SelectedItem == null)
                    {
                        go = false;
                        MessageBox.Show("Select Type of Case");
                    }

                    else if (comboBox5.SelectedItem == null)
                    {
                        go = false;
                        MessageBox.Show("Select Officer ID");
                    }

                    else if (comboBox7.SelectedItem == null)
                    {
                        go = false;
                        MessageBox.Show("Select Suspect ID");
                    }

                    else if (textBox1.Text == "")
                    {
                        go = false;
                        MessageBox.Show("Add Law Act and Section");
                    }


                    else if (textBox4.Text == "")
                    {
                        go = false;
                        MessageBox.Show("Add Victims");
                    }
                    else if (richTextBox1.Text == "")
                    {
                        go = false;
                        MessageBox.Show("Add Case Details");
                    }

                    if (go)
                    {
                        string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
                        SqlConnection cn = new SqlConnection(connectionString);
                        SqlConnection cn1 = new SqlConnection(connectionString);

                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = cn1;
                        cn1.Open();
                        cmd1.CommandText = "select caseID from [Case]";

                        SqlDataReader usernameRdr;

                        usernameRdr = cmd1.ExecuteReader();
                        string username11 = "";

                        if (usernameRdr.HasRows)
                        {
                            while (usernameRdr.Read())
                            {
                                username11 = usernameRdr["caseID"].ToString();
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
                        String ID = "CS" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                        if (username11 == ID || nw == numbers)
                            id++;
                        String OID = "CS" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                        cn1.Close();

                        cn.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;

                         const string message = "Are you sure that you want to submit?";
                            const string caption = "Confirm Submission";
                             DialogResult result = MessageBox.Show(message, caption,
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question); ;
                             if (result.Equals(DialogResult.OK))
                             {
                                 cmd.CommandText = "insert into [Case](caseID,suspectID,firID,ncID,officerID,district,date,type,details,victims,sol) values(@caseID,@suspectID,@firID,@ncID,@officerID,@district,@date,@type,@details,@victims,@sol)";

                                 cmd.Parameters.AddWithValue("@caseID", OID);
                                 cmd.Parameters.AddWithValue("@district", comboBox1.Text);
                                 cmd.Parameters.AddWithValue("@firID", comboBox2.Text);
                                 cmd.Parameters.AddWithValue("@ncID", DBNull.Value);
                                 cmd.Parameters.AddWithValue("@details", richTextBox1.Text.ToUpper());
                                 cmd.Parameters.AddWithValue("@type", comboBox4.Text);
                                 cmd.Parameters.AddWithValue("@officerID", comboBox5.Text);
                                 cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToShortDateString());
                                 cmd.Parameters.AddWithValue("@suspectID", comboBox7.Text);
                                 cmd.Parameters.AddWithValue("@victims", textBox4.Text + "," + textBox5.Text + "," + textBox6.Text);
                                 cmd.Parameters.AddWithValue("@sol", textBox1.Text + "," + textBox2.Text + "," + textBox3.Text);


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
                                 BindData2();
                                 BindData3();
                                 BindData4();
                             }
                             else
                             { }

                    }
                }
                else 
                {
                     if (comboBox1.SelectedItem == null)
                    {
                        go = false;
                        MessageBox.Show("Select District");
                    }



                    else if (comboBox4.SelectedItem == null)
                    {
                        go = false;
                        MessageBox.Show("Select Type of Case");
                    }

                    else if (comboBox5.SelectedItem == null)
                    {
                        go = false;
                        MessageBox.Show("Select Officer ID");
                    }

                    else if (comboBox7.SelectedItem == null)
                    {
                        go = false;
                        MessageBox.Show("Select Suspect ID");
                    }

                    else if (textBox1.Text == "")
                    {
                        go = false;
                        MessageBox.Show("Add Law Act and Section");
                    }


                    else if (textBox4.Text == "")
                    {
                        go = false;
                        MessageBox.Show("Add Victims");
                    }

                     if (go)
                     {

                         string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
                         SqlConnection cn = new SqlConnection(connectionString);
                         SqlConnection cn1 = new SqlConnection(connectionString);

                         SqlCommand cmd1 = new SqlCommand();
                         cmd1.Connection = cn1;
                         cn1.Open();
                         cmd1.CommandText = "select caseID from [Case]";

                         SqlDataReader usernameRdr;

                         usernameRdr = cmd1.ExecuteReader();
                         string username11 = "";

                         if (usernameRdr.HasRows)
                         {
                             while (usernameRdr.Read())
                             {
                                 username11 = usernameRdr["caseID"].ToString();
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
                         String ID = "CS" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                         if (username11 == ID || nw == numbers)
                             id++;
                         String OID = "CS" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                         cn1.Close();


                         cn.Open();

                         SqlCommand cmd = new SqlCommand();
                         cmd.Connection = cn;

                          const string message = "Are you sure that you want to submit?";
                            const string caption = "Confirm Submission";
                             DialogResult result = MessageBox.Show(message, caption,
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question); ;
                             if (result.Equals(DialogResult.OK))
                             {
                                 cmd.CommandText = "insert into [Case](caseID,firID,ncID,officerID,district,date,type,details,victims,sol) values(@caseID,@firID,@ncID,@officerID,@district,@date,@type,@details,@victims,@sol)";

                                 cmd.Parameters.AddWithValue("@caseID", OID);
                                 cmd.Parameters.AddWithValue("@district", comboBox1.Text);
                                 cmd.Parameters.AddWithValue("@firID", DBNull.Value);
                                 cmd.Parameters.AddWithValue("@ncID", comboBox3.Text);
                                 cmd.Parameters.AddWithValue("@details", richTextBox1.Text);
                                 cmd.Parameters.AddWithValue("@type", comboBox4.Text);
                                 cmd.Parameters.AddWithValue("@officerID", comboBox5.Text);
                                 cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToShortDateString());
                                 cmd.Parameters.AddWithValue("@victims", textBox4.Text + "," + textBox5.Text + "," + textBox6.Text);
                                 cmd.Parameters.AddWithValue("@sol", textBox1.Text + "," + textBox2.Text + "," + textBox3.Text);

                                 cmd.ExecuteNonQuery();

                                 cn.Close();

                                 MessageBox.Show("Data added successfully! ID is " + OID, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 this.Controls.Clear();
                                 this.InitializeComponent();
                                 BindData1();
                                 BindData2();
                                 BindData3();
                                 BindData4();
                             }
                             else
                             { }
                     }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void BindData1()
        {
            try
            {
                string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";


                SqlConnection cn2 = new SqlConnection(connectionString);
                cn2.Open();



                SqlCommand scm = new SqlCommand("select suspectID from Suspect", cn2);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                scm.ExecuteNonQuery();
                cn2.Close();

                comboBox7.DisplayMember = "suspectID";
                comboBox7.ValueMember = "suspectID";
                comboBox7.DataSource = table;

                comboBox7.Enabled = true;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void BindData2()
        {
            try
            {
                string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
                SqlConnection cn3 = new SqlConnection(connectionString);
                cn3.Open();

                SqlCommand scm1 = new SqlCommand("select officerID from Officer", cn3);
                DataTable table1 = new DataTable();
                SqlDataAdapter adp1 = new SqlDataAdapter(scm1);
                adp1.Fill(table1);
                scm1.ExecuteNonQuery();
                cn3.Close();

                comboBox5.DisplayMember = "officerID";
                comboBox5.ValueMember = "officerID";
                comboBox5.DataSource = table1;

                comboBox5.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BindData3()
        {
            try
            {
                string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";


                SqlConnection cn4 = new SqlConnection(connectionString);
                cn4.Open();



                SqlCommand scm2 = new SqlCommand("select firID from FIR", cn4);
                DataTable table2 = new DataTable();
                SqlDataAdapter adp2 = new SqlDataAdapter(scm2);
                adp2.Fill(table2);
                scm2.ExecuteNonQuery();
                cn4.Close();

                comboBox2.DisplayMember = "firID";
                comboBox2.ValueMember = "firID";
                comboBox2.DataSource = table2;

                comboBox2.Enabled = true;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void BindData4()
        {
            try
            {
                string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
                SqlConnection cn5 = new SqlConnection(connectionString);
                cn5.Open();

                SqlCommand scm3 = new SqlCommand("select ncID from [Non-Cognizable]", cn5);
                DataTable table3 = new DataTable();
                SqlDataAdapter adp3 = new SqlDataAdapter(scm3);
                adp3.Fill(table3);
                scm3.ExecuteNonQuery();
                cn5.Close();

                comboBox3.DisplayMember = "ncID";
                comboBox3.ValueMember = "ncID";
                comboBox3.DataSource = table3;

                comboBox3.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
