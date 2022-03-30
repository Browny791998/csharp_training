<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="FindJob.aspx.cs" Inherits="Job_Portal_Management_System.Views.Job.FindJob" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="text-center text-info mt-3 ">Job List</h2>
        <div class="row mt-3">

            <div class="col-12 col-md-4 mt-5 border-right">
                <h2 class="text-danger text-center"><i class="fa-solid fa-filter text-black-50 mr-2"></i>Filter Jobs</h2>
                <div class="row mb-2">
                    <div class="col-md-5">
                        <p class="ml-md-5">Country</p>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control bg-info text-white font-weight-bold">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row mb-2">
                    <div class="col-md-5">
                        <p class="ml-md-5">Position</p>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control bg-info text-white font-weight-bold">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row mb-2">
                    <div class="col-md-5">
                        <p class="ml-md-5">Type</p>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlJobtype" runat="server" CssClass="form-control bg-info text-white font-weight-bold">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-2">
                    <div class="col-md-5">
                        <p class="ml-md-2">Specialization</p>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlspeicalization" runat="server" CssClass="form-control bg-info text-white font-weight-bold">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-secondary btn-block" OnClick="btnFilter_Click" />
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-md-12">
                        <asp:Button ID="btnViewAllJob" runat="server" Text="All" CssClass="btn btn-danger btn-block" OnClick="btnViewAllJob_Click" />
                    </div>
                </div>
            </div>
            <div class="col-12 col-md-7 p-2 ml-md-5">
                <div class="row">
                    <asp:Repeater ID="rptJoblist" runat="server">
                        <ItemTemplate>

                            <div class="col-md-12 mt-2">
                                <div class="card shadow-sm">
                                    <div class="card-header bg-info text-white font-weight-bold">
                                        <i class="fa-solid fa-building"></i> <%# Eval("name") %>
                                        <p class="float-right"><%# Eval("specialization") %></p>
                                    </div>
                                    <div class="card-body">
                                        <asp:Label ID="jobId" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="companyId" runat="server" Text='<%# Eval("company_id") %>' Visible="false"></asp:Label>
                                        <h5 class="card-title"><%# Eval("title") %><span class="badge badge-success ml-3"><%# Eval("job_nature") %></span></h5>
                                        <p class="card-text float-right">Country - <%# Eval("country") %></p>
                                        <p class="card-text">Vacancy - <%# Eval("vacancy") %></p>
                                        <p class="card-text">Position - <%# Eval("position") %></p>
                                        <p class="card-text">Skill - <%# Eval("skill") %></p>
                                        <p>Salary - <%# Eval("salary") %></p>
                                        <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn btn-info" OnClick="btnView_Click" />
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