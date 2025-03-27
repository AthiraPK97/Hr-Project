<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Leave_cancel.aspx.cs" Inherits="Web_HR_Master.Leave_cancel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
  .ajax__calendar_body {
        width: 150px !important;  /* Set the width of the calendar */
        font-size: 12px !important; /* Set smaller font size for date text */
        padding: 0px !important; /* Remove unnecessary padding */
    }

    .ajax__calendar_day {
        padding: 2px !important; /* Reduce padding inside each date cell */
        text-align: center !important; /* Align the date text in the center */
    }

    .ajax__calendar_header {
        font-size: 12px !important; /* Make the header smaller */
        .custom-header {
        background-color: #003366;
        color: white;
        font-weight: bold;
        width: 100%;

    }
  .grid-data {
        color: black;
  }
    }
    </style>
    <div class="col-md-12 d-flex justify-content-center">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        
        <!-- Table container with a thicker gray border -->
        <div class="table-container" style="border: 2px solid gray; padding: 60px;">
            <!-- Leave Application heading centered -->
            <div class="col-md-12 text-center">
                <h3 class="text-themecolor">LEAVE CANCEL</h3>
            </div>
            <div class="form-group row">
                 <asp:DropDownList runat="server" ID="ddl_empList" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="fill_data"></asp:DropDownList>
            </div>
            <label id="Label1" runat="server" visible="false"></label>
            <table class="table" style="border-collapse: collapse; width: 100%;">
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Emp Code:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_EmpCode" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><b>Emp Name:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_EmpName" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Leave Type:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txtLeaveType" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><b>Leave Apply Date:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txtLeaveApplyDate" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
            </table>

    <div class="form-group row">
        <label class="col-lg-2 col-form-label">From Date: </label>
        <div class="col-lg-4">
                  <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txtFromDate" format="yyyy-MM-dd" EnableViewState="true" ></ajaxtoolkit:calendarextender>
                     </div>
                   
                    <label class="col-lg-2 col-form-label text-themecolor">To Date: </label>
        <div class="col-lg-4">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"   ></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender3" runat="server" targetcontrolid="txtToDate" format="yyyy-MM-dd" ></ajaxtoolkit:calendarextender>
                 </div></div>
       
              <table class="table" style="border-collapse: collapse; width: 100%;">
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Reason:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;" colspan="3"><asp:TextBox ID="txtReason" runat="server" ></asp:TextBox></td>
                  
                </tr></table>
             
            <div class="form-group row">
                <div class="col-lg-3 mx-auto d-flex justify-content-center">
                    <asp:Button ID="btnCancel" runat="server" Text="Confirm" class="btn btn-primary mx-2" OnClick="btnCancel_Click" />
                    <asp:Button ID="btnExit" runat="server" Text="EXIT" class="btn btn-primary mx-2" OnClick="btnExit_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
