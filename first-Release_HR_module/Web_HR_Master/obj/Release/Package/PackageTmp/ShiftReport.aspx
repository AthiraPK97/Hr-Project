<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ShiftReport.aspx.cs" Inherits="Web_HR_Master.ShiftReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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

    .ajax__calendar_container {
        z-index: 9999 !important;
    }
     </style><br /><br />
         <div class="form-group row">
    <label class="col-lg-2 col-form-label"> BRANCH :  </label>
        <div class="col-lg-10">
               <asp:DropDownList ID="ddl_Branch" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:DropDownList>                
   </div></div>
    <br />

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div class="form-group row">
                        <label for="example-date-input" class="col-md-2 col-form-label">FROM DATE</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="Text_frmdate" runat="server" CssClass="form-control" ></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Text_frmdate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
                        </div>
                        <div class="col-md-1"></div>
                        <label for="example-date-input" class="col-md-2 col-form-label">TO DATE</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="Text_todate" runat="server" CssClass="form-control" ></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Text_todate" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
                        </div>
                    </div>
      <div class="form-group row">
                        <label for="example-date-input" class="col-md-2 col-form-label">Temp Staff/Permanent</label>
                        <div class="col-md-3">
                           <asp:DropDownList runat="server" ID="ddlType" CssClass="form-control col-md-8">
                               <asp:ListItem Value="temp">Temporary staff</asp:ListItem>
                                  <asp:ListItem Value="Permanent">Permanent staff</asp:ListItem>
                           </asp:DropDownList>
                        </div></div>
     <div class="form-group row" style="text-align: center;"><button type="submit" class="btn btn-dark " runat="server" id="Button2" onserverclick="ButtonSubmit_Click"  >Submit</button></div>
        <div class="row" >
                <div class="col-md-12 d-flex justify-content-center">
                                <div class="col-sm-2 col-xs-2">
                <button type="submit" class="btn btn-dark waves-effect waves-light m-r-10" runat="server" id="Button1" onserverclick="ButtonExport_Click" visible="false">EXPORT TO EXCEL</button>
            </div>
        
             <div class="col-sm-2 col-xs-2">
                <button type="submit" class="btn btn-primary" runat="server" id="btnMail" onserverclick="ButtonsendMail_Click" Visible="false">SEND MAIL</button>
            </div>
                    </div>
            </div>
<br />

    <div class="row">
    <div class="col-md-12 d-flex justify-content-center">
        <div class="table-container">
                             <div class="table-container">
                            <div class="row" style="overflow-x: auto; text-align: center;">
                                <asp:GridView ID="GridView1" runat="server"   CssClass="grid-data">
                                      <HeaderStyle CssClass="custom-header" />
                 <%--                      <Columns>
             <asp:TemplateField HeaderText="EMP CODE" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-HorizontalAlign="Center"  ItemStyle-CssClass="padded-column">
                 <ItemTemplate>
                      <asp:Label ID="Lbl_username" runat="server" Width="80px" Height="30px" Text='<%#Eval("unique_username") %>'></asp:Label>
                </ItemTemplate>
                      <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
            </asp:TemplateField>
         <asp:TemplateField HeaderText="USER NAME" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                      <ItemTemplate>
                      <asp:Label ID="lbl_loguser" runat="server" Width="200px" Height="30px" Text='<%#Eval("emp_name") %>'></asp:Label>
                        </ItemTemplate>
                      <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="POST NAME" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366"  HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="padded-column" >
                      <ItemTemplate>
                      <asp:Label ID="lbl_PostName" runat="server" Width="150px" Height="30px" Text='<%#Eval("POST_NAME") %>'></asp:Label>
                        </ItemTemplate>
                      <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
            </asp:TemplateField>
        <asp:TemplateField HeaderText="BRANCH NAME" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-HorizontalAlign="Center"  ItemStyle-CssClass="padded-column" >
                      <ItemTemplate>
                      <asp:Label ID="lbl_BranchName" runat="server" Width="250px" Height="30px" Text='<%#Eval("BRANCH_NAME") %>'></asp:Label>
                        </ItemTemplate>
                      <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
            </asp:TemplateField>
        <asp:TemplateField HeaderText="SHIFT" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-CssClass="center-header"  ItemStyle-CssClass="padded-column" >
                      <ItemTemplate>
                      <asp:Label ID="lbl_shift" runat="server" Width="300px" Height="30px" Text='<%#Eval("SHIFT") %>'></asp:Label>
                        </ItemTemplate>
                      <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
            </asp:TemplateField>
       </Columns>--%>

                                </asp:GridView></div></div></div></div></div>
                            
</asp:Content>
