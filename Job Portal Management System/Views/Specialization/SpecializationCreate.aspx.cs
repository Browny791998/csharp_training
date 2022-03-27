using System;
using System.Data;
using System.Data.SqlClient;

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
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        SqlDataReader dr = JobPortal_Services.Specialization.SpecializationServices.ReadData(id);
                        while (dr.Read())
                        {
                            string ID = dr["id"].ToString();
                            string specialization = dr["Specialization"].ToString();
                            hfSpecialization.Value = ID;
                            txtSpecialization.Text = specialization;
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
                da = JobPortal_Services.Specialization.SpecializationServices.GetData(txtSpecialization.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already exist";
                    Session["alert-type"] = "warning";
                    Response.Redirect("SpecilizationList.aspx");
                }
                else
                {
                    InsertData();
                    bool success = JobPortal_Services.Specialization.SpecializationServices.Insert(specializationmodel);
                    if (success)
                    {
                        Session["alert"] = "Added Specialization Successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("SpecializationList.aspx");
                        txtSpecialization.Text = string.Empty;
                    }
                    else
                    {
                        Session["alert"] = "Adding failed. Try again!!";
                        Session["alert-type"] = "danger";
                        Response.Redirect("SpecializationList.aspx");
                    }
                }
            }
            else
            {
                da = JobPortal_Services.Specialization.SpecializationServices.GetData(txtSpecialization.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already exist";
                    Session["alert-type"] = "warning";
                    Response.Redirect("SpecializationList.aspx");
                }
                else
                {
                    UpdateData();
                    bool IsUpdate = JobPortal_Services.Specialization.SpecializationServices.Update(specializationmodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = "Updated successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("SpecializationList.aspx");
                    }
                    else
                    {
                        Session["alert"] = "Updating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("SpecializationList.aspx");
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