using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace eCommerce_Website
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        string cnxStr = ConfigurationManager.ConnectionStrings["EDASHOPDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnForgetPass_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnx = new SqlConnection(cnxStr))
            {
                SqlCommand cmd = new SqlCommand("select * from Users where Email = @email", cnx);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                if(tbl.Rows.Count != 0)
                {
                    String myGuid = Guid.NewGuid().ToString();
                    int Uid = Convert.ToInt32(tbl.Rows[0][0]);
                    SqlCommand cmdf = new SqlCommand("insert into ForgotPassword(Id, Uid, RequestDataTime) values('"+myGuid+"', "+Uid+", getdate())",cnx);
                    cnx.Open();
                    cmdf.ExecuteNonQuery();
                    cnx.Close();

                    //Send Reset link to  email
                    string ToEmailAdress = tbl.Rows[0][3].ToString();
                    string Username = tbl.Rows[0][1].ToString();
                    string EmailBody = "Hi, "+Username+" <br/><br/>Click the link bellow to reset your password<br/> https://localhost:44348/recoverpassword.aspx?id=" + myGuid;
                    MailMessage PassRecMail = new MailMessage("abdelali.rafik01@gmail.com", ToEmailAdress);

                    PassRecMail.Body = EmailBody;
                    PassRecMail.IsBodyHtml = true;
                    PassRecMail.Subject = "Reset Password";

                    //New Methode
                    using(SmtpClient client = new SmtpClient())
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("abdelali.rafik01@gmail.com", "abdelali2016rafik");
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;

                        client.Send(PassRecMail);
                    }

                    //Old Methode
                    //SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
                    //SMTP.Credentials = new NetworkCredential()
                    //{
                    //      UserName = "abdelali.rafik01@gmail.com",
                    //      Password = "abdelali2016rafik"
                    //};
                    //SMTP.EnableSsl = true;
                    //SMTP.Send(PassRecMail);


                    //Send Reset link to  email
                    lblResetPass.Text = "Reset link send ! check your email for reset password";
                    lblResetPass.ForeColor = System.Drawing.Color.Green;
                    txtEmail.Text = string.Empty;

                }
                else
                {
                    lblResetPass.Text = "Non email adress like this";
                    lblResetPass.ForeColor = System.Drawing.Color.Red;
                    txtEmail.Text = string.Empty;
                    txtEmail.Focus();

                }
            }

        }
    }
}