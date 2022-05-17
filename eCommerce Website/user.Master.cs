using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eCommerce_Website.assets
{
    public partial class user : System.Web.UI.MasterPage
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lnkAdminLogin.Visible = false;
                lnkAdminLogout.Visible = true;

            }else
            {
                lnkAdminLogin.Visible = true;
                lnkAdminLogout.Visible = false;
                //Response.Redirect("~/signin.aspx");
            }

            if(!IsPostBack)
            {
                BindCartNumber();

            }

        }

        protected void lnkAdminLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session["Username"] = null;
            Session.Remove("Username");
            Response.Redirect("~/edashop.aspx");
        }

        protected void lnkAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/signin.aspx");

        }

        public void BindCartNumber()
        {
            if (Session["USERID"] != null)
            {
                string UserIDD = Session["USERID"].ToString();
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("SP_BindCartNumberz", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@UserID", UserIDD);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                            pCount.InnerText = CartQuantity;
                        }
                        else
                        {
                            // _ = CartBadge.InnerText == 0.ToString();
                            pCount.InnerText = "0";
                        }
                    }
                }
            }  
        }
    }
}