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
using E_Justice;

namespace CRMS
{
    public partial class MainForm : Form
    {

        string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
        public MainForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
          
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
          
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox12_Validating(object sender, CancelEventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'crmsDataSet2.Case_Disposal' table. You can move, or remove it, as needed.
            this.case_DisposalTableAdapter.Fill(this.crmsDataSet2.Case_Disposal);
            // TODO: This line of code loads data into the 'crmsDataSet2._Non_Cognizable' table. You can move, or remove it, as needed.
            this.non_CognizableTableAdapter1.Fill(this.crmsDataSet2._Non_Cognizable);
            // TODO: This line of code loads data into the 'crmsDataSet2.FIR' table. You can move, or remove it, as needed.
            this.fIRTableAdapter.Fill(this.crmsDataSet1.FIR);
            // TODO: This line of code loads data into the 'crmsDataSet1.Complainant' table. You can move, or remove it, as needed.
            this.complainantTableAdapter.Fill(this.crmsDataSet1.Complainant);
            // TODO: This line of code loads data into the 'crmsDataSet1.Suspect' table. You can move, or remove it, as needed.
            this.suspectTableAdapter1.Fill(this.crmsDataSet1.Suspect);
            // TODO: This line of code loads data into the 'crmsDataSet1.Case' table. You can move, or remove it, as needed.
            this.caseTableAdapter1.Fill(this.crmsDataSet1.Case);
            // TODO: This line of code loads data into the 'dbDataSet2.Case_Disposal' table. You can move, or remove it, as needed.
          

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();


                SqlCommand scm = new SqlCommand("select * from Case", cn);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                dataGridView2.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox5.Text != "")
            {
                try
                {
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "UPDATE Case SET  caseID='" + comboBox1.SelectedValue + "',officerID='" + comboBox5.SelectedValue + "', district='" + comboBox8.SelectedValue + "', type ='" + comboBox4.SelectedValue + "', details ='" + richTextBox2.Text + "', date ='" + dateTimePicker2.Value.ToShortDateString() + "',  sol='" + textBox9.Text + "', victims='" + textBox11.Text + "',where caseID='" + comboBox1.SelectedValue.ToString()+ "'";
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(dt);
                    MessageBox.Show("Updated");

                    SqlCommand scm = new SqlCommand("select * from Case", cn);
                    DataTable table = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(scm);
                    adp.Fill(table);
                    dataGridView2.DataSource = table;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();


                SqlCommand scm = new SqlCommand("select * from Suspect", cn);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                dataGridView4.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "" && comboBox21.Text != "")
            {
                try
                {
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "UPDATE Suspect SET [officerID]='" + comboBox21.SelectedValue + "', [name] = '" + textBox28.Text + "', [age] = '" + int.Parse(textBox26.Text) + "', [height] ='" + textBox1.Text + "', [bodysign] = '" + textBox29.Text + "', [othsuspects] = '" + textBox23.Text + "', [complaintdetails] ='" + richTextBox8.Text + "', [alias] = '" + textBox27.Text + "', [address] ='" + richTextBox7.Text + "', [suspectstatus] ='" + comboBox3.SelectedItem.ToString() + "' WHERE suspectID='" + comboBox2.SelectedItem.ToString() + "'";
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(dt);
                    MessageBox.Show("Updated");

                    SqlCommand scm = new SqlCommand("select * from Suspectinfo", cn);
                    DataTable table = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(scm);
                    adp.Fill(table);
                    dataGridView4.DataSource = table;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fr = new Form1();
            fr.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void complainantRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewComplainant nc = new NewComplainant();
            nc.Show();
        }

        private void fIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFIR nf = new NewFIR();
            nf.Show();
        }

        private void nonCognizableOffenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewComplaint ncm = new NewComplaint();
            ncm.Show();
        }

        private void complainantListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComplainantsList cl = new ComplainantsList();
            cl.Show();
        }

        private void newCaseRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCase nc = new NewCase();
            nc.Show();
        }

        private void caseDisposalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCaseDisposal nd = new NewCaseDisposal();
            nd.Show();
        }

        private void allRecordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CasesList cl = new CasesList();
            cl.Show();
        }

        private void newSuspectRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSuspect ns = new NewSuspect();
            ns.Show();
        }

        private void allRecordsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SuspectsList sl = new SuspectsList();
            sl.Show();
        }

        private void showChartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Charts c = new Charts();
            c.Show();
        }

        private void caseDisposalReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisposalReport dr = new DisposalReport();
            dr.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                if (textBox38.Text != "")
                {
                    SearchDataSetTableAdapters.Non_CognizableTableAdapter ncr = new SearchDataSetTableAdapters.Non_CognizableTableAdapter();

                    SearchDataSet._Non_CognizableDataTable ncrtable = ncr.GetDataByID(textBox38.Text);
                    dataGridView4.DataSource = ncrtable;
                }
            }
            else if (radioButton6.Checked)
            {
                MessageBox.Show("You have to search by ID");
            }
        }

       
        

      

        

       
    }
}
