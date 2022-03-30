using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.JobSeeker
{
    public partial class JobSeekerProfile : System.Web.UI.Page
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
            if (Session["role"] == null || Session["role"].ToString() != "Job Seeker")
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            GetAcc();
        }

        #endregion bind data

        #region get data

        /// <summary>
        /// get data
        /// </summary>
        public void GetAcc()
        {
            int id = Convert.ToInt32(Session["id"]);
            da = JobPortal_Services.JobSeeker.JobSeekerService.GetAllData(id);
            rptJobseeker.DataSource = da;
            rptJobseeker.DataBind();
        }

        #endregion get data

        #region edit data

        /// <summary>
        /// edit data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Session.Remove("url");
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var IdValue = ((Label)item.FindControl("jobseekerId")).Text;
            string strURL = "JobSeekerEdit.aspx?";
            string strURLWithData = strURL + EncryptQueryString(string.Format("id={0}", IdValue));
            HttpContext.Current.Response.Redirect(strURLWithData);
        }
        public string EncryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
        }

        #endregion edit data
    }
}