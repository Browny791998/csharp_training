using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.JobSeeker
{
    public partial class RegisterJobSeeker : System.Web.UI.Page
    {
        
      JobPortal_Models.JobSeeker.JobSeeker jobseekermodel = new JobPortal_Models.JobSeeker.JobSeeker();
        JobPortal_Services.JobSeeker.JobSeekerService jobseekerservice = new JobPortal_Services.JobSeeker.JobSeekerService();
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
            jobseekermodel.Name = txtName.Text;
            jobseekermodel.Address = txtAddress.Text;
            jobseekermodel.Mobile = Convert.ToInt32(txtMobile.Text);
            jobseekermodel.Gender = ddlgender.SelectedValue;
            jobseekermodel.DOB = Convert.ToDateTime(txtDate.Text);
            string strskill = string.Empty;
            foreach (ListItem item in lbSkill.Items)
            {
                if (item.Selected)
                {
                    strskill += item.Text + ",";
                }
            }
            jobseekermodel.Skill = strskill.Remove(strskill.Length - 1);
            jobseekermodel.Experience = txtExperience.Text;
            jobseekermodel.Degree = ddlDegree.SelectedValue;
            if(txtDegree.Text == string.Empty)
            {
                txtDegree.Text = "Student";
            }
            jobseekermodel.DegreeName = txtDegree.Text;
            fuCV.SaveAs(Server.MapPath("~/CV/") + Path.GetFileName(fuCV.FileName));
            string cvform = "CV/" + Path.GetFileName(fuCV.FileName);
            jobseekermodel.CVForm = cvform;
          fuProfile.SaveAs(Server.MapPath("~/Profile/") + Path.GetFileName(fuProfile.FileName));
            string image = "~/Profile/" + Path.GetFileName(fuProfile.FileName);
            jobseekermodel.Profile = image;
            jobseekermodel.Email = txtEmail.Text;
            jobseekermodel.Password = txtPassword.Text;
            jobseekermodel.Detail = txtDetail.Text;
            jobseekermodel.Role = "Job Seeker";
            jobseekermodel.CreatedDate = DateTime.Now;
            jobseekermodel.UpdatedDate = DateTime.Now;

        }
        #endregion


        protected void ddlDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDegree.SelectedItem.Value == "Graduate")
            {
                pnldegree.Visible = true;
            }
            else
            {
                pnldegree.Visible = false;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            da =JobPortal_Services.JobSeeker.JobSeekerService.GetData(txtEmail.Text);
            if (da.Rows.Count > 0)
            {
                Session["alert"] = "Data already exist";
                Session["alert-type"] = "warning";
            }
            else
            {
                InsertData();
                bool success = JobPortal_Services.JobSeeker.JobSeekerService.Insert(jobseekermodel);
                if (success)
                {
                    Session["alert"] = "Successfully registered";
                    Session["alert-type"] = "success";
                }
                else
                {
                    Session["alert"] = "Failed registering";
                    Session["alert-type"] = "danger";
                }
            }
           
        }
    }
}