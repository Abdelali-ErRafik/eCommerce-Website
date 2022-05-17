using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Threading;

namespace eCommerce_Website
{
    public partial class cart : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    BindProductsCard();
                }
                else
                {
                    Response.Redirect("Signin.aspx");
                }
            }
        }

        private void BindProductsCard()
        {
            string UserIDD = Session["UserID"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("SP_BindUserCart", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", UserIDD);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    RptrCartProducts.DataSource = dt;
                    RptrCartProducts.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        string Total = dt.Compute("Sum(SubSAmount)", "").ToString();
                        string CartTotal = dt.Compute("Sum(SubPAmount)", "").ToString();
                        string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                        NoItems.InnerText = "My Cart ( " + CartQuantity + " Items )";
                        int Total1 = Convert.ToInt32(dt.Compute("Sum(SubSAmount)", ""));
                        int CartTotal1 = Convert.ToInt32(dt.Compute("Sum(SubPAmount)", ""));
                        pTotal.InnerText = string.Format("{0:#,###.##}", double.Parse(Total)) + ".00";
                        pCartTotal.InnerText =  string.Format("{0:#,###.##}", double.Parse(CartTotal)) + ".00";
                        pDescount.InnerText =  (CartTotal1 - Total1).ToString() + ".00";
                    }
                    else
                    {
                        NoItems.InnerText = "Your Shopping Cart is Empty.";
                        //divAmountSect.Visible = false;

                    }
                }
                //if (Request.Cookies["CartPID"] != null)
                //{
                //    string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                //    string[] CookieDataArray = CookieData.Split(',');
                //    if(CookieDataArray.Length > 0)
                //    {
                //        DataTable tbl = new DataTable();
                //        Int64 CartTotale = 0;
                //        Int64 Totale = 0;
                //        NoItems.InnerText="My Cart ("+ CookieDataArray.Length  + " items)";
                //        for (int i =0; i < CookieDataArray.Length; i++)
                //        {
                //            string PID = CookieDataArray[i].ToString().Split('-')[0];
                //            string SizeID = CookieDataArray[i].ToString().Split('-')[1];

                //            using (SqlConnection cnx = new SqlConnection(cnxStr))
                //            {
                //                using (SqlCommand cmd = new SqlCommand("select P.*, dbo.getSizeName(@SizeID1) as SizeNamee ,@SizeID2 as SizeIDD, SizeData.Name, Extention from Products P cross apply(select top 1 M.Name,Extention from ProductImages M where M.PID = P.PID)SizeData where P.PID = @PID", cnx))
                //                {
                //                    cmd.Parameters.AddWithValue("@SizeID1", SizeID);
                //                    cmd.Parameters.AddWithValue("@SizeID2", SizeID);
                //                    cmd.Parameters.AddWithValue("@PID", PID);

                //                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                //                    {
                //                        da.Fill(tbl);
                //                    }

                //                }
                //            }
                //            CartTotale += Convert.ToInt64(tbl.Rows[i]["PPrice"]);
                //            Totale += Convert.ToInt64(tbl.Rows[i]["PSelPrice"]);
                //        }

                //            RptrCartProducts.DataSource = tbl;
                //            RptrCartProducts.DataBind();

                //            pCartTotal.InnerText = CartTotale.ToString();
                //            pTotal.InnerText = "Rs. $" + Totale.ToString();
                //            pDescount.InnerText = "- $" + (CartTotale - Totale).ToString();

                //    }

                //} else
                //{
                //    NoItems.InnerText = "My Cart (0 items)";
                //}
            }
        }

        //protected void LnkRemoveProduct_Click(object sender, EventArgs e)
        //{
        //    string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];

        //    LinkButton btn = (LinkButton)(sender);

        //    string PIDSIZE = btn.CommandArgument;

        //    List<string> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
        //    CookiePIDList.Remove(PIDSIZE);

        //    string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
        //    if (CookiePIDUpdated == "")
        //    {
        //        HttpCookie CartProducts = new HttpCookie("CartPID");
        //        CartProducts.Values["CartPID"] = null;
        //        CartProducts.Expires = DateTime.Now.AddDays(-1);
        //        Response.Cookies.Add(CartProducts);
        //    }
        //    else
        //    {
        //        HttpCookie CartProducts = Request.Cookies["CartPID"];
        //        CartProducts.Values["CartPID"] = CookiePIDUpdated;
        //        CartProducts.Expires = DateTime.Now.AddDays(30);
        //        Response.Cookies.Add(CartProducts);
        //    }
        //    Response.Redirect("~/cart.aspx");

        //}

        protected void LnkBuyNow_Click(object sender, EventArgs e)
        {
            if(Session["UserName"] != null)
            {
                Response.Redirect("~/payment.aspx");
            }
            else
            {
                Response.Redirect("~/signin.aspx?rurl=cart");
            }
        }

        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("en-IN");
            ci.NumberFormat.CurrencySymbol = "DH";
            Thread.CurrentThread.CurrentCulture = ci;
            base.InitializeCulture();
        }

        protected void RptrCartProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Int32 UserID = Convert.ToInt32(Session["UserID"].ToString());
            //This will add +1 to current quantity using PID
            if (e.CommandName == "DoPlus")
            {
                string PID = (e.CommandArgument.ToString());
                using (SqlConnection con = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("SP_getUserCartItem", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@PID", PID);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
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
                            con.Open();
                            Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                            con.Close();
                            BindProductsCard();
                            Response.Redirect("cart.aspx");


                        }
                    }

                }
            }
            else if (e.CommandName == "DoMinus")
            {
                string PID = (e.CommandArgument.ToString());
                using (SqlConnection con = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("SP_getUserCartItem", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@PID", PID);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Int32 myQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                            if (myQty <= 1)
                            {
                                //divQtyError.Visible = true;
                            }
                            else
                            {
                                SqlCommand myCmd = new SqlCommand("SP_UpdateCart", con)
                                {
                                    CommandType = CommandType.StoredProcedure
                                };
                                myCmd.Parameters.AddWithValue("@Quantity", myQty - 1);
                                myCmd.Parameters.AddWithValue("@CartPID", PID);
                                myCmd.Parameters.AddWithValue("@UserID", UserID);
                                con.Open();
                                Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                                con.Close();
                                BindProductsCard();
                                Response.Redirect("cart.aspx");


                            }
                        }

                    }
                }
            }
            else if (e.CommandName == "RemoveThisCart")
            {
                int CartPID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                using (SqlConnection con = new SqlConnection(cnxStr))
                {
                    SqlCommand myCmd = new SqlCommand("SP_DeleteThisCartItem", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    myCmd.Parameters.AddWithValue("@CartID", CartPID);
                    con.Open();
                    myCmd.ExecuteNonQuery();
                    con.Close();
                    BindProductsCard();
                    Response.Redirect("cart.aspx");

                }
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];

        //    Button btn = (Button)(sender);

        //    string PIDSIZE = btn.CommandArgument;

        //    List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
        //    CookiePIDList.Remove(PIDSIZE);

        //    string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
        //    if (CookiePIDUpdated == "")
        //    {
        //        HttpCookie CartProducts = Request.Cookies["CartPID"];
        //        CartProducts.Values["CartPID"] = null;
        //        CartProducts.Expires = DateTime.Now.AddDays(-1);
        //        Response.Cookies.Add(CartProducts);
        //    }
        //    else
        //    {
        //        HttpCookie CartProducts = Request.Cookies["CartPID"];
        //        CartProducts.Values["CartPID"] = CookiePIDUpdated;
        //        CartProducts.Expires = DateTime.Now.AddDays(30);
        //        Response.Cookies.Add(CartProducts);
        //    }
        //    Response.Redirect("~/cart.aspx");
        //}
    }
}