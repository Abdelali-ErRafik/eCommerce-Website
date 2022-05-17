<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="woman.aspx.cs" Inherits="eCommerce_Website.woman" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/search.css" rel="stylesheet" />

    <section>
             <div class="container">
                       <div class="d-flex justify-content-center my-4">
                         <h3 class="text-center mt-2 mx-1">Woman</h3>
                            <div class="searchbar">
                                <asp:TextBox ID="txtFilter" runat="server" class="search_input" placeholder="Search..."></asp:TextBox>
                                 <asp:LinkButton ID="LnkSearch" runat="server" class="search_icon" OnClick="LnkSearch_Click" >
                                      <i class="fas fa-search"></i>
                               </asp:LinkButton>
                            </div>
                      </div>

                 <div class="">
                 </div>
                 <div class="row">

                     <asp:Repeater ID="RptProducts" runat="server">
                         <ItemTemplate>

                             <%--  --%>
                                <div class="col-lg-3 col-sm-6 d-flex flex-column align-items-center justify-content-center product-item my-3">
                                    <a href="productview.aspx?pid=<%# Eval("PID") %>">
                                        <div class="product"> <img src="assets/images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extention") %>" alt="<%# Eval("Name") %>">
                                            <ul class="d-flex align-items-center justify-content-center list-unstyled icons">
                                                <li class="icon"><span class="fas fa-expand-arrows-alt"></span></li>
                                                <li class="icon mx-3"><span class="far fa-heart"></span></li>
                                                <li class="icon"><span class="fas fa-shopping-bag"></span></li>
                                            </ul>
                                        </div>
                                        <div class="title pt-4 pb-1 text-center"><%# Eval("PName") %></div>
                                        <div class="d-flex align-content-center justify-content-center"> <span class="fas fa-star"></span> <span class="fas fa-star"></span> <span class="fas fa-star"></span> <span class="fas fa-star"></span> <span class="fas fa-star"></span> </div>
                                        <div class="price text-center">
                                            <del class="text-danger "><%# decimal.Parse(Eval("PPrice").ToString()).ToString("G29") %>Dh</del> <%# decimal.Parse(Eval("PSelPrice").ToString()).ToString("G29") %>Dh</div>
                                    </a>
                                </div>
                             <%--  --%>

                         </ItemTemplate>


                     </asp:Repeater>       
    </div>
</section>
</asp:Content>
