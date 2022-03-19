<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="JobSeekerEdit.aspx.cs" Inherits="Job_Portal_Management_System.Views.JobSeeker.JobSeekerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <%if (Session["alert"] != null && Session["alert-type"] != null )
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
        <h1 class="text-center text-info">Edit Profile</h1>
         <div class="row">
            
        <div class="col-md-5 mt-5 offset-md-1">
             <div class="form-group">
    <label for="txtName">Name</label>
       <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtName" ForeColor="Red">Name can&#39;t be blank</asp:RequiredFieldValidator>
  </div>
  <div class="form-group">
    <label for="txtAddress">Address</label>
      <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress" ForeColor="Red">Address can&#39;t be blank</asp:RequiredFieldValidator>
  </div>
  <div class="form-group">
    <label for="txtMobile">Mobile</label>
      <asp:TextBox ID="txtMobile" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtMobile" ForeColor="Red">Mobile can&#39;t be blank</asp:RequiredFieldValidator>
  </div>

   <div class="form-group">
    <label for="ddlgender">Gender</label>
       <asp:DropDownList ID="ddlgender" runat="server" CssClass="form-control">
           <asp:ListItem>Male</asp:ListItem>
           <asp:ListItem>Female</asp:ListItem>
           <asp:ListItem>Other</asp:ListItem>
       </asp:DropDownList>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlgender" ForeColor="Red">Please select Gender</asp:RequiredFieldValidator>
  </div>
    <div class="form-group">
    <label for="txtDate">Date of Birth</label>
        <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDate" ForeColor="Red">Please select your birth date</asp:RequiredFieldValidator>
  </div>
<div class="form-group">
    <label for="lbSkill">Skill</label>
    <asp:ListBox ID="lbSkill" runat="server" CssClass="form-control" SelectionMode="Multiple">
        <asp:ListItem>C#</asp:ListItem>
        <asp:ListItem>Java</asp:ListItem>
        <asp:ListItem>Python</asp:ListItem>
        <asp:ListItem>PHP</asp:ListItem>
        <asp:ListItem></asp:ListItem>

    </asp:ListBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="lbSkill" ForeColor="Red">Please select your skill</asp:RequiredFieldValidator>
  </div>
     <div class="form-group">
    <label for="txtExperience">Experience</label>
         <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtExperience" ForeColor="Red">Experience can&#39;t be blank</asp:RequiredFieldValidator>
  </div>

            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-info" OnClick="btnUpdate_Click" />
        </div>
    <div class="col-md-5 mt-5">
         <div class="form-group">
    <label for="ddldegree">Degree</label>
         <asp:DropDownList ID="ddlDegree" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDegree_SelectedIndexChanged" AutoPostBack="True">
             <asp:ListItem Value="Graduate">Graduate</asp:ListItem>
             <asp:ListItem Value="Under Graduate">Under Graduate</asp:ListItem>
             </asp:DropDownList>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDegree" ForeColor="Red">Please select Degree</asp:RequiredFieldValidator>
          </div>
          <div class="form-group">
    
              <asp:Panel ID="pnldegree" runat="server">
                  <label for="txtDegree">Degree Name</label>
                  <asp:TextBox ID="txtDegree" runat="server" CssClass="form-control" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDegree" ForeColor="Red">Degree can&#39;t be blank</asp:RequiredFieldValidator>
              </asp:Panel>
         
          </div>
        <div class="form-group">
    <label for="fuCV">CV Form</label>
            <asp:HiddenField ID="hfCV" runat="server" />
            <asp:FileUpload ID="fuCV" runat="server" CssClass="form-control pb-3" />
          </div>
        <div class="form-group">
    <label for="currentimg">Current Profile</label>
              <asp:Image ID="currentimg" runat="server" Width="200" Height="200" />
          </div>
        <div class="form-group">
          
    <label for="fuProfile">Profile</label>
            
            <asp:FileUpload ID="fuProfile" runat="server" CssClass="form-control pb-3" />
          </div>

        
        <div class="form-group">
    <label for="txtDetail">Detail</label>
            <asp:TextBox ID="txtDetail" runat="server" CssClass="form-control"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDetail" ForeColor="Red">Detail can&#39;t be blank</asp:RequiredFieldValidator>
          </div>
                   </div>
             
    </div>
    </div>
</asp:Content>
