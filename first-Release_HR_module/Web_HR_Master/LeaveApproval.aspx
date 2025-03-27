<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="LeaveApproval.aspx.cs" Inherits="Web_HR_Master.LeaveApproval" %>

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
                <h3 class="text-themecolor">LEAVE SANCTION</h3>
            </div>
            <div class="form-group row">
        <label class="col-lg-2 col-form-label">Select Date: </label>
        <div class="col-lg-9">
                  <asp:TextBox ID="txtselectDate" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="load_userdata"></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txtselectDate" format="yyyy-MM-dd" EnableViewState="true"  ></ajaxtoolkit:calendarextender>
                     </div></div>
                              <div class="form-group row">
                 <asp:DropDownList runat="server" ID="ddl_empList" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="fill_data"></asp:DropDownList>
            </div>
            <div class="col-md-12 text-center">
                <h3 class="text-themecolor">Details Of Available Leave</h3>
            </div>
            <table class="table" style="border-collapse: collapse; width: 100%;">
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Available Leave:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;" colspan="3"><asp:TextBox ID="txt_AvailableLeave" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txtEmpCode" runat="server" Visible="false"></asp:TextBox></td>
                
                </tr>
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Emp Name:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_EmpName" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><b> Apply Date:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_AppliedDate" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
               <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Post:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_Post" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><b>Current Branch:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_branch" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                   <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Leave Type:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_LeaveType" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><b>Duration:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_duration" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                   <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>From Date:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_fromDate" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><b>To Date:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_ToDate" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                   <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Total Leave of employee <br />in Requested Leave Month:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_totalLeave" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><b> Sanctioned leave <br /> in Dept/Branch:</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_sanctionLeave" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                  <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 8px;"><b>Leave Reason:</b></td>
                    <td style="border: 1px solid gray; padding: 8px;" colspan="3">
                        <asp:TextBox ID="txtReason" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>

                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 8px;"><b>Approved/Rejected:</b></td>
                    <td style="border: 1px solid gray; padding: 8px;" colspan="3">
                        <asp:DropDownList ID="ddl_ApprovedStatus" runat="server">
                            <asp:ListItem Text="-------Select----" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Sanction" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Reject" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                   
                </tr>
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 8px;"><b>Remark:</b></td>
                    <td style="border: 1px solid gray; padding: 8px;" colspan="3">
                        <asp:TextBox ID="txtReMark" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <!-- Buttons for Apply and Exit -->
            <div class="form-group row">
                <div class="col-lg-3 mx-auto d-flex justify-content-center">
                    <asp:Button ID="btnApply" runat="server" Text="SAVE" class="btn btn-primary mx-2" OnClick="btnApply_Click" />
                    <asp:Button ID="btnExit" runat="server" Text="EXIT" class="btn btn-primary mx-2" OnClick="btnExit_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
