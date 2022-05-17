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
    public partial class editsize : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        string BrandID = "";
        string SizeName = "";
        string MainCID = "";
        string SubCID = "";
        string GenderID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdateSize.Enabled = false;
            if (Request.QueryString["sizeid"] != null)
            {
                txtSizeID.Text = Request.QueryString["sizeid"];
            }
        }

        protected void txtSizeID_TextChanged(object sender, EventArgs e)
        {
            if(txtSizeID.Text != "" && Int32.TryParse(txtSizeID.Text, out int value))
            {
                    SqlConnection con = new SqlConnection(cnxStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("select SizeName,BrandID,CategoryID,SubCateID,GenderID from Sizes where SizeID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtSizeID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    BrandID = ds.Tables[0].Rows[0]["BrandID"].ToString();
                    BindBrand();
                    ddlBrand.SelectedValue = BrandID;

                    SizeName = ds.Tables[0].Rows[0]["SizeName"].ToString();
                    txtSize.Text = SizeName;
                    MainCID = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                    BindMainCategory();
                    ddlCategory.SelectedValue = MainCID;

                    SubCID = ds.Tables[0].Rows[0]["SubCateID"].ToString();
                    subcategory();
                    ddlSubCategory.SelectedValue = SubCID;

                    GenderID = ds.Tables[0].Rows[0]["GenderID"].ToString();
                    BindGender();
                    ddlGender.SelectedValue = GenderID;

                    btnUpdateSize.Enabled = true;
                }
                else
                {
                    btnUpdateSize.Enabled = false;
                }
                con.Close();

            }
        }

        protected void btnUpdateSize_Click(object sender, EventArgs e)
        {
            if (txtSizeID.Text != string.Empty && txtSize.Text != string.Empty && ddlCategory.SelectedIndex != -1)
            {
                SqlConnection con = new SqlConnection(cnxStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("update Sizes set SizeName=@SizeName,BrandID=@BrandID,CategoryID=@CategoryID,SubCateID=@SubCateID,GenderID=@GenderID where SizeID=@SizeID", con);
                cmd.Parameters.AddWithValue("@SizeID", Convert.ToInt32(txtSizeID.Text));
                cmd.Parameters.AddWithValue("@CategoryID", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@SubCateID", ddlSubCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@BrandID", ddlBrand.SelectedValue);
                cmd.Parameters.AddWithValue("@GenderID", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@SizeName", txtSize.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Update successfully')</script>");
                txtSizeID.Text = string.Empty;
                ddlBrand.SelectedIndex = -1;
                ddlCategory.SelectedIndex = -1;
                ddlSubCategory.SelectedIndex = -1;
                ddlGender.SelectedIndex = -1;
                txtSize.Text = string.Empty;
            }
        }

        private void BindBrand()
        {
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Brands", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlBrand.DataSource = dt;
                    ddlBrand.DataTextField = "BrandName";
                    ddlBrand.DataValueField = "BrandID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }

        private void BindMainCategory()
        {
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Category", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "CatName";
                    ddlCategory.DataValueField = "CatID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }

        private void BindGender()
        {
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Gender with(nolock)", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlGender.DataSource = dt;
                    ddlGender.DataTextField = "GenderName";
                    ddlGender.DataValueField = "GenderID";
                    ddlGender.DataBind();
                    ddlGender.Items.Insert(0, new ListItem("-Select-", "0"));

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

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);

            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from SubCategory where MainCatID='" + ddlCategory.SelectedValue + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
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
    }
}