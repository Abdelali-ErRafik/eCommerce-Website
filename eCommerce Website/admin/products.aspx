<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="eCommerce_Website.admin.products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../assets/css/search.css" rel="stylesheet" />
                <div class="d-flex justify-content-center my-4">
                         <h1 class="text-center mt-2 mx-1">Products</h1>
                            <div class="searchbar">
                                <asp:TextBox ID="txtFilter" runat="server" class="search_input" placeholder="Search..."></asp:TextBox>
                                 <asp:LinkButton ID="LnkSearch" runat="server" class="search_icon" OnClick="LnkSearch_Click" >
                                      <i class="fas fa-search"></i>
                               </asp:LinkButton>
                            </div>
                      </div>
      <asp:Repeater  ID="rptProducts" runat="server" OnItemCommand="rptBrands_ItemCommand">
            <HeaderTemplate>
                <div class="table-responsive">
                <table class="table table-striped table-Light shadow mb-4">
                <thead>
                    <tr>
                      <th scope="col">#</th>
                      <th scope="col">Name</th>
                      <th scope="col">Price</th>
                      <th scope="col">SellPrice</th>

                      <th scope="col">Brand</th>
                      <th scope="col">Category</th>
                      <th scope="col">SubCategory</th>
                      <th scope="col">Gender</th>                      
                        
<%--                       <th scope="col">Description</th>
                      <th scope="col">Details</th>
                      <th scope="col">Materiale and Care</th>                      
                        
                      <th scope="col">FreeDelivery</th>
                      <th scope="col">30DayRet</th>
                      <th scope="col">COD</th>--%>


                      <th scope="col">Edit</th>
                      <th scope="col">Delete</th>
                    </tr>
                </thead>
                  <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                      <th scope="row"><%# Eval("PID") %></th>
                      <th><%# Eval("PName") %></th>
                      <td><%# Eval("PPrice") %></td>
                      <td><%# Eval("PSelPrice") %></td>

                      <td><%# Eval("BrandName") %></td>
                      <td><%# Eval("CatName") %></td>
                      <td><%# Eval("SubCatName") %></td>
                      <td><%# Eval("GenderName") %></td>

<%--                      <td><%# Eval("PDescription") %></td>
                      <td><%# Eval("PProductDetails") %></td>
                      <td><%# Eval("PMaterialCare") %></td>

                      <td><%# Eval("FreeDelivery") %></td>
                      <td><%# Eval("30DayRet") %></td>
                      <td><%# Eval("COD") %></td>--%>

                      <td>
                          <a class="text-success" href="editproduct.aspx?PID=<%# Eval("PID") %>"><i class="fa-solid fa-pen"></i> Edit</a>  
                      </td>                      
                       <td>
                            <asp:LinkButton CommandArgument='<%#Eval("PID") %>' CommandName="Remove" CssClass="text-danger" ID="btnRemoveProducts" OnClientClick = "Confirm()"  runat="server" >
                                <i class="fa-solid fa-trash-can"></i> Delete
                            </asp:LinkButton>                       
                      </td>
                    </tr>
            </ItemTemplate>
          <FooterTemplate>
                  </tr>
                </tbody>
                </table>
              </div>
          </FooterTemplate>
      </asp:Repeater>

        <div class="d-grid gap-2 col-sm-2  mb-4">
            <asp:HyperLink ID="lnkAddSize" class="btn btn-primary text-light btn-block gradient-custom-2 shadow" runat="server" NavigateUrl="~/admin/addproduct.aspx">Add Product</asp:HyperLink>
    </div>

    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete this product")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
