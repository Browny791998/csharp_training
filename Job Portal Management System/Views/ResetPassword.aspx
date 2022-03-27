﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Job_Portal_Management_System.Views.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mb-5">
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
        <div class="row">
            <div class="col-md-6 offset-md-3 card p-5 mt-3 shadow rounded-sm">
                <h2>Password Reset Form</h2>
                <div class="form-group">
                    <label for="exampleInputEmail1">Email address</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">Role</label>
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                        <asp:ListItem>Job Seeker</asp:ListItem>
                        <asp:ListItem>Company</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" Text="Reset" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </div>
</asp:Content>