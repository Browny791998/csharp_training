<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="MovieRentingEdit.aspx.cs" Inherits="SampleTaskList.Views.MovieRenting.MovieRentingEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <h1>Edit MovieRenting</h1>
            <asp:Label ID="LblMessage" runat="server" Text="Label" Visible="False"></asp:Label>
    <div class="col-md-6">
         <asp:HiddenField ID="hfMovieRent" runat="server" />
  <div class="form-group">
    <label for="exampleInputPassword1">Movie</label>
       <asp:DropDownList ID="ddlMovie" runat="server" CssClass="form-control"></asp:DropDownList>
  </div>
        <div class="form-group">
    <label for="exampleInputPassword1">Customer</label>
       <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control"></asp:DropDownList>
  </div>
        
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear"  CssClass="btn btn-info" OnClick="btnClear_Click"/>
          <asp:Button ID="btnBack" runat="server" Text="Back"  CssClass="btn btn-info" OnClick="btnBack_Click" CausesValidation="False"/>
     </div>
        </div>
    </div>
</asp:Content>
