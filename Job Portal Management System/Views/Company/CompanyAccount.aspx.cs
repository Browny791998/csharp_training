using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Company
{
    public partial class CompanyAccount : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Services.Company.CompanyService companyservice = new JobPortal_Services.Company.CompanyService();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region bind data

        /// <summary>
        /// page load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
           GetAcc();
        }

        /// <summary>
        /// binding data
        /// </summary>
        public void GetAcc()
        {
            int id = Convert.ToInt32(Session["id"]);
            da = JobPortal_Services.Company.CompanyService.GetAllData(id);
            rptCompany.DataSource = da;
            rptCompany.DataBind();
        }

        #endregion bind data

        #region edit data

        /// <summary>
        /// edit company data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Session.Remove("url");
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var IdValue = ((Label)item.FindControl("companyId")).Text;
            string strURL = "CompanyEdit.aspx?";
            string strURLWithData = strURL + EncryptQueryString(string.Format("id={0}", IdValue));
            HttpContext.Current.Response.Redirect(strURLWithData);
        }

        public string EncryptQueryString(string strQueryString)
        {
            EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
        }

        #endregion edit data
    }
}