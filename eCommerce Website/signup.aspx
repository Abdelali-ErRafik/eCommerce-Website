<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="eCommerce_Website.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>SignUp</title>    
        <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" />
        <link href="assets/css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Start SignUp form-->
        <section class="background-radial-gradient overflow-hidden ">
          <div class="container px-4 py-5 px-md-5 text-center text-lg-start my-5">
            <div class="row gx-lg-5 align-items-center mb-5">
              <div class="col-lg-6 mb-5 mb-lg-0" style="z-index: 10">
                <h1 class="my-5 display-5 fw-bold ls-tight" style="color: hsl(218, 81%, 95%)">
                  The best offer <br />
                  <span style="color: hsl(218, 81%, 75%)">for your business</span>
                </h1>
                <p class="mb-4 opacity-70" style="color: hsl(218, 81%, 85%)">
                  Lorem ipsum dolor, sit amet consectetur adipisicing elit.
                  Temporibus, expedita iusto veniam atque, magni tempora mollitia
                  dolorum consequatur nulla, neque debitis eos reprehenderit quasi
                  ab ipsum nisi dolorem modi. Quos?
                </p>
              </div>

              <div class="col-lg-6 mb-5 mb-lg-0 position-relative">
                <div id="radius-shape-1" class="position-absolute rounded-circle shadow-5-strong"></div>
                <div id="radius-shape-2" class="position-absolute shadow-5-strong"></div>

                <div class="card bg-glass">
                  <div class="card-body px-4 py-5 px-md-5">
                      <!-- 2 column grid layout with text inputs for the first and last names -->
                    <div class="row ">
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <asp:TextBox ID="txtUserName" class="form-control" runat="server"></asp:TextBox>
                                <asp:Label class="form-label" ID="lblUserName" runat="server">User Name</asp:Label>
                            </div>
                            </div>

                            <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <asp:TextBox ID="txtFullName" class="form-control" runat="server"></asp:TextBox>
                                <asp:Label class="form-label" ID="lblFullName" runat="server" >Full Name</asp:Label>
                            </div>
                            </div>
                            

                        <div class="form-outline mb-4">
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                            <asp:Label class="form-label" ID="lblEmail" runat="server" >Email address</asp:Label>
                        </div>

                        <div class="form-outline mb-4">
                            <asp:TextBox ID="txtPass" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:Label class="form-label" ID="lblPass" runat="server" >Password</asp:Label>
                        </div>            
            
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="txtConPass" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:Label class="form-label" ID="lblConPass" runat="server" >Confirm Password</asp:Label>
                        </div>                        
                      
                      <div class="d-grid gap-2 mb-4">
                        <asp:Button ID="btnRegister" class="btn btn-primary btn-block gradient-custom-2" runat="server" Text="SignUp" OnClick="btnRegister_Click"  />
                       </div>

                      <div class="d-flex align-items-center justify-content-center pb-4">
                        <p class="mb-0 me-2">already have an account?</p>
                        <a type="button"  href="SignIn.aspx" class="btn btn-outline-danger">
                           Login
                        </a>
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
