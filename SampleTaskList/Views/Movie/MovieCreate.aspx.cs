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
    public partial class MovieCreate : System.Web.UI.Page
    {
        Models.Movie.Movie moviemodel = new Models.Movie.Movie();
        Services.Movie.MovieService movieservice = new Services.Movie.MovieService();
        DataTable da = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["label"] != null)
            {
                string label = Session["label"].ToString();
                if (label == "add")
                {
                    lblMovie.Text = "Add Movie";
                }
                else if (label == "update")
                {
                    lblMovie.Text = "Update Movie";
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        Services.Movie.MovieService movieservice = new Services.Movie.MovieService();
                        SqlDataReader dr = Services.Movie.MovieService.ReadData(id);
                        while (dr.Read())
                        {
                            string ID = dr["id"].ToString();
                            string movie = dr["movie"].ToString();
                            txtMovie.Text = movie;
                            hfMovie.Value = ID;
                        }
                    }
                }
            }
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

        #region UpdateData
        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            moviemodel.ID = Convert.ToInt32(hfMovie.Value);
            moviemodel.MOVIE = txtMovie.Text;
        }
        #endregion

        /// <summary>
        /// creating movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfMovie.Value == "")
            {
                da = Services.Movie.MovieService.GetData(txtMovie.Text);
                if (da.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Data already existed')", true);
                }
                else
                {
                    InsertData();
                    bool success = Services.Movie.MovieService.Insert(moviemodel);
                    if (success)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Created successfully')", true);
                        txtMovie.Text = string.Empty;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Creating failed')", true);
                    }
                }
            }
            else
            {
                UpdateData();
                bool IsUpdate = Services.Movie.MovieService.Update(moviemodel);
                if (IsUpdate)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Updated successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Updating failed')", true);
                }
            }
        }

        /// <summary>
        /// clear form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtMovie.Text = string.Empty;
        }

        /// <summary>
        /// back to list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MovieList.aspx");
        }
    }
}