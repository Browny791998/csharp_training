using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Jobnature
{
    public partial class JobnatureList : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Jobnature.Jobnature jobnaturemodel = new JobPortal_Models.Jobnature.Jobnature();
        private JobPortal_Services.Jobnature.JobnatureServices countryservice = new JobPortal_Services.Jobnature.JobnatureServices();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region binding data

        /// <summary>
        /// binding data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/User/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                GetData();
            }
        }

        #endregion binding data

        #region Get Data

        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
            da = JobPortal_Services.Jobnature.JobnatureServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvJobnature.DataSource = da;
                grvJobnature.DataBind();
                grvJobnature.Visible = true;
            }
            else
            {
                grvJobnature.DataSource = null;
                grvJobnature.DataBind();
            }
            grvJobnature.UseAccessibleHeader = true;
            grvJobnature.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion Get Data

        #region customer add,update,delete

        /// <summary>
        /// go to add page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["label"] = "add";
            Response.Redirect("JobnatureCreate.aspx");
        }

        /// <summary>
        /// go to update page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvJobnature_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["label"] = "update";
            int id = Convert.ToInt32(grvJobnature.DataKeys[e.RowIndex].Value);
            Response.Redirect("JobnatureCreate.aspx?id=" + id);
        }

        /// <summary>
        /// deleting jobnature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvJobnature_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int jnid;
            int id = Convert.ToInt32(grvJobnature.DataKeys[e.RowIndex].Value);
            da = JobPortal_Services.Job.JobService.GetAllJObData();
            for (int j = 0; j < da.Rows.Count; j++)
            {
                jnid = Convert.ToInt32(da.Rows[j]["job_nature_id"]);
                if (jnid == id)
                {
                    Session["alert"] = "Data Exist You can't delete this";
                    Session["alert-type"] = "warning";
                    GetData();
                    return;
                }
            }
            jobnaturemodel.ID = id;
            bool IsDelete = JobPortal_Services.Jobnature.JobnatureServices.Delete(jobnaturemodel);
            if (IsDelete)
            {
                Session["alert"] = "Deleted successfully";
                Session["alert-type"] = "success";
                GetData();
            }
            else
            {
                Session["alert"] = "Deleting failed";
                Session["alert-type"] = "danger";
            }
        }

        #endregion customer add,update,delete

        #region search jobnature

        /// <summary>
        /// search customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.Jobnature.JobnatureServices.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvJobnature.DataSource = da;
                grvJobnature.DataBind();
                grvJobnature.Visible = true;
            }
            else
            {
                grvJobnature.DataSource = null;
                grvJobnature.DataBind();
            }
            grvJobnature.UseAccessibleHeader = true;
            grvJobnature.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion search jobnature

        #region paging

        /// <summary>
        /// paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvJobnature_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvJobnature.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        #endregion paging

        #region clear and search Text changed

        /// <summary>
        /// clear text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            this.GetData();
        }

        /// <summary>
        /// search text changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            da = JobPortal_Services.Jobnature.JobnatureServices.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvJobnature.DataSource = da;
                grvJobnature.DataBind();
                grvJobnature.Visible = true;
            }
            else
            {
                grvJobnature.DataSource = null;
                grvJobnature.DataBind();
            }
            grvJobnature.UseAccessibleHeader = true;
            grvJobnature.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion clear and search Text changed
    }
}