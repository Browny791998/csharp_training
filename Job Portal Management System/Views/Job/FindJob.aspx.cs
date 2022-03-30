using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Job
{
    public partial class FindJob : System.Web.UI.Page
    {
        #region variable declaration

        private DataTable da = new DataTable();

        #endregion variable declaration

        #region bind data

        /// <summary>
        /// bind data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// bind data to datagrid
        /// </summary>
        public void BindJob()
        {
            da = JobPortal_Services.Job.JobService.GetActiveData();
            rptJoblist.DataSource = da;
            rptJoblist.DataBind();
        }

        /// <summary>
        /// bind Specialization data
        /// </summary>
        public void bindSpecialization()
        {
            da = JobPortal_Services.Specialization.SpecializationServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlspeicalization.DataSource = da;
                ddlspeicalization.DataValueField = "id";
                ddlspeicalization.DataTextField = "specialization";
                ddlspeicalization.SelectedIndex = -1;
                ddlspeicalization.DataBind();
                ddlspeicalization.Items.Insert(0, new ListItem("--Select Specialization--", "--Select Specialization--"));
            }
        }

        /// <summary>
        /// bind Position data
        /// </summary>
        public void bindPosition()
        {
            da = JobPortal_Services.Position.PositionServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlPosition.DataSource = da;
                ddlPosition.DataValueField = "id";
                ddlPosition.DataTextField = "position";
                ddlPosition.SelectedIndex = -1;
                ddlPosition.DataBind();
                ddlPosition.Items.Insert(0, new ListItem("--Select Position--", "--Select Position--"));
            }
        }

        /// <summary>
        /// bind Jobnature data
        /// </summary>
        public void bindJobType()
        {
            da = JobPortal_Services.Jobnature.JobnatureServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlJobtype.DataSource = da;
                ddlJobtype.DataValueField = "id";
                ddlJobtype.DataTextField = "job_nature";
                ddlJobtype.SelectedIndex = -1;
                ddlJobtype.DataBind();
                ddlJobtype.Items.Insert(0, new ListItem("--Select Type--", "--Select Type--"));
            }
        }

        /// <summary>
        /// bind Country data
        /// </summary>
        public void bindCountry()
        {
            da = JobPortal_Services.Country.CountryServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlCountry.DataSource = da;
                ddlCountry.DataValueField = "id";
                ddlCountry.DataTextField = "country";
                ddlCountry.SelectedIndex = -1;
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("--Select Country--", "--Select Country--"));
            }
        }

        #endregion bind data

        #region get data

        /// <summary>
        /// get data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            int countryID, positionID, jobtypeID, speiclizationID;
            if (ddlCountry.SelectedValue == "--Select Country--" && ddlJobtype.SelectedValue == "--Select Type--" && ddlPosition.SelectedValue == "--Select Position--" && ddlspeicalization.SelectedValue == "--Select Specialization--")
            {
                BindJob();
            }
            else if (ddlJobtype.SelectedValue == "--Select Type--" && ddlPosition.SelectedValue == "--Select Position--" && ddlspeicalization.SelectedValue == "--Select Specialization--" && ddlCountry.SelectedValue != "--Select Country--")
            {
                countryID = Convert.ToInt32(ddlCountry.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(countryID, 0, 0, 0);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlCountry.SelectedValue == "--Select Country--" && ddlPosition.SelectedValue == "--Select Position--" && ddlspeicalization.SelectedValue == "--Select Specialization--" && ddlJobtype.SelectedValue != "--Select Type--")
            {
                jobtypeID = Convert.ToInt32(ddlJobtype.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(0, 0, jobtypeID, 0);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlCountry.SelectedValue == "--Select Country--" && ddlJobtype.SelectedValue == "--Select Type--" && ddlspeicalization.SelectedValue == "--Select Specialization--" && ddlPosition.SelectedValue != "--Select Position--")
            {
                positionID = Convert.ToInt32(ddlPosition.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(0, positionID, 0, 0);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlCountry.SelectedValue == "--Select Country--" && ddlJobtype.SelectedValue == "--Select Type--" && ddlPosition.SelectedValue == "--Select Position--" && ddlspeicalization.SelectedValue != "--Select Specialization--")
            {
                speiclizationID = Convert.ToInt32(ddlspeicalization.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(0, 0, 0, speiclizationID);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlCountry.SelectedValue != "--Select Country--" && ddlJobtype.SelectedValue != "--Select Type--" && ddlPosition.SelectedValue != "--Select Position--" && ddlspeicalization.SelectedValue != "--Select Specialization--")
            {
                countryID = Convert.ToInt32(ddlCountry.SelectedValue);
                positionID = Convert.ToInt32(ddlPosition.SelectedValue);
                jobtypeID = Convert.ToInt32(ddlJobtype.SelectedValue);
                speiclizationID = Convert.ToInt32(ddlspeicalization.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(countryID, positionID, jobtypeID, speiclizationID);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlJobtype.SelectedValue == "--Select Type--" && ddlspeicalization.SelectedValue == "--Select Specialization--" && ddlCountry.SelectedValue != "--Select Country--" && ddlPosition.SelectedValue != "--Select Position--")
            {
                countryID = Convert.ToInt32(ddlCountry.SelectedValue);
                positionID = Convert.ToInt32(ddlPosition.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(countryID, positionID, 0, 0);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlPosition.SelectedValue == "--Select Position--" && ddlspeicalization.SelectedValue == "--Select Specialization--" && ddlCountry.SelectedValue != "--Select Country--" && ddlJobtype.SelectedValue != "--Select Type--")
            {
                countryID = Convert.ToInt32(ddlCountry.SelectedValue);
                jobtypeID = Convert.ToInt32(ddlJobtype.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(countryID, 0, jobtypeID, 0);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlPosition.SelectedValue == "--Select Position--" && ddlJobtype.SelectedValue == "--Select Type--" && ddlCountry.SelectedValue != "--Select Country--" && ddlspeicalization.SelectedValue != "--Select Specialization--")
            {
                countryID = Convert.ToInt32(ddlCountry.SelectedValue);
                speiclizationID = Convert.ToInt32(ddlspeicalization.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(countryID, 0, 0, speiclizationID);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlspeicalization.SelectedValue == "--Select Specialization--" && ddlCountry.SelectedValue != "--Select Country--" && ddlPosition.SelectedValue != "--Select Position--" && ddlJobtype.SelectedValue != "--Select Type--")
            {
                countryID = Convert.ToInt32(ddlCountry.SelectedValue);
                positionID = Convert.ToInt32(ddlPosition.SelectedValue);
                jobtypeID = Convert.ToInt32(ddlJobtype.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(countryID, positionID, jobtypeID, 0);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlPosition.SelectedValue == "--Select Position--" && ddlCountry.SelectedValue != "--Select Country--" && ddlJobtype.SelectedValue != "--Select Type--" && ddlspeicalization.SelectedValue != "--Select Specialization--")
            {
                countryID = Convert.ToInt32(ddlCountry.SelectedValue);
                speiclizationID = Convert.ToInt32(ddlspeicalization.SelectedValue);
                jobtypeID = Convert.ToInt32(ddlJobtype.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(countryID, 0, jobtypeID, speiclizationID);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlJobtype.SelectedValue == "--Select Type--" && ddlCountry.SelectedValue != "--Select Country--" && ddlPosition.SelectedValue != "--Select Position--" && ddlspeicalization.SelectedValue != "--Select Specialization--")
            {
                countryID = Convert.ToInt32(ddlCountry.SelectedValue);
                positionID = Convert.ToInt32(ddlPosition.SelectedValue);
                speiclizationID = Convert.ToInt32(ddlspeicalization.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(countryID, positionID, 0, speiclizationID);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlCountry.SelectedValue == "--Select Country--" && ddlJobtype.SelectedValue != "--Select Type--" && ddlPosition.SelectedValue != "--Select Position--" && ddlspeicalization.SelectedValue != "--Select Specialization--")
            {
                jobtypeID = Convert.ToInt32(ddlJobtype.SelectedValue);
                positionID = Convert.ToInt32(ddlPosition.SelectedValue);
                speiclizationID = Convert.ToInt32(ddlspeicalization.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(0, positionID, jobtypeID, speiclizationID);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlCountry.SelectedValue == "--Select Country--" && ddlspeicalization.SelectedValue == "--Select Specialization--" && ddlPosition.SelectedValue != "--Select Position--" && ddlJobtype.SelectedValue != "--Select Type--")
            {
                jobtypeID = Convert.ToInt32(ddlJobtype.SelectedValue);
                positionID = Convert.ToInt32(ddlPosition.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(0, positionID, jobtypeID, 0);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlCountry.SelectedValue == "--Select Country--" && ddlJobtype.SelectedValue == "--Select Type--" && ddlPosition.SelectedValue != "--Select Position--" && ddlspeicalization.SelectedValue != "--Select Specialization--")
            {
                positionID = Convert.ToInt32(ddlPosition.SelectedValue);
                speiclizationID = Convert.ToInt32(ddlspeicalization.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(0, positionID, 0, speiclizationID);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else if (ddlCountry.SelectedValue == "--Select Country--" && ddlPosition.SelectedValue == "--Select Position--" && ddlJobtype.SelectedValue != "--Select Type--" && ddlspeicalization.SelectedValue != "--Select Specialization--")
            {
                jobtypeID = Convert.ToInt32(ddlJobtype.SelectedValue);
                speiclizationID = Convert.ToInt32(ddlspeicalization.SelectedValue);
                da = JobPortal_Services.Job.JobService.FilterJob(0, 0, jobtypeID, speiclizationID);
                rptJoblist.DataSource = da;
                rptJoblist.DataBind();
            }
            else
            {
                BindJob();
            }
        }

        #endregion get data

        #region view data

        /// <summary>
        /// view all job
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnViewAllJob_Click(object sender, EventArgs e)
        {
            ddlCountry.SelectedValue = "--Select Country--";
            ddlJobtype.SelectedValue = "--Select Type--";
            ddlPosition.SelectedValue = "--Select Position--";
            ddlspeicalization.SelectedValue = "--Select Specialization--";
            da = JobPortal_Services.Job.JobService.GetActiveData();
            rptJoblist.DataSource = da;
            rptJoblist.DataBind();
        }

        /// <summary>
        /// view job and company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnView_Click(object sender, EventArgs e)
        {
            Session.Remove("url");
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var jobId = ((Label)item.FindControl("jobId")).Text;
            var CompanyId = ((Label)item.FindControl("companyId")).Text;
            string strURL = "JobDetail.aspx?";
            string strURLWithData = strURL +
          EncryptQueryString(string.Format("jobID={0}&ComID={1}",jobId,CompanyId));
            HttpContext.Current.Response.Redirect(strURLWithData);
        }

        public string EncryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
        }

        #endregion view data
    }
}