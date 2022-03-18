<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Job_Portal_Management_System.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
          <div class="col-md-6 offset-md-3 card p-5 mt-3 shadow rounded-sm">
              <h2>Login Form</h2>
              <div class="form-group">
    <label for="exampleInputEmail1">Email address</label>
    <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email"  runat="server"></asp:TextBox>
    
  </div>
  <div class="form-group">
    <label for="exampleInputPassword1">Password</label>
      <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
  </div>
               <div class="form-group">
    <label for="exampleInputPassword1">Role</label>
    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
        <asp:ListItem>Job Seeker</asp:ListItem>
        <asp:ListItem>Company</asp:ListItem>
                   </asp:DropDownList>          
  </div>
  <div class="form-group form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <label class="form-check-label" for="exampleCheck1">Remember Me</label>
      <asp:HyperLink ID="HyperLink1" runat="server" CssClass="text-primary pointer-event float-right">Forgot Password?</asp:HyperLink>
  </div>
              <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" Text="Login" OnClick="btnSubmit_Click"  />
          </div>
      </div>
  
   </div>
</asp:Content>
