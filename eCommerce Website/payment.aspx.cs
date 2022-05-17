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
    public partial class payment : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                if(!IsPostBack)
                {
                    //BindPriceData();
                    BindPriceData2();
                }
            }else
            {
                Response.Redirect("~/signin.aspx");
            }
        }


        protected void btnPay_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                string UserID = Session["UserID"].ToString();
                string PaymentType = "Paytm";
                string PaymentStatus = "NotPaid";
                string EMaild = Session["UserMail"].ToString();


                using (SqlConnection cnx = new SqlConnection(cnxStr))
                {
                    using (SqlCommand cmd = new SqlCommand("insert into Purchase values(@UserId, @PIDSizID, @CartAmount, @CartDiscount, @TotalePayed, @PaymentType, @PaymentStatus, getdate(), @Name, @Address, @PinCode, @MobileNumner ) select SCOPE_IDENTITY() ", cnx))
                    {
                        cmd.Parameters.AddWithValue("@UserId", UserID);
                        cmd.Parameters.AddWithValue("@PIDSizID", HdPidSize.Value);
                        cmd.Parameters.AddWithValue("@CartAmount", HdCartAmount.Value);
                        cmd.Parameters.AddWithValue("@CartDiscount", HdCartDiscount.Value);
                        cmd.Parameters.AddWithValue("@TotalePayed", HdTotalPayed.Value);
                        cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
                        cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@PinCode", txtPinCode.Text);
                        cmd.Parameters.AddWithValue("@MobileNumner", txtNumber.Text);

                        cnx.Open();
                        Int64 PurchaseID = Convert.ToInt64(cmd.ExecuteScalar());
                        cnx.Close();


                        Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5\" role=\"alert\">" +
                        "Payment Added Successfuly" +
                        "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                     "</div>");

                        txtName.Text = string.Empty;
                        txtAddress.Text = string.Empty;
                        txtPinCode.Text = string.Empty;
                        txtNumber.Text = string.Empty;



                    }
                }

            }else
            {
                Response.Redirect("~/signin.aspx");
            }
        }

        private void BindPriceData2()
        {
            string UserIDD = Session["UserID"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("SP_BindPriceData", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("UserID", UserIDD);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string Total = dt.Compute("Sum(SubSAmount)", "").ToString();
                        string CartTotal = dt.Compute("Sum(SubPAmount)", "").ToString();
                        string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                        int Total1 = Convert.ToInt32(dt.Compute("Sum(SubSAmount)", ""));
                        int CartTotal1 = Convert.ToInt32(dt.Compute("Sum(SubPAmount)", ""));
                        pTotal.InnerText = string.Format("{0:#,###.##}", double.Parse(Total)) + ".00";
                        Session["myCartAmount"] = string.Format("{0:####}", double.Parse(Total));
                        //pCartTotal.InnerText =  string.Format("{0:#,###.##}", double.Parse(CartTotal)) + ".00";
                        //pDescount.InnerText = (CartTotal1 - Total1).ToString();
                        Session["TotalAmount"] = pTotal.InnerText;
                        HdCartAmount.Value = CartTotal.ToString();
                        HdCartDiscount.Value = (CartTotal1 - Total1).ToString() + ".00";
                        HdTotalPayed.Value = Total.ToString();
                    }
                    else
                    {
                        Response.Redirect("Products.aspx");
                    }
                }
            }
        }


        private void BindPriceData()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] CookieDataArray = CookieData.Split(',');
                if (CookieDataArray.Length > 0)
                {
                    DataTable tbl = new DataTable();
                    Int64 CartTotale = 0;
                    Int64 Totale = 0;

                    for (int i = 0; i < CookieDataArray.Length; i++)
                    {
                        string PID = CookieDataArray[i].ToString().Split('-')[0];
                        string SizeID = CookieDataArray[i].ToString().Split('-')[1];

                        if(HdPidSize.Value != null && HdPidSize.Value == "")
                        {
                            HdPidSize.Value += "," + PID + "-" + SizeID;
                        }else
                        {
                            HdPidSize.Value += PID + "-" + SizeID;

                        }

                        using (SqlConnection cnx = new SqlConnection(cnxStr))
                        {
                            using (SqlCommand cmd = new SqlCommand("select P.*, dbo.getSizeName(@SizeID1) as SizeNamee ,@SizeID2 as SizeIDD, SizeData.Name, Extention from Products P cross apply(select top 1 M.Name,Extention from ProductImages M where M.PID = P.PID)SizeData where P.PID = @PID", cnx))
                            {
                                cmd.Parameters.AddWithValue("@SizeID1", SizeID);
                                cmd.Parameters.AddWithValue("@SizeID2", SizeID);
                                cmd.Parameters.AddWithValue("@PID", PID);

                                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                {
                                    da.Fill(tbl);
                                }

                            }
                        }
                        CartTotale += Convert.ToInt64(tbl.Rows[i]["PPrice"]);
                        Totale += Convert.ToInt64(tbl.Rows[i]["PSelPrice"]);
                    }


                    //pCartTotal.InnerText = CartTotale.ToString();
                    pTotal.InnerText = Totale.ToString();
                    //pDescount.InnerText = (CartTotale - Totale).ToString();

                    HdCartAmount.Value = CartTotale.ToString();
                    HdCartDiscount.Value = (CartTotale - Totale).ToString();
                    HdTotalPayed.Value = Totale.ToString();

                }

            }
        }


    }
}