<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Job_Portal_Management_System.Views.User.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Resources/css/lib/bootstrap.min.css" rel="stylesheet" />
 
</head>

<body>
    <form id="form1" runat="server">
        <div class="loginform">
            <div class="row">
                <div class="col-md-5 offset-md-4 card p-5 shadow-sm mt-5">
                    <h1 class="text-center text-info">Admin Login</h1>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Email address</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Password</label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-info" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>