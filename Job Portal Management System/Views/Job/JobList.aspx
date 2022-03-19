<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/CompanyDashboard.Master" AutoEventWireup="true" CodeBehind="JobList.aspx.cs" Inherits="Job_Portal_Management_System.Views.Job.JobList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

    </div>
   
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
     <h1 class="text-center text-info">Your Job List</h1>
    <div class="row mt-5 ml-5">
        <div class="col-md-2">
            <label for="txtSearch" class="text-dark font-weight-bold float-md-right">Job Title</label>
            </div>
        <div class="col-md-3">
      <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
      
        </div>
        <div class="col-md-4">
             <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info" OnClick="btnSearch_Click" />
             <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-info" OnClick="btnAdd_Click" />
             <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-info" OnClick="btnClear_Click" />
        </div>
      
     
  </div>
    <div class="row mt-5">
        <div class="col-md-12">
            <asp:GridView ID="grvJob" runat="server"  CssClass="gvJob table table-striped table-hover" ShowHeaderWhenEmpty="true"   DataKeyNames="id" PageSize="5" AllowPaging="false" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" OnRowDeleting="grvJob_RowDeleting" OnRowUpdating="grvJob_RowUpdating" OnPageIndexChanging="grvJob_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField >
              <HeaderTemplate>
                  <asp:Label ID="Label1" runat="server" Text="Label">No</asp:Label>
              </HeaderTemplate>
              <ItemTemplate>
                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
              </ItemTemplate>

<ItemStyle Width="5px" HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
                    <asp:BoundField DataField="title" HeaderText="Title" />
                    <asp:BoundField DataField="degree" HeaderText="Degree" />
                    <asp:BoundField DataField="skill" HeaderText="Skill" />
                    <asp:BoundField DataField="experience" HeaderText="Experience" />
                    <asp:BoundField DataField="vacancy" HeaderText="Vacancy" />
                    <asp:BoundField DataField="position" HeaderText="Position" />
                    <asp:BoundField DataField="job_nature" HeaderText="Job Type" />
                    <asp:BoundField DataField="salary" HeaderText="Salary" />
                    <asp:BoundField DataField="active" HeaderText="Status" />

                      <asp:TemplateField ItemStyle-CssClass="text-center table-options" HeaderStyle-CssClass="text-center">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update" Text="Update" CssClass="btn btn-success"></asp:LinkButton>
                    
              </ItemTemplate>
             
<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-center table-options"></ItemStyle>
             
            </asp:TemplateField>
                      <asp:TemplateField  ItemStyle-CssClass="text-center table-options"  HeaderStyle-CssClass="text-center">
                          <ItemTemplate>
                              
               <asp:LinkButton OnClientClick="return confirm('Are you sure to delete');" ID="btnDelete"  runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" CssClass="btn btn-danger"></asp:LinkButton>
                          </ItemTemplate>

<HeaderStyle CssClass="text-center"></HeaderStyle>

<ItemStyle CssClass="text-center table-options" ></ItemStyle>
                      </asp:TemplateField>
                </Columns>
                 <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                 <PagerStyle Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="pagination-ys" BackColor="White" BorderColor="White" />
            </asp:GridView>


           
        </div>
    </div>
    
</asp:Content>
