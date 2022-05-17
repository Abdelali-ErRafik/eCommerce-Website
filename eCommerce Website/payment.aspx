<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="eCommerce_Website.payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/payment.css" rel="stylesheet" />
    <div class="container mt-5 px-5">
            <asp:HiddenField ID="HdCartAmount" runat="server"  />
            <asp:HiddenField ID="HdCartDiscount" runat="server"  />
            <asp:HiddenField ID="HdTotalPayed" runat="server"/>
            <asp:HiddenField ID="HdPidSize" runat="server"  />

            <div class="mb-4">

                <h2>Confirm order and pay</h2>
            <span>please make the payment, after that you can enjoy all the features and benefits.</span>
                
            </div>

        <div class="row">

            <div class="col-md-8">
               
                <div class="card p-3">
                    <div class="mt-4 mb-4">
                        <h6 class="text-uppercase">Delivery Address</h6>
                        <div class="row mt-3">
                            <div class="col-md-6">
                                <div class="inputbox mt-3 mr-2"> 
                                    <asp:TextBox ID="txtName" runat="server" class="form-control" required="required"></asp:TextBox>
                                    <span>Name</span> 
                                </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Plese Enter Name" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                          </div>


                             <div class="col-md-6">
                                <div class="inputbox mt-3 mr-2"> 
                                    <asp:TextBox ID="txtAddress" runat="server" class="form-control" required="required"></asp:TextBox>
                                    <span>Address</span> 
                                </div>                            
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Plese Enter Address" ControlToValidate="txtAddress" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>


                            

                        </div>


                        <div class="row mt-2">
                            <div class="col-md-6">
                                <div class="inputbox mt-3 mr-2"> 
                                    <asp:TextBox ID="txtPinCode" runat="server" class="form-control" required="required"></asp:TextBox>
                                    <span>Pin Code</span> 
                                </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Plese Enter Pin Code" ControlToValidate="txtPinCode" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>


                             <div class="col-md-6">
                                <div class="inputbox mt-3 mr-2"> 
                                    <asp:TextBox ID="txtNumber" runat="server" class="form-control" required="required"></asp:TextBox>
                                    <span>Mobile Number</span> 
                                </div>                               
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Plese Enter Number" ControlToValidate="txtNumber" ForeColor="Red"></asp:RequiredFieldValidator>                                   
                            </div>
                        </div>
                    <div class="mt-4 mb-4 ">
                        <asp:Button ID="btnPay" runat="server" CssClass="btn btn-success px-3" Text="Pay" OnClick="btnPay_Click" />
                    </div>
                    </div>
                </div>


            </div>

            <div class="col-md-4">

                <div class="card card-blue p-3 text-white mb-3">

                   <span>You have to pay</span>
                    <div class="d-flex flex-row align-items-end mb-3">
                        <h1 class="mb-0 yellow">
                            <span  runat="server" id="pTotal">000Dh</span> Dh
                        </h1>
<%--                        <h1 class="mb-0 yellow" runat="server" id="pCartTotal">000Dh</h1> 
                        <h1 class="mb-0 yellow" runat="server" id="pDescount">000Dh</h1> --%>
                    </div>

                    <span>Enjoy all the features and perk after you complete the payment</span>

                    <div class="hightlight">

                        <span>100% Guaranteed support and update for the next 5 years.</span>
                        

                    </div>
                    
                </div>
                
            </div>
            
        </div>
          

      </div>
</asp:Content>
