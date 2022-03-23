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
        }
    }
}