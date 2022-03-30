<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="JobDetail.aspx.cs" Inherits="Job_Portal_Management_System.Views.Job.JobDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mb-5">
        <asp:HiddenField ID="hfJobID" runat="server" />
        <asp:HiddenField ID="hfCID" runat="server" />
        <%if (Session["alert"] != null && Session["alert-type"] != null)
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
            <asp:Repeater ID="rptJob" runat="server">
                <ItemTemplate>
                    <div class="col-md-7">
                        <div class="card p-5 mt-3 shadow-sm">
                            <h1 class="text-primary"><%# Eval("title") %></h1>
                            <div class="d-flex flex-row justify-content-between mt-3">
                                <p><i class="fas fa-building"></i><%# Eval("name") %></p>
                                <p><i class="fas fa-map-marker-alt"></i><%# Eval("country") %></p>
                                <p><i class="fas fa-money-bill-wave"></i><%# Eval("salary") %>/month</p>
                            </div>
                        </div>

                        <div class="job-detail mt-3">
                            <h2>Job Detail</h2>
                            <p><%# Eval("detail") %></p>
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
                                    <p>Posted Date:</p>
                                    <p><%# Eval("created_at") %></p>
                                </div>

                                <div class="d-flex flex-row justify-content-between">
                                    <p>Vacancy:</p>
                                    <p><%# Eval("vacancy") %></p>
                                </div>
                                <div class="d-flex flex-row justify-content-between">
                                    <p>Job Nature:</p>
                                    <p><%# Eval("job_nature") %></p>
                                </div>
                                <div class="d-flex flex-row justify-content-between">
                                    <p>Salary:</p>
                                    <p><%# Eval("salary") %></p>
                                </div>
                                <div class="d-flex flex-row justify-content-between">
                                    <p>Specialization:</p>
                                    <p><%# Eval("specialization") %></p>
                                </div>
                                <asp:Button ID="btnApply" CssClass="btn btn-warning text-white font-weight-bolder" runat="server" Text="Apply" OnClick="btnApply_Click" />
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
                                <p>Name:</p>
                                <p><%# Eval("name") %></p>
                            </div>
                            <div class="d-flex flex-row justify-content-between">
                                <p>Address:</p>
                                <p><%# Eval("address") %></p>
                            </div>
                            <div class="d-flex flex-row justify-content-between">
                                <p>CEO:</p>
                                <p><%# Eval("contact_person") %></p>
                            </div>
                            <div class="d-flex flex-row justify-content-between">
                                <p>Website:</p>
                                <p><%# Eval("website") %></p>
                            </div>
                            <div class="d-flex flex-row justify-content-between">
                                <p>Email:</p>
                                <p><%# Eval("email") %></p>
                            </div>
                            <div class="d-flex flex-row justify-content-between">
                                <p>Mobile:</p>
                                <p><%# Eval("mobile") %></p>
                            </div>
                            <div class="d-flex flex-row justify-content-between">
                                <p>Detail:</p>
                                <p><%# Eval("detail") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </div>
</asp:Content>