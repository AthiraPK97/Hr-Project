<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Staff_Availablereport.aspx.cs" Inherits="DoctorsOnDuty.Staff_Availablereport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group row">
        <label class="col-lg-4 col-form-label">Branch Name </label>
        <div class="col-lg-6">
            <asp:DropDownList ID="ddl_branch" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary" OnClick="Btn_view_Click"  />
        </div>
    </div>

    <asp:Panel ID="Panel1" runat="server" Height="5000px" Width="1100px">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ClientIDMode="AutoID" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px">
        </rsweb:ReportViewer>
    </asp:Panel>

</asp:Content>
