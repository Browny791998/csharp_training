using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.User
{
    public partial class AdminJobList : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Job.Job jobmodel = new JobPortal_Models.Job.Job();
        private JobPortal_Services.Job.JobService jobservice = new JobPortal_Services.Job.JobService();
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
            da = JobPortal_Services.Job.JobService.GetActiveData();
            if (da.Rows.Count > 0)
            {
                grvJob.DataSource = da;
                grvJob.DataBind();
                grvJob.Visible = true;
                grvJob.UseAccessibleHeader = true;
                grvJob.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grvJob.DataSource = null;
                grvJob.DataBind();
            }
        }

        #endregion Get Data

        #region search data

        /// <summary>
        /// search data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.Job.JobService.SearchActiveData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvJob.DataSource = da;
                grvJob.DataBind();
                grvJob.Visible = true;
            }
            else
            {
                grvJob.DataSource = null;
                grvJob.DataBind();
            }
            grvJob.UseAccessibleHeader = true;
            grvJob.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        /// <summary>
        /// bind data to datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvJob.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        #endregion search data
    }
}