<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="SalaryCalculation.aspx.cs" Inherits="Web_HR_Master.SalaryCalculation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="card-body">
                    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    
    <div class="form-group row">
        <label class="col-lg-1 col-form-label">From Date </label>
      <%--  <div class="col-lg-4">
           <asp:TextBox ID="txt_fromdate" runat="server" CssClass="form-control"  min="2020-01-30" ></asp:TextBox>
            <ajaxtoolkit:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txt_fromdate" format="yyyy-MM-dd" EnableViewState="true" ></ajaxtoolkit:calendarextender> 
        </div>--%>
         <div class="col-lg-3">
                  <asp:TextBox ID="txt_fromdate" runat="server" CssClass="form-control"></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txt_fromdate" format="yyyy-MM-dd" EnableViewState="true" ></ajaxtoolkit:calendarextender>
                     </div>
        <div class="col-lg-1"></div>
        <label class="col-lg-1 col-form-label">To Date </label>
        <div class="col-lg-4">
            <asp:TextBox ID="txt_todate" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxtoolkit:calendarextender ID="CalendarExtender2" runat="server" TargetControlID="txt_todate" Format="yyyy-MM-dd" EnableViewState="true" ></ajaxtoolkit:calendarextender> 
             
    </div></div>

    <div class="form-group row">
        <div class="col-lg-7 ml-auto">
            <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary" OnClick="Button1_Click" />
        </div>
        </div>
         </div>
         <asp:Panel ID="panel1" runat="server">
        <div class="row">
            <div class="col-sm-2 col-xs-2">
                <button type="submit" class="btn btn-dark waves-effect waves-light m-r-10" runat="server" id="Button2" onserverclick="ButtonExport_Click" visible="true">EXPORT TO EXCEL</button>
            </div>
        </div>
    <asp:GridView ID="GridView1" runat="server" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound">

    </asp:GridView>
             </asp:Panel>
                </div>  </div></div> 
</asp:Content>
