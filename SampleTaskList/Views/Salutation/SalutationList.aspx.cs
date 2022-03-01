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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalutationCreate.aspx");
        }

        protected void grvSalutation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvSalutation.DataKeys[e.RowIndex].Value);
            salutationmodel.ID = id;
            bool IsDelete = Services.Salutation.SalutationService.Delete(salutationmodel);
            if (IsDelete)
            {
                Response.Write("Deleting suuccessfully");
                GetData();
            }
            else
            {
                Response.Write("Deleting failed");
            }
        }

        protected void grvSalutation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(grvSalutation.DataKeys[e.RowIndex].Value);
            Response.Redirect("SalutationEdit.aspx?id=" + id);
        }

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
    }
}