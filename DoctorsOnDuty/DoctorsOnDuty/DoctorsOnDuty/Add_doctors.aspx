<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Add_doctors.aspx.cs" Inherits="DoctorsOnDuty.Add_doctors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" >Branch Name </label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>
    
    <div class="form-group row">
        <label class="col-lg-4 col-form-label" >Department Name </label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_doctor" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="Submit" class="btn btn-primary" OnClick="Submit_Click"/>
        </div>
    </div>

</asp:Content>
