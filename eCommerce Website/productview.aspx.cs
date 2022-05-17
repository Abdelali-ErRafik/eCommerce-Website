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
    public partial class productview : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        readonly Int32 myQty = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["PID"] != null){
                if (!IsPostBack)
                {
                    BindProductsReapater();
                    BindProductsDetailsReapater();

                    if(Session["UserName"] != null)
                    {
                        Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-fixed bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                        "Product Added To Cart " +
                        "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                        "</div>");

                    }
                }
            }else
            {
                Response.Redirect("~/products.aspx");
            }
        }

        private void BindProductsReapater()
        {
            int PID = Convert.ToInt32(Request.QueryString["PID"]);
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from ProductImages where PID = @PID", cnx))
                {
                    cmd.Parameters.AddWithValue("@PID", PID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tbl = new DataTable();
                        da.Fill(tbl);
                        RptImage1.DataSource = tbl;
                        RptImage1.DataBind();                        
                        RptImage2.DataSource = tbl;
                        RptImage2.DataBind();
                    }

                }
            }
        }
        
        private void BindProductsDetailsReapater()
        {
            int PID = Convert.ToInt32(Request.QueryString["PID"]);
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Products where PID = @PID", cnx))
                {
                    cmd.Parameters.AddWithValue("@PID", PID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tbl = new DataTable();
                        da.Fill(tbl);
                        RptProductDetails.DataSource = tbl;
                        RptProductDetails.DataBind();
                        Session["CartPID"] = Convert.ToInt32(tbl.Rows[0]["PID"].ToString());
                        Session["myPName"] = tbl.Rows[0]["PName"].ToString();
                        Session["myPPrice"] = tbl.Rows[0]["PPrice"].ToString();
                        Session["myPSelPrice"] = tbl.Rows[0]["PSelPrice"].ToString();
                    }

                }
            }
        }

        protected string GetActiveImgClass(int ItemIndex)
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }

        protected void RptProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string BrandID = (e.Item.FindControl("HfBrandID") as HiddenField).Value;
                string CategoryID = (e.Item.FindControl("HfCatID") as HiddenField).Value;
                string SubCateID = (e.Item.FindControl("HfSubCategoryID") as HiddenField).Value;
                string GenderID = (e.Item.FindControl("HfPGenderID") as HiddenField).Value;


                RadioButtonList RblSize = e.Item.FindControl("RblSize") as RadioButtonList;
                using (SqlConnection cnx = new SqlConnection(cnxStr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from Sizes where BrandID = @BrandID and CategoryID = @CategoryID and SubCateID = @SubCateID and GenderID = @GenderID", cnx))
                    {
                        cmd.Parameters.AddWithValue("@BrandID", BrandID);
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                        cmd.Parameters.AddWithValue("@SubCateID", SubCateID);
                        cmd.Parameters.AddWithValue("@GenderID", GenderID);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tbl = new DataTable();
                            da.Fill(tbl);
                            RblSize.DataSource = tbl;
                            RblSize.DataTextField = "SizeName";
                            RblSize.DataValueField = "SizeID";
                            RblSize.DataBind();
                        }

                    }
                }
            }
        }

        protected void BtnAddToCart_click(object sender, EventArgs e)
        {
            string SelectedSize = string.Empty;
            foreach (RepeaterItem item in RptProductDetails.Items)
            {
                if(item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var rbList = item.FindControl("RblSize") as RadioButtonList;
                    SelectedSize = rbList.SelectedValue;
                    var lblError = item.FindControl("lblError") as Label;
                    lblError.Text = "";
                }

            }

            if(SelectedSize != "")
            {
                Int64 PID = Convert.ToInt64(Request.QueryString["pid"]);
                //if (Request.Cookies["CartPID"]!= null)
                //{
                //    string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                //    CookiePID = CookiePID + "," + PID + "-" + SelectedSize;

                //    HttpCookie CartProducts = new HttpCookie("CartPID");
                //    CartProducts.Values["CartPID"] = CookiePID;
                //    CartProducts.Expires = DateTime.Now.AddDays(30);
                //    Response.Cookies.Add(CartProducts);

                //}else
                //{
                //    HttpCookie CartProducts = new HttpCookie("CartPID");

                //    CartProducts.Values["CartPID"] = PID.ToString()+"-"+SelectedSize;
                //    CartProducts.Expires = DateTime.Now.AddDays(30);
                //    Response.Cookies.Add(CartProducts);
                //}
                AddToCartProduction();
                Response.Redirect("productview.aspx?pid="+PID);
            }else
            {
                foreach (RepeaterItem item in RptProductDetails.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var lblError = item.FindControl("lblError") as Label;
                        lblError.Text = "Please select a size";
                    }

                }
            }

        }

        private void AddToCartProduction()
        {
            if (Session["Username"] != null)
            {
                Int32 UserID = Convert.ToInt32(Session["UserID"].ToString());
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                using (SqlConnection con = new SqlConnection(cnxStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_IsProductExistInCart", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@PID", PID);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Int32 updateQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                            SqlCommand myCmd = new SqlCommand("SP_UpdateCart", con)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            myCmd.Parameters.AddWithValue("@Quantity", updateQty + 1);
                            myCmd.Parameters.AddWithValue("@CartPID", PID);
                            myCmd.Parameters.AddWithValue("@UserID", UserID);
                            Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());

                        }
                        else
                        {
                            SqlCommand myCmd = new SqlCommand("SP_InsertCart", con)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            myCmd.Parameters.AddWithValue("@UID", UserID);
                            myCmd.Parameters.AddWithValue("@PID", Session["CartPID"].ToString());
                            myCmd.Parameters.AddWithValue("@PName", Session["myPName"].ToString());
                            myCmd.Parameters.AddWithValue("@PPrice", Session["myPPrice"].ToString());
                            myCmd.Parameters.AddWithValue("@PSelPrice", Session["myPSelPrice"].ToString());
                            myCmd.Parameters.AddWithValue("@Qty", myQty);
                            Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                            con.Close();

                        }
                    }
                }
            }
            else
            {
                //Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                Response.Redirect("Signin.aspx?rurl=PID");
                //Response.Redirect("Signin.aspx");
            }
        }

        protected void btnCart2_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("cart.aspx");
        }
    }
}