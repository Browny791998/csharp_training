<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="PositionCreate.aspx.cs" Inherits="Job_Portal_Management_System.Views.Position.PositionCreate"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
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
            <asp:HiddenField ID="hfPosition" runat="server" />
            <asp:Label ID="LblMessage" runat="server" Text="Label" Visible="False"></asp:Label>
            <div class="card col-md-11 ml-5 mt-5 p-3" style="height: 80vh;">
                <div class="card-body">
                    <div class="col-md-12">
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="../../Views/User/AdminHome.aspx">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="../../Views/Position/PositionList.aspx">Position List</a></li>
                                <li class="breadcrumb-item active">
                                    <asp:Label ID="lblPositionbreadcrumb" runat="server" Text="Label"></asp:Label></li>
                            </ol>
                        </nav>
                    </div>
                    <h1 class="card-title text-center" style="font-size: 24px;">
                        <asp:Label ID="lblPosition" runat="server"></asp:Label></h1>
                    <div class="row">
                        <div class="form-group col-md-6" style="margin-top: 50px;">
                            <label for="exampleInputPassword1">Position</label>
                            <span class="fill">*</span>
                            <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPosition" ErrorMessage="Please fill position" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="special charater doesn't allow" ForeColor="Red" ControlToValidate="txtPosition" ValidationExpression="^[A-Za-z0-9_.\s]+$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-info mr-2" OnClick="btnClear_Click" CausesValidation="False" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark text-white" OnClick="btnBack_Click" CausesValidation="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>