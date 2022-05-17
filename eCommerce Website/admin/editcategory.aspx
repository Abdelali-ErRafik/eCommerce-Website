<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="editcategory.aspx.cs" Inherits="eCommerce_Website.editcategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h2 class="text-center mt-4">Edit Category</h2>
      <section>
                <div class="card shadow-sm mb-4">
                    <div class="card-header">
                    Category Details
                    </div>
                    <div class="card-body">
                        <%--  --%>
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2 text-lg-end ">
                                <asp:Label class="form-label" ID="lblCategoryID" runat="server" >Category ID</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtCategoryID" class="form-control " runat="server" OnTextChanged="txtCategoryID_TextChanged" AutoPostBack="true" ></asp:TextBox>
                            </div>                    
                            <div class="col-lg-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCatgoryID" runat="server" ErrorMessage="Please Enter CategoryID" ControlToValidate="txtCategoryID" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>                        
                        
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2 text-lg-end ">
                                <asp:Label class="form-label" ID="lblCategory" runat="server" >Category Name</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtCategory" class="form-control " runat="server" ></asp:TextBox>
                            </div>                    
                            <div class="col-lg-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" ErrorMessage="Please Enter Category Name" ControlToValidate="txtCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        
                        <%--  --%>
                        <div class="row g-2 align-items-cente justify-content-start">   
                            <div class="col-md-2">
                            </div>                             
                            <div class="col-md-10">
                                <asp:Button ID="btnUpdateCategory" CssClass="btn btn-primary gradient-custom-2" runat="server" Text="Update Category" OnClick="btnUpdateCategory_Click"   />
                            </div>
                        </div>
                    </div>
                </div>

        </section>
</asp:Content>
