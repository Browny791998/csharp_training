using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (Session["label"] != null)
            {
                string label = Session["label"].ToString();
                if (label == "add")
                {
                    lblCountry.Text = "Add Country";
                    if (!IsPostBack)
                    {
                    }
                }
                else if (label == "update")
                {
                    lblCountry.Text = "Update Country";
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        SqlDataReader dr = JobPortal_Services.Country.CountryServices.ReadData(id);
                        while (dr.Read())
                        {
                            string ID = dr["id"].ToString();
                            string country = dr["country"].ToString();
                            hfCountry.Value = ID;
                            txtCountry.Text = country;
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfCountry.Value == "")
            {
                da = JobPortal_Services.Country.CountryServices.GetData(txtCountry.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already exist";
                    Session["alert-type"] = "warning";
                    Response.Redirect("CountryList.aspx");
                }
                else
                {
                    InsertData();
                    bool success = JobPortal_Services.Country.CountryServices.Insert(countrymodel);
                    if (success)
                    {
                        Session["alert"] = "Added Country Successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("CountryList.aspx");
                        txtCountry.Text = string.Empty;
                    }
                    else
                    {
                        Session["alert"] = "Adding failed. Try again!!";
                        Session["alert-type"] = "danger";
                        Response.Redirect("CountryList.aspx");
                    }
                }
            }
            else
            {
                da = JobPortal_Services.Country.CountryServices.GetData(txtCountry.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already exist";
                    Session["alert-type"] = "warning";
                    Response.Redirect("CountryList.aspx");
                }
                else
                {
                    UpdateData();
                    bool IsUpdate = JobPortal_Services.Country.CountryServices.Update(countrymodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = "Updated successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("CountryList.aspx");
                    }
                    else
                    {
                        Session["alert"] = "Updating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("CountryList.aspx");
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