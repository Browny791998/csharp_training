using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.Movie
{
    public partial class MovieCreate : System.Web.UI.Page
    {
        Models.Movie.Movie moviemodel = new Models.Movie.Movie();
        Services.Movie.MovieService movieservice = new Services.Movie.MovieService();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region InsertData
        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
           moviemodel.MOVIE = txtMovie.Text;

        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertData();
            bool success = Services.Movie.MovieService.Insert(moviemodel);
            if (success)
            {
                Response.Redirect("~/Views/Movie/MovieList", true);

            }
            else
            {
                Response.Write("added failed");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtMovie.Text = string.Empty;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MovieList.aspx");
        }
    }
}