<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="editgender.aspx.cs" Inherits="eCommerce_Website.editgender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 class="text-center mt-4">Edit Gender</h2>
      <section>
                <%--  --%>
                <div class="card shadow-sm mb-4">
                    <div class="card-header">
                    Gender Details
                    </div>
                    <div class="card-body">
                        
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2  text-lg-end ">
                                <asp:Label class="form-label" ID="lblGenderID" runat="server" >Gender ID</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtGenderID" class="form-control " runat="server"  AutoPostBack="true" OnTextChanged="txtGenderID_TextChanged" ></asp:TextBox>
                            </div>                    
                            <div class="col-md-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorGenderID" runat="server" ErrorMessage="Please Enter ID" ControlToValidate="txtGenderID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div> 

                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2  text-lg-end">
                                <asp:Label class="form-label" ID="lblGender" runat="server" >Gender Name</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtGender" class="form-control " runat="server" ></asp:TextBox>
                            </div>                    
                            <div class="col-lg-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ErrorMessage="Please Enter Gender Name" ControlToValidate="txtGender" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        
                        <%--  --%>
                        <div class="row g-2 align-items-cente justify-content-start">   
                            <div class="col-md-2">
                            </div>                             
                            <div class="col-md-10">
                                <asp:Button ID="btnUpdateGender" CssClass="btn btn-primary gradient-custom-2" runat="server" Text="Update Gender" OnClick="btnUpdateGender_Click"  />
                            </div>
                        </div>
                    </div>
                </div>


        </section>
</asp:Content>
