<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="TempstaffPersonalReport.aspx.cs" Inherits="Web_HR_Master.TempstaffPersonalReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
       <style>
  .custom-header {
        background-color: #003366;
        color: white;
        font-weight: bold;
        width: 100%;

    }
  .grid-data {
        color: black;
  }

     </style>
    <div class="row">
    <div class="col-md-12 d-flex justify-content-center">
        
                             <div class="table-container">
                    <div class="col-sm-2 col-xs-2">
                <button type="submit" class="btn btn-dark waves-effect waves-light m-r-10" runat="server" id="Button1" onserverclick="ButtonExport_Click">EXPORT TO EXCEL</button>
            </div><br />
        
                            <div class="row" style="overflow-x: auto; text-align: center;">
                                <asp:GridView ID="GridView1" runat="server"   CssClass="grid-data">
                                      <HeaderStyle CssClass="custom-header" /></asp:GridView></div></div></div>

                 
    </div></div>
</asp:Content>
