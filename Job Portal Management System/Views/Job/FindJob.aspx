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
                   <div class="col-md-6">
             <p class="ml-5">Country</p>
                   </div>
                   <div class="col-md-6">
            <div class="dropdown">
  <button class="btn btn-warning dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    Country
  </button>
  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <a class="dropdown-item" href="#">Myanmar</a>
    <a class="dropdown-item" href="#">Japan</a>
    <a class="dropdown-item" href="#">Singapore</a>
  </div>
</div>
                   </div>
               </div>
              
                <div class="row mb-2">
                   <div class="col-md-6">
             <p class="ml-5">Position</p>
                   </div>
                   <div class="col-md-6">
            <div class="dropdown">
  <button class="btn btn-warning dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
   Position
  </button>
  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <a class="dropdown-item" href="#">Senior Developer</a>
    <a class="dropdown-item" href="#">Junior Developer</a>
    <a class="dropdown-item" href="#">OJT</a>
  </div>
</div>
                   </div>
               </div>

               <div class="row mb-2">
                   <div class="col-md-6">
             <p class="ml-5">Job Type</p>
                   </div>
                   <div class="col-md-6">
            <div class="dropdown">
  <button class="btn btn-warning dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    Job Nature
  </button>
  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <a class="dropdown-item" href="#">Full Time</a>
    <a class="dropdown-item" href="#">Part Time</a>
    <a class="dropdown-item" href="#">Freelance</a>
  </div>
</div>
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
      <%# Eval("title") %>
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
