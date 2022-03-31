using System;
using System.Data;
using System.Data.SqlClient;
using Job_Portal_Management_System.Properties;
namespace Job_Portal_Management_System.Views.Specialization
{
    public partial class SpecializationCreate : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Specialization.Specialization specializationmodel = new JobPortal_Models.Specialization.Specialization();
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
                lblSpecialization.Text = "Add Specialization";
                lblSpecializationbreadcrumb.Text = "Add Specialization";
            }
            if (Session["label"] != null)
            {
                string label = Session["label"].ToString();
                if (label == "add")
                {
                    lblSpecialization.Text = "Add Specialization";
                    lblSpecializationbreadcrumb.Text = "Add Specialization";
                    if (!IsPostBack)
                    {
                    }
                }
                else if (label == "update")
                {
                    lblSpecialization.Text = "Update Specialization";
                    lblSpecializationbreadcrumb.Text = "Update Specialization";
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
                            SqlDataReader dr = JobPortal_Services.Specialization.SpecializationServices.ReadData(id);
                            while (dr.Read())
                            {
                                string ID = dr["id"].ToString();
                                string specialization = dr["Specialization"].ToString();
                                hfSpecialization.Value = ID;
                                txtSpecialization.Text = specialization;
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
            specializationmodel.Specialization_Name = txtSpecialization.Text;
        }

        #endregion InsertData

        #region UpdateData

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            specializationmodel.ID = Convert.ToInt32(hfSpecialization.Value);
            specializationmodel.Specialization_Name = txtSpecialization.Text;
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
            if (hfSpecialization.Value == "")
            {
                da = JobPortal_Services.Specialization.SpecializationServices.GetAddData(txtSpecialization.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = Message.I0004;
                    Session["alert-type"] = "warning";
                }
                else
                {
                    InsertData();
                    bool success = JobPortal_Services.Specialization.SpecializationServices.Insert(specializationmodel);
                    if (success)
                    {
                        Session["alert"] = Message.I0001;
                        Session["alert-type"] = "success";
                        Response.Redirect("SpecializationList.aspx");
                        txtSpecialization.Text = string.Empty;
                    }
                    else
                    {
                        Session["alert"] = Message.I0005;
                        Session["alert-type"] = "danger";
                        Response.Redirect("SpecializationList.aspx");
                    }
                }
            }
            else
            {
                int specializationID = Convert.ToInt32(hfSpecialization.Value);
                da = JobPortal_Services.Specialization.SpecializationServices.GetUpdateData(txtSpecialization.Text, specializationID);
                if (da.Rows.Count > 0)
                {
                    UpdateData();
                    bool IsUpdate = JobPortal_Services.Specialization.SpecializationServices.Update(specializationmodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = Message.I0002;
                        Session["alert-type"] = "success";
                        Response.Redirect("SpecializationList.aspx");
                    }
                    else
                    {
                        Session["alert"] = Message.I0006;
                        Session["alert-type"] = "danger";
                        Response.Redirect("SpecializationList.aspx");
                    }
                }
                else if (da.Rows.Count == 0)
                {
                    da = JobPortal_Services.Specialization.SpecializationServices.GetAddData(txtSpecialization.Text);
                    if (da.Rows.Count > 0)
                    {
                        Session["alert"] = Message.I0004;
                        Session["alert-type"] = "warning";
                    }
                    else
                    {
                        UpdateData();
                        bool IsUpdate = JobPortal_Services.Specialization.SpecializationServices.Update(specializationmodel);
                        if (IsUpdate)
                        {
                            Session["alert"] = Message.I0002;
                            Session["alert-type"] = "success";
                            Response.Redirect("SpecializationList.aspx");
                        }
                        else
                        {
                            Session["alert"] = Message.I0006;
                            Session["alert-type"] = "danger";
                            Response.Redirect("SpecializationList.aspx");
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
            txtSpecialization.Text = string.Empty;
        }

        /// <summary>
        ///  back to list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SpecializationList.aspx");
        }

        #endregion back and clear
    }
}