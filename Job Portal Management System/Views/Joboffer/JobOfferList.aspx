<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/CompanyDashboard.Master" AutoEventWireup="true" CodeBehind="JobOfferList.aspx.cs" Inherits="Job_Portal_Management_System.Views.Joboffer.JobOfferList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
     <h1 class="text-center text-info">Your Job Applier List</h1>
    <div class="row mt-5 ml-5">
        <div class="col-md-2">
            <label for="txtSearch" class="text-dark font-weight-bold float-md-right">Job Title</label>
            </div>
        <div class="col-md-3">
      <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
      
        </div>
        <div class="col-md-4">
             <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info" OnClick="btnSearch_Click" />
             
             <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-info" OnClick="btnClear_Click"  />

            

        </div>
        <div class="col-md-2">
            Accept: <asp:RadioButton ID="rdoAccept" runat="server" GroupName="Accept" CssClass="custom-radio" AutoPostBack="True" OnCheckedChanged="rdoAccept_CheckedChanged" />
            Reject: <asp:RadioButton ID="rdoReject" runat="server" GroupName="Accept" CssClass="custom-radio" OnCheckedChanged="rdoReject_CheckedChanged"  AutoPostBack="True"/>
        </div>
      
     
  </div>
    <div class="row mt-5">
        <div class="col-md-12">
          
            <asp:GridView ID="grvJobOffer" runat="server"  CssClass="gvJobOffer table table-striped " ShowHeaderWhenEmpty="True" PageSize="5"  DataKeyNames="id"  AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnRowCommand="grvJobOffer_RowCommand" OnPageIndexChanging="grvJobOffer_PageIndexChanging" OnRowDataBound="grvJobOffer_RowDataBound">
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
          

          <asp:BoundField DataField="title" HeaderText="Job Title" />
                    <asp:BoundField DataField="vacancy" HeaderText="Vacancy" />
                     <asp:BoundField DataField="name" HeaderText="Applier" />
                    <asp:BoundField DataField="Accept" HeaderText="Status" />
                   <asp:TemplateField HeaderText="Resume">
                       <ItemTemplate>
                           <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container,"DataItem.cvform","../../{0}") %>'><i class="fas fa-download"></i> Download</asp:HyperLink>
                       </ItemTemplate>
                   </asp:TemplateField>

                     <asp:TemplateField HeaderText="Accept" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbljobseekerId" runat="server" Text='<%# Eval("job_seeker_id") %>'></asp:Label>      
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                      <asp:Button ID="btnDetail" runat="server" CommandName="Detail" CssClass="btn btn-primary" Text="Detail" CommandArgument="<%#Container.DataItemIndex %>" />
                            <asp:Button ID="btnAccept" runat="server" CommandName="Accept" CssClass="btn btn-success" Text="Accept" CommandArgument="<%#Container.DataItemIndex %>" />
                            <asp:Button ID="btnReject" runat="server" CommandName="Reject" CssClass="btn btn-danger" Text="Reject" CommandArgument="<%#Container.DataItemIndex %>" />
                        </ItemTemplate>
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
