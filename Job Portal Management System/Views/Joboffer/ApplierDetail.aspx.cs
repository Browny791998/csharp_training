using System;
using System.Data;

namespace Job_Portal_Management_System.Views.Joboffer
{
    public partial class ApplierDetail : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Services.JobSeeker.JobSeekerService jobseekerservice = new JobPortal_Services.JobSeeker.JobSeekerService();
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
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            if (!IsPostBack)
            {
                GetApplier();
            }
        }

        #endregion bind data

        #region get data

        /// <summary>
        /// get data
        /// </summary>
        public void GetApplier()
        {
            int id = Convert.ToInt32(Request.QueryString["applierID"]);
            da = JobPortal_Services.JobSeeker.JobSeekerService.GetAllData(id);
            rptApplier.DataSource = da;
            rptApplier.DataBind();
        }

        #endregion get data

        #region back to joboofferlist

        /// <summary>
        /// back to job offer list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobOfferList.aspx");
        }

        #endregion back to joboofferlist
    }
}