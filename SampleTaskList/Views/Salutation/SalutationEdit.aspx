<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layouts/Main.Master" AutoEventWireup="true" CodeBehind="SalutationEdit.aspx.cs" Inherits="SampleTaskList.Views.Salutation.SalutationEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <h1>Edit Salutation</h1>
    <div class="col-md-6">
  <div class="form-group">
    <label for="exampleInputPassword1">Salutation</label>
      <asp:HiddenField ID="hfSalutation" runat="server" />
      <asp:TextBox ID="txtSalutation" runat="server" CssClass="form-control"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSalutation" ErrorMessage="Please fill salutation" ForeColor="Red"></asp:RequiredFieldValidator>
      <br />
  </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click"/>
        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"  CssClass="btn btn-info"/>
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btn_Back"  CssClass="btn btn-warning" CausesValidation="False"/>

     </div>
        </div>
    </div>
</asp:Content>
