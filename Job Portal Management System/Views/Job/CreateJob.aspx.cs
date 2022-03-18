using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.Job
{
    public partial class CreateJob : System.Web.UI.Page
    {
        JobPortal_Models.Job.Job jobmodel = new JobPortal_Models.Job.Job();
        JobPortal_Services.Job.JobService jobservice = new JobPortal_Services.Job.JobService();
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
           jobmodel.Title = txtTitle.Text;
            jobmodel.Degree = ddlDegree.SelectedValue;
            string strskill = string.Empty;
            foreach (ListItem item in lbSkill.Items)
            {
                if (item.Selected)
                {
                    strskill += item.Text + ",";
                }
            }
            jobmodel.Skill = strskill.Remove(strskill.Length - 1);
            jobmodel.Experience = txtExperience.Text;
            jobmodel.Vacancy = Convert.ToInt32(txtVacancy.Text);
            jobmodel.Company_id = 1;
            jobmodel.Position_id =Convert.ToInt32(ddlPosition.SelectedValue);
            jobmodel.Jobnature_id = Convert.ToInt32(ddlJobtype.SelectedValue);
            jobmodel.Salary = Convert.ToInt32(txtSalary.Text);
            jobmodel.Detail = txtDetail.Text;    
            jobmodel.CreatedDate = DateTime.Now;
            jobmodel.UpdatedDate = DateTime.Now;
        }
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InsertData();
            bool success = JobPortal_Services.Job.JobService.Insert(jobmodel);
            if (success)
            {
                Session["alert"] = "Successfully created";
                Session["alert-type"] = "success";
                ClearFields();
            }
            else
            {
                Session["alert"] = "Failed Creating";
                Session["alert-type"] = "danger";
            }
        }

        private void ClearFields()
        {
            txtTitle.Text = string.Empty;
            ddlDegree.SelectedIndex = -1;
            lbSkill.SelectedIndex = -1;
            txtExperience.Text = string.Empty;
            txtVacancy.Text = string.Empty;
            ddlPosition.SelectedIndex = -1;
            ddlJobtype.SelectedIndex = -1;
            txtSalary.Text = string.Empty;
            txtDetail.Text = string.Empty;

        }
    }
}