<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="DoctorsOnDuty.Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group row">
        <label class="col-lg-1 col-form-label">From Date </label>
        <div class="col-lg-4">
            <asp:TextBox ID="txt_fromdate" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_fromdate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
        </div>
        <div class="col-lg-1"></div>
        <label class="col-lg-1 col-form-label">To Date </label>
        <div class="col-lg-4">
            <asp:TextBox ID="txt_todate" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_todate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
        </div>        
    </div>

    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary" OnClick="Btn_view_Click" />
        </div>
    </div>

    <asp:Panel ID="Panel1" runat="server" Height="15000px" Width="1100px">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1210px" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
        </rsweb:ReportViewer>
    </asp:Panel>

</asp:Content>
