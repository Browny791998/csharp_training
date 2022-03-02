using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAOs;
namespace SampleTaskList.Views.Salutation
{
    public partial class SalutationCreate : System.Web.UI.Page
    {

        Models.Salutation.Salutation salutationmodel = new Models.Salutation.Salutation();
        Services.Salutation.SalutationService salutationservice = new Services.Salutation.SalutationService();
        DataTable da = new DataTable();

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

        #region Get Data
        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
          da = Services.Salutation.SalutationService.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvSalutation.DataSource = da;
                grvSalutation.DataBind();
                grvSalutation.Visible = true;
            }
            else
            {
                grvSalutation.DataSource = null;
            }
        }

        #endregion


        /// <summary>
        /// Add Salutation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalutationCreate.aspx");
        }

        /// <summary>
        /// delete salutation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvSalutation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvSalutation.DataKeys[e.RowIndex].Value);
            salutationmodel.ID = id;
            bool IsDelete = Services.Salutation.SalutationService.Delete(salutationmodel);
            if (IsDelete)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Deleted successfully')", true);
                GetData();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Deleting failed')", true);
            }
        }

        /// <summary>
        /// update salutation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvSalutation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(grvSalutation.DataKeys[e.RowIndex].Value);
            Response.Redirect("SalutationEdit.aspx?id=" + id);
        }

        /// <summary>
        /// Search salutation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = Services.Salutation.SalutationService.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvSalutation.DataSource = da;
                grvSalutation.DataBind();
                grvSalutation.Visible = true;
            }
            else
            {
                grvSalutation.DataSource = null;
            }
        }

        /// <summary>
        /// Paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvSalutation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           grvSalutation.PageIndex = e.NewPageIndex;
            this.GetData();
        }
    }
}