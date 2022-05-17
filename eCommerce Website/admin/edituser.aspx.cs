using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eCommerce_Website.admin
{
    public partial class edituser : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            BtnUpdateUser.Enabled = false;
            if (Request.QueryString["uid"] != null)
            {
                txtUserID.Text = Request.QueryString["uid"];

            }
        }

        protected void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cnxStr);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("update Users set UserName=@UserName, FullName=@FullName,Email=@Email,Password=@Password where UID=@UID and UserType='user'", con);
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(txtUserID.Text));
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Password", txtPass.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5\" role=\"alert\">" +
                    "User Updated successfully" +
                    "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                 "</div>");

            Clear();
        }

        private void Clear()
        {
            txtUserID.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtConPass.Text = string.Empty;
        }

        protected void txtUserID_TextChanged(object sender, EventArgs e)
        {
            if (txtUserID.Text != "" && Int32.TryParse(txtUserID.Text, out int value))
            {
                SqlConnection con = new SqlConnection(cnxStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("select * from Users where UID=@UID and UserType='user'", con);
                cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(txtUserID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();

                    txtFullName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();

                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                    txtPass.Text = ds.Tables[0].Rows[0]["Password"].ToString();

                    txtConPass.Text = ds.Tables[0].Rows[0]["Password"].ToString();

                    BtnUpdateUser.Enabled = true;

                }
                else
                {
                    BtnUpdateUser.Enabled = false;
                    Clear();
                }
                con.Close();

            }
        }
    }
}