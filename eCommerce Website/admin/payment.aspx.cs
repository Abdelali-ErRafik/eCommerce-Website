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
    public partial class payment : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPayementReapater();

        }

        private void BindPayementReapater()
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select *from Purchase", cnx);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                rptPayment.DataSource = tbl;
                rptPayment.DataBind();
            }
        }

        protected void LnkSearch_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text != string.Empty)
            {

            }

            SqlConnection con = new SqlConnection(cnxStr);
            con.Open();
            string qr = "select *from Purchase where Name like '%" + txtFilter.Text + "%' order by Name asc";
            SqlDataAdapter da = new SqlDataAdapter(qr, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptPayment.DataSource = ds.Tables[0];
                rptPayment.DataBind();
            }
            else
            {

            }
        }
    }
}