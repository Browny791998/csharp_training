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
    public partial class Edit : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["userDB"].ConnectionString;

        /// <summary>
        /// getting id from add page
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand("SELECT * from tbl_Cat WHERE id=@id", con);
                cmd.Parameters.AddWithValue("id", id);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string petid = dr["id"].ToString();
                    string name = dr["name"].ToString();
                    txtName.Text = name;
                    Lblpetid.Text = petid;
                }
                con.Close();
            }
        }

        /// <summary>
        /// Updating data
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                int id = Convert.ToInt32(Lblpetid.Text);
                string name = txtName.Text;
                SqlConnection con = new SqlConnection(constring);
                SqlCommand cmd = new SqlCommand("UPDATE tbl_Cat SET name=@name WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Add.aspx");
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.CssClass = "alert alert-danger";
                lblMessage.Text = "Please fill name";
            }
        }
    }
}