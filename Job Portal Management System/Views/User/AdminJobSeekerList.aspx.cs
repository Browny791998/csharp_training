using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.User
{
    public partial class AdminJobSeekerList : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.JobSeeker.JobSeeker jobseekermodel = new JobPortal_Models.JobSeeker.JobSeeker();
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
                Response.Redirect("~/Views/User/Login.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
            }
        }

        #endregion bind data

        #region Get Data

        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
            da = JobPortal_Services.JobSeeker.JobSeekerService.GetAllJobSeeker();
            if (da.Rows.Count > 0)
            {
                grvJobSeeker.DataSource = da;
                grvJobSeeker.DataBind();
                grvJobSeeker.Visible = true;
                grvJobSeeker.UseAccessibleHeader = true;
                grvJobSeeker.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grvJobSeeker.DataSource = null;
                grvJobSeeker.DataBind();
            }
        }

        #endregion Get Data

        #region search data

        /// <summary>
        /// bind data to datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvJobSeeker_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvJobSeeker.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        /// <summary>
        /// search data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.JobSeeker.JobSeekerService.SearchAllJobSeeker(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvJobSeeker.DataSource = da;
                grvJobSeeker.DataBind();
                grvJobSeeker.Visible = true;
            }
            else
            {
                grvJobSeeker.DataSource = null;
                grvJobSeeker.DataBind();
            }
            grvJobSeeker.UseAccessibleHeader = true;
            grvJobSeeker.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion search data

        #region clear data
        /// <summary>
        /// clear data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            this.GetData();
        }
        #endregion
    }
}