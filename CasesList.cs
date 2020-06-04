using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop;


namespace CRMS
{
    public partial class CasesList : Form
    {
        String name="";
        String filter="";
        
        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
        public CasesList()
        {
            InitializeComponent();
        }

        private void CasesList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'searchDataSet1.Case' table. You can move, or remove it, as needed.
            this.caseTableAdapter.Fill(this.searchDataSet1.Case);
            // TODO: This line of code loads data into the 'dbDataSet.Case' table. You can move, or remove it, as needed.
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool go = true;
            if (comboBox1.SelectedItem == null)
            {
                go = false;
                MessageBox.Show("Select District");
            }
            if (go)
            {
                try
                {
                    filter = comboBox1.SelectedItem.ToString();
                    name = "in the district of "+filter;
                    
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from [Case] where district='" + comboBox1.SelectedItem.ToString() + "' ";
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool go = true;
            if (comboBox2.SelectedItem == null)
            {
                go = false;
                MessageBox.Show("Select Type");
            }
            if (go)
            {
                try
                {
                    filter = comboBox2.SelectedItem.ToString();
                    name = "of type" + filter;

                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from [Case] where type='" + comboBox2.SelectedItem.ToString() + "' ";
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            bool go = true;
            if (dateTimePicker1.Value == null)
            {
                go = false;
                MessageBox.Show("Select Date");
            }
            if (go)
            {
                try
                {
                    filter = dateTimePicker1.Value.ToString();
                    name = "during the date " + filter;
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from [Case] where date='" + dateTimePicker1.Value.ToShortDateString() + "' ";
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            }
        

        private void button_Click(object sender, EventArgs e)
        {
            excel.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                excel.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    excel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }


            }

            saveFileDialog1.FileName = "Case "+name;
            saveFileDialog1.Filter = "Excel File(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                excel.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                filter = comboBox1.SelectedItem.ToString()+comboBox2.SelectedItem.ToString()+dateTimePicker1.Value.ToString();
                name = filter;
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "select * from [Case] where date='" + dateTimePicker1.Value.ToShortDateString() + "' , district='" + comboBox1.SelectedItem.ToString() + "',  type='" + comboBox2.SelectedItem.ToString() + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
