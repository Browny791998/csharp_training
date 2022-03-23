using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.User
{
    public partial class AdminJobList : System.Web.UI.Page
    {
        JobPortal_Models.Job.Job jobmodel = new JobPortal_Models.Job.Job();
        JobPortal_Services.Job.JobService jobservice = new JobPortal_Services.Job.JobService();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }

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

        #endregion

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

        protected void grvJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvJob.PageIndex = e.NewPageIndex;
            this.GetData();
        }
    }
}