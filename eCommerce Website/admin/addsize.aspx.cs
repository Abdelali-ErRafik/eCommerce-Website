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
    public partial class addsize : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategory();
                BindBrand();
                BindGender();
                ddlSubCategory.Items.Insert(0, new ListItem("-No subcategory-", "0"));

            }
        }

        protected void btnSize_Click(object sender, EventArgs e)
        {
            if (isformValid())
            {
                using (SqlConnection cnx = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("insert into Sizes(SizeName,CategoryID,SubCateID,BrandID,GenderID) values(@SizeName,@CategoryID,@SubCateID,@BrandID,@GenderID)", cnx);
                    cmd.Parameters.AddWithValue("@SizeName", txtSize.Text);
                    cmd.Parameters.AddWithValue("@CategoryID", ddlCategory.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@SubCateID", ddlSubCategory.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@BrandID", ddlBrand.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@GenderID", ddlGender.SelectedItem.Value);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();

                    Clear();

                    Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                                        "Size Added Successfuly" +
                                        "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                                     "</div>");
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
                    ddlSubCategory.Items.Insert(0, new ListItem("-select subcategory-", "0"));
                }else
                {
                    ddlSubCategory.Items.Clear();
                    ddlSubCategory.Items.Insert(0, new ListItem("-No subcategory-", "0"));
                }

            }
        }

        private void Clear()
        {
            txtSize.Text = string.Empty;

            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByValue("0").Selected = true;            
            
            ddlSubCategory.ClearSelection();
            ddlSubCategory.Items.FindByValue("0").Selected = true;            
            
            ddlBrand.ClearSelection();
            ddlBrand.Items.FindByValue("0").Selected = true;            
            
            ddlGender.ClearSelection();
            ddlSubCategory.Items.Insert(0, new ListItem("-No subcategory-", "0"));

        } 

        private bool isformValid()
        {
            if (ddlCategory.SelectedIndex <= 0)
            {
                lblCategoryErr.Text = "Please chose category";
                return false;
            }else
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

            if (ddlBrand.SelectedIndex <= 0)
            {
                lblBrandErr.Text = "Please chose brand";
                return false;
            }
            else
            {
                lblBrandErr.Text = "";
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