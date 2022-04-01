<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/CompanyDashboard.Master" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="Job_Portal_Management_System.Views.Company.SendMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
         <h1 class="text-center text-info">Contact to Admin</h1>
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
        <div class="row">
            <div class="col-md-5 mt-5 offset-md-3">
                <div class="form-group">
                    <label for="txtSubject">Subject</label><span class="fill">*</span>
                    <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" ControlToValidate="txtSubject" ForeColor="Red">Subject can&#39;t be blank</asp:RequiredFieldValidator>
                   
                </div>

                <div class="form-group">
                    <label for="txtCompanyName">Company Name</label><span class="fill">*</span>
                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCompanyName" ForeColor="Red">Company Name can&#39;t be blank</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="txtJob">Job Title</label><span class="fill">*</span>
                    <asp:TextBox ID="txtJob" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtJob" ForeColor="Red">Job Title can&#39;t be blank</asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label for="txtMessage">Message</label><span class="fill">*</span>
                    <textarea id="txtMessage" cols="20" rows="2" runat="server" class="form-control"></textarea>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtMessage" ForeColor="Red">Message can&#39;t be blank</asp:RequiredFieldValidator>
                </div>

               

                <div class="form-group">
                    <label for="txtEmail">Email</label><span class="fill">*</span>
                    <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmail" ForeColor="Red">Email can&#39;t be blank</asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="txtPassword">Password</label><span class="fill">*</span>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPassword" ForeColor="Red">Password can&#39;t be blank</asp:RequiredFieldValidator>
                </div>
               
               
                <asp:Button ID="btnSend" runat="server" Text="Send Mail" CssClass="btn btn-info" OnClick="btnSend_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-warning" CausesValidation="false" />
            </div>
        </div>
    </div>
</asp:Content>
