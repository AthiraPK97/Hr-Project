<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dr_incentiveedit.aspx.cs" Inherits="DoctorsOnDuty.Dr_incentiveedit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-email">Department</label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-email">Doctor Name </label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_drname" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_drname_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
        </div>
    </div>

    <div class="card-body">
        <div class="basic-form">
            <div class="row">
                <div class="form-group col-lg-4">
                    <label>Lab </label>
                    <asp:TextBox ID="txt_lab" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-lg-4">
                    <label>Mammogram / Scanning</label>
                    <asp:TextBox ID="txt_mammoscan" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-lg-4">
                    <label>CT</label>
                    <asp:TextBox ID="txt_ct" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="SUBMIT" class="btn btn-primary" OnClick="Edit_click" />
        </div>
    </div>

</asp:Content>
