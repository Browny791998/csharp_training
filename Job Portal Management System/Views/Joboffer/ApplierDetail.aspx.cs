using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Joboffer
{
    public partial class ApplierDetail : System.Web.UI.Page
    {
        JobPortal_Services.JobSeeker.JobSeekerService jobseekerservice = new JobPortal_Services.JobSeeker.JobSeekerService();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            if (!IsPostBack)
            {
                GetApplier();
            }
        }

        public void GetApplier()
        {
            int id = Convert.ToInt32(Request.QueryString["applierID"]);
            da = JobPortal_Services.JobSeeker.JobSeekerService.GetAllData(id);
            rptApplier.DataSource = da;
            rptApplier.DataBind();

        }
    }
}