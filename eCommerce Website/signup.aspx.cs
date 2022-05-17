using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace eCommerce_Website
{
    public partial class SignUp : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                if (Session["LoginType"].Equals("User"))
                {
                    Response.Redirect("~/userhome.aspx");
                }
                else
                {
                    Response.Redirect("~/admin/adminhome.aspx");
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if(isformValid())
            {
                using (SqlConnection cnx = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("insert into Users(UserName, FullName, Email, Password, UserType) values(@uname, @fname, @email, @pass, 'user')", cnx);
                    cmd.Parameters.AddWithValue("@uname", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@fname", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                                        "Sign Up Successfully" +
                                        "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>"+
                                     "</div>");
                    Clear();
                    Response.Redirect("~/signin.aspx");
                }
            }else
            {
                Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-warning alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                    "Sign Up Faild " +
                    "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                 "</div>");
            }
        }

        private void Clear()
        {
            txtUserName.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtConPass.Text = "";
        }

        private bool isformValid()
        {
            if (txtUserName.Text == "")
            {
                lblUserName.Text = "Please Enter Your Name";
                lblUserName.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (txtFullName.Text == "")
            {
                lblFullName.Text = "Please Enter Your Full Name";
                lblFullName.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (txtEmail.Text == "")
            {
                lblEmail.Text = "Please Enter Your Email";
                lblEmail.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (txtPass.Text == "")
            {
                lblPass.Text = "Please Enter Your Password";
                lblPass.ForeColor = System.Drawing.Color.Red;
                return false;
            }            
            if(txtPass.Text != txtConPass.Text)
            {
                lblConPass.Text = "Your Confirm Password Is Not Valid";
                lblConPass.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            lblUserName.ForeColor = System.Drawing.Color.Black;
            lblFullName.ForeColor = System.Drawing.Color.Black;
            lblEmail.ForeColor = System.Drawing.Color.Black;
            lblPass.ForeColor = System.Drawing.Color.Black;
            lblConPass.ForeColor = System.Drawing.Color.Black;

            return true;   
        }

    }
}