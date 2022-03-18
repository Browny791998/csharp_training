﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/CompanyDashboard.Master" AutoEventWireup="true" CodeBehind="CreateJob.aspx.cs" Inherits="Job_Portal_Management_System.Views.Job.CreateJob" %>
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
        <div class="col-md-6 col-md-offset-2 fixed-top">
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

         <h1 class="text-center text-info ml-5">Create Your Job Offer</h1>
        <div class="row">
              <div class="col-md-5 mt-5 offset-md-4">
                   <div class="form-group">
    <label for="txtTitle">Title</label>
       <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTitle" ForeColor="Red">Title can&#39;t be blank</asp:RequiredFieldValidator>
                  </div>

                   <div class="form-group">
    <label for="ddlDegree">Degree</label>
       <asp:DropDownList ID="ddlDegree" runat="server" CssClass="form-control">
           <asp:ListItem>Graduate</asp:ListItem>
           <asp:ListItem>Under Graduate</asp:ListItem>
           <asp:ListItem>Graduate &amp; Under Graduate</asp:ListItem>
                       </asp:DropDownList>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDegree" ForeColor="Red">Please Choose Degree</asp:RequiredFieldValidator>
  </div>

    <div class="form-group">
    <label for="lbSkill">Skill</label>
        <asp:ListBox ID="lbSkill" runat="server" CssClass="form-control" SelectionMode="Multiple">
            <asp:ListItem Value="1">C#</asp:ListItem>
            <asp:ListItem Value="2">Java</asp:ListItem>
            <asp:ListItem Value="3">PHP</asp:ListItem>
            <asp:ListItem Value="4">Python</asp:ListItem>
        </asp:ListBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="lbSkill" ForeColor="Red">Please Select Skill</asp:RequiredFieldValidator>
  </div>

                   <div class="form-group">
    <label for="txtExperience">Experience</label>
      <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtExperience" ForeColor="Red">Experience can&#39;t be blank</asp:RequiredFieldValidator>
                 </div>

           <div class="form-group">
    <label for="txtVacancy">Vacancy</label>
      <asp:TextBox ID="txtVacancy" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtVacancy" ForeColor="Red">Vacancy can&#39;t be blank</asp:RequiredFieldValidator>
  </div>

    <div class="form-group">
    <label for="ddlPosition">Position</label>
        <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control">
            <asp:ListItem Value="1">Junior Developer</asp:ListItem>
            <asp:ListItem Value="2">Senior Developer</asp:ListItem>
            <asp:ListItem Value="3">Leader</asp:ListItem>
        </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlPosition" ForeColor="Red">Please Select Position</asp:RequiredFieldValidator>
          </div>

       <div class="form-group">
    <label for="ddlJobtype">Job Type</label>
        <asp:DropDownList ID="ddlJobtype" runat="server" CssClass="form-control">
            <asp:ListItem Value="1">Part-time</asp:ListItem>
            <asp:ListItem Value="2">Full-time</asp:ListItem>
            <asp:ListItem Value="3">Freelance</asp:ListItem>
        </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlJobtype" ForeColor="Red">Please Select Job Type</asp:RequiredFieldValidator>
          </div>
                  <div class="form-group">
    <label for="txtSalary">Salary</label>
            <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtSalary" ForeColor="Red">Salary can&#39;t be blank</asp:RequiredFieldValidator>
          </div>
                   <div class="form-group">
    <label for="txtDetail">Detail</label>
            <asp:TextBox ID="txtDetail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtDetail" ForeColor="Red">Detail can&#39;t be blank</asp:RequiredFieldValidator>
          </div>
                   <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-info" OnClick="btnSubmit_Click"  />
            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-warning"/>
                  </div>
        </div>

    </div>
</asp:Content>
