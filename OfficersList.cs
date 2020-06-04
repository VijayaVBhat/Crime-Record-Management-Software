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
using System.IO;


namespace CRMS
{
    public partial class OfficersList : Form
    {
        String name = "";
        String filter = "";

        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
        public OfficersList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool go = true;
            if (comboBox1.SelectedItem == null)
            {
                go = false;
                MessageBox.Show("Select Rank");

            }
            if (go)
            {
                try
                {
                    filter = comboBox1.SelectedItem.ToString();
                    name = "with the rank of " + filter;
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from Officer where rank='" + comboBox1.SelectedItem.ToString() + "'";
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
        { bool go = true;
            if (dateTimePicker1.Value == null)
            {
                go = false;
                MessageBox.Show("Select the date of joining");
            }
            if (go)
            {
                try
                {
                    filter = dateTimePicker1.Value.ToString();
                    name = "with date of joining of " + filter;
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from Officer where doj='" + dateTimePicker1.Value.ToShortDateString() + "' ";
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
        { bool go = true;
            if (dateTimePicker1.Value == null)
            {
                go = false;
                MessageBox.Show("Select the date of birth");
            }
            if (go)
            {
                try
                {
                    filter = dateTimePicker2.Value.ToString();
                    name = "with date of birth of " + filter;
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from Officer where dob='" + dateTimePicker2.Value.ToShortDateString() + "' ";
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

        private void button4_Click(object sender, EventArgs e)
        { bool go = true;
            if (dateTimePicker1.Value == null)
            {
                go = false;
                MessageBox.Show("Select the access privilege");
            }
            if (go)
            {
                try
                {
                    filter = comboBox2.SelectedItem.ToString();
                    name = "with access privilege of " + filter;
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from Officer where accessp='" + filter + "' ";
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
           /* excel.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                excel.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    excel.Cells[i + 2, j + 1] =   (dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            


            }
            */
           Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            Microsoft.Office.Interop.Excel._Worksheet worksheet1 = null;


            // see the excel sheet behind the program
            app.Visible = true;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet1 = workbook.Sheets["Sheet1"];
            worksheet1 = workbook.ActiveSheet;


            // changing the name of active sheet
            worksheet.Name = "Officer List";
            //worksheet1.Name = "Image List";
            
          
             
            // storing header part in Excel
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            /*
            saveFileDialog1.FileName = "Officer " + name;
            saveFileDialog1.Filter = "Excel File(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                excel.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
            }*/

           
        }

        private void OfficersList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'searchDataSet.Officer' table. You can move, or remove it, as needed.
            this.officerTableAdapter.Fill(this.searchDataSet.Officer);

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                filter = comboBox1.SelectedItem.ToString() + comboBox2.SelectedItem.ToString() + dateTimePicker1.Value.ToString();
                name = filter;
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "select * from Officer where doj='" + dateTimePicker1.Value.ToShortDateString() + "' and dob='" + dateTimePicker2.Value.ToShortDateString() + "' and rank='" + comboBox1.SelectedItem.ToString() + "'and  accessp='" + comboBox2.SelectedItem.ToString() + "'";
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
