<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="AdminJobOffer.aspx.cs" Inherits="Job_Portal_Management_System.Views.User.AdminJobOffer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="text-center text-warning" style="padding-bottom: 80px">job offer List</h1>
    <div class="list-sec container">
        <%if (Session["alert"] != null && Session["alert-type"] != null)
            {
                Lblalert.Visible = true;
                Lblalert.Text = Session["alert"].ToString();
                string type = Session["alert-type"].ToString();
        %>
        <div class="AlertMessage" id="AlertMsg">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="alert alert-<% Response.Write(type); %> alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <asp:Label ID="Lblalert" runat="server" Text="Label" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <%
                Session.Remove("alert");
                Session.Remove("alert-type");
            } %>
     
        <div class="row">
            
            <div class="col-md-10 ">
                
                <asp:Label ID="Label4" runat="server" CssClass="font-weight-bold" Text="Label">Company Name</asp:Label>
                <asp:DropDownList ID="ddlCompany"  runat="server"></asp:DropDownList>
                <asp:Label ID="Label2" runat="server" CssClass="font-weight-bold" Text="Label">job Name</asp:Label>

                <asp:TextBox ID="txtSearch" runat="server" Style="padding: 5px 35px 5px 13px; outline: none;"></asp:TextBox>
                
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                 <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary" OnClick="btnClear_Click" />
            </div>
             <div class="col-md-2">
            Accept: <asp:RadioButton ID="rdoAccept" runat="server" GroupName="Accept" CssClass="custom-radio"/>
            Reject: <asp:RadioButton ID="rdoReject" runat="server" GroupName="Accept" CssClass="custom-radio"/>
        </div>
            
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="grvJoboffer" runat="server" CssClass="gvJoboffer table table-striped table-hover pt-5" AutoGenerateColumns="False" DataKeyNames="id" PageSize="5"
                    ShowHeaderWhenEmpty="True" OnPageIndexChanging="grvJoboffer_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="5%">
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Label">No</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>

                            <ItemStyle Width="5px" HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Name</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("seeker"))%>
                            </ItemTemplate>
                            <ItemStyle Width="200px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Job</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("title"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Company</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("company"))%>
                            </ItemTemplate>
                        </asp:TemplateField>

                       

                          <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Email</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("seekermail"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Status</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("Accept"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Applied Date</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("applied_date"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
         
         
         
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    <HeaderStyle BackColor="#6699FF" />
                    <PagerStyle Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="pagination-ys" BackColor="White" BorderColor="White" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
