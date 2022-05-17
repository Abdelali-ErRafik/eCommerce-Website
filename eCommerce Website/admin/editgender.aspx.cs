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
    public partial class editgender : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdateGender.Enabled = false;
            if (Request.QueryString["genderid"] != null)
            {
                txtGenderID.Text = Request.QueryString["genderid"];

            }
        }

        protected void txtGenderID_TextChanged(object sender, EventArgs e)
        {
            if (txtGenderID.Text != "" && Int32.TryParse(txtGenderID.Text, out int value))
            {
                SqlConnection con = new SqlConnection(cnxStr);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("select GenderName from Gender where GenderID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtGenderID.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "dt");
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnUpdateGender.Enabled = true;
                    txtGender.Text = ds.Tables[0].Rows[0]["GenderName"].ToString();

                }
                else
                {
                    btnUpdateGender.Enabled = false;
                    txtGender.Text = string.Empty;
                }
                con.Close();

            }

         
        }

        protected void btnUpdateGender_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cnxStr);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("update Gender set GenderName=UPPER(@Name) where GenderID=@ID", con);
            cmd.Parameters.AddWithValue("@Name", txtGender.Text);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtGenderID.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5\" role=\"alert\">" +
                    "Gender Updated1`    successfully" +
                    "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                 "</div>");
            txtGenderID.Text = string.Empty;
            txtGender.Text = string.Empty;
        }
    }
}