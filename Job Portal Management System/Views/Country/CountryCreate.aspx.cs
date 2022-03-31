using System;
using System.Data;
using System.Data.SqlClient;
using Job_Portal_Management_System.Properties;
namespace Job_Portal_Management_System.Views.Country
{
    public partial class CountryCreate : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Country.Country countrymodel = new JobPortal_Models.Country.Country();
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
                lblCountry.Text = "Add Country";
                lblCountrybreadcrumb.Text = "Add Country";
            }
            if (Session["label"] != null)
            {
                string label = Session["label"].ToString();
                if (label == "add")
                {
                    lblCountry.Text = "Add Country";
                    lblCountrybreadcrumb.Text = "Add Country";
                    if (!IsPostBack)
                    {
                    }
                }
                else if (label == "update")
                {
                    lblCountry.Text = "Update Country";
                    lblCountrybreadcrumb.Text = "Update Country";
                    if (!IsPostBack)
                    {
                        string strReq = "";
                        strReq = Request.RawUrl;
                        strReq = strReq.Substring(strReq.IndexOf('?') + 1);
                        if(Session["url"] == null)
                        {
                            Session["url"] = strReq;
                        }
                        else if(strReq != Session["url"].ToString())
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
                            SqlDataReader dr = JobPortal_Services.Country.CountryServices.ReadData(id);
                            while (dr.Read())
                            {
                                string ID = dr["id"].ToString();
                                string country = dr["country"].ToString();
                                hfCountry.Value = ID;
                                txtCountry.Text = country;
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
            countrymodel.Country_Name = txtCountry.Text;
        }

        #endregion InsertData

        #region UpdateData

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            countrymodel.ID = Convert.ToInt32(hfCountry.Value);
            countrymodel.Country_Name = txtCountry.Text;
        }

        #endregion UpdateData

        #region creating and updating country

        /// <summary>
        /// creating and updating country
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfCountry.Value == "")
            {
                da = JobPortal_Services.Country.CountryServices.GetAddData(txtCountry.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = Message.I0004;
                    Session["alert-type"] = "warning";
                }
                else
                {
                    InsertData();
                    bool success = JobPortal_Services.Country.CountryServices.Insert(countrymodel);
                    if (success)
                    {
                        Session["alert"] = Message.I0001;
                        Session["alert-type"] = "success";
                        Response.Redirect("CountryList.aspx");
                        txtCountry.Text = string.Empty;
                    }
                    else
                    {
                        Session["alert"] = Message.I0005;
                        Session["alert-type"] = "danger";
                        Response.Redirect("CountryList.aspx");
                    }
                }
            }
            else
            {
                int CountryID =Convert.ToInt32(hfCountry.Value);
                da = JobPortal_Services.Country.CountryServices.GetUpdateData(txtCountry.Text, CountryID);
                if (da.Rows.Count > 0)
                {
                    UpdateData();
                    bool IsUpdate = JobPortal_Services.Country.CountryServices.Update(countrymodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = Message.I0002;
                        Session["alert-type"] = "success";
                        Response.Redirect("CountryList.aspx");
                    }
                    else
                    {
                        Session["alert"] = Message.I0006;
                        Session["alert-type"] = "danger";
                        Response.Redirect("CountryList.aspx");
                    }
                }
                else if (da.Rows.Count == 0)
                {
                    da = JobPortal_Services.Country.CountryServices.GetAddData(txtCountry.Text);
                    if (da.Rows.Count > 0)
                    {
                        Session["alert"] = Message.I0004;
                        Session["alert-type"] = "warning";
                    }
                    else
                    {
                        UpdateData();
                        bool IsUpdate = JobPortal_Services.Country.CountryServices.Update(countrymodel);
                        if (IsUpdate)
                        {
                            Session["alert"] = Message.I0002;
                            Session["alert-type"] = "success";
                            Response.Redirect("CountryList.aspx");
                        }
                        else
                        {
                            Session["alert"] = Message.I0006;
                            Session["alert-type"] = "danger";
                            Response.Redirect("CountryList.aspx");
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
            txtCountry.Text = string.Empty;
        }

        /// <summary>
        ///  back to list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CountryList.aspx");
        }

        #endregion back and clear
    }
}