using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.MovieRenting
{
    public partial class MovieRentingList : System.Web.UI.Page
    {
        Models.MovieRenting.MovieRent movierentmodel = new Models.MovieRenting.MovieRent();
        Services.MovieRenting.MovieRentService movierentservice = new Services.MovieRenting.MovieRentService();
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

        /// <summary>
        /// go to creat page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("MovieRentingCreate.aspx");
        }

        #region Get Data
        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
            da = Services.MovieRenting.MovieRentService.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvMovieRent.DataSource = da;
                grvMovieRent.DataBind();
                grvMovieRent.Visible = true;
            }
            else
            {
                grvMovieRent.DataSource = null;
            }
        }

        #endregion

        /// <summary>
        /// search movierent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = Services.MovieRenting.MovieRentService.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvMovieRent.DataSource = da;
                grvMovieRent.DataBind();
                grvMovieRent.Visible = true;
            }
            else
            {
                grvMovieRent.DataSource = null;
            }
        }

        /// <summary>
        /// delet movierent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovieRent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvMovieRent.DataKeys[e.RowIndex].Value);
            movierentmodel.ID = id;
            bool IsDelete = Services.MovieRenting.MovieRentService.Delete(movierentmodel);
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
        /// go to update  page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovieRent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(grvMovieRent.DataKeys[e.RowIndex].Value);
            Response.Redirect("MovieRentingEdit.aspx?id=" + id);
        }

        /// <summary>
        /// paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovieRent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMovieRent.PageIndex = e.NewPageIndex;
            this.GetData();
        }
    }
}