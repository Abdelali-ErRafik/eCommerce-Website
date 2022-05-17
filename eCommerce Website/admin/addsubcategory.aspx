<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="addsubcategory.aspx.cs" Inherits="eCommerce_Website.admin.subcategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h2 class="text-center mt-4">Add SubCategory</h2>
      <section>
                <div class="card shadow-sm mb-4">
                    <div class="card-header">
                    SubCategory Details
                    </div>
                    <div class="card-body">
                        <%--  --%>
                          <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2 text-lg-end">
                                <asp:Label class="form-label" ID="lblMainCategoryID" runat="server" >Main CategoryID</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:DropDownList ID="DdlCategoryID" CssClass="form-control"  runat="server"></asp:DropDownList>
                            </div>                    
                            <div class="col-lg-2">
                                <asp:Label class="form-label" ID="lblMsg" runat="server" ForeColor="Red" ></asp:Label>
                            </div>
                        </div>

                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2  text-lg-end">
                                <asp:Label class="form-label" ID="lblSubCategory" runat="server" >SubCategory Name</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtSubCategory" class="form-control " runat="server" ></asp:TextBox>
                            </div>                    
                            <div class="col-lg-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategory" runat="server" ErrorMessage="Please Enter SubCategory Name" ControlToValidate="txtSubCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        
                        <%--  --%>
                        <div class="row g-2 align-items-cente justify-content-start">   
                            <div class="col-md-2">
                            </div>                             
                            <div class="col-md-10">
                                <asp:Button ID="btnAddSubCategory" class="btn btn-primary gradient-custom-2" runat="server" Text="Add SubCategory" OnClick="btnAddSubCategory_Click"  />
                            </div>
                        </div>

                    </div>
                </div>

        </section>
</asp:Content>
