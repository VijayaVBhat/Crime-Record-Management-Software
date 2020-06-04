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
    public partial class Charts : Form
    {
        public Charts()
        {
            InitializeComponent();
        }

        private void Charts_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas.Add("area");
            chart1.ChartAreas["area"].AxisX.Minimum = 1;
            chart1.ChartAreas["area"].AxisX.Maximum = 12;
            chart1.ChartAreas["area"].AxisY.Minimum = 0;
            chart1.ChartAreas["area"].AxisY.Interval = 10;

            chart1.Series.Add("area");

            chart1.Series["area"].Color = Color.Orange;

            chart1.Series["area"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chart1.Series["area"].Points.AddXY(0, 0);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
                        SqlConnection cn1 = new SqlConnection(connectionString);

                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = cn1;
                        cn1.Open();
            if (comboBox1.SelectedValue != comboBox2.SelectedValue)
            { 
           // if(comboBox1.Text=="")


            }
        }

       
    }
}
