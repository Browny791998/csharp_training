using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.Movie
{
    public partial class MovieEdit : System.Web.UI.Page
    {
        Models.Movie.Movie moviemodel = new Models.Movie.Movie();

        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Services.Movie.MovieService movieservice = new Services.Movie.MovieService();
                SqlDataReader dr = Services.Movie.MovieService.ReadData(id);
                while (dr.Read())
                {
                    string ID = dr["id"].ToString();
                    string movie = dr["movie"].ToString();
                    txtMovie.Text =movie;
                    hfMovie.Value = ID;
                }
            }
        }

        #region UpdateData
        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            moviemodel.ID = Convert.ToInt32(hfMovie.Value);
            moviemodel.MOVIE= txtMovie.Text;

        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UpdateData();
            bool IsUpdate = Services.Movie.MovieService.Update(moviemodel);
            if (IsUpdate)
            {
                Response.Write("Updated successfully");
            }
            else
            {
                Response.Write("Updating failed");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtMovie.Text = string.Empty;
        }

        protected void btn_Back(object sender, EventArgs e)
        {
            Response.Redirect("MovieList.aspx");
        }
    }
}