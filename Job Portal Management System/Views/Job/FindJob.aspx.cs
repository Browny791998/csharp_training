using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Job
{
    public partial class FindJob : System.Web.UI.Page
    {
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJob();
            }
        }

        public void BindJob()
        {
           
            da = JobPortal_Services.Job.JobService.GetActiveData();
            rptJoblist.DataSource = da;
            rptJoblist.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            int countryID = Convert.ToInt32(ddlCountry.SelectedValue);
            int positionID = Convert.ToInt32(ddlPosition.SelectedValue);
            int jobtypeID = Convert.ToInt32(ddlJobtype.SelectedValue);
            da = JobPortal_Services.Job.JobService.FilterJob(countryID, positionID, jobtypeID);
            rptJoblist.DataSource = da;
            rptJoblist.DataBind();
        }

        protected void btnViewAllJob_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.Job.JobService.GetActiveData();
            rptJoblist.DataSource = da;
            rptJoblist.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var jobId = ((Label)item.FindControl("jobId")).Text;
            var CompanyId= ((Label)item.FindControl("companyId")).Text;
            Response.Redirect("JobDetail.aspx?jobID=" + jobId +"&ComID="+CompanyId);
        }
    }
}