<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="JobnatureList.aspx.cs" Inherits="Job_Portal_Management_System.Views.Jobnature.JobnatureList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center text-warning" style="padding-bottom: 80px">Job-Nature List</h1>
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

            <%--<div class="col-md-7 col-md-offset-2">
                <div class="form-group row">
                    <label for="txtSearch" class="searchlabel col-sm-4 col-form-label">Country Name</label>
                    <div class="col-sm-6">
                    </div>
                    <div class="col-sm-2">
                    </div>
                </div>
            </div>--%>
            <div class="col-md-4">
                <asp:Button ID="btnAdd" runat="server" Text="Add Job-Nature" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
            </div>
            <div class="col-md-8 ">
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-warning float-right" OnClick="btnClear_Click" />
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary float-right mr-3" OnClick="btnSearch_Click" />
                <asp:TextBox ID="txtSearch" runat="server" placeholder="Search By Job-Nature" Style="padding: 5px 35px 5px 13px; outline: none;" CssClass="float-right mr-3" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="grvJobnature" runat="server" CssClass="gvJobnature table table-striped table-hover pt-5" AutoGenerateColumns="False" DataKeyNames="id" OnRowUpdating="grvJobnature_RowUpdating" OnRowDeleting="grvJobnature_RowDeleting" OnPageIndexChanging="grvJobnature_PageIndexChanging" PageSize="5"
                    ShowHeaderWhenEmpty="True">
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
                        <asp:TemplateField ItemStyle-Width="20%">
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Label">Job-Nature</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#HttpUtility.HtmlEncode(Eval("job_nature"))%>
                            </ItemTemplate>
                            <ItemStyle Width="200px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-CssClass="text-center table-options" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update" Text="Update" CssClass="btn btn-success btn-sm"></asp:LinkButton>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center"></HeaderStyle>

                            <ItemStyle CssClass="text-center table-options" Width="30px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-CssClass="text-center table-options" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton OnClientClick="return confirm('Are you sure to delete');" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" CssClass="btn btn-danger btn-sm"></asp:LinkButton>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center"></HeaderStyle>

                            <ItemStyle CssClass="text-center table-options" Width="30px"></ItemStyle>
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