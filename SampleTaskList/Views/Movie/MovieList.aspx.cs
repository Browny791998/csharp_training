﻿using System;
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

        #region data bind
        /// <summary>
        /// data bind
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
        #endregion

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


        #region search movie
        /// <summary>
        /// search movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion

        #region movie add,update,delete
        /// <summary>
        /// go to add page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["label"] = "add";
            Response.Redirect("MovieCreate.aspx");
        }

        /// <summary>
        /// deleting movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovie_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvMovie.DataKeys[e.RowIndex].Value);
            moviemodel.ID = id;
            bool IsDelete = Services.Movie.MovieService.Delete(moviemodel);
            if (IsDelete)
            {
                Session["alert"] = "Delete successfully";
                GetData();
            }
            else
            {
                Session["alert"] = "Delete failed";
            }
        }

        /// <summary>
        /// go to update page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovie_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["label"] = "update";
            int id = Convert.ToInt32(grvMovie.DataKeys[e.RowIndex].Value);
            Response.Redirect("MovieCreate.aspx?id=" + id);
        }
        #endregion

        #region paging
        /// <summary>
        /// paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvMovie_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMovie.PageIndex = e.NewPageIndex;
            this.GetData();
        }
        #endregion
    }
}