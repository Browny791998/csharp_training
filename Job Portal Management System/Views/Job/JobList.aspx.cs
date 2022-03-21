using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Job
{
    public partial class JobList : System.Web.UI.Page
    {
      JobPortal_Models.Job.Job jobmodel = new JobPortal_Models.Job.Job();
       JobPortal_Services.Job.JobService jobservice = new JobPortal_Services.Job.JobService();
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

        #region Get Data
        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
            int companyID = Convert.ToInt32(Session["id"]);
            da = JobPortal_Services.Job.JobService.GetAllData(companyID);
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

        protected void grvJob_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvJob.DataKeys[e.RowIndex].Value);
            jobmodel.ID = id;
            bool IsDelete = JobPortal_Services.Job.JobService.Delete(jobmodel);
            if (IsDelete)
            {
                Session["alert"] = "Delete successfully";
                Session["alert-type"] = "success";
                GetData();
            }
            else
            {
                Session["alert"] = "Delete failed";
                Session["alert-type"] = "danger";
            }
        }

        protected void grvJob_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
            int id = Convert.ToInt32(grvJob.DataKeys[e.RowIndex].Value);
            Response.Redirect("CreateJob.aspx?id=" + id +"&action=update");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.Job.JobService.GetSearchData(txtSearch.Text,Convert.ToInt32(Session["id"]));
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateJob.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            this.GetData();
        }

        protected void grvJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvJob.PageIndex = e.NewPageIndex;
            this.GetData();
        }
    }
}