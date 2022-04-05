<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="AdminJobSeekerList.aspx.cs" Inherits="Job_Portal_Management_System.Views.User.AdminJobSeekerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="list-sec container card p-3 mt-4">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="../../Views/User/AdminHome.aspx">Dashboard</a></li>
                <li class="breadcrumb-item active">Job Seeker List</li>
            </ol>
        </nav>
        <h1 class="text-center text-warning mb-5">Job Seeker List</h1>
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

            <div class="col-md-7">

                <asp:Label ID="Label2" runat="server" CssClass="font-weight-bold mr-3" Text="Label">Job Seeker Name</asp:Label>
                <asp:TextBox ID="txtSearch" runat="server" Style="padding: 5px 35px 5px 13px; outline: none;"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                 <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-info mr-2"  CausesValidation="False" OnClick="btnClear_Click" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="grvJobSeeker" runat="server" CssClass="gvJobSeeker table table-striped pt-5" AutoGenerateColumns="False" DataKeyNames="id" PageSize="5"
                    ShowHeaderWhenEmpty="True" OnPageIndexChanging="grvJobSeeker_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="5%">
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Label">No</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>

                            <ItemStyle Width="5px" HorizontalAlign="Left"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Name</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("name"))%>
                            </ItemTemplate>
                            <ItemStyle Width="250px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Address</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("address"))%>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Mobile</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("mobile"))%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Birth Date</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("dob"))%>
                            </ItemTemplate>
                            <ItemStyle Width="350px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Skill</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("skill"))%>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Degree</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("degree_name"))%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Email</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("email"))%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Profile">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="100" Width="100" ImageUrl='<%# Eval("profile") %>' />
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