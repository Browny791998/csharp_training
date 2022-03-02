using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.MovieRenting
{
    public partial class MovieRentingEdit : System.Web.UI.Page
    {
        DataTable da = new DataTable();
        Models.MovieRenting.MovieRent moviemodel = new Models.MovieRenting.MovieRent();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMovie();
                LoadCustomer();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                SqlDataReader dr = Services.MovieRenting.MovieRentService.ReadData(id);
                while (dr.Read())
                {
                    string ID = dr["id"].ToString();
                    int movie_id = Convert.ToInt32(dr["movie_id"].ToString());
                    int customer_id = Convert.ToInt32(dr["customer_id"].ToString());
                    hfMovieRent.Value = ID;
                    ddlMovie.SelectedValue = movie_id.ToString();
                    ddlCustomer.SelectedValue = customer_id.ToString();
                }
            }
        }

        /// <summary>
        /// binding movie list
        /// </summary>
        public void LoadMovie()
        {
            da = Services.Movie.MovieService.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlMovie.DataSource = da;
                ddlMovie.DataValueField = "id";
                ddlMovie.DataTextField = "movie";
                ddlMovie.DataBind();
            }
        }

        /// <summary>
        /// binding customer list
        /// </summary>
        public void LoadCustomer()
        {
            da = Services.Customer.CustomerService.GetAllData();
            if (da.Rows.Count > 0)
            {
                ddlCustomer.DataSource = da;
                ddlCustomer.DataValueField = "id";
                ddlCustomer.DataTextField = "full_name";
                ddlCustomer.DataBind();
            }
        }

        #region UpdateData
        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
          moviemodel.ID = Convert.ToInt32(hfMovieRent.Value);
          moviemodel.MovieID = Convert.ToInt32(ddlMovie.SelectedValue);
          moviemodel.CustomerID = Convert.ToInt32(ddlCustomer.SelectedValue);
        }
        #endregion

        /// <summary>
        /// Updaing movierent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UpdateData();
            bool IsUpdate = Services.MovieRenting.MovieRentService.Update(moviemodel);
            if (IsUpdate)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Updated successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Updating failed')", true);
            }
        }

        /// <summary>
        /// clear form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlMovie.SelectedIndex = -1;
            ddlCustomer.SelectedIndex = -1;
        }

        /// <summary>
        /// back to list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MovieRentingList.aspx");
        }
    }
}