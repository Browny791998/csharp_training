<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="JobDetail.aspx.cs" Inherits="Job_Portal_Management_System.Views.Job.JobDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
        <div class="row">
            <asp:Repeater ID="rptJob" runat="server">
                <ItemTemplate>
            <div class="col-md-7">
                <div class="card p-5 mt-3 shadow-sm">
                     <h1 class="text-primary"> <%# Eval("title") %></h1>
                <div class="d-flex flex-row justify-content-between mt-3">
                    <p> <%# Eval("name") %></p>
                     <p> <%# Eval("country") %></p>
                    <p> <%# Eval("salary") %>/month</p>
                </div>
                </div>

                <div class="job-detail mt-3">
                    <h2>Job Detail</h2>
                    <p> <%# Eval("detail") %></p>
                </div>
               
                <div class="job-desc mt-3">
                    <h2>Required Skill</h2>
                    <p><%# Eval("skill") %></p>
                </div>

                <div class="job-other mt-3">
                    <h2>Degree</h2>
                    <p><%# Eval("degree") %></p>

                     <h2>Experience</h2>
                    <p><%# Eval("experience") %></p>
                </div>
            </div>
           
            <div class="col-md-4 offset-md-1">
                <div class="card p-3 mt-3 shadow-sm">
                    <h3 class="text-danger">Job Overview</h3>
                    <div class="d-flex flex-column ">
                        <div class="d-flex flex-row justify-content-between">
                            <p>Posted Date:</p><p><%# Eval("created_at") %></p>
                        </div>
                      
                       <div class="d-flex flex-row justify-content-between">
                            <p>Vacancy:</p><p><%# Eval("vacancy") %></p>
                        </div>
                      <div class="d-flex flex-row justify-content-between">
                            <p>Job Nature:</p><p><%# Eval("job_nature") %></p>
                        </div>
                       <div class="d-flex flex-row justify-content-between">
                             <p>Salary:</p><p><%# Eval("salary") %></p>
                        </div>
                       <button class="btn btn-warning text-white font-weight-bolder">Apply</button>
                    </div>
                   
                </div>
                </ItemTemplate>
                </asp:Repeater>

            <asp:Repeater ID="rptcompany" runat="server">
                <ItemTemplate>
                <div class="card p-3 mt-3 shadow-sm">
                    <h3 class="text-warning mb-2">Company information</h3>
                   <div class="d-flex flex-column ">
                        <div class="d-flex flex-row justify-content-between">
                            <p>Name:</p><p><%# Eval("name") %></p>
                        </div>
                      <div class="d-flex flex-row justify-content-between">
                           <p>Address:</p><p><%# Eval("address") %></p>
                        </div>
                       <div class="d-flex flex-row justify-content-between">
                            <p>Website:</p><p><%# Eval("website") %></p>
                        </div>
                      <div class="d-flex flex-row justify-content-between">
                            <p>Email:</p><p><%# Eval("email") %></p>
                        </div>
                       <div class="d-flex flex-row justify-content-between">
                             <p>Mobile:</p><p><%# Eval("mobile") %></p>
                        </div>
                       <div class="d-flex flex-row justify-content-between">
                             <p>Detail:</p><p><%# Eval("detail") %></p>
                        </div>
                       
                    </div>
                </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        
    </div>
</asp:Content>
