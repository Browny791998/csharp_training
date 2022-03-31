using System;
using System.Data;
using System.Data.SqlClient;
using Job_Portal_Management_System.Properties;
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
                        string strReq = "";
                        strReq = Request.RawUrl;
                        strReq = strReq.Substring(strReq.IndexOf('?') + 1);
                        if (Session["url"] == null)
                        {
                            Session["url"] = strReq;
                        }
                        else if (strReq != Session["url"].ToString())
                        {
                            Session["alert"] = Message.I0009;
                            Session["alert-type"] = "warning";
                            strReq = Session["url"].ToString();
                        }
                        if (!strReq.Equals(""))
                        {
                            strReq = DecryptQueryString(strReq);
                            string[] arrMsgs = strReq.Split('&');
                            string[] arrIndMsg;
                            string CID = "";
                            arrIndMsg = arrMsgs[0].Split('=');
                            CID = arrIndMsg[1].ToString().Trim();
                            int id = Convert.ToInt32(CID);
                            SqlDataReader dr = JobPortal_Services.Jobnature.JobnatureServices.ReadData(id);
                            while (dr.Read())
                            {
                                string ID = dr["id"].ToString();
                                string jobnature = dr["job_nature"].ToString();
                                hfJobnature.Value = ID;
                                txtJobnature.Text = jobnature;
                            }
                        }
                        else
                        {
                            Session["alert"] = Message.I0009;
                            Session["alert-type"] = "warning";
                        }
                    }
                }
            }
        }

            private string DecryptQueryString(string strQueryString)
            {
                EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
                return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
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
                da = JobPortal_Services.Jobnature.JobnatureServices.GetAddData(txtJobnature.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = Message.I0004;
                    Session["alert-type"] = "warning";
                }
                else
                {
                    InsertData();
                    bool success = JobPortal_Services.Jobnature.JobnatureServices.Insert(jobnaturemodel);
                    if (success)
                    {
                        Session["alert"] = Message.I0001;
                        Session["alert-type"] = "success";
                        Response.Redirect("JobnatureList.aspx");
                        txtJobnature.Text = string.Empty;
                    }
                    else
                    {
                        Session["alert"] = Message.I0005;
                        Session["alert-type"] = "danger";
                        Response.Redirect("JobnatureList.aspx");
                    }
                }
            }
            else
            {
                int JobNatureID = Convert.ToInt32(hfJobnature.Value);
                da = JobPortal_Services.Jobnature.JobnatureServices.GetUpdateData(txtJobnature.Text, JobNatureID);
                if (da.Rows.Count > 0)
                {
                    UpdateData();
                    bool IsUpdate = JobPortal_Services.Jobnature.JobnatureServices.Update(jobnaturemodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = Message.I0002;
                        Session["alert-type"] = "success";
                        Response.Redirect("JobnatureList.aspx");
                    }
                    else
                    {
                        Session["alert"] = Message.I0006;
                        Session["alert-type"] = "danger";
                        Response.Redirect("JobnatureList.aspx");
                    }
                }
                else if (da.Rows.Count == 0)
                {
                    da = JobPortal_Services.Jobnature.JobnatureServices.GetAddData(txtJobnature.Text);
                    if (da.Rows.Count > 0)
                    {
                        Session["alert"] = Message.I0004;
                        Session["alert-type"] = "warning";
                    }
                    else
                    {
                        UpdateData();
                        bool IsUpdate = JobPortal_Services.Jobnature.JobnatureServices.Update(jobnaturemodel);
                        if (IsUpdate)
                        {
                            Session["alert"] = Message.I0002;
                            Session["alert-type"] = "success";
                            Response.Redirect("JobnatureList.aspx");
                        }
                        else
                        {
                            Session["alert"] = Message.I0006;
                            Session["alert-type"] = "danger";
                            Response.Redirect("JobnatureList.aspx");
                        }
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