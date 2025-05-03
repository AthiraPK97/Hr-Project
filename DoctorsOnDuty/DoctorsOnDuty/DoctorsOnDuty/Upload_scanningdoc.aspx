<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Upload_scanningdoc.aspx.cs" Inherits="DoctorsOnDuty.Upload_scanningdoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" >Bill ID </label>
        <div class="col-lg-5">
            <asp:TextBox ID="txt_billid" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <asp:Button ID="btn_view" runat="server" Text="VIEW DETAILS" CssClass="btn-secondary btn" OnClick="Btn_view_Click" />
        </div>
    </div>

    <div id="div_hide" runat="server">
        <div class="form-group row">
            <label class="col-lg-4 col-form-label" >Patient Name </label>
            <div class="col-lg-8">
                <asp:TextBox ID="txt_patientname" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                <asp:Label ID="lbl_patientid" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-lg-4 col-form-label" >Scanning Name </label>
            <div class="col-lg-8">
                <asp:DropDownList ID="ddl_scanning" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
    
        <div class="form-group row">
            <label class="col-lg-4 col-form-label" >Doctor Name </label>
            <div class="col-lg-8">
                <asp:DropDownList ID="ddl_doctor" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-lg-4 col-form-label" >Scanning Document </label>
            <div class="col-lg-8">
                <asp:FileUpload ID="file_scanning" runat="server" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group row">
            <div class="col-lg-8 ml-auto">
                <asp:Button ID="Btn_submit" runat="server" Text="Submit" class="btn btn-primary" OnClick="Btn_submit_Click" />
            </div>
        </div>
    </div>

</asp:Content>
