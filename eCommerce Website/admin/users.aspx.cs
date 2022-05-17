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
    public partial class users : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindAdminsReapater();
        }

        private void BindAdminsReapater()
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Users where UserType = 'user'", cnx);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                rptAdmins.DataSource = tbl;
                rptAdmins.DataBind();
            }
        }

        protected void rptAdmins_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (e.CommandName == "Remove")
                {
                    string UID = (e.CommandArgument.ToString());
                    using (SqlConnection con = new SqlConnection(cnxStr))
                    {
                        SqlCommand cmd = new SqlCommand("delete from Users where UID = @UID and UserType='user'", con);
                        cmd.Parameters.AddWithValue("@UID", UID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                        "User " + UID + " Deleted" +
                        "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                        "</div>");
                    }
                }

            }
        }
    }
}