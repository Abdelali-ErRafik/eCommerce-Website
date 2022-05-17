<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="userhome.aspx.cs" Inherits="eCommerce_Website.userhome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%-- Start Hero Carousel --%>
        <div id="carouselExampleCaptions" class="carousel carousel-dark slide" data-bs-ride="carousel">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
          <div class="carousel-inner">
            <div class="carousel-item active" data-bs-interval="1000">
              <img src="assets/images/hero1.jpg" class="d-block w-100" alt="Hero01" />
              <div class="carousel-caption d-none d-md-block position-absolute top-50 start-0 translate-middle-y">
                <h5>SUMMER 2022</h5>
                <h1>New Arrival Collection</h1>
                 <a href="products.aspx" class="btn btn-dark text-white px-4 mb-5">Explore Now</a>
              </div>
            </div>
            <div class="carousel-item">
              <img src="assets/images/hero2.jpg" class="d-block w-100" alt="Hero02" />
              <div class="carousel-caption d-none d-md-block position-absolute top-50 start-0 translate-middle-y">
                <h5>NEW SEASON</h5>
                <h1>Loobook Collection</h1>
                 <a href="products.aspx" class="btn btn-dark text-white border-0 px-4 mb-5">Explore Now</a>                 
              </div>
            </div>
            <div class="carousel-item">
              <img src="assets/images/hero3.jpg" class="d-block w-100" alt="Hero03" />
              <div class="carousel-caption d-none d-md-block position-absolute top-50 start-0 translate-middle-y">
                <h5>SUMMER SALE</h5>
                <h1>Save up to 70% </h1>
                 <a href="products.aspx" class="btn btn-dark text-white px-4 mb-5">Explore Now</a>                
              </div>
            </div>
          </div>
          <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
          </button>
          <button class="carousel-control-next " type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
          </button>
        </div> 
        <%-- End Hero Carousel --%>


        <%--Middle Content Start--%>
          <main>
            <div class="container bg-trasparent mt-5" style="position: relative;">
                <div class="row row-cols-1 row-cols-xs-2 row-cols-sm-2 row-cols-lg-4 ">
                    <%--  --%>
                    <div class="col position-relative">
                        <a href="woman.aspx" class="text-dark">
                        <div class="card border-0 mb-4"> 
                            <img src="assets/images/woman55ds.jpg" class="img-fluid" alt="Woman" />
                            <div class="position-absolute bottom-0 start-50 translate-middle-x bg-light px-4 py-2 mb-3 ">
                                <div class="">Woman</div>
                            </div>
                        </div>
                        </a>
                        
                    </div>
                    <%--  --%>
                    <div class="col">
                        <a href="footwear.aspx" class="text-dark">
                        <div class="card border-0"> 
                            <img src="assets/images/shoes.jpg" class="img-fluid" alt="Shoes" />
                            <div class="position-absolute bottom-0 start-50 translate-middle-x bg-light px-4 py-2 mb-3 ">
                                <div class="">footwear</div>
                            </div>
                        </div>
                       </a>
                    </div>
                    <div class="col">
                         <a href="man.aspx" class="text-dark">
                        <div class="card border-0"> 
                            <img src="assets/images/man.jpg" class="img-fluid" alt="man" />
                            <div class="position-absolute bottom-0 start-50 translate-middle-x bg-light px-4 py-2 mb-3 ">
                                <div class="">Man</div>
                            </div>
                        </div>
                          </a>
                    </div>
                    <div class="col">
                        <a href="watches.aspx" class="text-dark">
                        <div class="card border-0 "> 
                            <img src="assets/images/watches.jpg" class="img-fluid" alt="watches" />
                            <div class="position-absolute bottom-0 start-50 translate-middle-x bg-light px-4 py-2 mb-3 ">
                                <div class="">Watches</div>
                            </div>
                        </div>
                        </a>
                    </div>
                    <%--  --%>
                </div>
            </div>
        </main>
        <%--Middle Content End--%>
    <%-- Most Popular --%>
    <section>
             <div class="container">
                 <div class="my-4">
                     <h3 class="text-center">Most Popular</h3>
                     <h5 class="text-center fst-italic text-danger" style="font-weight:200;">Top view in this week</h5>
                 </div>
                 <div class="row">

                     <asp:Repeater ID="RptMostPapular" runat="server">

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
                      <div class="d-grid gap-2 col-2 mx-auto mb-4">
                        <asp:Button ID="btnViewAll1" class="btn btn-outline-danger" runat="server" Text="Explore New" OnClick="btnViewAll1_Click"   />
                       </div>
    </div>
</section>
        <%-- New Products  --%>
		<section>
             <div class="container">
                 <div class="my-4">
                     <h3 class="text-center">New Product</h3>
                     <h5 class="text-center fst-italic text-danger" style="font-weight:200;">Top view in this week</h5>
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
                       <div class="d-grid gap-2 col-2 mx-auto mb-4">
                        <asp:Button ID="btnViewAll2" class="btn btn-outline-danger" runat="server" Text="Explore Now" OnClick="btnViewAll2_Click"   />
                       </div>
    </div>
</section> 
    
 <%--  --%>
</asp:Content>
