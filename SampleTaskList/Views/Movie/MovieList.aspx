<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="SampleTaskList.Views.Movie.MovieList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    
  


       <h1 class="text-center text-warning">Movie List</h1>
    <div class="list-sec container">
        <%if (Session["alert"] != null)
            { 
                Lblalert.Visible = true;
                Lblalert.Text = Session["alert"].ToString();%>
          <div class="row">
        <div class="col-md-6 col-md-offset-2">
        <div class="alert alert-warning alert-dismissible" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <asp:Label ID="Lblalert" runat="server" Text="Label" Visible="False"></asp:Label>
</div>
    </div>
    </div>
        <%
                Session.Remove("alert");
            } %>
        <div class="row">
            <div class="col-md-3">
             <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
            </div>
            <div class="col-md-5">
                <div class="form-group row">
    <label for="txtSearch" class="col-sm-3 col-form-label text-info">Movie Name</label>
    <div class="col-sm-6">
    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
     <div class="col-sm-2">
    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
    </div>
  </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-7">
                <asp:GridView ID="grvMovie" runat="server" CssClass="table table-striped table-hover pt-5" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="grvMovie_RowDeleting" OnRowUpdating="grvMovie_RowUpdating" AllowPaging="True" PageSize="5" OnPageIndexChanging="grvMovie_PageIndexChanging">
                    <Columns>
            <asp:TemplateField ItemStyle-Width="5%">
              <HeaderTemplate>
                  <asp:Label ID="Label1" runat="server" Text="Label">No</asp:Label>
              </HeaderTemplate>
              <ItemTemplate>
                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
              </ItemTemplate>

<ItemStyle Width="5%" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="35%">
              <HeaderTemplate>
                  <asp:Label ID="Label2" runat="server" Text="Label">Movie</asp:Label>
              </HeaderTemplate>
              <ItemTemplate>
                <%#HttpUtility.HtmlEncode(Eval("movie"))%>
              </ItemTemplate>

<ItemStyle Width="35%"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="20%" ItemStyle-CssClass="text-center table-options" HeaderStyle-CssClass="text-center">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update" Text="Update" CssClass="btn btn-success"></asp:LinkButton>
                    
              </ItemTemplate>
             
<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-center table-options" Width="20%"></ItemStyle>
             
            </asp:TemplateField>
                      <asp:TemplateField ItemStyle-Width="20%" ItemStyle-CssClass="text-center table-options"  HeaderStyle-CssClass="text-center">
                          <ItemTemplate>
                              
               <asp:LinkButton OnClientClick="return confirm('Are you sure to delete');" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" CssClass="btn btn-danger"></asp:LinkButton>
                          </ItemTemplate>

<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-center table-options" Width="20%"></ItemStyle>
                      </asp:TemplateField>

          </Columns>
                    <HeaderStyle BackColor="#6699FF" ForeColor="Black" />
            <PagerStyle   Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="pagination-ys" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
