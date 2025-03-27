<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="LeaveStatusReport.aspx.cs" Inherits="Web_HR_Master.LeaveStatusReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <style>
        .grid-data {
    color: black;
}
    </style>
    <div class="form-group row">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

        <label class="col-lg-1 col-form-label">From Date: </label>
        <div class="col-lg-3">
                  <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txtFromDate" format="dd-MM-yyyy" EnableViewState="true" ></ajaxtoolkit:calendarextender>
                     </div>
                   
                    <label class="col-lg-1 col-form-label">To Date: </label>
        <div class="col-lg-3">
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"  AutoPostBack="true"  OnTextChanged="load_data"></asp:TextBox>
                        <ajaxtoolkit:calendarextender id="CalendarExtender3" runat="server" targetcontrolid="txtToDate" format="dd-MM-yyyy" ></ajaxtoolkit:calendarextender>
                 </div></div>
       <div class="row">
    <div class="col-md-12 d-flex justify-content-center">
        <div class="table-container">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="grid-data"> 
        <Columns>
             <asp:TemplateField HeaderText="LEAVE_DATE" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                <ItemTemplate>
                     <asp:Label ID="lbl_LeaveDate" runat="server" Width="150px" Height="30px" Text='<%#Eval("leave_date") %>'></asp:Label>
                      </ItemTemplate>
                    <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                </asp:TemplateField>
            <asp:TemplateField HeaderText="APPLY_DATE" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                <ItemTemplate>
                     <asp:Label ID="lbl_ApplyDate" runat="server" Width="150px" Height="30px" Text='<%#Eval("apply_date") %>'></asp:Label>
                      </ItemTemplate>
                    <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                </asp:TemplateField>
            <asp:TemplateField HeaderText="REASON" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                <ItemTemplate>
                     <asp:Label ID="lbl_Reason" runat="server" Width="180px" Height="30px" Text='<%#Eval("reason") %>'></asp:Label>
                      </ItemTemplate>
                    <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                </asp:TemplateField>
            <asp:TemplateField HeaderText="LEAVE_TYPE" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                <ItemTemplate>
                     <asp:Label ID="lbl_leaveType" runat="server" Width="80px" Height="30px" Text='<%#Eval("leave_type") %>'></asp:Label>
                      </ItemTemplate>
                    <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                </asp:TemplateField>
            <asp:TemplateField HeaderText="APPROVAL STATUS" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                <ItemTemplate>
                     <asp:Label ID="lbl_ApprovalStatus" runat="server" Width="80px" Height="30px" Text='<%#Eval("Approve_Status") %>'></asp:Label>
                      </ItemTemplate>
                    <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                </asp:TemplateField>
            <asp:TemplateField HeaderText="CANCEL STATUS" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                <ItemTemplate>
                     <asp:Label ID="lbl_cancelStatus" runat="server" Width="80px" Height="30px" Text='<%#Eval("Cancel_Status") %>'></asp:Label>
                      </ItemTemplate>
                    <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                </asp:TemplateField>
              <asp:TemplateField HeaderText="Remarks" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                <ItemTemplate>
                     <asp:Label ID="lbl_remark" runat="server" Width="80px" Height="30px" Text='<%#Eval("remarks") %>'></asp:Label>
                      </ItemTemplate>
                    <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
                </asp:TemplateField>
            </Columns>
    </asp:GridView>
            </div></div></div>
</asp:Content>
