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
    public partial class man : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindProductsReapater();
        }

        private void BindProductsReapater()
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                using (SqlCommand cmd = new SqlCommand("procBindAllProductsMan", cnx))
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

        protected void LnkSearch_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text != string.Empty)
            {

            }

            SqlConnection con = new SqlConnection(cnxStr);
            con.Open();
            string qr = "select A.*,B.*,C.BrandName ,A.PPrice-A.PSelPrice as DiscAmount,B.Name as ImageName, C.BrandName as BrandName from Products A inner join Brands C on C.BrandID =A.PBrandID inner join Category as t2 on t2.CatID=A.PCategory cross apply( select top 1 * from ProductImages B where B.PID= A.PID order by B.PID desc )B where t2.CatName='man' AND A.PName like '" + txtFilter.Text + "%' order by A.PID desc";
            SqlDataAdapter da = new SqlDataAdapter(qr, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                RptProducts.DataSource = ds.Tables[0];
                RptProducts.DataBind();
            }
            else
            {

            }
        }
    }
}