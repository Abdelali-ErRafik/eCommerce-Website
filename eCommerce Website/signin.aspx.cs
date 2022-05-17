using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace eCommerce_Website
{
    public partial class SignIn : System.Web.UI.Page
    {

        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.Cookies["UserName"] != null && Request.Cookies["UserPassword"] != null)
                {
                    txtUserName.Text = Request.Cookies["UserName"].Value;
                    txtPass.Text = Request.Cookies["UserPassword"].Value;
                    cbxRemamber.Checked = true;
                }else
                {
                    txtUserName.Text = "";
                    txtPass.Text = "";
                }
                ////////////////
                if (Session["UserName"] != null)
                {
                    if (Session["LoginType"].Equals("User"))
                    {
                        Response.Redirect("~/userhome.aspx");
                    }else
                    {
                        Response.Redirect("~/admin/adminhome.aspx");
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Users where UserName = @uname and Password = @pass", cnx);
                cmd.Parameters.AddWithValue("@uname", txtUserName.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                if(tbl.Rows.Count != 0)
                {
                    Session["UserID"] = tbl.Rows[0]["Uid"].ToString();
                    Session["UserMail"] = tbl.Rows[0]["Email"].ToString();
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["UserPassword"].Expires = DateTime.Now.AddDays(-1);
                    if (cbxRemamber.Checked)
                    {
                        Response.Cookies["UserName"].Value = txtUserName.Text;
                        Response.Cookies["UserPassword"].Value = txtPass.Text;

                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(10);
                        Response.Cookies["UserPassword"].Expires = DateTime.Now.AddDays(10);
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["UserPassword"].Expires = DateTime.Now.AddDays(-1);
                    }

                    string userType;
                    userType = tbl.Rows[0]["UserType"].ToString().Trim().ToLower();

                    if(userType == "user")
                    {
                        Session["Username"] = txtUserName.Text;
                        Session["USEREMAIL"] = tbl.Rows[0]["Email"].ToString();
                        Session["getFullName"] = tbl.Rows[0]["FullName"].ToString();
                        //Session["Mobile"] = dt.Rows[0]["Mobile"].ToString();
                        Session["LoginType"] = "User";
                        if (Request.QueryString["rurl"] != null)
                        {
                            if (Request.QueryString["rurl"] == "cart")
                            {
                                Response.Redirect("~/cart.aspx");
                            }

                            if (Request.QueryString["rurl"] == "PID")
                            {
                                string myPID = Session["CartPID"].ToString();
                                Response.Redirect("ProductView.aspx?PID=" + myPID );
                            }
                        }
                        else
                        {
                            Response.Redirect("~/UserHome.aspx");

                        }

                    }
                    if(userType == "admin")
                    {
                        Session["Username"] = txtUserName.Text;
                        Session["LoginType"] = "Admin";
                        Response.Redirect("admin/adminhome.aspx");
                    }

                }
                else
                {
                    Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                    "Login Faild" +
                    "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                    "</div>");
                    Clear();

                }
            }     
        }

        private void Clear()
        {
            txtUserName.Text = "";
            txtPass.Text = "";
        }
    }
}