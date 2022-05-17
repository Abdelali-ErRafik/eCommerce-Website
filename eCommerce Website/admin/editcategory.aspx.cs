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
    public partial class editcategory : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            btnUpdateCategory.Enabled = false;
                if (Request.QueryString["catid"] != null)
                {
                    txtCategoryID.Text = Request.QueryString["catid"];
                }

            }
        }

        protected void txtCategoryID_TextChanged(object sender, EventArgs e)
        {
            if (txtCategoryID.Text != "" && Int32.TryParse(txtCategoryID.Text, out int value))
            {
                SqlConnection con = new SqlConnection(cnxStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("select CatName from Category where CatID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtCategoryID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnUpdateCategory.Enabled = true;
                    txtCategory.Text = ds.Tables[0].Rows[0]["CatName"].ToString();

                }
                else
                {
                    btnUpdateCategory.Enabled = false;
                    txtCategory.Text = string.Empty;
                }
                con.Close();

            }

            
        }

        protected void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cnxStr);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("update Category set CatName=@Name where CatID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtCategoryID.Text));
            cmd.Parameters.AddWithValue("@Name", txtCategory.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-fixed bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
             "Update category Successfully " +
             "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
             "</div>");
            txtCategory.Text = string.Empty;
            txtCategoryID.Text = string.Empty;
        }
    }
}