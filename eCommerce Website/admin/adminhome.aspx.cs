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
    public partial class adminhome : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-fixed bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                "Login Successfully " +
                "Welcome Admin " + Session["Username"].ToString() +
                "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                "</div>"); ;
                if (!IsPostBack)
                {
                    BindCustomersCount();
                    BindOrdersCount();
                    BindProductsCount();
                    BindCartCount();
                    LatestUsers();
                    LatestProducts();
                    LatestPayment();
                }

            }
            else
            {
                Response.Redirect("~/signin.aspx");
            }
        }

        private void LatestPayment()
        {
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select top 8 * from Purchase order by PurchaseID desc", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Rptpayment.DataSource = dt;
                Rptpayment.DataBind();
            }
        }

        private void LatestProducts()
        {
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select top 8 * from Products order by PID desc", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                RptProducts.DataSource = dt;
                RptProducts.DataBind();
            }
        }

        private void LatestUsers()
        {
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select top 8 * from Users where Usertype='user' order by UID desc", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                RptCustomers.DataSource = dt;
                RptCustomers.DataBind();
            }
        }

        private void BindCustomersCount()
        {
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select count(*) from Users where UserType = 'user'", con);
                con.Open();
                double CustomersCount= (int)cmd.ExecuteScalar();
                customersCount.InnerText = CustomersCount+"";
                customersPourSent.InnerText = (CustomersCount / 100) + "%";
                con.Close();
            }
        }

        private void BindOrdersCount()
        {
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select count(*) from Purchase", con);
                con.Open();
                double OrdersCount = (int)cmd.ExecuteScalar();
                ordersCount.InnerText = OrdersCount + "";
                ordersPoursent.InnerText = (OrdersCount / 100)+"%";
                con.Close();
            }
        }        
        
        private void BindProductsCount()
        {
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select count(*) from Products", con);
                con.Open();
                double ProductsCount = (int)cmd.ExecuteScalar();
                productsCount.InnerText = ProductsCount + "";
                productsPourSent.InnerText = (ProductsCount / 100)+"%";
                con.Close();
            }
        }        
        
        private void BindCartCount()
        {
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select count(*) from Cart", con);
                con.Open();
                double ProductsCount = (int)cmd.ExecuteScalar();
                CartCount.InnerText = ProductsCount + "";
                CartPourSent.InnerText = (ProductsCount / 100)+"%";
                con.Close();
            }
        }
    }

}