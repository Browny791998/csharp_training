using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tutorial8
{
    public partial class Add : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["userDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }
        /// <summary>
        /// Retrieving all data
        /// </summary>
        private void GetData()
        {
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("SELECT * from tbl_Cat", con);
            con.Open();
            gvPet.DataSource = cmd.ExecuteReader();
            gvPet.DataBind();
            con.Close();
        }

        /// <summary>
        /// Adding data
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Cat VALUES(@name)", con);
                cmd.Parameters.AddWithValue("name", txtName.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblMessage.Visible = true;
                lblMessage.Text = "Added successfully";
                txtName.Text = "";
                GetData();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Please fill name";
            }
        }

        /// <summary>
        /// Delet data
        /// </summary>
        protected void gvPet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvPet.DataKeys[e.RowIndex].Value);
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("DELETE FROM tbl_Cat WHERE id=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lblMessage.Visible = true;
            lblMessage.Text = "Deleted successfully";
            GetData();
        }
    }
}