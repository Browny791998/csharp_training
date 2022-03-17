using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.JobSeeker
{
    public partial class JobSeekerEdit : System.Web.UI.Page
    {
       JobPortal_Models.JobSeeker.JobSeeker jobseekermodel = new JobPortal_Models.JobSeeker.JobSeeker();
        DataTable da = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                SqlDataReader dr = JobPortal_Services.JobSeeker.JobSeekerService.ReadData(id);
                while (dr.Read())
                {
                    txtName.Text = dr["name"].ToString();
                    txtAddress.Text = dr["address"].ToString();
                    txtMobile.Text = dr["mobile"].ToString();
                    ddlgender.SelectedValue = dr["gender"].ToString();
                    txtDate.Text= (Convert.ToDateTime(dr["dob"]).ToString("yyyy-MM-dd")); 
                    string skills = dr["skill"].ToString();
                    string[] skillList = skills.Split(',');
                    foreach (string s in skillList)
                    {
                        foreach (ListItem item in lbSkill.Items)
                        {
                            if (s == item.Text)
                            {
                                item.Selected = true;
                            }
                        }
                    }
                    hfCV.Value = dr["cvform"].ToString();
                    currentimg.ImageUrl= dr["profile"].ToString();
                    txtExperience.Text = dr["experience"].ToString();
                    ddlDegree.SelectedValue = dr["degree"].ToString();
                    txtDegree.Text = dr["degree_name"].ToString();
                    txtDetail.Text = dr["detail"].ToString();
                }
            }
        }

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

        #region UpdateData
        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            jobseekermodel.ID = Convert.ToInt32(Request.QueryString["ID"]);
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
            if (txtDegree.Text == string.Empty)
            {
                txtDegree.Text = "Student";
            }
            jobseekermodel.DegreeName = txtDegree.Text;
            if (!fuCV.HasFile)
            {
                jobseekermodel.CVForm = hfCV.Value;
            }
            else
            {
                string cvpath = Server.MapPath(hfCV.Value);
                FileInfo file = new FileInfo(cvpath);
                if (file.Exists)
                {
                    file.Delete();
                }
                fuCV.SaveAs(Server.MapPath("~/CV/") + Path.GetFileName(fuCV.FileName));
                string cvform = "~/CV/" + Path.GetFileName(fuCV.FileName);
                jobseekermodel.CVForm = cvform;
            }
           
            if (!fuProfile.HasFile)
            {
                jobseekermodel.Profile = currentimg.ImageUrl;
            }
            else
            {
                string currentpath= Server.MapPath(currentimg.ImageUrl);
                FileInfo file = new FileInfo(currentpath);
                if (file.Exists)
                {
                    file.Delete();
                }
                fuProfile.SaveAs(Server.MapPath("~/Profile/") + Path.GetFileName(fuProfile.FileName));
                string image = "~/Profile/" + Path.GetFileName(fuProfile.FileName);
                jobseekermodel.Profile = image;
            }
            jobseekermodel.Detail = txtDetail.Text;
            jobseekermodel.UpdatedDate = DateTime.Now;
         
        }
        #endregion

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
            bool IsUpdate = JobPortal_Services.JobSeeker.JobSeekerService.Update(jobseekermodel);
            if (IsUpdate)
            {
                Session["alert"] = "Successfully updated your profile";
                Session["alert-type"] = "success";
            }
            else
            {
                Session["alert"] = "failed to update your profile";
                Session["alert-type"] = "danger";
            }
        }
    }
}