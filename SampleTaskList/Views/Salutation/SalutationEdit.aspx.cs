using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
namespace SampleTaskList.Views.Salutation
{
    public partial class SalutationEdit : System.Web.UI.Page
    {

        Models.Salutation.Salutation salutationmodel = new Models.Salutation.Salutation();
        
        DataTable da = new DataTable();
       
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Services.Salutation.SalutationService salutationservice = new Services.Salutation.SalutationService();
                 SqlDataReader dr =Services.Salutation.SalutationService.ReadData(id);
                while (dr.Read())
                {
                    string ID = dr["id"].ToString();
                    string name = dr["salutation"].ToString();
                    txtSalutation.Text = name;
                    hfSalutation.Value = ID;
                }
            }
        }

        #region UpdateData
        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            salutationmodel.ID =Convert.ToInt32(hfSalutation.Value);
            salutationmodel.SALUTATION = txtSalutation.Text;

        }
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UpdateData();
            bool IsUpdate = Services.Salutation.SalutationService.Update(salutationmodel);
            if (IsUpdate)
            {
                Response.Write("Updated successfully");
            }
            else
            {
                Response.Write("Updating failed");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSalutation.Text = string.Empty;
        }

        protected void btn_Back(object sender, EventArgs e)
        {
            Response.Redirect("SalutationList.aspx");
        }
    }
}