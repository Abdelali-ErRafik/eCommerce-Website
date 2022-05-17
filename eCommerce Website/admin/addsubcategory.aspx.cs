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
    public partial class subcategory : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindMainCat();

            }

        }

        protected void btnAddSubCategory_Click(object sender, EventArgs e)
        {
            if(DdlCategoryID.SelectedIndex  > 0) { 
                using (SqlConnection cnx = new SqlConnection(cnxStr))
                {
                    SqlCommand cmd = new SqlCommand("insert into SubCategory(SubCatName,MainCatID) values(@subcat,@maincatid)", cnx);
                    cmd.Parameters.AddWithValue("@subcat", txtSubCategory.Text);
                    cmd.Parameters.AddWithValue("@maincatid", DdlCategoryID.SelectedItem.Value);

                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();

                    txtSubCategory.Text = string.Empty;
                    DdlCategoryID.ClearSelection();
                    DdlCategoryID.Items.FindByValue("0").Selected = true;

                  

                    Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                                        "SubCategory Added Successfuly" +
                                        "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                                     "</div>");
                }
            }else
            {
                lblMsg.Text = "No Category Chosed";
            }

        }

        private void BindMainCat()
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Category", cnx);
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                dt.Fill(tbl);

                if (tbl.Rows.Count != 0)
                {
                    DdlCategoryID.DataSource = tbl;
                    DdlCategoryID.DataTextField = "CatName";
                    DdlCategoryID.DataValueField = "CatID";
                    DdlCategoryID.DataBind();
                    DdlCategoryID.Items.Insert(0, new ListItem("-select-", "0"));
                }

            }
        }
    }
}