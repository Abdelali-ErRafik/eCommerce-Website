<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="eCommerce_Website.admin.users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="text-center  my-4">Users</h1>
      <asp:Repeater  ID="rptAdmins" runat="server" OnItemCommand="rptAdmins_ItemCommand" >
            <HeaderTemplate>
                <div class="table-responsive">
                <table class="table table-striped table-Light shadow mb-4">
                <thead>
                    <tr>
                      <th scope="col">#</th>
                      <th scope="col">User Name</th>
                      <th scope="col">Full Name</th>
                      <th scope="col">Email</th>

                    
                      <th scope="col">Edit</th>
                      <th scope="col">Delete</th>
                    </tr>
                </thead>
                  <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                      <th scope="row"><%# Eval("UID") %></th>
                      <th><%# Eval("UserName") %></th>
                      <td><%# Eval("FullName") %></td>
                      <td><%# Eval("Email") %></td>

                      <td>
                          <a class="text-success" href="edituser.aspx?uid=<%#Eval("UID")%>"><i class="fa-solid fa-pen"></i> Edit</a>  
                      </td>                      
                       <td>
                            <asp:LinkButton CommandArgument='<%#Eval("UID")%>' CommandName="Remove" CssClass="text-danger" ID="btnRemoveAdmin" OnClientClick = "Confirm()"  runat="server" >
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
            <asp:HyperLink ID="lnkAddAdmin" class="btn btn-primary text-light btn-block gradient-custom-2 shadow" runat="server" NavigateUrl="~/admin/adduser.aspx">Add User</asp:HyperLink>
    </div>

    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete this User")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
