<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="DoctorsOnDuty.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

</asp:Content>
