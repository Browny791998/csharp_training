﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="MovieList.aspx.cs" Inherits="SampleTaskList.Views.Movie.MovieList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
             <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="col-md-3">
                  <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-9">
                <asp:GridView ID="grvMovie" runat="server" CssClass="table table-striped table-hover pt-5" AutoGenerateColumns="false" DataKeyNames="id" OnRowDeleting="grvMovie_RowDeleting" OnRowUpdating="grvMovie_RowUpdating">
                    <Columns>
            <asp:TemplateField>
              <HeaderTemplate>
                <asp:HyperLink ID="hl_username" runat="server">No</asp:HyperLink>
              </HeaderTemplate>
              <ItemTemplate>
                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <HeaderTemplate>
                <asp:HyperLink ID="hl_email" runat="server">Movie</asp:HyperLink>
              </HeaderTemplate>
              <ItemTemplate>
                <%#HttpUtility.HtmlEncode(Eval("movie"))%>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="200px" ItemStyle-CssClass="text-center table-options" HeaderText="Action" HeaderStyle-CssClass="text-center">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update" Text="Update" CssClass="btn btn-success"></asp:LinkButton>
               <asp:LinkButton OnClientClick="return confirm('Are you sure to delete');" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" CssClass="btn btn-danger"></asp:LinkButton>
                    
              </ItemTemplate>
             
            </asp:TemplateField>
          </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
