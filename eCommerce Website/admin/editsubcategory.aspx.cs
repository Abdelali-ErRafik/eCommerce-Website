using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace eCommerce_Website.admin
{
    public partial class editsubcategory : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        string ID = "";
        string SCName = "";
        string MainCID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdateSubCategory.Enabled = false;
            if (Request.QueryString["subcatid"] != null)
            {
                txtSubCategoryID.Text = Request.QueryString["subcatid"];
            }
        }

        protected void txtSubCategoryID_TextChanged(object sender, EventArgs e)
        {
            if(txtSubCategoryID.Text != "")
            {
                    SqlConnection con = new SqlConnection(cnxStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("select SubCatID,SubCatName,MainCatID from SubCategory where SubCatID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtSubCategoryID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "dt");
                con.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {

                    ID = ds.Tables[0].Rows[0]["SubCatID"].ToString();
                    SCName = ds.Tables[0].Rows[0]["SubCatName"].ToString();
                    MainCID = ds.Tables[0].Rows[0]["MainCatID"].ToString();
                    BindMainCat();
                    txtSubCategory.Text = SCName;
                    btnUpdateSubCategory.Enabled = true;

                }
                else
                {
                    ID = "";
                    SCName = "";
                    MainCID = "";
                    btnUpdateSubCategory.Enabled = false;
                }
                con.Close();

            }

        }

        private void BindMainCat()
        {
            using (SqlConnection con = new SqlConnection(cnxStr))
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("Select * from Category", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count != 0)
                {
                    ddlMainCategory.DataSource = dt;
                    ddlMainCategory.DataTextField = "CatName";
                    ddlMainCategory.DataValueField = "CatID";
                    ddlMainCategory.DataBind();
                    ddlMainCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                    ddlMainCategory.SelectedValue = MainCID;

                }
            }
        }

        protected void btnUpdateSubCategory_Click(object sender, EventArgs e)
        {
            if (txtSubCategoryID.Text != string.Empty && txtSubCategory.Text != string.Empty && ddlMainCategory.SelectedIndex != -1)
            {
                SqlConnection con = new SqlConnection(cnxStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("update SubCategory set SubCatName=@SCN , MainCatID=@MCI where SubCatID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtSubCategoryID.Text));
                cmd.Parameters.AddWithValue("@MCI", ddlMainCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@SCN", txtSubCategory.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-fixed bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                "SubCategory Updated Successfully " +
                "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                "</div>"); ;

                txtSubCategoryID.Text = string.Empty;
                ddlMainCategory.SelectedIndex = -1;
                txtSubCategory.Text = string.Empty;
            }

        }
    }

}