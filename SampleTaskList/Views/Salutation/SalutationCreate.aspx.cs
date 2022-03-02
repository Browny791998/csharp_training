using System;
using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// Creating Salutation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
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