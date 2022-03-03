﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="MovieRentingList.aspx.cs" Inherits="SampleTaskList.Views.MovieRenting.MovieRentingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center text-warning">MovieRenting List</h1>
    <div class="list-sec container">
        <div class="row">

            <div class="col-md-3">
             <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
            </div>
             <div class="col-md-5">
                <div class="form-group row">
    <label for="txtSearch" class="col-sm-4 col-form-label text-info">Customer Name</label>
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
            <div class="col-md-9">
                <asp:GridView ID="grvMovieRent" runat="server" CssClass="table table-striped table-hover pt-5" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="grvMovieRent_RowDeleting" OnRowUpdating="grvMovieRent_RowUpdating" AllowPaging="True" OnPageIndexChanging="grvMovieRent_PageIndexChanging" PageSize="5">
                    <Columns>
            <asp:TemplateField>
              <HeaderTemplate>
                  <asp:Label ID="Label1" runat="server" Text="Label">No</asp:Label>
              </HeaderTemplate>
              <ItemTemplate>
                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
              <HeaderTemplate>
                  <asp:Label ID="Label2" runat="server" Text="Label">Salutation</asp:Label>
              </HeaderTemplate>
              <ItemTemplate>
                <%#HttpUtility.HtmlEncode(Eval("salutation"))%>
              </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField>
              <HeaderTemplate>
                  <asp:Label ID="Label3" runat="server" Text="Label">Customer Name</asp:Label>
              </HeaderTemplate>
              <ItemTemplate>
                <%#HttpUtility.HtmlEncode(Eval("full_name"))%>
              </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField>
              <HeaderTemplate>
                  <asp:Label ID="Label4" runat="server" Text="Label">Address</asp:Label> 
              </HeaderTemplate>
              <ItemTemplate>
                <%#HttpUtility.HtmlEncode(Eval("address"))%>
              </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
              <HeaderTemplate>
                  <asp:Label ID="Label5" runat="server" Text="Label">Movie</asp:Label>  
              </HeaderTemplate>
              <ItemTemplate>
                <%#HttpUtility.HtmlEncode(Eval("movie"))%>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="50px" ItemStyle-CssClass="text-center table-options"  HeaderStyle-CssClass="text-center">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update" Text="Update" CssClass="btn btn-success"></asp:LinkButton>
                    
              </ItemTemplate>
             
<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-center table-options" Width="50px"></ItemStyle>
             
            </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="50px" ItemStyle-CssClass="text-center table-options"  HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                
               <asp:LinkButton OnClientClick="return confirm('Are you sure to delete');" ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" CssClass="btn btn-danger"></asp:LinkButton>
                            </ItemTemplate>

<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-center table-options" Width="50px"></ItemStyle>
                        </asp:TemplateField>
          </Columns>
                     <HeaderStyle BackColor="#6699FF" />
                     <PagerStyle   Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="page" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
