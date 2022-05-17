<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="adminhome.aspx.cs" Inherits="eCommerce_Website.admin.adminhome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.12.1/css/all.min.css" integrity="sha256-mmgLkCYLUQbXn0B1SRqzHar6dCnv9oZFPEC1g1cwlkk=" crossorigin="anonymous" />
    <link href="../assets/css/dashcard.css" rel="stylesheet" />
    <%--  --%>
        <h1 class="my-4 text-center">Dashboard</h1>
    <%--  --%>
        <div class="row">
            <%--  --%>
            <%--  --%>
                 <div class="col-xl-3 col-lg-6">
                <div class="card l-bg-cherry">
                    <div class="card-statistic-3 p-4">
                        <div class="card-icon card-icon-large"><i class="fas fa-shopping-cart"></i></div>
                        <div class="mb-4">
                            <h5 class="card-title mb-0">New Orders</h5>
                        </div>
                        <div class="row align-items-center mb-2 d-flex">
                            <div class="col-8">
                                <h2 id="ordersCount" runat="server" class="d-flex align-items-center mb-0">
                                    3,243
                                </h2>
                            </div>
                            <div class="col-4 text-right">
                                <span id="ordersPoursent" runat="server">12.5% </span><i class="fa fa-arrow-up"></i>
                            </div>
                        </div>
                        <div class="progress mt-1 " data-height="8" style="height: 8px;">
                            <div class="progress-bar l-bg-cyan" role="progressbar" data-width="25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" style="width: 5%;"></div>
                        </div>
                    </div>
                </div>
            </div>
            <%--  --%>
            
            <div class="col-xl-3 col-lg-6">
                <div class="card l-bg-blue-dark">
                    <div class="card-statistic-3 p-4">
                        <div class="card-icon card-icon-large"><i class="fas fa-users"></i></div>
                        <div class="mb-4">
                            <h5 class="card-title mb-0">Customers</h5>
                        </div>
                        <div class="row align-items-center mb-2 d-flex">
                            <div class="col-8">
                                <h2 id="customersCount" class="d-flex align-items-center mb-0" runat="server">
                                    15.07k
                                </h2>
                            </div>
                            <div class="col-4 text-right">
                                <span id="customersPourSent" runat="server">9.23% </span><i class="fa fa-arrow-up"></i>
                            </div>
                        </div>
                        <div class="progress mt-1 " data-height="8" style="height: 8px;">
                            <div class="progress-bar l-bg-green" role="progressbar" data-width="25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" style="width: 8%;"></div>
                        </div>
                    </div>
                </div>
            </div>
            <%--  --%>
            <div class="col-xl-3 col-lg-6">
                <div class="card l-bg-green-dark">
                    <div class="card-statistic-3 p-4">
                        <div class="card-icon card-icon-large"><i class="fas fa-ticket-alt"></i></div>
                        <div class="mb-4">
                            <h5 class="card-title mb-0">New Products</h5>
                        </div>
                        <div class="row align-items-center mb-2 d-flex">
                            <div class="col-8">
                                <h2 id="productsCount" runat="server" class="d-flex align-items-center mb-0">
                                    578
                                </h2>
                            </div>
                            <div class="col-4 text-right">
                                <span id="productsPourSent" runat="server">10% </span><i class="fa fa-arrow-up"></i>
                            </div>
                        </div>
                        <div class="progress mt-1 " data-height="8" style="height: 8px;">
                            <div class="progress-bar l-bg-orange" role="progressbar" data-width="25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" style="width: 15%;"></div>
                        </div>
                    </div>
                </div>
            </div>
            <%--  --%>
            <div class="col-xl-3 col-lg-6">
                <div class="card l-bg-orange-dark">
                    <div class="card-statistic-3 p-4">
                        <div class="card-icon card-icon-large"><i class="fas fa-dollar-sign"></i></div>
                        <div class="mb-4">
                            <h5 class="card-title mb-0">Product In Cart</h5>
                        </div>
                        <div class="row align-items-center mb-2 d-flex">
                            <div class="col-8">
                                <h2 id="CartCount" runat="server" class="d-flex align-items-center mb-0">
                                    $11.61k
                                </h2>
                            </div>
                            <div class="col-4 text-right">
                                <span id="CartPourSent" runat="server">2.5% </span><i class="fa fa-arrow-up"></i>
                            </div>
                        </div>
                        <div class="progress mt-1 " data-height="8" style="height: 8px;">
                            <div class="progress-bar l-bg-cyan" role="progressbar" data-width="25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" style="width: 8%;"></div>
                        </div>
                    </div>
                </div>
            </div>
        <%--  --%>
        </div>

    <%--  --%>
    <%--  --%>
    <%--  --%>

        <div class="row">
            <%--  --%>
            <%--  --%>
                 <div class="col-xl-6 col-lg-6">
                <div class="card"style="background: linear-gradient(to right top, #051937, #004d7a, #008793, #00bf72, #a8eb12); color:#fff;">
                    <div class="card-statistic-3 p-4">
                        <div class="mb-4">
                            <h5 class="card-title mb-0">Latest Customers</h5>
                        </div>

                        <asp:Repeater ID="RptCustomers" runat="server">
                            <ItemTemplate>
                        <div class="row align-items-center mb-2 d-flex">
                            <div class="col-4">
                                <span  class="d-flex align-items-center mb-0">
                                    <%# Eval("UID") %>
                                </span>
                            </div>
                            <div class="col-4">
                                <span  class="d-flex align-items-center mb-0">
                                    <%# Eval("UserName") %>
                                </span>
                            </div>                            
                            <div class="col-4">
                                <span  class="d-flex align-items-center mb-0">
                                    <%# Eval("FullName") %>
                                </span>
                            </div>
                        </div>
                           </ItemTemplate>
                       </asp:Repeater>
                    </div>
                </div>
            </div>
            <%--  --%>
           
                 <div class="col-xl-6 col-lg-6">
                <div class="card" style="background: linear-gradient(to right top, #d16ba5, #c777b9, #ba83ca, #aa8fd8, #9a9ae1, #8aa7ec, #79b3f4, #69bff8, #52cffe, #41dfff, #46eefa, #5ffbf1); color:#fff">
                    <div class="card-statistic-3 p-4">
                        <div class="mb-4">
                            <h5 class="card-title mb-0">Latest Products</h5>
                        </div>

                        <asp:Repeater ID="RptProducts" runat="server">
                            <ItemTemplate>
                        <div class="row align-items-center mb-2 d-flex">
                            <div class="col-4">
                                <span  class="d-flex align-items-center mb-0">
                                    <%# Eval("PID") %>
                                </span>
                            </div>
                            <div class="col-4">
                                <span  class="d-flex align-items-center mb-0">
                                    <%# Eval("PName") %>
                                </span>
                            </div>                            
                            <div class="col-4">
                                <span  class="d-flex align-items-center mb-0">
                                    <%# Eval("PPrice") %>
                                </span>
                            </div>
                        </div>
                           </ItemTemplate>
                       </asp:Repeater>
                    </div>
                </div>
            </div>
            <%--  --%>
            <%--  --%>
</div>

            <div class="row">
            <%--  --%>
            <%--  --%>
                 <div class="col-xl-12 col-lg-12">
                <div class="card"style="background: linear-gradient(to right, #de6262, #ffb88c); color:#fff">
                    <div class="card-statistic-3 p-4">
                        <div class="mb-4">
                            <h5 class="card-title mb-0">Latest Payment</h5>
                        </div>

                        <asp:Repeater ID="Rptpayment" runat="server">
                            <ItemTemplate>
                        <div class="row align-items-center mb-2 d-flex">
                            <div class="col-4">
                                <span  class="d-flex align-items-center mb-0">
                                    <%# Eval("PurchaseID ") %>
                                </span>
                            </div>
                            <div class="col-4">
                                <span  class="d-flex align-items-center mb-0">
                                    <%# Eval("TotalePayed") %>
                                </span>
                            </div>                            
                            <div class="col-4">
                                <span  class="d-flex align-items-center mb-0">
                                    <%# Eval("DateOfPurchase") %>
                                </span>
                            </div>                            
                        </div>
                           </ItemTemplate>
                       </asp:Repeater>
                    </div>
                </div>
            </div>
            <%--  --%>
          
</div>
    
</asp:Content>
