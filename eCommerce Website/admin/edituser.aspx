<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="edituser.aspx.cs" Inherits="eCommerce_Website.admin.edituser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 class="text-center mt-4">Edit User</h2>
      <section>
                <div class="card shadow mb-4">
                    <div class="card-header">
                    Admin Details
                    </div>
                    <div class="card-body">
                        <%--  --%>
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2  text-lg-end ">
                                <asp:Label ID="lblUserID" runat="server" Text="User ID" CssClass="form-label"></asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtUserID" runat="server"  CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUserID_TextChanged" ></asp:TextBox>
                            </div>                    
                            <div class="col-md-2">
                                <asp:RequiredFieldValidator ID="ControlToValidatetxtUserID" runat="server" ErrorMessage="Please Enter User ID" ControlToValidate="txtUserID" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </div>
                         </div>                          
                        <%--  --%>
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2  text-lg-end ">
                                <asp:Label ID="lblUserName" runat="server" Text="User Name" CssClass="form-label"></asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtUserName" runat="server"  CssClass="form-control"></asp:TextBox>
                            </div>                    
                            <div class="col-md-2">
                                <asp:RequiredFieldValidator ID="ControlToValidateUserName" runat="server" ErrorMessage="Please Enter User Name" ControlToValidate="txtUserName" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </div>
                         </div>  
                           <%--  --%>                        <%--  --%>
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                             <div class="col-md-2  text-lg-end ">
                                <asp:Label ID="lblFullName" runat="server" Text="Full Name" CssClass="form-label"></asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtFullName" runat="server"  CssClass="form-control " ></asp:TextBox>
                            </div>                    
                            <div class="col-md-2">
                                <asp:RequiredFieldValidator ID="ControlToValidateFullName" runat="server" ErrorMessage="Please Enter Full Name" ControlToValidate="txtFullName" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </div>
                         </div>  
                           <%--  --%>                     
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2  text-lg-end ">
                                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtEmail" runat="server"  CssClass="form-control"    ></asp:TextBox>
                            </div>                    
                            <div class="col-md-2">
                                <asp:RequiredFieldValidator ID="ControlToValidateEmail" runat="server" ErrorMessage="Please Enter User Email" ControlToValidate="txtEmail" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </div>
                         </div>  
                           <%--  --%>                    
                        <div class="row g-2 align-items-cente justify-content-start ">   
                            <div class="col-md-2  text-lg-end ">
                                <asp:Label ID="lblPass" runat="server" Text="Password" CssClass="form-label"></asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtPass"  runat="server" CssClass="form-control"   ></asp:TextBox>
                            </div>                    
                            <div class="col-md-2">
                                <asp:RequiredFieldValidator ID="ControlToValidatePass" runat="server" ErrorMessage="Please Enter User Password" ControlToValidate="txtPass" ForeColor="Red" ></asp:RequiredFieldValidator>
                            </div>
                         </div>  
                           <%--  --%>                        
                        <div class="row g-2 align-items-cente justify-content-start">   
                            <div class="col-md-2  text-lg-end ">
                                <asp:Label ID="lblConPass" runat="server" Text="Confirme Password" CssClass="form-label"></asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtConPass"  runat="server" CssClass="form-control"  ></asp:TextBox>
                            </div>                    
                            <div class="col-md-2">
                                <asp:RequiredFieldValidator ID="ControlToValidateConPass" runat="server" ErrorMessage="Please Enter Confirme Password" ControlToValidate="txtConPass" ForeColor="Red" ></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidatorConPass" runat="server" ErrorMessage="Confirme Password Is Not Valid" ControlToValidate="txtConPass" ControlToCompare="txtPass" ForeColor="Red"></asp:CompareValidator>
                            </div>
                         </div>  
                           <%--  --%>
                            

                        <div class="row g-2 align-items-cente justify-content-start ">   
                            <div class="col-md-2">
                            </div>                             
                            <div class="col-md-10">
                                <asp:Button ID="BtnUpdateUser" CssClass="btn btn-primary gradient-custom-2" runat="server" Text="Update User"  OnClick="BtnUpdateUser_Click"  />
                            </div>
                        </div>
                    </div>
                </div>
          </section>
</asp:Content>
