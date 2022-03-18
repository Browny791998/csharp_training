<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/CompanyDashboard.Master" AutoEventWireup="true" CodeBehind="CompanyAccount.aspx.cs" Inherits="Job_Portal_Management_System.Views.Company.CompanyAccount" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h1 class="text-center text-info mt-5">Company Account</h1>
   
            <div class="row">
                 
        <div class="col-md-8 card p-3 mt-3 mx-auto d-flex flex-column">
            <asp:Repeater ID="rptCompany" runat="server">
                <ItemTemplate>
                     <div class="row d-flex flex-row justify-content-center mb-2">
                            <asp:Label ID="companyId" runat="server" Text='<%# Eval("id") %>' Visible="false"></asp:Label>
                 <h3 class="col-md-4">Name: </h3> <h3 class="col-md-6"><%# Eval("name") %></h3>
            </div>
            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-4">Country: </h3><h3 class="col-md-6"><%# Eval("country") %></h3>
                 </div>

             <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-4">Address: </h3><h3 class="col-md-6"><%# Eval("address") %></h3>
                 </div>

            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-4">Contact Person: </h3><h3 class="col-md-6"><%# Eval("contact_person") %></h3>
                 </div>

             <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-4">Mobile: </h3><h3 class="col-md-6"><%# Eval("mobile") %></h3>
                 </div>

            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-4">Email: </h3><h3 class="col-md-6"><%# Eval("email") %></h3>
                 </div>
              <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-4">Website: </h3><h3 class="col-md-6"><%# Eval("website") %></h3>
                 </div>

            <div class="row d-flex flex-row justify-content-center mb-2">
            <h3 class="col-md-4">Detail: </h3><p class="col-md-6"><%# Eval("detail") %></p>
                 </div>
               
           
            
            <div class="row d-flex flex-row justify-content-center mb-2">
                <div class="col-md-3"></div>
                <div class="col-md-4">
                    <asp:Button ID="btnEdit" CssClass="btn btn-info" runat="server" Text="Edit" OnClick="btnEdit_Click" />
               <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-warning" />
                </div>
            
                 </div>
                     </ItemTemplate>
            </asp:Repeater>
        </div>
                </div>
</asp:Content>
