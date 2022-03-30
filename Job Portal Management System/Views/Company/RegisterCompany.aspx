<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="RegisterCompany.aspx.cs" Inherits="Job_Portal_Management_System.Views.Company.RegisterCompany" ValidateRequest="false" %>

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

        <h1 class="text-center text-info">Company Registration Form</h1>
        <div class="row">
            <div class="col-md-5 mt-5 offset-md-3">
                <div class="form-group">
                    <label for="txtName">Name</label><span class="fill">*</span>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" ControlToValidate="txtName" ForeColor="Red">Name can&#39;t be blank</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator1" ControlToValidate="txtName" Display="Dynamic" runat="server" ErrorMessage="Special characters are not allowed" ValidationExpression="^[a-zA-Z'.\s]{1,40}$"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label for="ddlCountry">Country</label><span class="fill">*</span>
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCountry" ForeColor="Red">Please select Country</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="txtAddress">Address</label><span class="fill">*</span>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress" ForeColor="Red">Address can&#39;t be blank</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="txtContactPerson">Contact Person Name</label><span class="fill">*</span>
                    <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtContactPerson" Display="Dynamic" ForeColor="Red">Contact Person Name can&#39;t be blank</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator2" ControlToValidate="txtContactPerson" Display="Dynamic" runat="server" ErrorMessage="Special characters are not allowed" ValidationExpression="^[a-zA-Z'.\s]{1,40}$"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label for="txtMobile">Mobile</label><span class="fill">*</span>
                    <asp:TextBox ID="txtMobile" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtMobile" ForeColor="Red">Mobile can&#39;t be blank</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="txtWebsite">Website</label><span class="fill">*</span>
                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtWebsite" ForeColor="Red">Website can&#39;t be blank</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="txtEmail">Email</label><span class="fill">*</span>
                    <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmail" ForeColor="Red">Email can&#39;t be blank</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="txtPassword">Password</label><span class="fill">*</span>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPassword" ForeColor="Red">Password can&#39;t be blank</asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="txtDetail">Detail</label><span class="fill">*</span>
                    <asp:TextBox ID="txtDetail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDetail" ForeColor="Red">Detail can&#39;t be blank</asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-info" OnClick="btnRegister_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-warning" OnClick="btnClear_Click" />
            </div>
        </div>
    </div>
</asp:Content>