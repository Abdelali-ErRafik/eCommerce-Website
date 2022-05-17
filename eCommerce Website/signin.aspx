<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="eCommerce_Website.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>SignIn</title>    
        <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" />
        <link href="assets/css/main.css" rel="stylesheet" />
</head>
<body>
         <form id="form1" runat="server">
        <!-- Start SignUp form-->
        <section class="background-radial-gradient overflow-hidden ">
          <div class="container px-4 py-5 px-md-5 text-center text-lg-start my-5">
            <div class="row gx-lg-5 justify-content-center align-items-center mb-5">

              <div class="col-lg-6 mb-5 mb-lg-0 position-relative">
                <div id="radius-shape-1" class="position-absolute rounded-circle shadow-5-strong"></div>
                <div id="radius-shape-2" class="position-absolute shadow-5-strong"></div>

                <div class="card bg-glass">
                  <div class="card-body px-4 py-5 px-md-5">
                      <!-- 2 column grid layout with text inputs for the first and last names -->
                    <div class="row ">                            
                        <div class="form-outline mb-4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" ErrorMessage="Please enter user name" ControlToValidate="txtUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtUserName" class="form-control" runat="server" ></asp:TextBox>
                            <asp:Label class="form-label" ID="lblUserName" runat="server" >User Name</asp:Label>
                        </div>

                        <div class="form-outline mb-4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Please enter your password" ControlToValidate="txtPass" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtPass" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:Label class="form-label" ID="lblPass" runat="server" >Password</asp:Label>
                        </div>       
                        
                       <div class="d-flex justify-content-around align-items-center mb-4">
                        <!-- Checkbox -->
                        <div class="form-check">
                            <asp:CheckBox type="checkbox" ID="cbxRemamber" runat="server" checked/>
                            <label class="form-check-label" for="form1Example3"> Remember me </label>
                        </div>
                           <asp:LinkButton ID="lnkForgetPass" runat="server" CssClass="text-muted" PostBackUrl="~/forgotpassword.aspx">Forgot password?</asp:LinkButton>
                      </div>

                      <div class="d-grid gap-2 mb-4">
                        <asp:Button ID="btnLogin" class="btn btn-primary btn-block gradient-custom-2" runat="server" Text="LogIn" OnClick="btnLogin_Click"  />
                       </div>
                        
                      <div class="d-flex align-items-center justify-content-center pb-4">
                        <p class="mb-0 me-2">Don't have an account?</p>
                        <a type="button"  href="SignUp.aspx" class="btn btn-outline-danger">
                           Create new
                        </a>
                      </div>

                      <!-- Register buttons -->
                      <div class="text-center">
                        <p>or sign up with:</p>
                        <button type="button" class="btn btn-link btn-floating mx-1 ">
                          <i class="fab fa-facebook-f"></i>
                        </button>

                        <button type="button" class="btn btn-link btn-floating mx-1">
                          <i class="fab fa-google"></i>
                        </button>

                        <button type="button" class="btn btn-link btn-floating mx-1">
                          <i class="fab fa-twitter"></i>
                        </button>

                        <button type="button" class="btn btn-link btn-floating mx-1">
                          <i class="fab fa-github"></i>
                        </button>
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
