<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="eCommerce_Website.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="h-100 h-custom" >
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col">
        <div class="card  rounded-3 shadow">
          <div class="card-body p-4">

            <div class="row">

              <div class="col-lg-7 ">
                <h5 class="my-3"><a href="products.aspx" class="text-body"><i
                      class="fas fa-long-arrow-alt-left me-2"></i>Continue shopping</a></h5>
                <hr>
                  <span class="" runat="server" id="NoItems"></span>

                                 <%-- <div id="divQtyError" runat="server" class="alert alert-success alert-dismissible fade in h4">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close"> &times;</a>
                                <strong>Oops! </strong>Quantity cannot be less than 1.
                     </div>--%>
                  <asp:Repeater ID="RptrCartProducts" runat="server" OnItemCommand="RptrCartProducts_ItemCommand">
                      <ItemTemplate>
                        <div class="card mb-3 mt-2 shadow-sm">
                          <div class="card-body">
                            <div class="d-flex justify-content-between ">
                              <div class="d-flex flex-row align-items-center ">
                                <div>
                                    <a href="productview.aspx?pid=<%# Eval("PID") %>" target="_blank">
                                      <img
                                        src="assets/images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extention") %>" alt="<%# Eval("Name") %>" onerror="this.src='assets/images/shoes.jpg'"
                                        class="img-fluid rounded-3" style="width: 65px;">
                                    </a>
                              </div>
                                <div class="ms-3" style="width: 200px;">
                                  <h5><%# Eval("PName") %></h5>
                                  <h5 class="mb-0"><%# decimal.Parse(Eval("PSelPrice").ToString()).ToString("G29") %>Dh</h5>

                                    <%--<h5 class="mb-0"> $<%# decimal.Parse(Eval("PSelPrice").ToString()).ToString("G29") %></h5>--%>
                                                   
                                </div>
                              </div>
                                <div class="d-flex flex-row align-items-center" >
                                     <asp:LinkButton CssClass="text-danger mx-2" ID="BtnMinus" CommandArgument='<%# Eval("PID") %>' CommandName="DoMinus" Font-Size="Large" runat="server" Text="-" >

                                     </asp:LinkButton>

                                     <asp:TextBox ID="txtQty" runat="server" Width="40" Font-Size="Large" TextMode="SingleLine" Style="text-align: center" Text='<%# Eval("Qty") %>'></asp:TextBox>
                                     
                                    <asp:LinkButton CssClass="text-danger mx-2" ID="BtnPlus" CommandArgument='<%# Eval("PID") %>' CommandName="DoPlus" runat="server" Text="+" Font-Size="Large" >

                                    </asp:LinkButton>
                                </div>
                              <div class="d-flex flex-row align-items-center">
                                  <div>
                                    <span class="proNameViewCart pull-right text-success">SubTotale <%# Eval("SubSAmount","{0:0}") %></span>
                                      <%--<span class="text-danger"><del>$<%# decimal.Parse(Eval("PPrice").ToString()).ToString("G29") %></del></span>--%>
                                  </div>
                                <div class="text-center text-danger" style="width: 80px;">
                                        <asp:LinkButton CommandArgument='<%#Eval("CartID") %>' CommandName="RemoveThisCart" ID="btnRemoveCart" CssClass="RemoveButton1" runat="server"  >
                                            <i class="fa-solid fa-trash-can text-danger"></i>
                                        </asp:LinkButton>        
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>

                      </ItemTemplate>
                  </asp:Repeater>

                

              </div>
              <div class="col-lg-5" id="divAmountSect">

                <div class="card">
                  <div class="card-body">
                    <div class="mb-3 ">
                      <h5 class="mb-0">Card details
                    </div>
                      <hr>
                        <div class="shadow-sm p-3 mt-5">
                        <div class="d-flex justify-content-between">
                          <p class="mb-2">Cart Total</p>
                          <p class="mb-2" runat="server" id="pCartTotal">$00.00</p>
                        </div>

                        <div class="d-flex justify-content-between">
                          <p class="mb-2">Discount</p>
                          <p class="mb-2 text-success" runat="server" id="pDescount">$00.00</p>
                        </div>

                        <div class="d-flex justify-content-between mb-4">
                          <p class="mb-2">Total</p>
                          <p class="mb-2 text-danger" runat="server" id="pTotal">$00.00</p>
                        </div>

                        <div class="d-grid gap-2 mb-4">
                            <asp:LinkButton ID="LnkBuyNow" class="btn btn-primary btn-block gradient-custom-2" runat="server" OnClick="LnkBuyNow_Click" >
                               <div class="text-white">
                                <span><i class="fa-solid fa-bag-shopping"></i> BUY NOW</span>
                              </div>
                            </asp:LinkButton>
                       </div>
<%--                         <div class="d-grid gap-2 mb-2">
                            <button type="button" class="btn btn-primary gradient-custom-2">
                              <div class="text-white">
                                <span><i class="fa-solid fa-bag-shopping"></i> BUY NOW</span>
                              </div>
                            </button>
                         </div>--%>

                         <div class="text-center">
                            <a href="#!" type="submit" class="text-danger"><i
                                class="fab fa-cc-mastercard fa-2x me-2"></i></a>
                            <a href="#!" type="submit" class="text-danger"><i
                                class="fab fa-cc-visa fa-2x me-2"></i></a>
                            <a href="#!" type="submit" class="text-danger"><i
                                class="fab fa-cc-amex fa-2x me-2"></i></a>
                            <a href="#!" type="submit" class="text-danger"><i class="fab fa-cc-paypal fa-2x"></i></a>
                         </div>

                        </div>

                  </div>
                </div>

              </div>

            </div>

          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</asp:Content>
