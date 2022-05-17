<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="eCommerce_Website.admin.payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="../assets/css/search.css" rel="stylesheet" />
                <div class="d-flex justify-content-center my-4">
                         <h1 class="text-center mt-2 mx-1">Payments</h1>
                            <div class="searchbar">
                                <asp:TextBox ID="txtFilter" runat="server" class="search_input" placeholder="Search..."></asp:TextBox>
                                 <asp:LinkButton ID="LnkSearch" runat="server" class="search_icon" OnClick="LnkSearch_Click" >
                                      <i class="fas fa-search"></i>
                               </asp:LinkButton>
                            </div>
                      </div>
      <asp:Repeater  ID="rptPayment" runat="server">
            <HeaderTemplate>
                <div class="table-responsive">
                <table class="table table-striped table-Light shadow mb-4 overflow-auto">
                <thead>
                    <tr>
                      <th scope="col">#</th>
                      <th scope="col">UserID</th>
                      <th scope="col">Cart Amount</th>
                      <th scope="col">Cart Discount</th>

                      <th scope="col">Totale Payed</th>
                      <th scope="col">Payment Type</th>
                      <th scope="col">Payment Status</th>
                      <th scope="col">DateOfPurchase</th>                      
                      <th scope="col">Name</th>                      
                      <th scope="col">Address</th>                      
                      <th scope="col">MobileNumner</th>                      

                    </tr>
                </thead>
                  <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                      <th scope="row"><%# Eval("PurchaseID") %></th>
                      <th><%# Eval("UserId") %></th>
                      <td><%# Eval("CartAmount") %></td>
                      <td><%# Eval("CartDiscount") %></td>

                      <td><%# Eval("TotalePayed") %></td>
                      <td><%# Eval("PaymentType") %></td>
                      <td><%# Eval("PaymentStatus") %></td>
                      <td><%# Eval("DateOfPurchase") %></td>
                      <td><%# Eval("Name") %></td>
                      <td><%# Eval("Address") %></td>
                      <td><%# Eval("MobileNumner") %></td>

                    </tr>
            </ItemTemplate>
          <FooterTemplate>
                  </tr>
                </tbody>
                </table>
              </div>
          </FooterTemplate>
      </asp:Repeater>
</asp:Content>
