using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace Job_Portal_Management_System.Views.JobSeeker
{
    public partial class JobSeekerEdit : System.Web.UI.Page
    {
        #region variable declrartion

        private JobPortal_Models.JobSeeker.JobSeeker jobseekermodel = new JobPortal_Models.JobSeeker.JobSeeker();
        private DataTable da = new DataTable();

        #endregion variable declrartion

        #region bind data

        /// <summary>
        /// bind data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }

            if (!IsPostBack)
            {
                bindSkill();
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                SqlDataReader dr = JobPortal_Services.JobSeeker.JobSeekerService.ReadData(id);
                while (dr.Read())
                {
                    txtName.Text = dr["name"].ToString();
                    txtAddress.Text = dr["address"].ToString();
                    txtMobile.Text = dr["mobile"].ToString();
                    ddlgender.SelectedValue = dr["gender"].ToString();
                    txtDate.Text = (Convert.ToDateTime(dr["dob"]).ToString("yyyy-MM-dd"));
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
                    currentimg.ImageUrl = dr["profile"].ToString();
                    txtExperience.Text = dr["experience"].ToString();
                    ddlDegree.SelectedValue = dr["degree"].ToString();
                    txtDegree.Text = dr["degree_name"].ToString();
                    txtDetail.Text = dr["detail"].ToString();
                }
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

        #region hide textbox

        /// <summary>
        /// check if gradurate hide textbox
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

        #region UpdateData

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            string ext;
            bool isValidFile;
            jobseekermodel.ID = Convert.ToInt32(Request.QueryString["ID"]);
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
            if (!fuCV.HasFile)
            {
                jobseekermodel.CVForm = hfCV.Value;
            }
            else
            {
                string[] validCVFileTypes = { "doc", "docx" };
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
            }

            if (!fuProfile.HasFile)
            {
                jobseekermodel.Profile = currentimg.ImageUrl;
            }
            else
            {
                string[] validImageFileTypes = { "png", "jpg", "jpeg" };
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
                    string currentpath = Server.MapPath(currentimg.ImageUrl);
                    FileInfo file = new FileInfo(currentpath);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    fuProfile.SaveAs(Server.MapPath("~/Profile/") + Path.GetFileName(fuProfile.FileName));
                    string image = "~/Profile/" + Path.GetFileName(fuProfile.FileName);
                    jobseekermodel.Profile = image;
                }
            }
            jobseekermodel.Detail = txtDetail.Text;
            jobseekermodel.UpdatedDate = DateTime.Now;
        }

        /// <summary>
        /// check cv form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
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
                bool IsUpdate = JobPortal_Services.JobSeeker.JobSeekerService.Update(jobseekermodel);
                if (IsUpdate)
                {
                    Session["alert"] = "Successfully updated your profile";
                    Session["alert-type"] = "success";
                    Response.Redirect("~/Views/JobSeeker/JobSeekerProfile.aspx");
                }
                else
                {
                    Session["alert"] = "failed to update your profile";
                    Session["alert-type"] = "danger";
                }
            }
        }

        #endregion UpdateData
    }
}