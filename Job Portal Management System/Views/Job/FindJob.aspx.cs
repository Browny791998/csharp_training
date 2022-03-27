using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Job
{
    public partial class FindJob : System.Web.UI.Page
    {
        private DataTable da = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJob();
                bindPosition();
                bindJobType();
                bindSpecialization();
                bindCountry();
            }
        }

        public void BindJob()
        {
            da = JobPortal_Services.Job.JobService.GetActiveData();
            rptJoblist.DataSource = da;
            rptJoblist.DataBind();
        }

        public void bindSpecialization()
        {
            da = JobPortal_Services.Specialization.SpecializationServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlspeicalization.DataSource = da;
                ddlspeicalization.DataValueField = "id";
                ddlspeicalization.DataTextField = "specialization";
                ddlspeicalization.DataBind();
            }
        }

        public void bindPosition()
        {
            da = JobPortal_Services.Position.PositionServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlPosition.DataSource = da;
                ddlPosition.DataValueField = "id";
                ddlPosition.DataTextField = "position";
                ddlPosition.DataBind();
            }
        }

        public void bindJobType()
        {
            da = JobPortal_Services.Jobnature.JobnatureServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlJobtype.DataSource = da;
                ddlJobtype.DataValueField = "id";
                ddlJobtype.DataTextField = "job_nature";
                ddlJobtype.DataBind();
            }
        }

        public void bindCountry()
        {
            da = JobPortal_Services.Country.CountryServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlCountry.DataSource = da;
                ddlCountry.DataValueField = "id";
                ddlCountry.DataTextField = "country";
                ddlCountry.DataBind();
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            int countryID = Convert.ToInt32(ddlCountry.SelectedValue);
            int positionID = Convert.ToInt32(ddlPosition.SelectedValue);
            int jobtypeID = Convert.ToInt32(ddlJobtype.SelectedValue);
            int speiclizationID = Convert.ToInt32(ddlspeicalization.SelectedValue);
            da = JobPortal_Services.Job.JobService.FilterJob(countryID, positionID, jobtypeID, speiclizationID);
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
            var CompanyId = ((Label)item.FindControl("companyId")).Text;
            Response.Redirect("JobDetail.aspx?jobID=" + jobId + "&ComID=" + CompanyId);
        }
    }
}