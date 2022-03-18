using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Company
{
    public partial class CompanyAccount : System.Web.UI.Page
    {
        JobPortal_Services.Company.CompanyService companyservice = new JobPortal_Services.Company.CompanyService();
        DataTable da = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAcc();
        }
        public void GetAcc()
        {
            int id = Convert.ToInt32(Session["id"]);
            da = JobPortal_Services.Company.CompanyService.GetAllData(id);
           rptCompany.DataSource = da;
            rptCompany.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var IdValue = ((Label)item.FindControl("companyId")).Text;

            Response.Redirect("CompanyEdit.aspx?ID=" + IdValue);
        }
    }
}