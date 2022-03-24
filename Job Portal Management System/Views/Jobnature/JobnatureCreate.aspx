<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="JobnatureCreate.aspx.cs" Inherits="Job_Portal_Management_System.Views.Jobnature.JobnatureCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <asp:HiddenField ID="hfJobnature" runat="server" />
            <asp:Label ID="LblMessage" runat="server" Text="Label" Visible="False"></asp:Label>
            <div class="card col-md-6 mx-auto mt-5">
                <div class="card-body">
                    <h1 class="card-title text-center" style="font-size: 24px;">
                        <asp:Label ID="lblJobnature" runat="server"></asp:Label></h1>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Job-Nature</label>
                        <span class="fill">*</span>
                        <asp:TextBox ID="txtJobnature" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtJobnature" ErrorMessage="Please fill job-nature" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="special charater doesn't allow" ForeColor="Red" ControlToValidate="txtJobnature" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-info mr-2" OnClick="btnClear_Click" CausesValidation="False" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark text-white" OnClick="btnBack_Click" CausesValidation="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>