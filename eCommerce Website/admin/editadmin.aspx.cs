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
    public partial class editadmin : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        string adminId = "";
        string Name = "";
        string FullName = "";
        string Email = "";
        string Password = "";
        string ConPassword = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            BtnUpdateAdmin.Enabled = false;
            if (Request.QueryString["uid"] != null)
            {
                txtAdminID.Text = Request.QueryString["uid"];

            }
        }



        protected void BtnUpdateAdmin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cnxStr);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("update Users set UserName=@UserName, FullName=@FullName,Email=@Email,Password=@Password where UID=@UID and UserType='admin'", con);
            cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(txtAdminID.Text));
            cmd.Parameters.AddWithValue("@UserName", txtAdminName.Text);
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Password", txtPass.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5\" role=\"alert\">" +
                    "Admin Updated successfully" +
                    "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                 "</div>");

            Clear();
        }

        private void Clear()
        {
            txtAdminID.Text = string.Empty;
            txtAdminName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtConPass.Text = string.Empty;
        }

        protected void txtAdminID_TextChanged1(object sender, EventArgs e)
        {
            if (txtAdminID.Text != "" && Int32.TryParse(txtAdminID.Text, out int value))
            {
                SqlConnection con = new SqlConnection(cnxStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("select * from Users where UID=@UID and UserType='admin'", con);
                cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(txtAdminID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    adminId = ds.Tables[0].Rows[0]["UID"].ToString();
                    txtAdminID.Text = adminId;

                    Name = ds.Tables[0].Rows[0]["UserName"].ToString();
                    txtAdminName.Text = Name;

                    FullName = ds.Tables[0].Rows[0]["FullName"].ToString();
                    txtFullName.Text = FullName;

                    Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtEmail.Text = Email;

                    Password = ds.Tables[0].Rows[0]["Password"].ToString();
                    txtPass.Text = Password;

                    ConPassword = ds.Tables[0].Rows[0]["Password"].ToString();
                    txtConPass.Text = ConPassword;

                    BtnUpdateAdmin.Enabled = true;



                }
                else
                {
                    BtnUpdateAdmin.Enabled = false;
                    Clear();
                }
                con.Close();

            }

        }
    }
}