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
    public partial class SuspectsList : Form
    {
        String name = "";
        String filter = "";

        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
        public SuspectsList()
        {
            InitializeComponent();
        }

        private void SuspectsList_Load(object sender, EventArgs e)
        {
            
           BindData1();
           BindData2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool go = true;
            if (comboBox1.SelectedItem == null)
            {
                go = false;
                MessageBox.Show("Select the status");
            }
            if (go)
            {

                try
                {
                    filter = comboBox1.SelectedItem.ToString();
                    name = "with the status of " + filter;
                    
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from Suspect where status like '%" + comboBox1.SelectedItem.ToString() +"%' ";
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
                MessageBox.Show("Select the gender");
            }

            if (go)
            {
                try
                {
                    filter = comboBox1.SelectedItem.ToString();
                    name = "with the gender of " + filter;
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from Suspect where gender like '%" + comboBox1.SelectedItem.ToString() + "%' ";
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
            if (textBox1.Text == null)
            {
                go = false;
                MessageBox.Show("Enter the alias");
            }
            if (go)
            {
                try
                {
                    filter = textBox1.Text.ToString();
                    name = "with the alias of " + filter;
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from Suspect where alias like '%" + textBox1.Text.ToString() + "%' ";
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

            saveFileDialog1.FileName = "Suspect " + name;
            saveFileDialog1.Filter = "Excel File(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                excel.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
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
                cmd.CommandText = "select * from Suspect where status='" + comboBox1.Text + "' and gender='" + comboBox2.Text + "'and  officerID='" + comboBox3.Text + "' and alias like '%" + textBox1.Text + "%' ";
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                filter = comboBox3.Text;
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "select * from Suspect where officerID = '" + comboBox3.Text + "' ";
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

                comboBox3.DisplayMember = "officerID";
                comboBox3.ValueMember = "officerID";
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


                SqlConnection cn2 = new SqlConnection(connectionString);
                cn2.Open();



                SqlCommand scm = new SqlCommand("select officerID from Officer", cn2);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                scm.ExecuteNonQuery();
                cn2.Close();

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
       
    }
}
