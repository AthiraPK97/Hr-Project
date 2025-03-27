<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Leave_Application.aspx.cs" Inherits="Web_HR_Master.Leave_Application" %>

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
    }
    </style>
    <div class="col-md-12 d-flex justify-content-center">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        
        <!-- Table container with a thicker gray border -->
        <div class="table-container" style="border: 2px solid gray; padding: 60px;">
            <!-- Leave Application heading centered -->
            <div class="col-md-12 text-center">
                <h3 class="text-themecolor">LEAVE APPLICATION</h3>
            </div>

            <!-- Table for Employee Details with borders between rows and columns -->
            <table class="table" style="border-collapse: collapse; width: 100%;">
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Emp Code:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_EmpCode" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><b>Emp Name:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_EmpName" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Post:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_Post" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><b>Current Branch:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_branch" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
            </table>

            <!-- Leave Details heading centered -->
            <div class="col-md-12 text-center">
                <h3 class="text-themecolor">LEAVE DETAILS</h3>
            </div>

            <!-- Table for Leave Details with borders between rows and columns -->
            <table class="table" style="border-collapse: collapse; width: 100%;">
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 8px;"><b>Eligible Leaves:</b></td>
                    <td style="border: 1px solid gray; padding: 8px;" colspan="3" ><b>Total:</b>
                    <asp:TextBox ID="txtTotal" runat="server" Enabled="false"></asp:TextBox> 
                        <asp:Label><strong>4 Week Off + 1 casual</strong></asp:Label></td>
                   
                </tr>

                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 8px;"><b>Leave Type:</b></td>
                    <td style="border: 1px solid gray; padding: 8px;">
                        <asp:DropDownList ID="ddl_leaveType" runat="server">
                            <asp:ListItem Text="-------Select----" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Casual" Value="Casual"></asp:ListItem>
                            <asp:ListItem Text="Weekly Off" Value="Off"></asp:ListItem>
                            <asp:ListItem Text="LOP" Value="LOP"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="border: 1px solid gray; padding: 8px;"><b>Applied Date:</b></td>
                    <td style="border: 1px solid gray; padding: 8px;">
                        <asp:TextBox ID="txt_AppliedDate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txt_AppliedDate" format="dd-MM-yyyy"></ajaxtoolkit:calendarextender>
                    </td>
                </tr>
               </table>
    <div class="form-group row">
        <label class="col-lg-2 col-form-label">From Date: </label>
        <div class="col-lg-4">
                  <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txtFromDate" format="dd-MM-yyyy" EnableViewState="true" ></ajaxtoolkit:calendarextender>
                     </div>
                   
                    <label class="col-lg-2 col-form-label">To Date: </label>
        <div class="col-lg-4">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="calculate_date"></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender3" runat="server" targetcontrolid="txtToDate" format="dd-MM-yyyy" ></ajaxtoolkit:calendarextender>
                 </div></div>
            
            <table class="table" style="border-collapse: collapse; width: 100%;">
                 <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 8px;"><b>Days:</b></td>
                    <td style="border: 1px solid gray; padding: 8px;" colspan="3">
                        <asp:TextBox ID="txtDays" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 8px;"><b>Reason:</b></td>
                    <td style="border: 1px solid gray; padding: 8px;" colspan="3">
                        <asp:TextBox ID="txtReason" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <!-- Buttons for Apply and Exit -->
            <div class="form-group row">
                <div class="col-lg-3 mx-auto d-flex justify-content-center">
                    <asp:Button ID="btnApply" runat="server" Text="APPLY" class="btn btn-primary mx-2" OnClick="btnApply_Click" />
                    <asp:Button ID="btnExit" runat="server" Text="EXIT" class="btn btn-primary mx-2" OnClick="btnExit_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
