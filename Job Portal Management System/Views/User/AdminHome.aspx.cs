using System;
using System.Data;

namespace Job_Portal_Management_System.Views
{
    public partial class AdminHome : System.Web.UI.Page
    {
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/User/Login.aspx");
            }
            da = JobPortal_Services.JobSeeker.JobSeekerService.GetAllJobSeeker();
            lblJobseeker.Text = da.Rows.Count.ToString();
            da = JobPortal_Services.Company.CompanyService.GetCompanyAllData();
            lblCompany.Text = da.Rows.Count.ToString();
            da = JobPortal_Services.Job.JobService.GetActiveData();
            lblJob.Text= da.Rows.Count.ToString();


            da = JobPortal_Services.JobSeeker.JobSeekerService.GetChartData();
            if (da.Rows.Count > 0)
            {
                string ChartData = "";
                string views = "";
                string labels = "";
                ChartData += "<script>";
                for(int i = 0; i < da.Rows.Count; i++)
                {
                    views += da.Rows[i]["JobSeeker"] + ",";
                    labels +=da.Rows[i]["Day"] + ",";
                }
                views = views.Substring(0, views.Length - 1);
                labels= labels.Substring(0, labels.Length - 1);
                ChartData += " chartLabels=["+labels+ "];chartData=["+views+"]";
                ChartData += "</script>";
                ltChartData.Text = ChartData;
            }
        }
    }
}