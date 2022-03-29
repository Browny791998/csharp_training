using System;
using System.Data;
using System.Data.SqlClient;

namespace Job_Portal_Management_System.Views.Position
{
    public partial class PositionCreate : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.Position.Position positionmodel = new JobPortal_Models.Position.Position();
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
                lblPosition.Text = "Add Position";
                lblPositionbreadcrumb.Text = "Add Position";
            }
            if (Session["label"] != null)
            {
                string label = Session["label"].ToString();
                if (label == "add")
                {
                    lblPosition.Text = "Add Position";
                    lblPositionbreadcrumb.Text = "Add Position";
                    if (!IsPostBack)
                    {
                    }
                }
                else if (label == "update")
                {
                    lblPosition.Text = "Update Position";
                    lblPositionbreadcrumb.Text = "Update Position";
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(MyCrypto.GetDecryptedQueryString(Request.QueryString["id"]));
                        SqlDataReader dr = JobPortal_Services.Position.PositionServices.ReadData(id);
                        while (dr.Read())
                        {
                            string ID = dr["id"].ToString();
                            string position = dr["position"].ToString();
                            hfPosition.Value = ID;
                            txtPosition.Text = position;
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
            positionmodel.Position_Name = txtPosition.Text;
        }

        #endregion InsertData

        #region UpdateData

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            positionmodel.ID = Convert.ToInt32(hfPosition.Value);
            positionmodel.Position_Name = txtPosition.Text;
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
            if (hfPosition.Value == "")
            {
                da = JobPortal_Services.Position.PositionServices.GetData(txtPosition.Text);
                if (da.Rows.Count > 0)
                {
                    Session["alert"] = "Data already exist";
                    Session["alert-type"] = "warning";
                    Response.Redirect("PositionList.aspx");
                }
                else
                {
                    InsertData();
                    bool success = JobPortal_Services.Position.PositionServices.Insert(positionmodel);
                    if (success)
                    {
                        Session["alert"] = "Added Position Successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("PositionList.aspx");
                        txtPosition.Text = string.Empty;
                    }
                    else
                    {
                        Session["alert"] = "Adding failed. Try again!!";
                        Session["alert-type"] = "danger";
                        Response.Redirect("PositionList.aspx");
                    }
                }
            }
            else
            {
                int positionID = Convert.ToInt32(hfPosition.Value);
                da = JobPortal_Services.Position.PositionServices.GetUpdateData(txtPosition.Text,positionID);
                if (da.Rows.Count>0)
                {
                    UpdateData();
                    bool IsUpdate = JobPortal_Services.Position.PositionServices.Update(positionmodel);
                    if (IsUpdate)
                    {
                        Session["alert"] = "Updated successfully";
                        Session["alert-type"] = "success";
                        Response.Redirect("PositionList.aspx");
                    }
                    else
                    {
                        Session["alert"] = "Updating failed";
                        Session["alert-type"] = "danger";
                        Response.Redirect("PositionList.aspx");
                    }
                }
                else if(da.Rows.Count == 0)
                {
                    da = JobPortal_Services.Position.PositionServices.GetData(txtPosition.Text);
                    if (da.Rows.Count > 0)
                    {
                        Session["alert"] = "Data already exist";
                        Session["alert-type"] = "warning";
                    }
                    else{
                        UpdateData();
                        bool IsUpdate = JobPortal_Services.Position.PositionServices.Update(positionmodel);
                        if (IsUpdate)
                        {
                            Session["alert"] = "Updated successfully";
                            Session["alert-type"] = "success";
                            Response.Redirect("PositionList.aspx");
                        }
                        else
                        {
                            Session["alert"] = "Updating failed";
                            Session["alert-type"] = "danger";
                            Response.Redirect("PositionList.aspx");
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
            txtPosition.Text = string.Empty;
        }

        /// <summary>
        ///  back to list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PositionList.aspx");
        }

        #endregion back and clear
    }
}