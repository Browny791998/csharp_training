using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.Data;

namespace Tutorial9
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string excelfilepath = Server.MapPath("~/Upload/User.xlsx");
            ImoprtExceltoGridView(excelfilepath, ".xlsx", "Yes");
        }

        /// <summary>
        /// getting data from excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            string excelfilepath = Server.MapPath("~/Upload/User.xlsx");
            ImoprtExceltoGridView(excelfilepath, ".xlsx", "Yes");
        }

        /// <summary>
        /// importing excel to gridview
        /// </summary>
        /// <param name="File"></param>
        /// <param name="extension"></param>
        /// <param name="ishdr"></param>
        public void ImoprtExceltoGridView(string File, string extension, string ishdr)
        {
             string connectionStr = ConfigurationManager.ConnectionStrings["Excelconnection"].ConnectionString;
            connectionStr = String.Format(connectionStr, File, ishdr);
            OleDbConnection con = new OleDbConnection(connectionStr);
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmd.Connection = con;
            con.Open();
            DataTable dtexcel = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetname = dtexcel.Rows[0]["TABLE_NAME"].ToString();
            cmd.CommandText = "Select * from [" + sheetname + "]";
            oda.SelectCommand = cmd;
            oda.Fill(dt);
            con.Close();
            gvFile.DataSource = dt;
            gvFile.DataBind();
        }

        /// <summary>
        /// getting data from csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCSV_Click(object sender, EventArgs e)
        {
            string csvPath = Server.MapPath("~/Upload/User.csv");
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"),
            new DataColumn("Name"),
            new DataColumn("Address"),
            new DataColumn("Email")});
            string csvData = File.ReadAllText(csvPath);
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }
            gvFile.DataSource = dt;
            gvFile.DataBind();
        }
       
        /// <summary>
        /// getting data from text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnText_Click(object sender, EventArgs e)
        {
            string csvPath = Server.MapPath("~/Upload/User.txt");
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"),
            new DataColumn("Name"),
            new DataColumn("Address"),
            new DataColumn("Email")});
            string csvData = File.ReadAllText(csvPath);
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }
            gvFile.DataSource = dt;
            gvFile.DataBind();
        }
    }
}