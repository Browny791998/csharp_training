<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tutorial7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></h1>

        <asp:LinkButton ID="btnLogout" runat="server" Font-Bold="True" Font-Size="X-Large" OnClick="btnLogout_Click">Logout</asp:LinkButton>
    </div>

</asp:Content>
