<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddTempStaffDetails.aspx.cs" Inherits="Web_HR_Master.AddTempStaffDetails" %><%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <h3 class="text-themecolor">ADD TEMPORARY STAFF'S DETAILS</h3>
            </div>
                    <label class="col-lg-2 col-form-label">Select User: </label>
        <div class="col-lg-12">
             <div class="form-group row">
                 <asp:DropDownList runat="server" ID="ddl_empList" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="load_UserDetails"></asp:DropDownList>
            </div>
            <!-- Table for Employee Details with borders between rows and columns -->
            <table class="table" style="border-collapse: collapse; width: 100%;">
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Emp Code :</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_EmpCode" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><b>Emp Name :</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_EmpName" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr style="border: 1px solid gray;">
                    <td style="border: 1px solid gray; padding: 10px;"><b>Post :</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_Post" runat="server" Enabled="false"></asp:TextBox></td>
                    <td style="border: 1px solid gray; padding: 10px;"><b>Current Branch :</b></td>
                    <td style="border: 1px solid gray; padding: 10px;"><asp:TextBox ID="txt_branch" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
            </table>

            <!-- Leave Details heading centered -->
            <div class="col-md-12 text-center">
                <h3 class="text-themecolor">PERSONAL DETAILS</h3>
            </div>
            <table class="table" style="border-collapse: collapse; width: 100%;">
            <!-- Table for Leave Details with borders between rows and columns -->
        <tr style="border: 1px solid gray;">
        <td style="border: 1px solid gray; padding: 8px; width: 30%; text-align: center; vertical-align: middle;"><b>Address :</b></td>
        <td style="border: 1px solid gray; padding: 8px; width: 70%;">
            <div style="display: flex; flex-direction: column; gap: 10px;">
                <div>
                    <b>Address Line 1 :</b>
                    <asp:TextBox ID="txtAddress1" runat="server" style="width: 100%;"></asp:TextBox>
                </div>
                <div>
                    <b>Address Line 2 :</b>
                    <asp:TextBox ID="txtAddress2" runat="server" style="width: 100%;"></asp:TextBox>
                </div>
                  <div>
                    <b>Address Line 3 :</b>
                    <asp:TextBox ID="txtAddress3" runat="server" style="width: 100%;"></asp:TextBox>
                </div>
                  <div>
                    <b>Address Line 4 :</b>
                    <asp:TextBox ID="txtAddress4" runat="server" style="width: 100%;"></asp:TextBox>
                </div>
            </div>
        </td>
    </tr>

               </table>
            <div></div>
    <div class="form-group row">
        <label class="col-lg-2 col-form-label">Date Of Birth: </label>
        <div class="col-lg-3">
                  <asp:TextBox ID="txtDob" runat="server" CssClass="form-control"></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txtDob" format="dd-MM-yyyy" EnableViewState="true" ></ajaxtoolkit:calendarextender>
                     </div>
                   
                    <label class="col-lg-3 col-form-label">Date of Joining : </label>
        <div class="col-lg-4">
                        <asp:TextBox ID="txtDateOfJoining" runat="server" CssClass="form-control" ></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender3" runat="server" targetcontrolid="txtDateOfJoining" format="dd-MM-yyyy" ></ajaxtoolkit:calendarextender>
                 </div></div>
            
         

            <!-- Buttons for Apply and Exit -->
            <div class="form-group row">
                <div class="col-lg-3 mx-auto d-flex justify-content-center">
                    <asp:Button ID="btnSave" runat="server" Text="APPLY" class="btn btn-primary mx-2" OnClick="btnApply_Click" />
                    <asp:Button ID="btnExit" runat="server" Text="EXIT" class="btn btn-primary mx-2" OnClick="btnExit_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
