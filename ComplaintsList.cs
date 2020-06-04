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
    public partial class ComplaintsList : Form
    {
        public ComplaintsList()
        {
            InitializeComponent();
        }

        string filter = "";


        string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
      
        
        private void ComplaintsList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'searchDataSet1._Non_Cognizable' table. You can move, or remove it, as needed.
            this.non_CognizableTableAdapter.Fill(this.searchDataSet1._Non_Cognizable);
            BindData1();
            BindData2();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "select * from [Non-Cognizable] where date='" + dateTimePicker1.Value.ToShortDateString() + "' ";
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

        private void button2_Click(object sender, EventArgs e)
        {
            bool go = true;
            if (comboBox2.Text == null)
            {
                go = false;
                MessageBox.Show("Select the complainantID");
            }
            if (go)
            {
                try
                {
                    filter = comboBox2.SelectedItem.ToString();
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from [Non-Cognizable] where complainantID = '" + comboBox1.Text + "' ";
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
            if (comboBox2.Text == null)
            {
                go = false;
                MessageBox.Show("Select the officerID");
            }
            if (go)
            {
                try
                {
                    filter = comboBox2.SelectedItem.ToString();
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from [Non-Cognizable] where officerID = '" + comboBox2.Text + "' ";
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
        {
            bool go = true;
            if (comboBox3.Text == null)
            {
                go = false;
                MessageBox.Show("Select the type of crime");
            }
            if (go)
            {
                try
                {
                    filter = comboBox2.SelectedItem.ToString();
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from [Non-Cognizable] where offencetype like '%" + comboBox3.Text + "%' ";
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
            worksheet.Name = "Non-Cognizable Offences List";
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
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "select * from [Non-Cognizable] where date='" + dateTimePicker1.Value.ToShortDateString() + "' and complainantID='" + comboBox1.Text + "'and  officerID='" + comboBox2.Text + "' and offencetype='" + comboBox3.Text + "'";
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

                comboBox2.DisplayMember = "officerID";
                comboBox2.ValueMember = "officerID";
                comboBox2.DataSource = table;

                comboBox2.Enabled = true;

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

       
    }
}
