<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="eCommerce_Website.forgotpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Forgot Password</title>    
        <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" />
        <link href="assets/css/main.css" rel="stylesheet" />
</head>
<body>
         <form id="form1" runat="server">
        <!-- Start SignUp form-->
        <section class="background-radial-gradient overflow-hidden vh-100">
          <div class="container px-4 py-5 px-md-5 text-center text-lg-start my-5">
            <div class="row gx-lg-5  justify-content-center align-items-center mb-5">
              <div class="col-lg-6 mb-5 mb-lg-0 position-relative">
                <div id="radius-shape-1" class="position-absolute rounded-circle shadow-5-strong"></div>
                <div id="radius-shape-2" class="position-absolute shadow-5-strong"></div>
                <div class="card bg-glass">
                  <div class="card-body px-4 py-5 px-md-5">
                      <!-- 2 column grid layout with text inputs for the first and last names -->
                    <div class="row ">     
                        <h5 class="text-center">Please enter your email address</h5>
                        <div class="form-outline mb-4" style="height: 84px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Please enter your email adrress" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server" ></asp:TextBox>
                            <asp:Label class="form-label" ID="lblEmail" runat="server" >Email Adress</asp:Label>
                        </div>

                      <div class="d-grid gap-2 mb-4">
                        <asp:Button ID="btnForgetPass" class="btn btn-primary btn-block gradient-custom-2" runat="server" Text="Send" OnClick="btnForgetPass_Click" />
                          <asp:Label class="form-label" ID="lblResetPass" runat="server" ></asp:Label>
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
