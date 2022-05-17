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
    public partial class products : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindProductReapater();
        }

        private void BindProductReapater()
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Products P inner join Brands B on B.BrandID = P.PBrandID inner join Category C on C.CatID = P.PCategory inner join SubCategory Sb on Sb.SubCatID = P.PSubCategory inner join Gender G on G.GenderID = P.PGender", cnx);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                rptProducts.DataSource = tbl;
                rptProducts.DataBind();
            }
        }

        protected void rptBrands_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (e.CommandName == "Remove")
                {
                    string PID = (e.CommandArgument.ToString());
                    using (SqlConnection con = new SqlConnection(cnxStr))
                    {
                        SqlCommand cmd = new SqlCommand("delete from products where PID = @PID", con);
                        cmd.Parameters.AddWithValue("@PID", PID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                        "Product" + PID+" Deleted"+
                        "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                        "</div>");
                    }
                }

            }
        }

        protected void LnkSearch_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text != string.Empty)
            {

            }

            SqlConnection con = new SqlConnection(cnxStr);
            con.Open();
            string qr = "select * from Products P inner join Brands B on B.BrandID = P.PBrandID inner join Category C on C.CatID = P.PCategory inner join SubCategory Sb on Sb.SubCatID = P.PSubCategory inner join Gender G on G.GenderID = P.PGender where PName like '%" + txtFilter.Text + "%' order by PName asc";
            SqlDataAdapter da = new SqlDataAdapter(qr, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptProducts.DataSource = ds.Tables[0];
                rptProducts.DataBind();
            }
            else
            {

            }
        }
    }
}