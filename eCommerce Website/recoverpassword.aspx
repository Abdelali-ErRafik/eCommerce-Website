<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recoverpassword.aspx.cs" Inherits="eCommerce_Website.recoverpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Recover Password</title>    
        <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" />
        <link href="assets/css/main.css" rel="stylesheet" />
</head>
<body>
         <form id="form1" runat="server">
        <!-- Start SignUp form-->
        <section class="background-radial-gradient overflow-hidden vh-100 ">
          <div class="container px-4 py-5 px-md-5 text-center text-lg-start my-5">
            <div class="row gx-lg-5 justify-content-center align-items-center mb-5">
              <div class="col-lg-6 mb-5 mb-lg-0 position-relative">
                <div id="radius-shape-1" class="position-absolute rounded-circle shadow-5-strong"></div>
                <div id="radius-shape-2" class="position-absolute shadow-5-strong"></div>

                <div class="card bg-glass">
                  <div class="card-body px-4 py-5 px-md-5">
                    <div class="row ">   
                        <asp:Label class="form-label" ID="lblmsg" runat="server">Your Password reset link is expired or invalid... try again</asp:Label>
                        <div class="form-outline mb-4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Please enter your password" ControlToValidate="txtPass" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtPass" class="form-control" runat="server" TextMode="Password" Visible="False"></asp:TextBox>
                            <asp:Label class="form-label" ID="lblPass" runat="server" Visible="False" >Password</asp:Label>
                        </div>            
            
                        <div class="form-outline mb-4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCofirmePassword" runat="server" ErrorMessage="Please enter your confirme password" ControlToValidate="txtConPass" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtConPass" class="form-control" runat="server" TextMode="Password" Visible="False"></asp:TextBox>
                            <asp:Label class="form-label" ID="lblConPass" runat="server" Visible="False" >Confirm Password</asp:Label>
                            <br/>
                            <asp:CompareValidator ID="CompareValidatorPassword" ErrorMessage="Your Confirm Password Is Not Valid" runat="server" ControlToCompare="txtPass" ControlToValidate="txtConPass" ForeColor="Red"></asp:CompareValidator>
                            
                        </div>  

                      <div class="d-grid gap-2 mb-4">
                        <asp:Button ID="btnReset" class="btn btn-primary btn-block gradient-custom-2" runat="server" Text="Reset Your Password" Visible="False" OnClick="btnReset_Click"  />
                       </div>
                        
                  </div>
                </div>
              </div>
          </div>
        </section>
        <!-- End SignUp form-->
        </form>


        <%--  --%>
        <script src="assets/js/bootstrap.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js" ></script>
        <script src="assets/js/main.js"></script>
</body>
</html>
