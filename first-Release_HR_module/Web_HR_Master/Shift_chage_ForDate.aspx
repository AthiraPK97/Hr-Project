<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Shift_chage_ForDate.aspx.cs" Inherits="Web_HR_Master.Shift_chage_ForDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">SHIFT CHANGE TEMP EMPLOYEES</h3>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-2 col-form-label"> EMPLOYEE'S NAME </label>
        <div class="col-lg-10">
                                <asp:DropDownList ID="ddl_name" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_name_changed" AutoPostBack="true"></asp:DropDownList>                
        </div>
        </div><br />
         <div class="col-lg-12 ">
       <div class="row">
           <label class="col-lg-2 col-form-label">DESIGNATION</label>
    <div class="col-lg-4">
        <asp:TextBox ID="txt_designation" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
    </div>

    <label class="col-lg-2 col-form-label">CURRENT SHIFT</label>
    <div class="col-lg-4">
        <asp:DropDownList ID="Text_current_shift" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
    </div>

    </div></div><br />
         <div class="col-lg-12 ">
       <div class="row">
            <label class="col-lg-2 col-form-label">CHANGE DATE</label>
         <div class="col-lg-4">
                  <asp:TextBox ID="txt_date" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                  <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_date" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender>
         </div>
        <br /><br /><br />
        <asp:label id="lbl_change_shift" class="col-lg-2 col-form-label" runat="server">CHANGE SHIFT </asp:label>
        <div class="col-lg-4">
          <asp:DropDownList ID="ddl_shift" runat="server" CssClass="form-control"></asp:DropDownList> 
        </div></div><br /><br />
  <div class="form-group row">
    <div class="col-lg-8 ml-auto d-flex">
        <asp:Button ID="Btn_shift" runat="server" Text="CHANGE SHIFT" class="btn btn-primary" OnClick="Btn_Change_Click" Width="136px" />
    </div>
</div>
    </div>
</asp:Content>
