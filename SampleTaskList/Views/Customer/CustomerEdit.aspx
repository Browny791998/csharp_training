<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="SampleTaskList.Views.Customer.CustomerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container">
        <div class="row">
            <h1>Edit Customer</h1>
            <asp:Label ID="LblMessage" runat="server" Text="Label" Visible="False"></asp:Label>
    <div class="col-md-6">
        <asp:HiddenField ID="hfCustomer" runat="server" />
  <div class="form-group">
    <label for="exampleInputPassword1">Salutation</label>
       <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="form-control"></asp:DropDownList>
  </div>
        <div class="form-group">
    <label for="exampleInputPassword1">Full Name</label>
      <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
  </div>
        <div class="form-group">
    <label for="exampleInputPassword1">Address</label>
      <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
  </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnClear" runat="server" Text="Clear"  CssClass="btn btn-info" OnClick="btnClear_Click"/>
          <asp:Button ID="btnBack" runat="server" Text="Back"  CssClass="btn btn-info" OnClick="btnBack_Click"/>
     </div>
        </div>
    </div>
</asp:Content>
