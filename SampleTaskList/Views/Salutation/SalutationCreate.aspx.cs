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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertData();
            bool success = Services.Salutation.SalutationService.Insert(salutationmodel);
            if (success)
            {
                Response.Redirect("~/Views/Salutation/SalutationList", true);

            }
            else
            {
                Response.Write("added failed");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSalutation.Text = string.Empty;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalutationList.aspx");
        }
    }
}