using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace eCommerce_Website.admin
{
    public partial class editproduct : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;

        string PName = "";
        string PPrice = "";
        string PSelPrice = "";

        string BrandID = "";
        string MainCID = "";
        string SubCID = "";
        string GenderID = "";        
        
        string Quantity = "";

        string PDescription = "";
        string PProductDetails = "";
        string PMaterialCare = "";        
        
        string FreeDelivery = "";
        string DayRet = "";
        string COD = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                BindBrand();
                BindCategory();
                BindGender();
                ddlSubCategory.Enabled = false;
                ddlGender.Enabled = false;
                ddlSubCategory.Items.Insert(0, new ListItem("-No subcategory-", "0"));
                cblSize.Items.Insert(0, new ListItem("-No Size To chose-", "0"));
                btnUpdatePoduct.Enabled = false;

                if (Request.QueryString["PID"] != null)
                {
                    txtProductID.Text = Request.QueryString["PID"];
                }
               

            }
        }

        protected void btnUpdatePoduct_Click(object sender, EventArgs e)
        {
            if (isformValid())
            {
                using (SqlConnection cnx = new SqlConnection(cnxStr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateProduct", cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PID", txtProductID.Text);
                        cmd.Parameters.AddWithValue("@PName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@PPrice", txtPrice.Text);
                        cmd.Parameters.AddWithValue("@PSellPrice", txtSellingPrice.Text);
                        cmd.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@PSubCatID", ddlSubCategory.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@PGenderID", ddlGender.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@PDescription", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@PProductDetails", txtProductDetails.Text);
                        cmd.Parameters.AddWithValue("@PMaterialeCare", txtMaterialsAndCare.Text);
                        if (cbFreeDelivery.Checked)
                        {
                            cmd.Parameters.AddWithValue("@FreeDel", 1.ToString());
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@FreeDel", 0.ToString());
                        }

                        if (cb30DaysReturn.Checked)
                        {
                            cmd.Parameters.AddWithValue("@30DayRet", 1.ToString());
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@30DayRet", 0.ToString());
                        }

                        if (cbCOD.Checked)
                        {
                            cmd.Parameters.AddWithValue("@COD", 1.ToString());
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@COD", 0.ToString());
                        }

                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        string PID = txtProductID.Text;

                        //Quantity
                        for (int i = 0; i < cblSize.Items.Count; i++)
                        {
                            Int64 SizeID = Convert.ToInt64(cblSize.Items[i].Value);
                            int Qte = Convert.ToInt32(txtQte.Text);


                            SqlCommand cmd2 = new SqlCommand("update ProductsSizeQuantity set SizeID=@SizeID, Quantity=@Quantity where PID = @PID ", cnx);
                            cmd2.Parameters.AddWithValue("@PID", txtProductID.Text);
                            cmd2.Parameters.AddWithValue("@SizeID", SizeID);
                            cmd2.Parameters.AddWithValue("@Quantity", Qte);

                            cmd2.ExecuteNonQuery();

                            Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-warning alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5\" role =\"alert\">" +
                            "Product Quantity Added Successfuly" +
                            "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +

                                  "</div>");

                        }

                        //Insert and upload images
                        //image01
                        if (FileUploadImage1.HasFile)
                        {
                            string SavePath = Server.MapPath("../assets/images/ProductImages/") + PID;
                            if (!Directory.Exists(SavePath))
                            {
                                Directory.CreateDirectory(SavePath);
                            }

                            string Extention = Path.GetExtension(FileUploadImage1.PostedFile.FileName);
                            FileUploadImage1.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "01" + Extention);

                            SqlCommand cmd3 = new SqlCommand("update ProductImages set Name = @Name, Extention =@Extention where PID = @PID ", cnx);
                            cmd3.Parameters.AddWithValue("@PID", PID);
                            cmd3.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "01");
                            cmd3.Parameters.AddWithValue("@Extention", Extention);

                            cmd3.ExecuteNonQuery();

                            Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-warning alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5\" role =\"alert\">" +
                            "Product Images Added Successfuly" +
                            "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                                  "</div>");

                        }

                        //image02
                        if (FileUploadImage2.HasFile)
                        {
                            string SavePath = Server.MapPath("../assets/images/ProductImages/") + PID;
                            if (!Directory.Exists(SavePath))
                            {
                                Directory.CreateDirectory(SavePath);
                            }

                            string Extention = Path.GetExtension(FileUploadImage2.PostedFile.FileName);
                            FileUploadImage2.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "02" + Extention);

                            SqlCommand cmd4 = new SqlCommand("update ProductImages set Name = @Name, Extention =@Extention where PID = @PID ", cnx);
                            cmd4.Parameters.AddWithValue("@PID", PID);
                            cmd4.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "02");
                            cmd4.Parameters.AddWithValue("@Extention", Extention);

                            cmd4.ExecuteNonQuery();

                        }

                        //image03
                        if (FileUploadImage3.HasFile)
                        {
                            string SavePath = Server.MapPath("../assets/images/ProductImages/") + PID;
                            if (!Directory.Exists(SavePath))
                            {
                                Directory.CreateDirectory(SavePath);
                            }

                            string Extention = Path.GetExtension(FileUploadImage3.PostedFile.FileName);
                            FileUploadImage3.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "03" + Extention);

                            SqlCommand cmd5 = new SqlCommand("update ProductImages set Name = @Name, Extention =@Extention where PID = @PID", cnx);
                            cmd5.Parameters.AddWithValue("@PID", PID);
                            cmd5.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "03");
                            cmd5.Parameters.AddWithValue("@Extention", Extention);

                            cmd5.ExecuteNonQuery();

                            } 
                            //image04
                            if (FileUploadImage4.HasFile)
                            {
                                string SavePath = Server.MapPath("../assets/images/ProductImages/") + PID;
                                if (!Directory.Exists(SavePath))
                                {
                                    Directory.CreateDirectory(SavePath);
                                }

                                string Extention = Path.GetExtension(FileUploadImage4.PostedFile.FileName);
                                FileUploadImage4.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "04" + Extention);

                                SqlCommand cmd6 = new SqlCommand("update ProductImages set Name = @Name, Extention =@Extention where PID = @PID", cnx);
                                cmd6.Parameters.AddWithValue("@PID", PID);
                                cmd6.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "04");
                                cmd6.Parameters.AddWithValue("@Extention", Extention);

                                cmd6.ExecuteNonQuery();

                            }

                            //image05
                            if (FileUploadImage5.HasFile)
                            {
                                string SavePath = Server.MapPath("../assets/images/ProductImages/") + PID;
                                if (!Directory.Exists(SavePath))
                                {
                                    Directory.CreateDirectory(SavePath);
                                }

                                string Extention = Path.GetExtension(FileUploadImage5.PostedFile.FileName);
                                FileUploadImage5.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "05" + Extention);

                                SqlCommand cmd7 = new SqlCommand("update ProductImages set Name = @Name, Extention =@Extention where PID = @PID", cnx);
                                cmd7.Parameters.AddWithValue("@PID", PID);
                                cmd7.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "05");
                                cmd7.Parameters.AddWithValue("@Extention", Extention);

                                cmd7.ExecuteNonQuery();

                            }
                            cnx.Close();

                            Clear();
                            Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5\" role =\"alert\">" +
                                                "Product Added Successfuly" +
                                                "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +

                                                      "</div>");
                        }
                }
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MainCatID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select * from SubCategory where MainCatID = @MainCatID", cnx);
                cmd.Parameters.AddWithValue("@MainCatID", MainCatID);
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dt.Fill(tbl);

                if (tbl.Rows.Count != 0)
                {
                    ddlSubCategory.DataSource = tbl;
                    ddlSubCategory.DataTextField = "SubCatName";
                    ddlSubCategory.DataValueField = "SubCatID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Enabled = true;
                    ddlSubCategory.Items.Insert(0, new ListItem("-select subcategory-", "0"));
                }
                else
                {
                    ddlSubCategory.Items.Clear();
                    ddlSubCategory.Items.Insert(0, new ListItem("-No subcategory-", "0"));
                    ddlSubCategory.Enabled = false;
                }

            }
        }

        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sizes();
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedIndex > 0 && ddlCategory.SelectedIndex > 0 && ddlSubCategory.SelectedIndex > 0)
            {
                ddlGender.Enabled = true;
            }
        }

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedIndex > 0 && ddlCategory.SelectedIndex > 0 && ddlSubCategory.SelectedIndex > 0)
            {
                ddlGender.Enabled = true;
            }
        }

        private void Clear()
        {
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtSellingPrice.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtProductDetails.Text = string.Empty;
            txtMaterialsAndCare.Text = string.Empty;
            txtQte.Text = string.Empty;

            cblSize.ClearSelection();

            ddlBrand.ClearSelection();
            ddlBrand.Items.FindByValue("0").Selected = true;

            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByValue("0").Selected = true;

            ddlSubCategory.ClearSelection();
            ddlSubCategory.Items.FindByValue("0").Selected = true;

            ddlGender.ClearSelection();
            ddlSubCategory.Items.Insert(0, new ListItem("-No subcategory-", "0"));

        }

        private bool isformValid()
        {
            if (ddlBrand.SelectedIndex <= 0)
            {
                lblBrandErr.Text = "Please chose brand";
                return false;
            }
            else
            {
                lblBrandErr.Text = "";
            }
            if (ddlCategory.SelectedIndex <= 0)
            {
                lblCategoryErr.Text = "Please chose category";
                return false;
            }
            else
            {
                lblCategoryErr.Text = "";
            }

            if (ddlSubCategory.SelectedIndex <= 0)
            {
                lblSubCategoryErr.Text = "Please chose subcategory";
                return false;
            }
            else
            {
                lblSubCategoryErr.Text = "";
            }

            if (ddlGender.SelectedIndex <= 0)
            {
                lblGenderErr.Text = "Please chose gender";
                return false;
            }
            else
            {
                lblGenderErr.Text = "";
            }

            return true;
        }

        private void BindBrand()
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Brands", cnx);
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dt.Fill(tbl);

                if (tbl.Rows.Count != 0)
                {
                    ddlBrand.DataSource = tbl;
                    ddlBrand.DataTextField = "BrandName";
                    ddlBrand.DataValueField = "BrandID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("-select brand-", "0"));
                }

            }
        }

        private void BindCategory()
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Category", cnx);
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dt.Fill(tbl);

                if (tbl.Rows.Count != 0)
                {
                    ddlCategory.DataSource = tbl;
                    ddlCategory.DataTextField = "CatName";
                    ddlCategory.DataValueField = "CatID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-select category-", "0"));
                }

            }
        }

        private void BindGender()
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Gender with(nolock)", cnx);
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dt.Fill(tbl);

                if (tbl.Rows.Count != 0)
                {
                    ddlGender.DataSource = tbl;
                    ddlGender.DataTextField = "GenderName";
                    ddlGender.DataValueField = "GenderID";
                    ddlGender.DataBind();
                    ddlGender.Items.Insert(0, new ListItem("-select gender-", "0"));
                }

            }
        }

        private void Sizes()
        {
            int BrandID = Convert.ToInt32(ddlBrand.SelectedItem.Value);
            int CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            int SubCateID = Convert.ToInt32(ddlSubCategory.SelectedItem.Value);
            int GenderID = Convert.ToInt32(ddlGender.SelectedItem.Value);

            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Sizes where BrandID = @BrandID and CategoryID = @CatID  and SubCateID = @SubCatID and GenderID = @GenderID  ", cnx);
                cmd.Parameters.AddWithValue("@BrandID", BrandID);
                cmd.Parameters.AddWithValue("@CatID", CategoryID);
                cmd.Parameters.AddWithValue("@SubCatID", SubCateID);
                cmd.Parameters.AddWithValue("@GenderID", GenderID);

                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dt.Fill(tbl);

                if (tbl.Rows.Count != 0)
                {
                    cblSize.Items.Clear();
                    cblSize.DataSource = tbl;
                    cblSize.DataTextField = "SizeName";
                    cblSize.DataValueField = "SizeID";
                    cblSize.DataBind();
                    
                }
                else
                {
                    cblSize.Items.Clear();
                    cblSize.Items.Insert(0, new ListItem("-No Size To chose-", "0"));
                }

            }
        }

        private void subcategory()
        {
            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("Select * from SubCategory where MainCatID='" + ddlCategory.SelectedValue + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count != 0)
                {
                    ddlSubCategory.DataSource = dt;
                    ddlSubCategory.DataTextField = "SubCatName";
                    ddlSubCategory.DataValueField = "SubCatID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }

        protected void txtProductID_TextChanged(object sender, EventArgs e)
        {
            if(txtProductID.Text != "" && Int32.TryParse(txtProductID.Text, out int value))
            {

                SqlConnection con = new SqlConnection(cnxStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("getProductData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", Convert.ToInt32(txtProductID.Text));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    PName = ds.Tables[0].Rows[0]["PName"].ToString();
                    txtProductName.Text = PName;

                    PPrice = ds.Tables[0].Rows[0]["PPrice"].ToString();
                    txtPrice.Text = PPrice;

                    PSelPrice = ds.Tables[0].Rows[0]["PSelPrice"].ToString();
                    txtSellingPrice.Text = PSelPrice;

                    //////////////////////////
                    BrandID = ds.Tables[0].Rows[0]["PBrandID"].ToString();
                    BindBrand();
                    ddlBrand.SelectedValue = BrandID;


                    MainCID = ds.Tables[0].Rows[0]["PCategory"].ToString();
                    BindCategory();
                    ddlCategory.SelectedValue = MainCID;

                    SubCID = ds.Tables[0].Rows[0]["PSubCategory"].ToString();
                    subcategory();
                    ddlSubCategory.SelectedValue = SubCID;

                    GenderID = ds.Tables[0].Rows[0]["PGender"].ToString();
                    BindGender();
                    ddlGender.SelectedValue = GenderID;

                    Sizes();

                    /////////////////////////////////////////////
                    Quantity = ds.Tables[0].Rows[0]["Quantity"].ToString();
                    txtQte.Text = Quantity;

                    //////////////////////////////////////////////
                    PDescription = ds.Tables[0].Rows[0]["PDescription"].ToString();
                    txtDescription.Text = PDescription;

                    PProductDetails = ds.Tables[0].Rows[0]["PProductDetails"].ToString();
                    txtProductDetails.Text = PProductDetails;

                    PMaterialCare = ds.Tables[0].Rows[0]["PMaterialCare"].ToString();
                    txtMaterialsAndCare.Text = PMaterialCare;

                    ///////////////////////////////////////////////
                    FreeDelivery = ds.Tables[0].Rows[0]["FreeDelivery"].ToString();
                    if (FreeDelivery == "1")
                    {
                        cbFreeDelivery.Checked = true;
                    }
                    else
                    {
                        cbFreeDelivery.Checked = false;
                    }

                    DayRet = ds.Tables[0].Rows[0]["30DayRet"].ToString();
                    if (DayRet == "1")
                    {
                        cb30DaysReturn.Checked = true;
                    }
                    else
                    {
                        cb30DaysReturn.Checked = false;
                    }

                    COD = ds.Tables[0].Rows[0]["COD"].ToString();
                    if (COD == "1")
                    {
                        cbCOD.Checked = true;
                    }
                    else
                    {
                        cbCOD.Checked = false;


                    }
                        btnUpdatePoduct.Enabled = true;
                }
                else
                {
                    btnUpdatePoduct.Enabled = false;
                    Clear();
                }
                con.Close();
            }


        }
        
    }
}