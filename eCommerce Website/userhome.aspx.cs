using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eCommerce_Website
{
    public partial class userhome : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-fixed bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                "Login Successfully " +
                "Welcome User " + Session["Username"].ToString() +
                "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                "</div>"); ;

            }
            else
            {
                Response.Redirect("~/edashop.aspx");
            }

            BindProductsReapater();
            BindMostProductsReapater();
        }

        private void BindProductsReapater()
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                using (SqlCommand cmd = new SqlCommand("procBindfoorProducts", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tbl = new DataTable();
                        da.Fill(tbl);
                        RptProducts.DataSource = tbl;
                        RptProducts.DataBind();
                    }

                }
            }
        }

        private void BindMostProductsReapater()
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                using (SqlCommand cmd = new SqlCommand("procBindfoorMostProducts", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tbl = new DataTable();
                        da.Fill(tbl);
                        RptMostPapular.DataSource = tbl;
                        RptMostPapular.DataBind();
                    }

                }
            }
        }

        protected void btnViewAll1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/products.aspx");
        }

        protected void btnViewAll2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/products.aspx");
        }
    }
}