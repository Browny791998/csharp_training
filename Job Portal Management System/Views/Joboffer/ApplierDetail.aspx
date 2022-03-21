<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/CompanyDashboard.Master" AutoEventWireup="true" CodeBehind="ApplierDetail.aspx.cs" Inherits="Job_Portal_Management_System.Views.Joboffer.ApplierDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="text-center text-info">Applier Detail</h1>
   
            <div class="row">
                 
        <div class="col-md-12 card p-3 mt-3  d-flex flex-column">
           <div class="row">
               <asp:Repeater ID="rptApplier" runat="server">
                   <ItemTemplate>
                        <div class="col-md-2">
                   <asp:Image ID="Image1" runat="server" Height="250" Width="250" ImageUrl='<%# Eval("profile") %>' />
               </div>

               <div class="col-md-10">
                   <div class="row d-flex flex-row justify-content-center mb-2">
                       <asp:Label ID="jobseekerId" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                 <h3 class="col-md-3">Name: </h3> <h3 class="col-md-5"><%# Eval("name") %></h3>
            </div>
            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Address: </h3><h3 class="col-md-5"><%# Eval("address") %></h3>
                 </div>
            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Mobile: </h3><h3 class="col-md-5"><%# Eval("mobile") %></h3>
                 </div>
             <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Birth Date: </h3><h3 class="col-md-5"><%# Eval("dob") %></h3>
                 </div>
            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Skill: </h3><h3 class="col-md-5"><%# Eval("skill") %></h3>
                 </div>
            
                   <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Experience: </h3><h3 class="col-md-5"><%# Eval("experience") %></h3>
                 </div>
                    <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Degree Name: </h3><h3 class="col-md-5"><%# Eval("degree_name") %></h3>
                 </div>
                   <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Email: </h3><h3 class="col-md-5"><%# Eval("email") %></h3>
                 </div>
            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-3">Detail: </h3><p class="col-md-5"><%# Eval("detail") %></p>
                 </div>
          

               </div>
                   </ItemTemplate>
               </asp:Repeater>
              
           </div>
            
        </div>
                </div>
</asp:Content>
