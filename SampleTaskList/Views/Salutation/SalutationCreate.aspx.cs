using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleTaskList.Views.Salutation
{
    public partial class SalutationCreate1 : System.Web.UI.Page
    {
        Models.Salutation.Salutation salutationmodel = new Models.Salutation.Salutation();
        Services.Salutation.SalutationService salutationservice = new Services.Salutation.SalutationService();
        DataTable da = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["label"] != null)
            {
                string label = Session["label"].ToString();
                if (label == "add")
                {
                    LblSalutation.Text = "Add Salutation";
                }
                else if (label == "update")
                {
                    LblSalutation.Text = "Update Salutation";
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        Services.Salutation.SalutationService salutationservice = new Services.Salutation.SalutationService();
                        SqlDataReader dr = Services.Salutation.SalutationService.ReadData(id);
                        while (dr.Read())
                        {
                            string ID = dr["id"].ToString();
                            string name = dr["salutation"].ToString();
                            txtSalutation.Text = name;
                            hfSalutation.Value = ID;
                        }
                    }
                }
            }
        }

        #region InsertData
        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
            salutationmodel.SALUTATION= txtSalutation.Text;
        }
        #endregion


        #region UpdateData
        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            salutationmodel.ID = Convert.ToInt32(hfSalutation.Value);
            salutationmodel.SALUTATION = txtSalutation.Text;

        }
        #endregion

        /// <summary>
        /// Creating Salutation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hfSalutation.Value == "")
            {
                da = Services.Salutation.SalutationService.GetData(txtSalutation.Text);
                if (da.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Data already existed')", true);
                }
                else
                {
                    InsertData();
                    bool success = Services.Salutation.SalutationService.Insert(salutationmodel);
                    if (success)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Created successfully')", true);
                        txtSalutation.Text = string.Empty;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Creating Failed')", true);
                    }
                }

            }
            else
            {
                UpdateData();
                bool IsUpdate = Services.Salutation.SalutationService.Update(salutationmodel);
                if (IsUpdate)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Updated successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Updating failed')", true);
                }
            }
        }

        /// <summary>
        /// clear form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSalutation.Text = string.Empty;
        }

        /// <summary>
        /// back to list page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalutationList.aspx");
        }
    }
}