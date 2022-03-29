using System;
using System.Data;
using System.Data.SqlClient;

namespace Job_Portal_Management_System.Views.Jobnature
{
    public partial class JobnatureCreate : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Jobnature.Jobnature jobnaturemodel = new JobPortal_Models.Jobnature.Jobnature();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region binding data and getting data

        /// <summary>
        /// binding data and getting data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "add")
            {
                Session.Remove("label");
                lblJobnature.Text = "Add Job nature";
                lblJobnaturebreadcrumb.Text = "Add Job nature";
            }
            if (Session["label"] != null)
            {
                string label = Session["label"].ToString();
                if (label == "add")
                {
                    lblJobnature.Text = "Add Jobnature";
                    lblJobnaturebreadcrumb.Text = "Add Jobnature";
                    if (!IsPostBack)
                    {
                    }
                }
                else if (label == "update")
                {
                    lblJobnature.Text = "Update Jobnature";
                    lblJobnaturebreadcrumb.Text = "Update Jobnature";
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"]));
                        SqlDataReader dr = JobPortal_Services.Jobnature.JobnatureServices.ReadData(id);
                        while (dr.Read())
                        {
                            string ID = dr["id"].ToString();
                            string jobnature = dr["job_nature"].ToString();
                            hfJobnature.Value = ID;
                            txtJobnature.Text = jobnature;
                        }
                    }
                }
            }
        }

        #endregion binding data and getting data

        #region InsertData

        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
            jobnaturemodel.Job_Nature = txtJobnature.Text;
        }

        #endregion InsertData

        #region UpdateData

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            jobnaturemodel.ID = Convert.ToInt32(hfJobnature.Value);
            jobnaturemodel.Job_Nature = txtJobnature.Text;
        }

        #endregion UpdateData

        #region creating and updating country

        /// <summary>
        /// creating and updating country
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfJobnature.Value == "")
            {
                da = JobPortal_Services.Jobnature.JobnatureServices.GetData(txtJobnature.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already exist";
                    Session["alert-type"] = "warning";
                    Response.Redirect("JobnatureList.aspx");
                }
                else
                {
                    InsertData();
                    bool success = JobPortal_Services.Jobnature.JobnatureServices.Insert(jobnaturemodel);
                    if (success)
                    {
                        Session["alert"] = "Added Country Successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("JobnatureList.aspx");
                        txtJobnature.Text = string.Empty;
                    }
                    else
                    {
                        Session["alert"] = "Adding failed. Try again!!";
                        Session["alert-type"] = "danger";
                        Response.Redirect("JobnatureList.aspx");
                    }
                }
            }
            else
            {
                int JobNatureID=Convert.ToInt32(hfJobnature.Value);
                da = JobPortal_Services.Jobnature.JobnatureServices.GetUpdateData(txtJobnature.Text,JobNatureID);
                if (da.Rows.Count == 0)
                {
                    Session["alert"] = "Data already exist";
                    Session["alert-type"] = "warning";
                    Response.Redirect("JobnatureList.aspx");
                }
                else
                {
                    UpdateData();
                    bool IsUpdate = JobPortal_Services.Jobnature.JobnatureServices.Update(jobnaturemodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = "Updated successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("JobnatureList.aspx");
                    }
                    else
                    {
                        Session["alert"] = "Updating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("JobnatureList.aspx");
                    }
                }
            }
        }

        #endregion creating and updating country

        #region back and clear

        /// <summary>
        /// clear form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtJobnature.Text = string.Empty;
        }

        /// <summary>
        ///  back to list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobnatureList.aspx");
        }

        #endregion back and clear
    }
}