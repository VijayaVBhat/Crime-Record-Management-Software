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
    public partial class NewCaseDisposal : Form
    {
        public NewCaseDisposal()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void casebindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void NewCaseDisposal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'crmsDataSet1.Case' table. You can move, or remove it, as needed.
            this.caseTableAdapter.Fill(this.crmsDataSet1.Case);
            // TODO: This line of code loads data into the 'crmsDataSet1.Officer' table. You can move, or remove it, as needed.
            this.officerTableAdapter.Fill(this.crmsDataSet1.Officer);
            // TODO: This line of code loads data into the '_C__PROGRAM_FILES_MICROSOFT_SQL_SERVER_MSSQL10_50_SQLEXPRESS_MSSQL_DATA_CRMS_MDFDataSet.Officer' table. You can move, or remove it, as needed.
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
            bool go = true;
            if (comboBox1.SelectedItem == null)
            {
                go = false;
                MessageBox.Show("Select Officer ID");
            }

            else if (comboBox2.SelectedItem == null)
            {
                go = false;
                MessageBox.Show("Select Court");
            }

            else if (comboBox3.SelectedItem == null)
            {
                go = false;
                MessageBox.Show("Select CaseID");
            }

            else if (comboBox4.SelectedItem == null)
            {
                go = false;
                MessageBox.Show("Select District");
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
                    cmd1.CommandText = "select disposalID from [Case Disposal]";

                    SqlDataReader usernameRdr;

                    usernameRdr = cmd1.ExecuteReader();
                    string username11 = "";

                    if (usernameRdr.HasRows)
                    {
                        while (usernameRdr.Read())
                        {
                            username11 = usernameRdr["disposalID"].ToString();
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
                    String ID = "CD" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
                    if (username11 == ID || nw == numbers)
                        id++;
                    String OID = "CD" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + id;
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

                                 cmd.CommandText = "insert into [Case Disposal](disposalID,caseID,officerID,court,district,framingdate,judgementdate,prosecutor,judgementdetails,fine,witness) values(@disposalID,@caseID,@officerID,@court,@district,@framingdate,@judgementdate,@prosecutor,@judgementdetails,@fine,@witness)";

                                 cmd.Parameters.AddWithValue("@disposalID", OID);
                                 cmd.Parameters.AddWithValue("@caseID", comboBox3.Text);
                                 cmd.Parameters.AddWithValue("@officerID", comboBox1.Text);
                                 cmd.Parameters.AddWithValue("@court", comboBox2.SelectedItem.ToString());
                                 cmd.Parameters.AddWithValue("@district", comboBox4.SelectedItem.ToString());
                                 cmd.Parameters.AddWithValue("@framingdate", dateTimePicker1.Value.ToShortDateString());
                                 cmd.Parameters.AddWithValue("@judgementdate", dateTimePicker2.Value.ToShortDateString());
                                 cmd.Parameters.AddWithValue("@prosecutor", textBox1.Text + "," + textBox2.Text + "," + textBox3.Text);
                                 cmd.Parameters.AddWithValue("@judgementdetails", richTextBox1.Text.ToUpper());
                                 cmd.Parameters.AddWithValue("@fine", (textBox7.Text));
                                 cmd.Parameters.AddWithValue("@witness", textBox4.Text + "," + textBox5.Text + "," + textBox6.Text);

                                 cmd.ExecuteNonQuery();

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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String x = (textBox7.Text);
                errorProvider1.SetError(textBox7, "");

            }
            catch
            {
                errorProvider1.SetError(textBox7, "Enter Fine Amount");
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String x = (textBox4.Text);
                errorProvider1.SetError(textBox4, "");

            }
            catch
            {
                errorProvider1.SetError(textBox4, "Enter Witness 1");
            }
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                String x = (textBox5.Text);
                errorProvider1.SetError(textBox5, "");

            }
            catch
            {
                errorProvider1.SetError(textBox5, "Enter Witness 2");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String x = (textBox6.Text);
                errorProvider1.SetError(textBox6, "");

            }
            catch
            {
                errorProvider1.SetError(textBox6, "Enter Other Witnesses");
            }
        }

        private void BindData1()
        {
            try
            {
                string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";


                SqlConnection cn2 = new SqlConnection(connectionString);
                cn2.Open();



                SqlCommand scm = new SqlCommand("select caseID from [Case]", cn2);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                scm.ExecuteNonQuery();
                cn2.Close();

                comboBox3.DisplayMember = "caseID";
                comboBox3.ValueMember = "caseID";
                comboBox3.DataSource = table;

                comboBox3.Enabled = true;

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

                comboBox1.DisplayMember = "officerID";
                comboBox1.ValueMember = "officerID";
                comboBox1.DataSource = table1;

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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }


        }
    }

    

}
