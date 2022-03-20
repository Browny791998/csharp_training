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
        JobPortal_Models.JobOffer.JobOffer joboffermodel = new JobPortal_Models.JobOffer.JobOffer();
        JobPortal_Services.JobOffer.JobOfferService jobofferservice = new JobPortal_Services.JobOffer.JobOfferService();
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

        #region InsertData
        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
            joboffermodel.JobSeekerID = Convert.ToInt32(Session["id"]);
            joboffermodel.CompanyID = Convert.ToInt32(Request.QueryString["ComID"]);
         joboffermodel.JobID = Convert.ToInt32(Request.QueryString["jobID"]);;
           joboffermodel.AppliedDate = DateTime.Now;
        }
        #endregion
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
                da = JobPortal_Services.JobOffer.JobOfferService.GetJobandSeeker(Convert.ToInt32(Request.QueryString["jobID"]), Convert.ToInt32(Session["id"]));
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "You already applied this job!";
                    Session["alert-type"] = "danger";
                }
                else
                {
                    InsertData();
                    bool success = JobPortal_Services.JobOffer.JobOfferService.Insert(joboffermodel);
                    if (success)
                    {
                        Session["alert"] = "Successfully applied this job,we will reply you soon";
                        Session["alert-type"] = "success";
                    }
                    else
                    {
                        Session["alert"] = "Failed to apply this job";
                        Session["alert-type"] = "danger";
                    }
                }
               
            }
        }
    }
}