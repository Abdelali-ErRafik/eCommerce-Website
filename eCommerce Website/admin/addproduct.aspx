<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="eCommerce_Website.admin.addproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center my-4">Add Product</h2>
      <section>
            <div class="card shadow mb-4">
                <div class="card-header">
                Product Details
                </div>
                <div class="card-body">
                <div class="row g-2 align-items-cente justify-content-start mb-2">   
                    <div class="col-md-2 ">
                        <asp:Label class="form-label" ID="lblProductName" runat="server" >Product Name</asp:Label>
                    </div>                             
                    <div class="col-md-8">
                        <asp:TextBox ID="txtProductName" class="form-control " runat="server" ></asp:TextBox>
                    </div>                            
                    <div class="col-md-2 ">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductName" runat="server" ErrorMessage="Please enter product name" ControlToValidate="txtProductName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row g-2 align-items-cente mb-2">   
                    <div class="col-md-2  ">
                        <asp:Label class="form-label" ID="lblPrice" runat="server">Price</asp:Label>
                    </div>                             
                    <div class="col-md-8">
                        <asp:TextBox ID="txtPrice" class="form-control" runat="server"></asp:TextBox>
                    </div>                            
                    <div class="col-md-2 ">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" runat="server" ErrorMessage="Please enter price" ControlToValidate="txtPrice" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row g-2 align-items-cente mb-2">   
                    <div class="col-md-2   ">
                        <asp:Label class="form-label" ID="lblSellingPrice" runat="server" >Selling Price</asp:Label>
                    </div>                             
                    <div class="col-md-8">
                        <asp:TextBox ID="txtSellingPrice" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2 ">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSellingPrice" runat="server" ErrorMessage="Please enter sellingprice" ControlToValidate="txtSellingPrice" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                </div>
            </div>
            <%--  --%>

            <%--  --%>
            <div class="card shadow mb-4">
                <div class="card-header">
                Product Choises
                </div>
                <div class="card-body">
                <div class="row g-2 align-items-cente mb-2">   
                    <div class="col-md-2   ">
                        <asp:Label class="form-label" ID="lblBrand" runat="server" >Brand</asp:Label>
                    </div>                             
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 ">
                        <asp:Label class="form-label" ID="lblBrandErr" runat="server" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrand" runat="server" ErrorMessage="Please choise Brand" ControlToValidate="ddlBrand" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="row g-2 align-items-cente mb-2">   
                    <div class="col-md-2   ">
                        <asp:Label class="form-label" ID="lblCategory" runat="server" >Category</asp:Label>
                    </div>                             
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 ">
                        <asp:Label class="form-label" ID="lblCategoryErr" runat="server" ForeColor="Red" ></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" ErrorMessage="Please choise Category" ControlToValidate="ddlCategory" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="row g-2 align-items-cente mb-2">   
                    <div class="col-md-2   ">
                        <asp:Label class="form-label" ID="lblSubCategory" runat="server" >SubCategory</asp:Label>
                    </div>                             
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlSubCategory" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 ">
                        <asp:Label class="form-label" ID="lblSubCategoryErr" runat="server" ForeColor="Red" ></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategory" runat="server" ErrorMessage="Please choise SubCategory" ControlToValidate="ddlSubCategory" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="row g-2 align-items-cente mb-2">   
                    <div class="col-md-2   ">
                        <asp:Label class="form-label" ID="lblGender" runat="server" >Gender</asp:Label>
                    </div>                             
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGender_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 ">
                        <asp:Label class="form-label" ID="lblGenderErr" runat="server" ForeColor="Red" ></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ErrorMessage="Please choise Gender" ControlToValidate="ddlGender" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                </div>                       
                        
                <div class="row g-2 align-items-cente mb-2">   
                    <div class="col-md-2   ">
                        <asp:Label class="form-label" ID="lblSize" runat="server" >Size</asp:Label>
                    </div>                             
                    <div class="col-md-8">
                        <asp:CheckBoxList ID="cblSize" CssClass="form-control" runat="server"></asp:CheckBoxList>
                    </div>                            
                    <div class="col-md-2 ">
                    </div>
                </div>                        
                </div>
            </div>
            <%--  --%>
                <div class="card shadow mb-4">
                    <div class="card-header">
                        Product Quantity
                    </div>
                    <div class="card-body">
                        <div class="row g-2 align-items-cente justify-content-start mb-2">   
                            <div class="col-md-2 ">
                                <asp:Label class="form-label" ID="Label1" runat="server" >Quantity</asp:Label>
                            </div>                             
                            <div class="col-md-8">
                                <asp:TextBox ID="txtQte" class="form-control " runat="server" ></asp:TextBox>
                            </div>                            
                            <div class="col-md-2 ">
                            </div>
                        </div>
                    </div>
                </div>

                        
            <%--  --%>

            <div class="card shadow mb-4">
                <div class="card-header">
                Product Description
                </div>
                <div class="card-body">
                    <div class="row g-2 align-items-cente mb-2">   
                        <div class="col-md-2   ">
                            <asp:Label class="form-label" ID="lblDescription" runat="server" >Description</asp:Label>
                        </div>                             
                        <div class="col-md-8">
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 ">
                        </div>
                    </div>                       
                        
                    <div class="row g-2 align-items-cente mb-2">   
                        <div class="col-md-2   ">
                            <asp:Label class="form-label" ID="lblProductDetails" runat="server" >Product Details</asp:Label>
                        </div>                             
                        <div class="col-md-8">
                            <asp:TextBox ID="txtProductDetails" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>                            
                        <div class="col-md-2 ">
                        </div>
                    </div>                        
                        
                    <div class="row g-2 align-items-cente mb-2">   
                        <div class="col-md-2   ">
                            <asp:Label class="form-label" ID="lblMaterialsAndCare" runat="server" >Materials And Care</asp:Label>
                        </div>                             
                        <div class="col-md-8">
                            <asp:TextBox ID="txtMaterialsAndCare" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2 ">
                        </div>
                    </div> 

                </div>
            </div>
                        
            <%--  --%>
            <div class="card shadow mb-4">
                <div class="card-header">
                Product Images
                </div>
                <div class="card-body">
                    <div class="row g-2 align-items-cente mb-2">   
                        <div class="col-md-2   ">
                            <asp:Label class="form-label" ID="lblUploadImage1" runat="server" >Upload Image</asp:Label>
                        </div>                             
                        <div class="col-md-8">
                            <asp:FileUpload ID="FileUploadImage1" class="form-control" runat="server" />
                        </div>
                        <div class="col-md-2 ">
                        </div>
                            
                    </div>

                    <div class="row g-2 align-items-cente mb-2">   
                        <div class="col-md-2   ">
                            <asp:Label class="form-label" ID="lblUploadImage2" runat="server" >Upload Image</asp:Label>
                        </div>                             
                        <div class="col-md-8">
                            <asp:FileUpload ID="FileUploadImage2" class="form-control" runat="server" />
                        </div>
                        <div class="col-md-2 ">
                        </div>
                    </div> 
                        
                    <div class="row g-2 align-items-cente mb-2">   
                        <div class="col-md-2   ">
                            <asp:Label class="form-label" ID="lblUploadImage3" runat="server" >Upload Image</asp:Label>
                        </div>                             
                        <div class="col-md-8">
                            <asp:FileUpload ID="FileUploadImage3" class="form-control" runat="server" />
                        </div>
                        <div class="col-md-2 ">
                        </div>
                    </div>                        

                    <div class="row g-2 align-items-cente mb-2">   
                        <div class="col-md-2   ">
                            <asp:Label class="form-label" ID="lblUploadImage4" runat="server" >Upload Image</asp:Label>
                        </div>                             
                        <div class="col-md-8">
                            <asp:FileUpload ID="FileUploadImage4" class="form-control" runat="server" />
                        </div>
                        <div class="col-md-2 ">
                        </div>
                    </div>                       

                    <div class="row g-2 align-items-cente mb-2">   
                        <div class="col-md-2   ">
                            <asp:Label class="form-label" ID="lblUploadImage5" runat="server" >Upload Image</asp:Label>
                        </div>                             
                        <div class="col-md-8">
                            <asp:FileUpload ID="FileUploadImage5" class="form-control" runat="server" />
                        </div>
                        <div class="col-md-2 ">
                        </div>
                    </div>                        

                </div>
            </div>

            <%--  --%>
            <div class="card shadow mb-4">
                <div class="card-header">
                Product Checked
                </div>
                <div class="card-body">
                    <div class="row g-2 align-items-cente mb-2">   
                        <div class="col-md-2  ">
                            <asp:Label class="form-label" ID="lblFreeDelivery" runat="server" >Free Delivery</asp:Label>
                        </div>                             
                        <div class="col-md-8">
                            <asp:CheckBox ID="cbFreeDelivery" CssClass="form-control" runat="server" />
                        </div>
                        <div class="col-md-2 ">
                        </div>
                    </div>

                    <div class="row g-2 align-items-cente mb-2">   
                        <div class="col-md-2   ">
                            <asp:Label class="form-label" ID="lbl30DaysReturn" runat="server" >30 DaysReturn</asp:Label>
                        </div>   
                            
                        <div class="col-md-8">
                            <asp:CheckBox ID="cb30DaysReturn" CssClass="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 ">
                        </div>
                    </div>                     

                    <div class="row g-2 align-items-cente mb-4">   
                        <div class="col-md-2   ">
                            <asp:Label class="form-label" ID="lblCOD" runat="server" >COD</asp:Label>
                        </div>                             
                        <div class="col-md-8">
                            <asp:CheckBox ID="cbCOD" CssClass="form-control" runat="server" />
                        </div>
                        <div class="col-md-2 ">
                        </div>
                    </div> 

                    <div class="row g-2 align-items-cente justify-content-start">   
                        <div class="col-md-2">
                        </div>                             
                        <div class="col-md-10">
                             <asp:Button ID="btnAddPoduct" class="btn btn-primary gradient-custom-2" runat="server" Text="Add Product" OnClick="btnAddPoduct_Click"   />
                        </div>
                    </div>
                </div>
            </div>
 
        </section>

</asp:Content>
