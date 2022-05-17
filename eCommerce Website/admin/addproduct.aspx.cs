using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eCommerce_Website.admin
{
    public partial class addproduct : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
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

            }
        }

        protected void btnAddPoduct_Click(object sender, EventArgs e)
        {
            if (isformValid())
            {
                using (SqlConnection cnx = new SqlConnection(cnxStr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertProduct", cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
                        Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());

                        //Quantity
                        for(int i=0; i < cblSize.Items.Count; i++)
                        {
                            Int64 SizeID = Convert.ToInt64(cblSize.Items[i].Value);
                            int Qte = Convert.ToInt32(txtQte.Text);


                            SqlCommand cmd2 = new SqlCommand("insert into ProductsSizeQuantity values(@PID, @SizeID, @Quantity) ", cnx);
                            cmd2.Parameters.AddWithValue("@PID",PID);
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

                            SqlCommand cmd3 = new SqlCommand("insert into ProductImages values(@PID, @Name, @Extention) ", cnx);
                            cmd3.Parameters.AddWithValue("@PID", PID);
                            cmd3.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim()+"01");
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
                            FileUploadImage2.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "02"+ Extention);

                            SqlCommand cmd4 = new SqlCommand("insert into ProductImages values(@PID, @Name, @Extention) ", cnx);
                            cmd4.Parameters.AddWithValue("@PID", PID);
                            cmd4.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim()+"02");
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

                            SqlCommand cmd5 = new SqlCommand("insert into ProductImages values(@PID, @Name, @Extention) ", cnx);
                            cmd5.Parameters.AddWithValue("@PID", PID);
                            cmd5.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim()+"03");
                            cmd5.Parameters.AddWithValue("@Extention", Extention);

                            cmd5.ExecuteNonQuery();

                        } //image04
                        if (FileUploadImage4.HasFile)
                        {
                            string SavePath = Server.MapPath("../assets/images/ProductImages/") + PID;
                            if (!Directory.Exists(SavePath))
                            {
                                Directory.CreateDirectory(SavePath);
                            }

                            string Extention = Path.GetExtension(FileUploadImage4.PostedFile.FileName);
                            FileUploadImage4.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "04" + Extention);

                            SqlCommand cmd6 = new SqlCommand("insert into ProductImages values(@PID, @Name, @Extention) ", cnx);
                            cmd6.Parameters.AddWithValue("@PID", PID);
                            cmd6.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim()+"04");
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
                            FileUploadImage5.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "05"+ Extention);

                            SqlCommand cmd7 = new SqlCommand("insert into ProductImages values(@PID, @Name, @Extention) ", cnx);
                            cmd7.Parameters.AddWithValue("@PID", PID);
                            cmd7.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim()+"05");
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

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedIndex > 0 && ddlCategory.SelectedIndex > 0 && ddlSubCategory.SelectedIndex > 0)
            {
                ddlGender.Enabled = true;
            }
        }

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlBrand.SelectedIndex>0 && ddlCategory.SelectedIndex > 0 && ddlSubCategory.SelectedIndex > 0)
            {
                ddlGender.Enabled = true;
            }
        }

        private void Clear()
        {
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


    }
}