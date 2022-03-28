﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="JobnatureCreate.aspx.cs" Inherits="Job_Portal_Management_System.Views.Jobnature.JobnatureCreate" 
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <asp:HiddenField ID="hfJobnature" runat="server" />
            <asp:Label ID="LblMessage" runat="server" Text="Label" Visible="False"></asp:Label>
            <div class="card col-md-11 ml-5 mt-5 p-3" style="height: 80vh;">
                <div class="card-body">
                    <div class="card-body">
                        <div class="col-md-12">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="../../Views/User/AdminHome.aspx">Dashboard</a></li>
                                    <li class="breadcrumb-item"><a href="../../Views/Jobnature/JobnatureList.aspx">Jobnature List</a></li>
                                    <li class="breadcrumb-item active">
                                        <asp:Label ID="lblJobnaturebreadcrumb" runat="server" Text="Label"></asp:Label></li>
                                </ol>
                            </nav>
                        </div>
                        <h1 class="card-title text-center" style="font-size: 24px;">
                            <asp:Label ID="lblJobnature" runat="server"></asp:Label></h1>
                        <div class="row">
                            <div class="form-group col-md-6" style="margin-top: 50px;">
                                <label for="exampleInputPassword1">Job-Nature</label>
                                <span class="fill">*</span>
                                <asp:TextBox ID="txtJobnature" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtJobnature" ErrorMessage="Please fill job-nature" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="special charater doesn't allow" ForeColor="Red" ControlToValidate="txtJobnature" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" Display="Dynamic"></asp:RegularExpressionValidator>
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