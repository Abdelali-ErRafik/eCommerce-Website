﻿using System;
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
    public partial class addgender : System.Web.UI.Page
    {

        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddGender_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("insert into Gender(GenderName) values(@gender)", cnx);
                cmd.Parameters.AddWithValue("@gender", txtGender.Text);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();

                txtGender.Text = string.Empty;

                Response.Write("<div style=\"z-index:10000;\" class=\"alert alert-success alert-dismissible fade show position-absolute bottom-0 start-50 translate-middle-x mb-5 \" role=\"alert\">" +
                                    "Gender Added Successfuly" +
                                    "<button type= \"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>" +
                                 "</div>");
            }
        }
    }
}