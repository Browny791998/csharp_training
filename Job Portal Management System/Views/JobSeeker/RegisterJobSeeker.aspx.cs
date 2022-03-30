using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.JobSeeker
{
    public partial class RegisterJobSeeker : System.Web.UI.Page
    {
        #region variable declaration

        private JobPortal_Models.JobSeeker.JobSeeker jobseekermodel = new JobPortal_Models.JobSeeker.JobSeeker();
        private JobPortal_Services.JobSeeker.JobSeekerService jobseekerservice = new JobPortal_Services.JobSeeker.JobSeekerService();
        private DataTable da = new DataTable();

        #endregion variable declaration

        #region bind data

        /// <summary>
        /// bind data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindSkill();
            }
        }

        /// <summary>
        /// bind skill data
        /// </summary>
        public void bindSkill()
        {
            da = JobPortal_Services.Skill.SkillServices.GetAllData();
            if (da.Rows.Count > 0)
            {
                lbSkill.DataSource = da;
                lbSkill.DataValueField = "id";
                lbSkill.DataTextField = "skill";
                lbSkill.DataBind();
            }
        }

        #endregion bind data

        #region InsertData

        /// <summary>
        /// InsertData
        /// </summary>
        private void InsertData()
        {
            string ext;
            bool isValidFile;
            jobseekermodel.Name = txtName.Text;
            jobseekermodel.Address = txtAddress.Text;
            jobseekermodel.Mobile = Convert.ToInt64(txtMobile.Text);
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
            string[] validCVFileTypes = { "doc", "docx", "DOC", "DOCX" };
            ext = System.IO.Path.GetExtension(fuCV.PostedFile.FileName);
            isValidFile = false;
            for (int i = 0; i < validCVFileTypes.Length; i++)
            {
                if (ext == "." + validCVFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile)
            {
                jobseekermodel.CVForm = null;
            }
            else
            {
                fuCV.SaveAs(Server.MapPath("~/CV/") + Path.GetFileName(fuCV.FileName));
                string cvform = "CV/" + Path.GetFileName(fuCV.FileName);
                jobseekermodel.CVForm = cvform;
            }
            string[] validImageFileTypes = { "png", "jpg", "jpeg", "PNG", "JPG", "JPEG" };
            ext = System.IO.Path.GetExtension(fuProfile.PostedFile.FileName);
            isValidFile = false;
            for (int i = 0; i < validImageFileTypes.Length; i++)
            {
                if (ext == "." + validImageFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile)
            {
                jobseekermodel.Profile = null;
            }
            else
            {
                fuProfile.SaveAs(Server.MapPath("~/Profile/") + Path.GetFileName(fuProfile.FileName));
                string image = "~/Profile/" + Path.GetFileName(fuProfile.FileName);
                jobseekermodel.Profile = image;
            }
            jobseekermodel.Email = txtEmail.Text;
            jobseekermodel.Password = EncryptPassword(txtPassword.Text);
            jobseekermodel.Detail = txtDetail.Text;
            jobseekermodel.Role = "Job Seeker";
            jobseekermodel.CreatedDate = DateTime.Now;
            jobseekermodel.UpdatedDate = DateTime.Now;
        }

        #endregion InsertData

        #region hide textbox

        /// <summary>
        /// hide textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDegree.SelectedItem.Value == "1")
            {
                pnldegree.Visible = true;
            }
            else
            {
                pnldegree.Visible = false;
            }
        }

        #endregion hide textbox

        #region register jobseeker

        /// <summary>
        ///  register jobseeker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            da = JobPortal_Services.JobSeeker.JobSeekerService.GetData(txtEmail.Text);
            if (da.Rows.Count > 0)
            {
                Session["alert"] = "Data already exist";
                Session["alert-type"] = "warning";
            }
            else
            {
                InsertData();
                if (jobseekermodel.CVForm == null)
                {
                    Session["alert"] = "CV Form File Type is invalid";
                    Session["alert-type"] = "warning";
                    return;
                }
                else if (jobseekermodel.Profile == null)
                {
                    Session["alert"] = "Profile File Type is invalid";
                    Session["alert-type"] = "warning";
                    return;
                }
                else
                {
                    bool success = JobPortal_Services.JobSeeker.JobSeekerService.Insert(jobseekermodel);
                    if (success)
                    {
                        Session["alert"] = "Successfully registered";
                        Session["alert-type"] = "success";
                        ClearFields();
                    }
                    else
                    {
                        Session["alert"] = "Failed registering";
                        Session["alert-type"] = "danger";
                    }
                }
            }
        }

        #endregion register jobseeker

        #region clear data

        /// <summary>
        /// clear data
        /// </summary>
        public void ClearFields()
        {
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtMobile.Text = string.Empty;
            ddlgender.SelectedIndex = -1;
            txtDate.Text = string.Empty;
            lbSkill.SelectedIndex = -1;
            txtExperience.Text = string.Empty;
            ddlDegree.SelectedIndex = -1;
            txtDegree.Text = string.Empty;
            fuCV.Attributes.Clear();
            fuProfile.Attributes.Clear();
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtDetail.Text = string.Empty;
        }

        /// <summary>
        /// clear data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        #endregion clear data

        #region encrypt password

        /// <summary>
        ///  encrypt password
        /// </summary>
        /// <param name="passEncrypted"></param>
        /// <returns></returns>
        public string EncryptPassword(string passEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(passEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        #endregion encrypt password
    }
}