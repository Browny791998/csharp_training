using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Specialization
{
    public partial class SpecializationList : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Specialization.Specialization specializationmodel = new JobPortal_Models.Specialization.Specialization();
        private JobPortal_Services.Specialization.SpecializationServices specializationservice = new JobPortal_Services.Specialization.SpecializationServices();
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
            da = JobPortal_Services.Specialization.SpecializationServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvSpecialization.DataSource = da;
                grvSpecialization.DataBind();
                grvSpecialization.Visible = true;
            }
            else
            {
                grvSpecialization.DataSource = null;
                grvSpecialization.DataBind();
            }
            grvSpecialization.UseAccessibleHeader = true;
            grvSpecialization.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion Get Data

        #region specialization add,update,delete

        /// <summary>
        /// go to add page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["label"] = "add";
            Response.Redirect("SpecializationCreate.aspx");
        }

        /// <summary>
        /// go to update page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvSpecialization_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["label"] = "update";
            int id = Convert.ToInt32(grvSpecialization.DataKeys[e.RowIndex].Value);
            Response.Redirect("SpecializationCreate.aspx?id=" + id);
        }

        /// <summary>
        /// deleting customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvSpecialization_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int mid;
            int id = Convert.ToInt32(grvSpecialization.DataKeys[e.RowIndex].Value);
            da = JobPortal_Services.Specialization.SpecializationServices.GetAllData();
            //for (int j = 0; j < da.Rows.Count; j++)
            //{
            //    mid = Convert.ToInt32(da.Rows[j]["id"]);
            //    if (mid == id)
            //    {
            //        Session["alert"] = "Data Exist You can't delete this";
            //        Session["alert-type"] = "warning";
            //        GetData();
            //        return;
            //    }
            //}
            specializationmodel.ID = id;
            bool IsDelete = JobPortal_Services.Specialization.SpecializationServices.Delete(specializationmodel);
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

        #endregion specialization add,update,delete

        #region search specialization

        /// <summary>
        /// search customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.Specialization.SpecializationServices.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvSpecialization.DataSource = da;
                grvSpecialization.DataBind();
                grvSpecialization.Visible = true;
            }
            else
            {
                grvSpecialization.DataSource = null;
                grvSpecialization.DataBind();
            }
            grvSpecialization.UseAccessibleHeader = true;
            grvSpecialization.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion search specialization

        #region paging

        /// <summary>
        /// paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvSpecialization_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSpecialization.PageIndex = e.NewPageIndex;
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
            da = JobPortal_Services.Specialization.SpecializationServices.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvSpecialization.DataSource = da;
                grvSpecialization.DataBind();
                grvSpecialization.Visible = true;
            }
            else
            {
                grvSpecialization.DataSource = null;
                grvSpecialization.DataBind();
            }
            grvSpecialization.UseAccessibleHeader = true;
            grvSpecialization.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion clear and search Text changed
    }
}