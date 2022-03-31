﻿using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using Job_Portal_Management_System.Properties;
namespace Job_Portal_Management_System.Views.Job
{
    public partial class JobList : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Job.Job jobmodel = new JobPortal_Models.Job.Job();
        private JobPortal_Services.Job.JobService jobservice = new JobPortal_Services.Job.JobService();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region bind data

        /// <summary>
        /// bind data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
            }
        }

        #endregion bind data

        #region Get Data

        /// <summary>
        /// Get Data
        /// </summary>
        public void GetData()
        {
            int companyID = Convert.ToInt32(Session["id"]);
            da = JobPortal_Services.Job.JobService.GetAllData(companyID);
            if (da.Rows.Count > 0)
            {
                grvJob.DataSource = da;
                grvJob.DataBind();
                grvJob.Visible = true;
                grvJob.UseAccessibleHeader = true;
                grvJob.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grvJob.DataSource = null;
                grvJob.DataBind();
            }
        }

        #endregion Get Data

        #region delete and update data

        /// <summary>
        /// delete data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvJob_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grvJob.DataKeys[e.RowIndex].Value);
            jobmodel.ID = id;
            bool IsDelete = JobPortal_Services.Job.JobService.Delete(jobmodel);
            if (IsDelete)
            {
                Session["alert"] =Message.I0003;
                Session["alert-type"] = "success";
                GetData();
            }
            else
            {
                Session["alert"] = Message.I0007;
                Session["alert-type"] = "danger";
            }
        }

        /// <summary>
        /// update data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvJob_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["label"] = "update";
            Session.Remove("url");
            int id = Convert.ToInt32(grvJob.DataKeys[e.RowIndex].Value);
            string action = "update";
            string strURL = "CreateJob.aspx?";
            string strURLWithData = strURL +
          EncryptQueryString(string.Format("id={0}&action={1}",id, action));
            HttpContext.Current.Response.Redirect(strURLWithData);
        }

        public string EncryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.Job.JobService.GetSearchData(txtSearch.Text, Convert.ToInt32(Session["id"]));
            if (da.Rows.Count > 0)
            {
                grvJob.DataSource = da;
                grvJob.DataBind();
                grvJob.Visible = true;
            }
            else
            {
                grvJob.DataSource = null;
                grvJob.DataBind();
            }
            grvJob.UseAccessibleHeader = true;
            grvJob.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        #endregion delete and update data

        #region add and clear data

        /// <summary>
        /// add data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateJob.aspx");
        }

        /// <summary>
        /// clear textbox data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            this.GetData();
        }

        #endregion add and clear data

        #region paging

        /// <summary>
        /// pagination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvJob_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvJob.PageIndex = e.NewPageIndex;
            this.GetData();
        }

        #endregion paging
    }
}