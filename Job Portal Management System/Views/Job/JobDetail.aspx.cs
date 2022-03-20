using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Job
{
    public partial class JobDetail : System.Web.UI.Page
    {
         
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJob();
                BindCompany();
            }
        }
        public void BindJob()
        {
            int Jobid= Convert.ToInt32(Request.QueryString["jobID"]);
            da = JobPortal_Services.Job.JobService.GetData(Jobid);
            rptJob.DataSource = da;
            rptJob.DataBind();
        }

        public void BindCompany()
        {
            int companyid = Convert.ToInt32(Request.QueryString["ComID"]);
            da = JobPortal_Services.Company.CompanyService.GetAllData(companyid);
            rptcompany.DataSource = da;
            rptcompany.DataBind();
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else if (Session["role"].ToString() == "Company")
            {
                Session["alert"] = "Only Job Seeker can apply the job";
                Session["alert-type"] = "warning";
            }
            else
            {

            }
        }
    }
}