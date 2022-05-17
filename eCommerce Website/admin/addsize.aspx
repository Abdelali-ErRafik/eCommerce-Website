<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="addsize.aspx.cs" Inherits="eCommerce_Website.admin.addsize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <h2 class="text-center mt-4">Add Size</h2>
      <section>
                <div class="card shadow-sm mb-4">
                    <div class="card-header">
                    Size Details
                    </div>
                    <div class="card-body">
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2  text-lg-end">
                                <asp:Label class="form-label" ID="lblSize" runat="server" >Size Name</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtSize" class="form-control " runat="server" ></asp:TextBox>
                            </div>                    
                            <div class="col-lg-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSize" runat="server" ErrorMessage="Please Enter Size Name" ControlToValidate="txtSize" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>               
                
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2 text-lg-end">
                                <asp:Label class="form-label" ID="lblCategory" runat="server" >Category</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlCategory" CssClass="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                            </div>                    
                            <div class="col-lg-2">
                                <asp:Label class="form-label" ID="lblCategoryErr" runat="server" ForeColor="Red" ></asp:Label>
                            </div>
                        </div>                
                
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2 text-lg-end">
                                <asp:Label class="form-label" ID="lblSubCategory" runat="server" >SubCategory</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlSubCategory" CssClass="form-control"  runat="server"></asp:DropDownList>
                            </div>                    
                            <div class="col-lg-2">
                                <asp:Label class="form-label" ID="lblSubCategoryErr" runat="server" ForeColor="Red" ></asp:Label>
                            </div>
                        </div>                
                
                
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2 text-lg-end">
                                <asp:Label class="form-label" ID="lblBrand" runat="server" >Brand</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlBrand" CssClass="form-control"  runat="server"></asp:DropDownList>
                            </div>                    
                            <div class="col-lg-2">
                                <asp:Label class="form-label" ID="lblBrandErr" runat="server" ForeColor="Red" ></asp:Label>
                            </div>
                        </div> 

                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2 text-lg-end">
                                <asp:Label class="form-label" ID="lblGender" runat="server" >Gender</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlGender" CssClass="form-control"  runat="server"></asp:DropDownList>
                            </div>                    
                            <div class="col-lg-2">
                                <asp:Label class="form-label" ID="lblGenderErr" runat="server" ForeColor="Red" ></asp:Label>
                            </div>
                        </div>
                        
                        <%--  --%>
                        <div class="row g-2 align-items-cente justify-content-start">   
                            <div class="col-md-2">
                            </div>                             
                            <div class="col-md-10">
                                <asp:Button ID="btnSize" class="btn btn-primary gradient-custom-2" runat="server" Text="Add Size" OnClick="btnSize_Click" />
                            </div>
                        </div>

                    </div>
                </div>
        </section>
</asp:Content>
