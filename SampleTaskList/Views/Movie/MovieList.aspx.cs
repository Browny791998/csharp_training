using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.Movie
{
    public partial class MovieList : System.Web.UI.Page
    {
        Models.Movie.Movie moviemodel = new Models.Movie.Movie();
        Services.Movie.MovieService movieservice = new Services.Movie.MovieService();
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
            da = Services.Movie.MovieService.GetAllData();
            if (da.Rows.Count > 0)
            {
                grvMovie.DataSource = da;
                grvMovie.DataBind();
                grvMovie.Visible = true;
            }
            else
            {
                grvMovie.DataSource = null;
            }
        }

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("MovieCreate.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
             da = Services.Movie.MovieService.GetSearchData(txtSearch.Text);
            if (da.Rows.Count > 0)
            {
                grvMovie.DataSource = da;
                grvMovie.DataBind();
                grvMovie.Visible = true;
            }
            else
            {
                grvMovie.DataSource = null;
            }
        }

        protected void grvMovie_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvMovie.DataKeys[e.RowIndex].Value);
            moviemodel.ID = id;
            bool IsDelete = Services.Movie.MovieService.Delete(moviemodel);
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

        protected void grvMovie_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(grvMovie.DataKeys[e.RowIndex].Value);
            Response.Redirect("MovieEdit.aspx?id=" + id);
        }
    }
}