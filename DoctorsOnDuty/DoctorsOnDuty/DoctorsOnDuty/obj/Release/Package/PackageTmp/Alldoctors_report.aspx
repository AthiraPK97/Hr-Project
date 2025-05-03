<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Alldoctors_report.aspx.cs" Inherits="DoctorsOnDuty.Alldoctors_report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

    <div class="form-group row">
        <label class="col-lg-2 col-form-label">Branch Name : </label>
        <div class="col-lg-3">
            <asp:DropDownList ID="ddl_branch" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_branchname_SelectedIndexChanged" OnTextChanged="ddl_branchname_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
        <label class="col-lg-2 col-form-label">Department Name : </label>
        <div class="col-lg-3">
            <asp:DropDownList ID="ddl_dept" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>        
    </div>

    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary" OnClick="ButtonSubmit_Click" />
        </div>
    </div>

    <asp:Panel ID="Panel1" runat="server" Height="15000px" Width="1100px">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1210px" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
        </rsweb:ReportViewer>
    </asp:Panel>

</asp:Content>
