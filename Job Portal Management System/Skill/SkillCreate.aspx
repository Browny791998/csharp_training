<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="SkillCreate.aspx.cs" Inherits="Job_Portal_Management_System.Views.Skill.SkillCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <asp:HiddenField ID="hfSkill" runat="server" />
            <asp:Label ID="LblMessage" runat="server" Text="Label" Visible="False"></asp:Label>
            <div class="card col-md-11 ml-5 mt-5 p-3" style="height: 80vh;">
                <div class="card-body">
                    <div class="col-md-12">
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="../../Views/User/AdminHome.aspx">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="../../Views/Skill/SkillList.aspx">Skill List</a></li>
                                <li class="breadcrumb-item active">
                                    <asp:Label ID="lblSkillbreadcrumb" runat="server" Text="Label"></asp:Label></li>
                            </ol>
                        </nav>
                    </div>
                    <h1 class="card-title text-center" style="font-size: 24px;">
                        <asp:Label ID="lblSkill" runat="server"></asp:Label></h1>
                    <div class="row">
                        <div class="form-group col-md-6" style="margin-top: 50px;">
                            <label for="exampleInputPassword1">Skill</label>
                            <span class="fill">*</span>
                            <asp:TextBox ID="txtSkill" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSkill" Display="Dynamic" ErrorMessage="Please fill skill" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="special charater doesn't allow" ForeColor="Red" ControlToValidate="txtSkill" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-info mr-2" OnClick="btnClear_Click" CausesValidation="False" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-dark text-white" OnClick="btnBack_Click" CausesValidation="False" />
                    </div>
                </div>
            </div>
            <%--     <div class="col-md-6">
                <div class="form-group">
                    <label for="exampleInputPassword1">Country</label>
                    <span class="fill">*</span>
                    <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCountry" ErrorMessage="Please fill country" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-info" OnClick="btnClear_Click" CausesValidation="False" />
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-info" OnClick="btnBack_Click" CausesValidation="False" />
            </div>--%>
        </div>
    </div>
</asp:Content>