<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Tutorial8.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server" style="margin-top: 20px">
        <h1 class="text-center text-info">CRUD Form</h1>
        <div class="col-md-8 col-md-offset-2">
            <div class="form-group">
                <div class="row">
                    <div class="col-md-2">
                        <label>Name</label>
                    </div>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-md-2 col-md-offset-1">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                    </div>

                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-md-6 col-md-offset-3">
                        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-success" Visible="False"></asp:Label>

                    </div>

                </div>
            </div>
        </div>
        <div class="col-md-8 col-md-offset-2">
            <asp:GridView ID="gvPet" runat="server" CssClass="table table-hover" AutoGenerateColumns="False"
                DataKeyNames="id" OnRowDeleting="gvPet_RowDeleting">
                <Columns>
                    <asp:BoundField HeaderText="No" DataField="id" />
                    <asp:BoundField HeaderText="Cat Name" DataField="name" />
                    <asp:HyperLinkField Text="Update" DataNavigateUrlFields="id"
                        DataNavigateUrlFormatString="Edit.aspx?id={0}" HeaderText="Edit" ControlStyle-CssClass="btn btn-info" />
                    <asp:CommandField ShowDeleteButton="true"
                        ControlStyle-CssClass="btn btn-danger" HeaderText="Delete" />

                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>

