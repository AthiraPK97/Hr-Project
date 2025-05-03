<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Shift_change.aspx.cs" Inherits="DoctorsOnDuty.Shift_change" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-email">Branch <span class="text-danger">*</span></label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_branch" runat="server" CssClass="form-control" required="required" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-confirm-password">Current Date<span class="text-danger">*</span></label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_olddate" runat="server" type="text" class="form-control" OnTextChanged="txt_date_OnChanged" AutoPostBack="true" required="required"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_olddate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-email">Department <span class="text-danger">*</span></label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged" OnTextChanged="ddl_dept_SelectedIndexChanged" AutoPostBack="true" required="required"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-email">Doctor Name <span class="text-danger">*</span></label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_drname" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_drname_SelectedIndexChanged" OnTextChanged="ddl_drname_SelectedIndexChanged" AutoPostBack="true" required="required"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-confirm-password">New Date <span class="text-danger">*</span></label>
        <div class="col-lg-8">
            <asp:TextBox ID="txt_newdate" runat="server" type="text" class="form-control" required="required"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_newdate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-confirm-password">Duty Time <span class="text-danger">*</span></label>
        <div class="col-lg-8">
           <asp:DropDownList ID="ddl_oldtime" runat="server" CssClass="form-control" required="required" ></asp:DropDownList> 
        </div>
    </div>
                                 
    <div class="form-group row">
        <label class="col-lg-2 col-form-label">From Time </label>
        <div class="col-lg-3">
            <asp:TextBox ID="txt_frmtime" runat="server" CssClass="form-control" type="time"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
        <label class="col-lg-2 col-form-label">To Time </label>
        <div class="col-lg-3">
            <asp:TextBox ID="txt_totime" runat="server" CssClass="form-control" type="time"></asp:TextBox>
        </div>        
    </div>

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="Submit" class="btn btn-primary" OnClick="ButtonSubmit_Click" />
        </div>
    </div>

</asp:Content>
