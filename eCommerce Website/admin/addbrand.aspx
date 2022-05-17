<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="addbrand.aspx.cs" Inherits="eCommerce_Website.admin.addbrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2 class="text-center mt-4">Add Brand</h2>
      <section>
                <div class="card shadow mb-4">
                    <div class="card-header">
                    Brand Details
                    </div>
                    <div class="card-body">
                        <%--  --%>
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2  text-lg-end ">
                                <asp:Label class="form-label" ID="lblBrand" runat="server" >Brand Name</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtBrand" class="form-control " runat="server" ></asp:TextBox>
                            </div>                    
                            <div class="col-md-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrand" runat="server" ErrorMessage="Please Enter Brand Name" ControlToValidate="txtBrand" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="row g-2 align-items-cente justify-content-start ">   
                            <div class="col-md-2">
                            </div>                             
                            <div class="col-md-10">
                                <asp:Button ID="btnAddBrand" class="btn btn-primary gradient-custom-2" runat="server" Text="Add Brand" OnClick="btnAddBrand_Click"   />
                            </div>
                        </div>
                    </div>
                </div>
    

        </section>
</asp:Content>
