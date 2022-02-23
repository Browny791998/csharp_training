using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            gvPet.DataSource = ds;
            gvPet.DataBind();
            con.Close();
        }

        /// <summary>
        /// Adding data
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                if (!DataExist())
                {
                    SqlConnection con = new SqlConnection(constring);
                    SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Cat VALUES(@name)", con);
                    cmd.Parameters.AddWithValue("name", txtName.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Added successfully')", true);
                    txtName.Text = "";
                    GetData();
                }
                else
                {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Data already exists')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Please fill name')", true);
            }
        }

        /// <summary>
        /// checking data exist or not
        /// </summary>
        /// <returns></returns>
        private bool DataExist()
        {
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("SELECT * from tbl_Cat WHERE name=@name ", con);
            cmd.Parameters.AddWithValue("name", txtName.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            return false;
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
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMesage", "alert('Deleted successfully')", true);
            GetData();
        }

        /// <summary>
        /// pagination
        /// </summary>
        protected void gvPet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPet.PageIndex = e.NewPageIndex;
            this.GetData();
        }
    }
}