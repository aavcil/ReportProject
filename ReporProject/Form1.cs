using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using ReportLibrary;
using ReportLibrary.Input.Models;
using ReportProject;

namespace ReporProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
        DataTable dt = new DataTable();

        private void Button3_Click(object sender, EventArgs e)
        {
            GetData getData = new GetData();

            var response = ReportHelper.CreateReport(getData.works(), getData.stops());
            int totalWorks = 0;
            foreach (var item in response.WorkOrders)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.work;
                dr[2] = item.Trouble;
                dr[1] = item.Break;
                dr[3] = item.Setup;
                dr[4] = item.ArGe;
                dr[5] = item.Total;
                dt.Rows.Add(dr);
                totalWorks += item.Total;
            }

            DataRow lastRow = dt.NewRow();
            lastRow[0] = "Toplam";
            lastRow[2] = response.TotalTrouble;
            lastRow[1] = response.TotalBreak;
            lastRow[3] = response.TotalSetup;
            lastRow[4] = response.TotalArGe;
            lastRow[5] = totalWorks;
            dt.Rows.Add(lastRow);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("İş Emri");
            dt.Columns.Add("Mola");
            dt.Columns.Add("Arıza");
            dt.Columns.Add("Setup");
            dt.Columns.Add("Arge");
            dt.Columns.Add("Toplam");

            dataGridView1.DataSource = dt;
        }
    }
}
