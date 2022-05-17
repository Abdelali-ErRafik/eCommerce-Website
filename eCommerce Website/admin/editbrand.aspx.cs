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
    public partial class editbrand : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        string BrandName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdateBrand.Enabled = false;
            if (Request.QueryString["brandid"] != null)
            {
                txtBrandID.Text = Request.QueryString["brandid"];

            }

        }

        protected void txtBrandID_TextChanged(object sender, EventArgs e)
        {
            if (txtBrandID.Text != "" && Int32.TryParse(txtBrandID.Text, out int value))
            { 
                 SqlConnection con = new SqlConnection(cnxStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("select BrandName from Brands where BrandID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtBrandID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    BrandName = ds.Tables[0].Rows[0]["BrandName"].ToString();
                    txtBrandName.Text = BrandName;
                    btnUpdateBrand.Enabled = true;

                }
                else
                {
                    txtBrandName.Text = string.Empty;
                    btnUpdateBrand.Enabled = false;
                }
                con.Close();
            }


            
        }

        protected void btnUpdateBrand_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cnxStr);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("update Brands set BrandName=UPPER(@Name) where BrandID=@ID", con);
            cmd.Parameters.AddWithValue("@Name", txtBrandName.Text);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtBrandID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5\" role=\"alert\">" +
                    "Brand Updated successfully" +
                    "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                 "</div>");
            txtBrandID.Text = string.Empty;
            txtBrandName.Text = string.Empty;
        }


    }
}