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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lnkAdminLogin.Visible = false;
                lnkAdminLogout.Visible = true;

            }
            else
            {
                lnkAdminLogin.Visible = true;
                lnkAdminLogout.Visible = false;
                //Response.Redirect("~/signin.aspx");
            }


            BindProductsReapater();
            BindMostProductsReapater();
        }

        protected void lnkAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/signin.aspx");
        }

        protected void lnkAdminLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["Username"] = null;
            Session.Remove("Username");
            Response.Redirect("~/sou9ino.aspx");
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