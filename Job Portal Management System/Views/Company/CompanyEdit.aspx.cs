﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Company
{
    public partial class CompanyEdit : System.Web.UI.Page
    {
        JobPortal_Models.Company.Company companymodel = new JobPortal_Models.Company.Company();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                SqlDataReader dr = JobPortal_Services.Company.CompanyService.ReadData(id);
                while (dr.Read())
                {
                    txtName.Text = dr["name"].ToString();
                    ddlCountry.SelectedValue = dr["country_id"].ToString();
                    txtAddress.Text = dr["address"].ToString();
                    txtContactPerson.Text= dr["contact_person"].ToString();
                    txtMobile.Text= dr["mobile"].ToString();
                    txtWebsite.Text = dr["website"].ToString();
                    txtDetail.Text = dr["detail"].ToString();
                }
            }
        }


        #region UpdateData
        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
        companymodel.ID = Convert.ToInt32(Request.QueryString["ID"]);
            companymodel.Name = txtName.Text;
            companymodel.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            companymodel.Address = txtAddress.Text;
            companymodel.ContactPerson = txtContactPerson.Text;
            companymodel.Mobile = Convert.ToInt32(txtMobile.Text);
            companymodel.Website = txtWebsite.Text;
            companymodel.Detail = txtDetail.Text;
            companymodel.UpdatedDate = DateTime.Now;
        }
        #endregion
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
            bool IsUpdate = JobPortal_Services.Company.CompanyService.Update(companymodel);
            if (IsUpdate)
            {
                Session["alert"] = "Successfully updated your company information";
                Session["alert-type"] = "success";
            }
            else
            {
                Session["alert"] = "failed to update  your company information";
                Session["alert-type"] = "danger";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Text = string.Empty;
            ddlCountry.SelectedIndex = -1;
            txtAddress.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            txtDetail.Text = string.Empty;

        }
    }
}