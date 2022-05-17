using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace eCommerce_Website.admin
{
    public partial class addadmin : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddAdmin_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("insert into Users(UserName, FullName, Email, Password, UserType) values(@uname, @fname, @email, @pass, 'admin')", cnx);
                cmd.Parameters.AddWithValue("@uname", txtAdminName.Text);
                cmd.Parameters.AddWithValue("@fname", txtFullName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
                Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                                    "Admin Added Successfully" +
                                    "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                                 "</div>");
                Clear();
            }
        }

        private void Clear()
        {
            txtAdminName.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtConPass.Text = "";
        }


    }

}