using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace eCommerce_Website
{
    public partial class recoverpassword : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        DataTable tbl = new DataTable();
        string GUIDvalue;
        int Uid;
        protected void Page_Load(object sender, EventArgs e)
        {

            using(SqlConnection cnx = new SqlConnection(cnxStr))
            {

                GUIDvalue = Request.QueryString["id"];
                if (GUIDvalue != null)
                {
                    SqlCommand cmd = new SqlCommand("select * from ForgotPassword where Id = @id",cnx);
                    cmd.Parameters.AddWithValue("@id", GUIDvalue);
                    SqlDataAdapter dt = new SqlDataAdapter(cmd);
                    dt.Fill(tbl);

                    if (tbl.Rows.Count != 0)
                    {
                        Uid = Convert.ToInt32(tbl.Rows[0][1]);
                    }
                    else
                    {
                        lblmsg.Visible = true;
                    }

                    

                }
                else
                {
                    Response.Redirect("~/edashop.aspx");

                }
            }

            if (!IsPostBack)
            {
                if (tbl.Rows.Count != 0)
                {
                    txtPass.Visible = true;
                    txtConPass.Visible = true;
                    lblPass.Visible = true;
                    lblConPass.Visible = true;
                    btnReset.Visible = true;
                    lblmsg.Visible = false;


                }
                else
                {
                    lblmsg.Visible = true;

                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

            if(txtPass.Text != "" && txtConPass.Text != "" && txtPass.Text == txtConPass.Text)
            {
                using (SqlConnection cnx = new SqlConnection(cnxStr))
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("Update Users set Password = @pass where Uid = @uid", cnx);
                    cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                    cmd.Parameters.AddWithValue("@uid", Uid);  
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("delete from ForgotPassword where Uid = @uid", cnx);
                    cmd2.Parameters.AddWithValue("@uid", Uid);
                    cnx.Close();

                    Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                                        "Password Reset Succefuly" +
                                        "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                                     "</div>");
                    Response.Redirect("~/SignIn.aspx");

                }

            }

        }
    }
}