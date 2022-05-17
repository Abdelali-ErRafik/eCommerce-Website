<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edashop.aspx.cs" Inherits="eCommerce_Website.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>EDASHOP</title>    
        <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" />
        <link href="assets/css/main.css" rel="stylesheet" />
        <link href="assets/css/productscard.css" rel="stylesheet" />

    </head>
<body>
    <form id="form1" runat="server">
       <%--Start NavBar--%>
    <div>
       <div class="superNav py-1 bg-light">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 centerOnMobile">
                    <span class="d-none d-lg-inline-block d-md-inline-block d-sm-inline-block d-xs-none me-3">
                        <i class="fa-solid fa-envelope me-1"></i>
                        <a class="text-black-50"  href="#">
                           EDAShop@gmail.com
                        </a>
                    </span>
                    <span class="me-3">
                        <i class="fa-solid fa-phone me-1"></i> 
                        <a class="text-black-50"  href="#">
                            +212 653334584
                        </a>
                    </span>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 d-none d-lg-block d-md-block-d-sm-block d-xs-none text-end">
                    <span class="me-3">
                        <i class="fa-solid fa-phone me-1"></i>
                        <a class="text-black-50"  href="#">
                            Location
                        </a>
                    </span>                 
                    <span class="me-3">
                        <select  class="me-3 border-0 bg-light">
                          <option value="en-us">English</option>
                          <option value="en-us">French</option>
                          <option value="en-us">العربية</option>
                        </select>
                        <select  class=" border-0 bg-light">
                          <option value="en-us">MAD</option>
                          <option value="en-us">USD</option>
                          <option value="en-us">ERO</option>
                        </select>
                    </span>                   
                </div>
            </div>
            </div>
        </div>
        <nav class="navbar navbar-expand-lg bg-white sticky-top navbar-light shadow-sm ">
            <div class="container-fluid">
            <a class="navbar-brand text-danger" href="edashop.aspx"><i class="fa-solid fa-shop me-2"></i> <strong >EDASHOP</strong></a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="navLinks collapse navbar-collapse" id="navbarNavDropdown">
                <ul class="navbar-nav ms-auto ">
                <li class="nav-item">
                    <a class="nav-link mx-2" href="userhome.aspx">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link mx-2" href="products.aspx">Products</a>
                </li>
                  <li class="nav-item position-relative">
                     <a href="./cart.aspx" id="LnkCart" class="nav-link mx-2" >
                         Cart <span id="pCount" class="badge bg-danger text-white rounded-circle position-absolute top-0" runat="server">0</span>
                     </a>                 
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link mx-2 dropdown-toggle" href="#" id="navbardropdownmenulink" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Categories
                    </a>
                    <ul class="dropdown-menu" aria-labelledby="navbardropdownmenulink">
                        <li><a class="dropdown-item" href="woman.aspx">Woman</a></li>
                        <li><a class="dropdown-item" href="man.aspx">Man</a></li>
                        <li><a class="dropdown-item" href="footwear.aspx">Footwear</a></li>
                        <li><a class="dropdown-item" href="watches.aspx">Watches</a></li>
                    </ul>
                </li>

                <li class="nav-item">
                    <a class="nav-link mx-2" href="payment.aspx">Payment</a>
                </li>

               <%-- <li class="nav-item dropdown">
                    <a class="nav-link mx-2 dropdown-toggle" href="#" id="navbarDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Products
                    </a>
                    <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                         <li><a class="dropdown-item" href="products.aspx">All Products</a></li>
                        <li role="separator" class="dropdown-divider"></li>



                        <li class="dropdown-header" href="#">Man</li>
                        <li><a class="dropdown-item" href="#">Shirts</a></li>
                        <li><a class="dropdown-item" href="#">Pants</a></li>
                        <li><a class="dropdown-item" href="#">Denims</a></li>
                        <li role="separator" class="dropdown-divider"></li>
                        <li class="dropdown-header" href="#">Woman</li>
                        <li role="separator" class="dropdown-divider"></li>
                        <li><a class="dropdown-item" href="#">Top</a></li>
                        <li><a class="dropdown-item" href="#">Leggings</a></li>
                        <li><a class="dropdown-item" href="#">Denims</a></li>
                    </ul>
                </li>--%>
                </ul>
                <ul class="navbar-nav ms-auto ">
                <li class="nav-item">
                     <asp:LinkButton class="nav-link mx-2 text-danger" ID="lnkAdminLogin" runat="server" OnClick="lnkAdminLogin_Click" ><i class="fa-solid fa-arrow-right-to-bracket me-1"></i> Log In</asp:LinkButton>
                     <asp:LinkButton class="nav-link mx-2 text-danger" ID="lnkAdminLogout" runat="server" OnClick="lnkAdminLogout_Click" ><i class="fa-solid fa-arrow-right-to-bracket me-1"></i> Log out</asp:LinkButton>
                </li>                
                </ul>
            </div>
        </div>
    </nav>
   </div>
    <%-- End NavBar --%>

        <%-- Start Hero Carousel --%>
        <div id="carouselExampleCaptions" class="carousel carousel-dark slide position-relative" data-bs-ride="carousel">
<%--            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>--%>
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
                        <asp:Button ID="btnViewAll1" class="btn btn-outline-danger" runat="server" Text="Explore Now" OnClick="btnViewAll1_Click"   />
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
        <!-- Footer -->
            <footer class="text-center text-lg-start bg-light text-muted">
                <!-- Section: Social media -->
                <section
                class="d-flex justify-content-center justify-content-lg-between p-4"
                >
                <!-- Left -->
                <div class="me-5 d-none d-lg-block">
                    <span>Get connected with us on social networks:</span>
                </div>
                <!-- Left -->

                <!-- Right -->
                <div>
                    <a href="" class="me-4 text-reset" />
                    <i class="fab fa-facebook-f"></i>
                    </a>
                    <a href="" class="me-4 text-reset" />
                    <i class="fab fa-twitter"></i>
                    </a>
                    <a href="" class="me-4 text-reset" />
                    <i class="fab fa-google"></i>
                    </a>
                    <a href="" class="me-4 text-reset" />
                    <i class="fab fa-instagram"></i>
                    </a>
                    <a href="" class="me-4 text-reset" />
                    <i class="fab fa-linkedin"></i>
                    </a>
                    <a href="" class="me-4 text-reset" />
                    <i class="fab fa-github"></i>
                    </a>
                </div>
                <!-- Right -->
                </section>
                <!-- Section: Social media -->

                <!-- Section: Links  -->
                <section class="bg-light">
                <div class="container text-center text-md-start mt-5">
                    <!-- Grid row -->
                    <div class="row mt-3">
                    <!-- Grid column -->
                    <div class="col-md-3 col-lg-4 col-xl-3 mx-auto mb-4">
                        <!-- Content -->
                        <h6 class=" fw-bold mb-4">
                        <i class="fas fa-gem me-3"></i>EDASHOP
                        </h6>
                        <p>
                            EDA Shop its best choise to sell your product and free deleviry
                        </p>
                    </div>
                    <!-- Grid column -->

                    <!-- Grid column -->
                    <div class="col-md-2 col-lg-2 col-xl-2 mx-auto mb-4">
                        <!-- Links -->
                        <h6 class=" fw-bold mb-4">
                        Products
                        </h6>
                        <p>
                        <a href="woman.aspx" class="text-reset">Woman</a>
                        </p>
                        <p>
                        <a href="footwear.aspx" class="text-reset">Footwear</a>
                        </p>
                        <p>
                        <a href="man.aspx" class="text-reset">Man</a>
                        </p>
                        <p>
                        <a href="watches.aspx" class="text-reset">Watches</a>
                        </p>
                    </div>
                    <!-- Grid column -->

                    <!-- Grid column -->
                    <div class="col-md-3 col-lg-2 col-xl-2 mx-auto mb-4">
                        <!-- Links -->
                        <h6 class=" fw-bold mb-4">
                        Links
                        </h6>
                        <p>
                        <a href="userhome.aspx" class="text-reset">Home</a>
                        </p>
                        <p>
                        <a href="products.aspx" class="text-reset">Products</a>
                        </p>
                        <p>
                        <a href="cart.aspx" class="text-reset">Cart</a>
                        </p>
                        <p>
                        <a href="payment.aspx" class="text-reset">Payment</a>
                        </p>
                    </div>
                    <!-- Grid column -->

                    <!-- Grid column -->
                    <div class="col-md-4 col-lg-3 col-xl-3 mx-auto mb-md-0 mb-4">
                        <!-- Links -->
                        <h6 class=" fw-bold mb-4">
                        Contact
                        </h6>
                        <p><i class="fas fa-home me-3"></i> ISTA ASSAKA, TIKIOUIN</p>
                        <p>
                        <i class="fas fa-envelope me-3"></i>
                        EDAShop@gmail.com
                        </p>
                        <p><i class="fas fa-phone me-3"></i> + 212 653334584</p>
                        <p><i class="fas fa-print me-3"></i> + 212 634865152</p>
                    </div>
                    <!-- Grid column -->
                    </div>
                    <!-- Grid row -->
                </div>
                </section>
                <!-- Section: Links  -->

                <!-- Copyright -->
                <div class="text-center p-4" style="background-color: rgba(0, 0, 0, 0.05);">
                © 2022 Copyright:
                <a class="text-reset fw-bold" href="edashop.aspx">EDASHOP.com</a>
                </div>
                <!-- Copyright -->
            </footer>
        <!-- Footer -->
</div>
<!-- End of .container -->
  </form>



    <%--  --%>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js" ></script>
    <script src="assets/js/main.js"></script>
</body>
</html>


