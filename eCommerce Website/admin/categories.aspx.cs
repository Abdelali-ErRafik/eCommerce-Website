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
    public partial class category : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            BindCategoryReapater();

        }

        private void BindCategoryReapater()
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Category", cnx);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                rptBrands.DataSource = tbl;
                rptBrands.DataBind();
            }
        }

        protected void rptBrands_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (e.CommandName == "Remove")
                {
                    string CatID = (e.CommandArgument.ToString());
                    using (SqlConnection con = new SqlConnection(cnxStr))
                    {
                        SqlCommand cmd = new SqlCommand("delete from Category where CatID = @CatID ", con);
                        cmd.Parameters.AddWithValue("@CatID", CatID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                        "Category " + CatID + " Deleted" +
                        "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                        "</div>");
                    }
                }
                else
                {

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
            string qr = "select * from Category where CatName like '%" + txtFilter.Text + "%' order by CatName asc";
            SqlDataAdapter da = new SqlDataAdapter(qr, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptBrands.DataSource = ds.Tables[0];
                rptBrands.DataBind();
            }
            else
            {

            }
        }
    }
}