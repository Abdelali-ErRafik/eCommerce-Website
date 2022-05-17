<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="genders.aspx.cs" Inherits="eCommerce_Website.admin.gender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="../assets/css/search.css" rel="stylesheet" />
                <div class="d-flex justify-content-center my-4">
                         <h1 class="text-center mt-2 mx-1">Genders</h1>
                            <div class="searchbar">
                                <asp:TextBox ID="txtFilter" runat="server" class="search_input" placeholder="Search..."></asp:TextBox>
                                 <asp:LinkButton ID="LnkSearch" runat="server" class="search_icon" OnClick="LnkSearch_Click" >
                                      <i class="fas fa-search"></i>
                               </asp:LinkButton>
                            </div>
                      </div>
      <asp:Repeater  ID="rptBrands" runat="server" OnItemCommand="rptBrands_ItemCommand">
            <HeaderTemplate>
                <div class="table-responsive">
                <table class="table table-striped table-Light shadow mb-4">
                <thead>
                    <tr>
                      <th scope="col">#</th>
                      <th scope="col">Gender</th>
                      <th scope="col">Edit</th>
                      <th scope="col">Delete</th>
                    </tr>
                </thead>
                  <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                      <th scope="row"><%# Eval("GenderID") %></th>
                      <td><%# Eval("GenderName") %></td>
                      <td>
                          <a class="text-success" href="editgender.aspx?genderid=<%# Eval("GenderID") %>"><i class="fa-solid fa-pen"></i> Edit</a>  
                      </td> 
                     <td>
                            <asp:LinkButton CommandArgument='<%#Eval("GenderID") %>'  CommandName="Remove" CssClass="text-danger" ID="btnRemoveProducts" OnClientClick = "Confirm()"  runat="server" >
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
            <asp:HyperLink ID="lnkAddgender" class="btn btn-primary text-light btn-block gradient-custom-2 shadow" runat="server" NavigateUrl="~/admin/addgender.aspx">Add Gender</asp:HyperLink>
    </div>

            <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete this Gender")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
            </script>
</asp:Content>
