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
    public partial class NewComplaint : Form
    {
        public NewComplaint()
        {
            InitializeComponent();
        }

        private void NewComplaint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'crmsDataSet1.Complainant' table. You can move, or remove it, as needed.
            this.complainantTableAdapter.Fill(this.crmsDataSet1.Complainant);
            // TODO: This line of code loads data into the 'crmsDataSet1.Complainant' table. You can move, or remove it, as needed.
            this.complainantTableAdapter.Fill(this.crmsDataSet1.Complainant);
            // TODO: This line of code loads data into the 'crmsDataSet1.Officer' table. You can move, or remove it, as needed.
            this.officerTableAdapter.Fill(this.crmsDataSet1.Officer);
            // TODO: This line of code loads data into the '_C__PROGRAM_FILES_MICROSOFT_SQL_SERVER_MSSQL10_50_SQLEXPRESS_MSSQL_DATA_CRMS_MDFDataSet.Complainant' table. You can move, or remove it, as needed.


            BindData1();
            BindData2();
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

                bool go = true;

                if (comboBox3.SelectedItem == null)
                {
                    go = false;
                    MessageBox.Show("Select District");
                }
                else if (comboBox5.SelectedItem == null)
                {
                    go = false;
                    MessageBox.Show("Select Station");
                }
                else if (comboBox2.SelectedItem == null)
                {
                    go = false;
                    MessageBox.Show("Select Officer");
                }

                else if (textBox1.Text == "")
                {
                    go = false;
                    MessageBox.Show("Add Accused Name");
                }

                else if (textBox3.Text == "")
                {
                    go = false;
                    MessageBox.Show("Add Incident Location");
                }

                else if (richTextBox2.Text == "")
                {
                    go = false;
                    MessageBox.Show("Add Incident Details");
                }
                if (go)
                {

                    try
                    {
                        string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
                        SqlConnection cn = new SqlConnection(connectionString);

                        SqlConnection cn1 = new SqlConnection(connectionString);

                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = cn1;
                        cn1.Open();
                        cmd1.CommandText = "select ncID from [Non-Cognizable]";

                        SqlDataReader usernameRdr;

                        usernameRdr = cmd1.ExecuteReader();
                        string username11 = "";

                        if (usernameRdr.HasRows)
                        {
                            while (usernameRdr.Read())
                            {
                                try
                                {

                                    username11 = usernameRdr["ncID"].ToString();
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
                        String ID = "NC" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                        int cmp = nw.CompareTo(numbers);
                        if (username11 == ID || cmp <= 0)
                            id++;

                        String OID = "NC" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
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
                                 cmd.CommandText = "insert into [Non-Cognizable](ncID,complainantID,officerID,date,district,stationname,incidentdate,incidentloc,accused,offencetype,property,offencedetails) values(@ncID,@complainantID,@officerID,@date,@district,@stationname,@incidentdate,@incidentloc,@accused,@offencetype,@property,@offencedetails)";

                                 cmd.Parameters.AddWithValue("@ncID", OID);
                                 cmd.Parameters.AddWithValue("@complainantID", comboBox1.Text);
                                 cmd.Parameters.AddWithValue("@officerID", comboBox2.Text);
                                 cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToShortDateString());
                                 cmd.Parameters.AddWithValue("@district", comboBox3.Text);
                                 cmd.Parameters.AddWithValue("@stationname", comboBox5.Text);
                                 cmd.Parameters.AddWithValue("@incidentdate", dateTimePicker2.Value.ToShortDateString());
                                 cmd.Parameters.AddWithValue("@incidentloc", textBox3.Text);
                                 cmd.Parameters.AddWithValue("@accused", textBox1.Text + "," + textBox2.Text);
                                 cmd.Parameters.AddWithValue("@offencetype", comboBox4.Text);
                                 cmd.Parameters.AddWithValue("@property", richTextBox3.Text.ToUpper());
                                 cmd.Parameters.AddWithValue("@offencedetails", richTextBox2.Text.ToUpper());

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
                             }
                             else
                             { }
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                errorProvider1.SetError(textBox2, "Enter Other Accused");
            }
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String x = (richTextBox3.Text);
                errorProvider1.SetError(richTextBox3, "");

            }
            catch
            {
                errorProvider1.SetError(richTextBox3, "Enter details of property");
            }
        }




        private void BindData1()
        {
            try
            {
                string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";


                SqlConnection cn2 = new SqlConnection(connectionString);
                cn2.Open();



                SqlCommand scm = new SqlCommand("select complainantID from Complainant", cn2);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                scm.ExecuteNonQuery();
                cn2.Close();

                comboBox1.DisplayMember = "complainantID";
                comboBox1.ValueMember = "complainantID";
                comboBox1.DataSource = table;

                comboBox1.Enabled = true;

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

                comboBox2.DisplayMember = "officerID";
                comboBox2.ValueMember = "officerID";
                comboBox2.DataSource = table1;

                comboBox2.Enabled = true;
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
    }

}

