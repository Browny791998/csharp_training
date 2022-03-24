<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="JobSeekerProfile.aspx.cs" EnableEventValidation="false" Inherits="Job_Portal_Management_System.Views.JobSeeker.JobSeekerProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="text-center text-info">My Profile</h1>
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
            <div class="row">
                 
        <div class="col-md-8 card p-3 mt-3 mx-auto d-flex flex-column">
           <div class="row">
               <asp:Repeater ID="rptJobseeker" runat="server">
                   <ItemTemplate>
                        <div class="col-md-2">
                   <asp:Image ID="Image1" runat="server" Height="250" Width="250" ImageUrl='<%# Eval("profile") %>' />
               </div>

               <div class="col-md-10">
                   <div class="row d-flex flex-row justify-content-center mb-2">
                       <asp:Label ID="jobseekerId" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                 <h3 class="col-md-3">Name: </h3> <h3 class="col-md-4"><%# Eval("name") %></h3>
            </div>
            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Address: </h3><h3 class="col-md-4"><%# Eval("address") %></h3>
                 </div>
            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Mobile: </h3><h3 class="col-md-4"><%# Eval("mobile") %></h3>
                 </div>
             <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Birth Date: </h3><h3 class="col-md-4"><%# Eval("dob") %></h3>
                 </div>
            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Skill: </h3><h3 class="col-md-4"><%# Eval("skill") %></h3>
                 </div>
            
                   <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Experience: </h3><h3 class="col-md-4"><%# Eval("experience") %></h3>
                 </div>
                    <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Degree Name: </h3><h3 class="col-md-4"><%# Eval("degree_name") %></h3>
                 </div>
                   <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Email: </h3><h3 class="col-md-4"><%# Eval("email") %></h3>
                 </div>
            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Detail: </h3><p class="col-md-4"><%# Eval("detail") %></p>
                 </div>
            <div class="row d-flex flex-row justify-content-center mb-2">
                <div class="col-md-3"></div>
                <div class="col-md-4">
                    <asp:Button ID="btnEdit" CssClass="btn btn-info" runat="server" Text="Edit" OnClick="btnEdit_Click"/>
                 
                </div>
            
                 </div>

               </div>
                   </ItemTemplate>
               </asp:Repeater>
              
           </div>
            
        </div>
                </div>
</asp:Content>
