using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tutorial7
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string constring = ConfigurationManager.ConnectionStrings["userDB"].ConnectionString;
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("SELECT Password FROM tbl_User WHERE Name=@Name and Password=@Password", con);
            cmd.Parameters.AddWithValue("Name", txtUserName.Text);
            cmd.Parameters.AddWithValue("Password", txtPassword.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Session["name"] = txtUserName.Text;
                Response.Redirect("Default.aspx");
            }
            else
            {
                SqlConnection con2 = new SqlConnection(constring);
                string name = txtUserName.Text;
                int id;
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM tbl_User WHERE Name='" + name + "'", con2);
                con2.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    id = Convert.ToInt32(dr["id"]);
                    name = dr["Name"].ToString();
                    reset_password(id, name);
                }
                con2.Close();
            }
        }

        private void reset_password(int id, string name)
        {
            Session["Email"] = name;
            SqlConnection con3 = new SqlConnection(constring);
            SqlCommand cmd3 = new SqlCommand("Update tbl_User set Password=NULL,Status=1 WHERE id=@id", con3);
            cmd3.Parameters.AddWithValue("id", id);
            con3.Open();
            cmd3.ExecuteNonQuery();
            con3.Close();
            Response.Redirect("Reset.aspx");
        }
    }
}