using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using System.IO;
using System.Data.SqlClient;
using E_Justice;

namespace CRMS
{
    public partial class AdminForm : Form
    {
        string connectionString = @"Data Source=VIJAYA-PC\SQLEXPRESS;Initial Catalog=C:\PROGRAM FILES\MICROSOFT SQL SERVER\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CRMS.MDF;Integrated Security=True";
        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        private int childFormNumber = 0;
        String Chosen_File = "";
        public AdminForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }







        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void accusedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void caseOutcomeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newComplainantRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
          
            // TODO: This line of code loads data into the 'crmsDataSet2.Complainant' table. You can move, or remove it, as needed.
            this.complainantTableAdapter.Fill(this.crmsDataSet2.Complainant);
            // TODO: This line of code loads data into the 'crmsDataSet1.Officer' table. You can move, or remove it, as needed.
            this.officerTableAdapter.Fill(this.crmsDataSet1.Officer);
            // TODO: This line of code loads data into the 'crmsDataSet1.Case' table. You can move, or remove it, as needed.
            this.caseTableAdapter.Fill(this.crmsDataSet1.Case);
            // TODO: This line of code loads data into the 'crmsDataSet1.Suspect' table. You can move, or remove it, as needed.
            this.suspectTableAdapter1.Fill(this.crmsDataSet1.Suspect);
            // TODO: This line of code loads data into the 'dbDataSet2.Case_Disposal' table. You can move, or remove it, as needed.
            this.fIRTableAdapter.Fill(this.crmsDataSet2.FIR);
            this.non_CognizableTableAdapter.Fill(this.crmsDataSet2._Non_Cognizable);
         
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (textBox1.Text != "")
                {
                    SearchDataSetTableAdapters.ComplainantTableAdapter cm = new CRMS.SearchDataSetTableAdapters.ComplainantTableAdapter();

                    SearchDataSet.ComplainantDataTable cmtable = cm.GetDataByID(textBox1.Text);
                    dataGridView1.DataSource = cmtable;
                }
            }
            else if (radioButton2.Checked)
            {
                if (textBox1.Text != "")
                {
                    SearchDataSetTableAdapters.ComplainantTableAdapter cm = new CRMS.SearchDataSetTableAdapters.ComplainantTableAdapter();


                    dataGridView1.DataSource = cm.GetDataByName(textBox1.Text);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (textBox2.Text != "")
                {
                   // SearchDataSetTableAdapters.FIRTableAdapter fir = new CRMS.SearchDataSetTableAdapters.FIRTableAdapter();
                    SearchDataSetTableAdapters.FIRTableAdapter fir = new SearchDataSetTableAdapters.FIRTableAdapter();
                    SearchDataSet.FIRDataTable firtable = fir.GetDataByID(textBox2.Text);
                    dataGridView3.DataSource = firtable;
                }
            }
            else if (radioButton2.Checked)
            {
                MessageBox.Show("You have to search by ID");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (textBox13.Text != "")
                {
                    SearchDataSetTableAdapters.Non_CognizableTableAdapter ncr = new SearchDataSetTableAdapters.Non_CognizableTableAdapter();
                   
                    SearchDataSet._Non_CognizableDataTable ncrtable = ncr.GetDataByID(textBox13.Text);
                    dataGridView5.DataSource = ncrtable;
                }
            }
            else if (radioButton2.Checked)
            {
                MessageBox.Show("You have to search by ID");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (textBox5.Text != "")
                {
                    SearchDataSetTableAdapters.SuspectTableAdapter sus = new SearchDataSetTableAdapters.SuspectTableAdapter();

                    SearchDataSet.SuspectDataTable sustable = sus.GetDataByID(textBox5.Text);
                    dataGridView4.DataSource = sustable;
                }
            }
            else if (radioButton2.Checked)
            {
                if (textBox5.Text != "")
                {
                    SearchDataSetTableAdapters.SuspectTableAdapter sus = new SearchDataSetTableAdapters.SuspectTableAdapter();

                    SearchDataSet.SuspectDataTable sustable = sus.GetDataByName(textBox5.Text);
                    dataGridView4.DataSource = sustable;
                }
            }


        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (textBox3.Text != "")
                {
                    SearchDataSetTableAdapters.CaseTableAdapter ca = new CRMS.SearchDataSetTableAdapters.CaseTableAdapter();

                    SearchDataSet.CaseDataTable cstable = ca.GetDataByID((comboBox17.SelectedValue.ToString()));
                    dataGridView2.DataSource = cstable;
                }
            }
            else if (radioButton2.Checked)
            {
                MessageBox.Show("You have to search by ID");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (textBox4.Text != "")
                {
                    SearchDataSetTableAdapters.Case_DisposalTableAdapter di = new CRMS.SearchDataSetTableAdapters.Case_DisposalTableAdapter();

                    SearchDataSet.Case_DisposalDataTable ditable = di.GetDataByID(textBox4.Text);
                    dataGridView5.DataSource = ditable;
                }
            }
            else if (radioButton2.Checked)
            {
                MessageBox.Show("You have to search by ID");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (textBox38.Text != "")
                {
                    String officerID = textBox38.Text;
                    SearchDataSetTableAdapters.OfficerTableAdapter or = new CRMS.SearchDataSetTableAdapters.OfficerTableAdapter();
                    SearchDataSet.OfficerDataTable ori = or.GetDataByID(officerID);
                    dataGridView6.DataSource = ori;
                }
                else
                {
                    MessageBox.Show("Enter Data");
                }
            }
            if (radioButton2.Checked)
            {
                if (textBox5.Text != "")
                {
                    SearchDataSetTableAdapters.OfficerTableAdapter or = new CRMS.SearchDataSetTableAdapters.OfficerTableAdapter();

                    SearchDataSet.OfficerDataTable ori = or.GetDataByName(textBox38.Text);
                    dataGridView6.DataSource = ori;
                }
            }
        }


        private void button19_Click(object sender, EventArgs e)
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


        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "" && comboBox21.Text != "")
            {
                try
                {
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "UPDATE Suspect SET [name] = '" + textBox31.Text + "', [age] = '" + int.Parse(textBox22.Text) + "', [height] ='" + textBox7.Text + "', [bodysign] = '" + textBox29.Text + "', [othsuspects] = '" + richTextBox4.Text + "', [complaintdetails] ='" + richTextBox3.Text + "', [alias] = '" + textBox30.Text + "', [address] ='" + textBox7.Text + "', [suspectstatus] ='" + comboBox22.SelectedItem.ToString() + "' WHERE suspectID='" + comboBox2.SelectedItem.ToString() + "'";
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




        private void button18_Click(object sender, EventArgs e)
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
            if (comboBox17.Text != "" && comboBox14.Text != "")
            {
                try
                {
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "UPDATE Case SET  officerID='" + comboBox14.SelectedValue + "', district='" + comboBox16.SelectedValue + "', type ='" + comboBox15.SelectedValue + "', details ='" + richTextBox1.Text + "', date ='" + dateTimePicker2.Value.ToShortDateString() + "', suspectID='" + comboBox6.SelectedValue +"', sol='"+ textBox6.Text + "', victims='"+ richTextBox2.Text + "',where caseID='" + comboBox16.SelectedValue + "'";
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



        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();


                SqlCommand scm = new SqlCommand("select * from Officer", cn);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                dataGridView6.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button23_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                try
                {
                    byte[] byteImg = null;
                    FileStream fs = new FileStream(this.textBoximgpath.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    byteImg = br.ReadBytes((int)fs.Length);
                    SqlConnection cn = new SqlConnection(connectionString);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "UPDATE Officer SET dob = '" + dateTimePicker3.Value.ToShortDateString() + "', address ='" + textBox12.Text + "', contactno1 ='" + textBox11.Text + "', contactno2 = '" + textBox10.Text + "', emailID ='" + textBox9.Text + "', doj ='" + dateTimePicker1.Value.ToShortDateString() + "', rank='" + comboBox1.SelectedItem.ToString() + "',pass='" + textBox8.Text + "',accessp='" + comboBox4.SelectedItem.ToString() + "',photo='" + byteImg + "' WHERE officerid='" + comboBox3.SelectedItem.ToString() + "'";
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(dt);
                    MessageBox.Show("Updated");

                    SqlCommand scm = new SqlCommand("select * from Officerinfo", cn);
                    DataTable table = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(scm);
                    adp.Fill(table);
                    dataGridView6.DataSource = table;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void complainantRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewComplainant nc = new NewComplainant();
            nc.Show();

        }

        private void fIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFIR nf = new NewFIR();
            nf.Show();
        }

        private void nonCognizableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewComplaint ncm = new NewComplaint();
            ncm.Show();
        }

      

        private void newRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSuspect ns = new NewSuspect();
            ns.Show();
        }

        private void allRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuspectsList sl = new SuspectsList();
            sl.Show();
        }

        private void caseRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCase nc = new NewCase();
            nc.Show();
        }

        private void caseDisposalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCaseDisposal nd = new NewCaseDisposal();
            nd.Show();
        }

        

        private void createAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewAcc nc = new NewAcc();
            nc.Show();
        }

       private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OfficersList ol = new OfficersList();
            ol.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dgr in this.dataGridView2.Rows)
            {
                if (dgr.Selected)
                {
                    comboBox17.SelectedItem = dgr.Cells[0].Value;
                    comboBox16.SelectedItem = dgr.Cells[5].Value;
                    comboBox15.SelectedItem = dgr.Cells[7].Value;
                    richTextBox1.Text = dgr.Cells[8].Value.ToString();
                    comboBox14.SelectedItem = dgr.Cells[4].Value;
                    dateTimePicker2.Value = DateTime.Parse(dgr.Cells[6].Value.ToString()); 
                    comboBox6.SelectedItem = dgr.Cells[1].Value;

                    textBox6.Text = dgr.Cells[10].Value.ToString();
                    richTextBox2.Text = dgr.Cells[9].Value.ToString();
                    


                    break;
                }
            }
        }



        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dgr in this.dataGridView4.Rows)
            {
                if (dgr.Selected)
                {
                    comboBox2.Text = dgr.Cells[0].Value.ToString();
                    comboBox21.Text = dgr.Cells[1].Value.ToString();
                    textBox31.Text = dgr.Cells[2].Value.ToString();
                    textBox30.Text = dgr.Cells[9].Value.ToString();
                    textBox7.Text = dgr.Cells[4].Value.ToString();
                    textBox22.Text = dgr.Cells[5].Value.ToString();
                    textBox29.Text = dgr.Cells[6].Value.ToString();
                    comboBox22.SelectedItem = dgr.Cells[13].Value;

                    richTextBox4.Text = dgr.Cells[7].Value.ToString();
                    richTextBox3.Text = dgr.Cells[8].Value.ToString();
                    richTextBox7.Text = dgr.Cells[10].Value.ToString();
                    comboBox5.SelectedItem = dgr.Cells[3].Value;

                    byte[] imageData1 = (byte[])dataGridView4.CurrentRow.Cells[11].Value;


                    Image image1;

                    using (MemoryStream ms1 = new MemoryStream(imageData1, 0, imageData1.Length))
                    {
                        ms1.Write(imageData1, 0, imageData1.Length);
                        image1 = Image.FromStream(ms1, true);
                    }
                    pictureBox1.Image = image1;
                    textBoximgpath.Text = pictureBox2.ImageLocation;
                    break;
                


                byte[] imageData2 = (byte[])dataGridView4.CurrentRow.Cells[12].Value;


                    Image image2;

                    using (MemoryStream ms2 = new MemoryStream(imageData2, 0, imageData2.Length))
                    {
                        ms2.Write(imageData2, 0, imageData2.Length);
                        image2 = Image.FromStream(ms2, true);
                    }
                    pictureBox4.Image = image2;
                    textBoximgpath.Text = pictureBox4.ImageLocation;
                    break;
                }
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dgr in this.dataGridView6.Rows)
            {
                if (dgr.Selected)
                {
                    comboBox3.Text= dgr.Cells[0].Value.ToString();
                    dateTimePicker3.Value = DateTime.Parse(dgr.Cells[3].Value.ToString());
                    textBox12.Text = dgr.Cells[4].Value.ToString();
                    textBox11.Text = dgr.Cells[5].Value.ToString();
                    textBox10.Text = dgr.Cells[6].Value.ToString();
                    textBox9.Text = dgr.Cells[7].Value.ToString();
                    dateTimePicker1.Value = DateTime.Parse(dgr.Cells[8].Value.ToString());
                    comboBox2.SelectedItem = dgr.Cells[9].Value;
                    textBox8.Text = dgr.Cells[10].Value.ToString();
                    comboBox3.SelectedItem = dgr.Cells[11].Value;

                    byte[] imageData1 = (byte[])dataGridView6.CurrentRow.Cells[12].Value;
                   
                    
                    Image image1;

                    using (MemoryStream ms1 = new MemoryStream(imageData1, 0, imageData1.Length))
                    {
                        ms1.Write(imageData1, 0, imageData1.Length);
                        image1 = Image.FromStream(ms1, true);
                    }
                    pictureBox2.Image = image1;
                    textBoximgpath.Text = pictureBox2.ImageLocation;
                    break;
                }
            }

        }


      

       /* private void showReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OfficerReport or = new OfficerReport();
            or.Show();
        }
        
         private void showReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SuspectReport sr = new SuspectReport();
            sr.Show();
        }
        
        */

        private void showReportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DisposalReport dr = new DisposalReport();
            dr.Show();

        }
        
       
        private void showDisposalReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisposalReport dr = new DisposalReport();
            dr.Show();
        }
        
        private void showChartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Charts c = new Charts();
            c.Show();
        }


        private void button25_Click(object sender, EventArgs e)
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

            saveFileDialog1.FileName = "Complainant";
            saveFileDialog1.Filter = "Excel File(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                excel.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
            }

        }

        private void button27_Click(object sender, EventArgs e)
        {
            excel.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i < dataGridView3.Columns.Count + 1; i++)
            {
                excel.Cells[1, i] = dataGridView3.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView3.Columns.Count; j++)
                {
                    excel.Cells[i + 2, j + 1] = dataGridView3.Rows[i].Cells[j].Value.ToString();
                }
            }
            saveFileDialog1.FileName = "FIR";
            saveFileDialog1.Filter = "Excel File(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                excel.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            excel.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i < dataGridView5.Columns.Count + 1; i++)
            {
                excel.Cells[1, i] = dataGridView5.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView5.Columns.Count; j++)
                {
                    excel.Cells[i + 2, j + 1] = dataGridView5.Rows[i].Cells[j].Value.ToString();
                }
            }
            saveFileDialog1.FileName = "Case Disposal";
            saveFileDialog1.Filter = "Excel File(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                excel.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            excel.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i < dataGridView4.Columns.Count + 1; i++)
            {
                excel.Cells[1, i] = dataGridView4.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView4.Columns.Count; j++)
                {
                    excel.Cells[i + 2, j + 1] = dataGridView4.Rows[i].Cells[j].Value.ToString();
                }
            }
            saveFileDialog1.FileName = "Suspect";
            saveFileDialog1.Filter = "Excel File(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                excel.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            excel.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i < dataGridView3.Columns.Count + 1; i++)
            {
                excel.Cells[1, i] = dataGridView3.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView3.Columns.Count; j++)
                {
                    excel.Cells[i + 2, j + 1] = dataGridView3.Rows[i].Cells[j].Value.ToString();
                }
            }
            saveFileDialog1.FileName = "NonCognizable";
            saveFileDialog1.Filter = "Excel File(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                excel.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
            }
        }
        private void button26_Click(object sender, EventArgs e)
        {
            excel.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i < dataGridView2.Columns.Count + 1; i++)
            {
                excel.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    excel.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                }
            }

            saveFileDialog1.FileName = "Case";
            saveFileDialog1.Filter = "Excel File(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                excel.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
            }
        }


        private void button30_Click(object sender, EventArgs e)
        {
            excel.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i < dataGridView6.Columns.Count + 1; i++)
            {
                excel.Cells[1, i] = dataGridView6.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView6.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView6.Columns.Count; j++)
                {
                    excel.Cells[i + 2, j + 1] = dataGridView6.Rows[i].Cells[j].Value.ToString();
                }
            }
            saveFileDialog1.FileName = "Officer";
            saveFileDialog1.Filter = "Excel File(*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                excel.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName);
                excel.ActiveWorkbook.Saved = true;
                excel.Quit();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";


            if (open.ShowDialog() == DialogResult.OK)
            {

                Chosen_File = open.FileName.ToString();
                textBoximgpath.Text = Chosen_File;

                pictureBox1.ImageLocation = Chosen_File;



            }

        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void fIRReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FIRReport fr = new FIRReport();
            fr.Show();
        }

        private void casebindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void liveChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chat chat = new Chat();
            chat.Show();
        }

        private void complainantRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComplainantsList cl = new ComplainantsList();
            cl.Show();
        }

        private void firRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FIRList fr = new FIRList();
            fr.Show();
        }

        private void complaintRecordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ComplaintsList cml = new ComplaintsList();
            cml.Show();
        }

        private void caseRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CasesList cl = new CasesList();
            cl.Show();
        }

        private void disposalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisposalsList dl = new DisposalsList();
            dl.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();


                SqlCommand scm = new SqlCommand("select * from FIR", cn);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                dataGridView3.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();


                SqlCommand scm = new SqlCommand("select * from Complainant", cn);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                dataGridView1.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();


                SqlCommand scm = new SqlCommand("select * from [Non-Cognizable]", cn);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                dataGridView5.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(connectionString);
                cn.Open();


                SqlCommand scm = new SqlCommand("select * from [Case Disposal]", cn);
                DataTable table = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(scm);
                adp.Fill(table);
                dataGridView7.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      
    }
}
