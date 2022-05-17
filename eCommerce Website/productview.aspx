<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="productview.aspx.cs" Inherits="eCommerce_Website.productview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container ">	
        <div class="card my-5 ">	
            <div class="row g-0">	
                <div class="col-md-6">	
                    <div class="d-flex flex-column justify-content-center">		
                            <%-- image slider --%>
                            <div id="carouselExampleFade" class="carousel slide carousel-fade mx-auto" data-bs-ride="carousel">
                                <div class="carousel-inner">
                                    <asp:Repeater ID="RptImage1" runat="server">
                                        <ItemTemplate>
                                            <div class="carousel-item <%# GetActiveImgClass(Container.ItemIndex) %>">
                                              <img src="assets/images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extention") %>" alt="<%# Eval("Name") %>" class="" onerror="this.src='assets/images/shoes.jpg'">
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                              <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                              </button>
                              <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                              </button>
                            <%-- image slider --%>
                        </div>	
                        <div class="thumbnail_images">	
                            <ul id="thumbnail ">	
                              <asp:Repeater ID="RptImage2" runat="server">
                                <ItemTemplate>
                                <li><img  src="assets/images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extention") %>" alt="<%# Eval("Name") %>" width="50"></li>	
                                </ItemTemplate>
                            </asp:Repeater>
                            </ul>	
                         </div>	
                    </div>	
                 </div>
                <div class="col-md-6">	
                    <asp:Repeater ID="RptProductDetails" runat="server" OnItemDataBound="RptProductDetails_ItemDataBound">
                        <ItemTemplate>
                        <div class="p-3 right-side">	
                             <h3><%# Eval("PName") %></h3>	
                             <div class="">               
                                <div>
                                    <span class="text-danger"><del><%# decimal.Parse(Eval("PPrice").ToString()).ToString("G29") %>Dh</del></span> <%# decimal.Parse(Eval("PSelPrice").ToString()).ToString("G29") %>Dh(<%# string.Format("{0}", Convert.ToInt64(Eval("PPrice")) - Convert.ToInt64(Eval("PSelPrice")))  %>Off)
                                </div>	
                            </div>

                            <div class="content mt-2">	
                                <p><%# Eval("PDescription") %></p>	
                            </div>
                        
                            <div class="Sizes mt-2">	
		                            <h5>Size</h5>
                                    <asp:RadioButtonList ID="RblSize" runat="server" RepeatDirection="Horizontal" CssClass="p-3">
                                        <asp:ListItem  Value="S" Text="S"></asp:ListItem>
                                        <asp:ListItem Value="M" Text="M"></asp:ListItem>
                                        <asp:ListItem Value="L" Text="L"></asp:ListItem>
                                        <asp:ListItem Value="XL" Text="XL"></asp:ListItem>
                                    </asp:RadioButtonList>
                             </div>
                        
                            <div class="ratings d-flex flex-row align-items-center mt-1">	
                                <div class="d-flex flex-row">	
                                     <i class="fa-solid fa-star"></i>
                                     <i class="fa-solid fa-star"></i>
                                     <i class="fa-solid fa-star"></i>
                                     <i class="fa-solid fa-star"></i>
                                     <i class="fa-solid fa-star"></i>
                                </div>	
                                <span>0 reviews</span>	
                            </div>

                            <div class="buttons d-flex flex-row mt-2 mt-3 gap-3">	
                                <asp:Button ID="BtnAddToCart" CssClass="btn btn-dark" runat="server" Text="Add to Cart" OnClick="BtnAddToCart_click"  />
                                <asp:Label CssClass="mt-2" ID="lblError" runat="server"  ForeColor="Red"></asp:Label>
                            </div>
                                                
                            <div class="product-desc mt-3">	
                            
                                <p><strong>Product Details :</strong> <%# Eval("PProductDetails") %></p>
                            </div>	                        
                            <div class="product-desc">	          
                                <p><strong>Material & Care :</strong> <%# (Eval("PMaterialCare").ToString()!="")?Eval("PMaterialCare"):"...." %> </p>
                            </div>	                        
                       
                            <div class="product-desc">	               
                                <p><strong>Free Delivery :</strong> <%# ((int)Eval("FreeDelivery")==1)?"Yes":"No" %> </p>
                            </div>	                        
                            <div class="product-desc">	                          
                                <p><strong>30 Days Returns :</strong> <%# ((int)Eval("30DayRet")==1)?"Yes":"No" %></p>
                            </div>	                        
                            <div class="product-desc">	                    
                                <p><strong>Csah on Delivery :</strong> <%# ((int)Eval("COD")==1)?"Yes":"No" %></p>
                            </div>	
                        </div>	

                            <asp:HiddenField ID="HfBrandID" runat="server" Value ='<%# Eval("PBrandID") %>' />
                            <asp:HiddenField ID="HfCatID" runat="server" Value ='<%# Eval("PCategory") %>' />
                            <asp:HiddenField ID="HfSubCategoryID" runat="server" Value ='<%# Eval("PSubCategory") %>' />
                            <asp:HiddenField ID="HfPGenderID" runat="server" Value ='<%# Eval("PGender") %>' />

                        </ItemTemplate>
                    </asp:Repeater>
                </div>	                            	
            </div>	
        </div> 

    </div>
</asp:Content>
