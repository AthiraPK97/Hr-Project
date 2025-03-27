<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ShiftReportUnitWise.aspx.cs" Inherits="Web_HR_Master.ShiftReportUnitWise" %>
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

     </style><br /><br />
     <div class="form-group row">
    <label class="col-lg-2 col-form-label"> BRANCH :  </label>
        <div class="col-lg-10">
               <asp:DropDownList ID="ddl_Branch" runat="server" CssClass="form-control" onSelectedIndexChanged="load_Shift" AutoPostBack="true"></asp:DropDownList>                
   </div></div>
    <br />
    <div class="row">
                <div class="col-md-12 d-flex justify-content-center">
                                <div class="col-sm-2 col-xs-2">
                <button type="submit" class="btn btn-dark waves-effect waves-light m-r-10" runat="server" id="Button1" onserverclick="ButtonExport_Click">EXPORT TO EXCEL</button>
            </div>
        
             <div class="col-sm-2 col-xs-2">
                <button type="submit" class="btn btn-primary" runat="server" id="btnMail" onserverclick="ButtonsendMail_Click">SEND MAIL</button>
            </div>
                    </div>
            </div>
    
    <div class="row">
    <div class="col-md-12 d-flex justify-content-center">
        <div class="table-container">
                             <div class="table-container">
                            <div class="row" style="overflow-x: auto; text-align: center;">
                                <asp:GridView ID="GridView1" runat="server"   CssClass="grid-data">
                                      <HeaderStyle CssClass="custom-header" />

                                    
                                </asp:GridView></div></div></div></div></div>
</asp:Content>
