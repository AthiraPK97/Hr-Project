<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Incentive_report.aspx.cs" Inherits="DoctorsOnDuty.Incentive_report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

    <div class="row">
        <div class="form-group col-lg-4">
            <label>From Date </label>
            <asp:TextBox ID="txt_fromdate" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_fromdate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
        </div>
        <div class="form-group col-lg-4">
            <label>To Date </label>
            <asp:TextBox ID="txt_todate" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_todate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
        </div>
        <div class="form-group col-lg-4">
            <label>Select Incentive Type</label>
            <asp:DropDownList ID="ddl_type" runat="server" CssClass="form-control">
                <asp:ListItem>---Select---</asp:ListItem>
                <asp:ListItem>Lab Incentive</asp:ListItem>
                <asp:ListItem>Scanning/Mammogram Incentive</asp:ListItem>
                <asp:ListItem>CT Incentive</asp:ListItem>
                <asp:ListItem>Procedure Charges Incentive</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="form-group col-lg-5">
        </div>
        <div class="form-group col-lg-4">
            <asp:Button ID="Button1" runat="server" Text="VIEW INCENTIVE" class="btn btn-primary" OnClick="view_click" />
        </div>
    </div>

    <asp:Panel ID="Panel1" runat="server" Height="5000px" Width="1100px">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1210px" ClientIDMode="AutoID" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
        </rsweb:ReportViewer>
    </asp:Panel>

</asp:Content>
