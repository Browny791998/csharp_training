<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="FindJob.aspx.cs" Inherits="Job_Portal_Management_System.Views.Job.FindJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
          <h2 class="text-center text-info mt-3 ">Recent Job List</h2>
       <div class="row mt-3">
          
           <div class="col-12 col-md-3 mt-5 border-right">
              <h2 class="text-danger text-center"> <i class="fa-solid fa-filter text-black-50 mr-2"></i>Filter Jobs</h2>
               <div class="row mb-2">
                   <div class="col-md-5">
             <p class="ml-5">Country</p>
                   </div>
                   <div class="col-md-7">
               <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control bg-info text-white font-weight-bold">
                   <asp:ListItem  Value="1">Singapore</asp:ListItem>
                   <asp:ListItem Value="2">Myanmar</asp:ListItem>
                   <asp:ListItem Value="3">Japan</asp:ListItem>
                   <asp:ListItem Value="4">China</asp:ListItem>
                   <asp:ListItem Value="5">Korea</asp:ListItem>
                       </asp:DropDownList>
                   </div>
               </div>
                <div class="row mb-2">
                   <div class="col-md-5">
             <p class="ml-5">Position</p>
                   </div>
                   <div class="col-md-7">
               <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control bg-info text-white font-weight-bold">
                   <asp:ListItem Value="1">Junior Developer</asp:ListItem>
                   <asp:ListItem Value="2">Senior Developer</asp:ListItem>
                   <asp:ListItem Value="3">Leader</asp:ListItem>
                
                       </asp:DropDownList>
                   </div>
               </div>
                <div class="row mb-2">
                   <div class="col-md-5">
             <p class="ml-5">Job Type</p>
                   </div>
                   <div class="col-md-7">
               <asp:DropDownList ID="ddlJobtype" runat="server" CssClass="form-control bg-info text-white font-weight-bold">
                   <asp:ListItem Value="1">Part-time</asp:ListItem>
                   <asp:ListItem Value="2">Full-time</asp:ListItem>
                   <asp:ListItem Value="3">Freelance</asp:ListItem>
                
                
                       </asp:DropDownList>
                   </div>
               </div>

               

              <div class="row">
                  <div class="col-md-12">
                       <button class="btn btn-secondary btn-block">Filter</button>
                   </div>
              </div>
                   
          
           </div>
           <div class="col-12 col-md-8 p-2 ml-5">
           <div class="row">
          
               <asp:Repeater ID="rptJoblist" runat="server">
                   <ItemTemplate>
                         <div class="col-md-12 mt-2">
                   <div class="card">
  <div class="card-header">
      <%# Eval("name") %>
  </div>
  <div class="card-body">
    <h5 class="card-title"><%# Eval("title") %><span class="badge badge-success ml-3"><%# Eval("job_nature") %></span></h5>
      <p class="card-text">Position - <%# Eval("position") %></p>
       <p class="card-text">Skill - <%# Eval("skill") %></p>
      <p>Salary - <%# Eval("salary") %></p>
    <a href="#" class="btn btn-info">View</a>
  </div>
</div>
               </div>
                   </ItemTemplate>
               </asp:Repeater>
              
           
           </div>
           </div>
       </div>
    </div>
</asp:Content>
