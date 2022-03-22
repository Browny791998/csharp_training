using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.JobSeeker
{
    public partial class AppliedJob : System.Web.UI.Page
    {


        JobPortal_Models.JobOffer.JobOffer joboffermodel = new JobPortal_Models.JobOffer.JobOffer();
        JobPortal_Services.JobOffer.JobOfferService jobofferservice = new JobPortal_Services.JobOffer.JobOfferService();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            if (!IsPostBack)
            {
                GetData();

            }
        }

       
        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
            int companyID = Convert.ToInt32(Session["id"]);
            da = JobPortal_Services.JobOffer.JobOfferService.GetJobByJobseeker(companyID);
            if (da.Rows.Count > 0)
            {
                grvAppliedJob.DataSource = da;
                grvAppliedJob.DataBind();
                grvAppliedJob.Visible = true;
                grvAppliedJob.UseAccessibleHeader = true;
                grvAppliedJob.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grvAppliedJob.DataSource = null;
                grvAppliedJob.DataBind();
            }
        }


        protected void grvAppliedJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAppliedJob.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        protected void grvAppliedJob_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvAppliedJob.DataKeys[e.RowIndex].Value);
            joboffermodel.ID = id;
            bool IsDelete = JobPortal_Services.JobOffer.JobOfferService.Delete(joboffermodel);
            if (IsDelete)
            {
                Session["alert"] = "Reject this job successfully";
                Session["alert-type"] = "success";
                GetData();
            }
            else
            {
                Session["alert"] = "Rejecting failed";
                Session["alert-type"] = "danger";
            }
        }
    }
}