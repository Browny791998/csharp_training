<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="AppliedJob.aspx.cs" Inherits="Job_Portal_Management_System.Views.JobSeeker.AppliedJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["alert"] != null && Session["alert-type"] != null)
        {
            Lblalert.Visible = true;
            Lblalert.Text = Session["alert"].ToString();
            string type = Session["alert-type"].ToString();
    %>
    <div class="AlertMessage" id="AlertMsg">
        <div class="row">
            <div class="col-md-6 col-md-offset-2">
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
    <h1 class="text-center text-info">Your Applied Job</h1>
    <div class="container">
        <div class="row mt-5 mb-5">
            <div class="col-md-12">

                <asp:GridView ID="grvAppliedJob" runat="server" CssClass="gvJobOffer table table-striped table-hover" ShowHeaderWhenEmpty="True" PageSize="5" DataKeyNames="id" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnPageIndexChanging="grvAppliedJob_PageIndexChanging" OnRowDeleting="grvAppliedJob_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Label">No</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>

                            <ItemStyle Width="5px" HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:BoundField DataField="title" HeaderText="Title" />
                        <asp:BoundField DataField="name" HeaderText="Name" />
                        <asp:BoundField DataField="country" HeaderText="Country" />
                        <asp:BoundField DataField="position" HeaderText="Position" />
                        <asp:BoundField DataField="job_nature" HeaderText="Job Nature" />
                        <asp:BoundField DataField="specialization" HeaderText="Specialization" />
                        <asp:BoundField DataField="applied_date" HeaderText="Applied Date" />

                        <asp:TemplateField ItemStyle-CssClass="text-center table-options" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>

                                <asp:LinkButton OnClientClick="return confirm('Are you sure to undo');" ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Undo" CssClass="btn btn-danger"></asp:LinkButton>
                            </ItemTemplate>

                            <HeaderStyle CssClass="text-center"></HeaderStyle>

                            <ItemStyle CssClass="text-center table-options"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    <PagerStyle Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="pagination-ys" BackColor="White" BorderColor="White" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>