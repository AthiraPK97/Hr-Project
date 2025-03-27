<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Add_Temp_Staff.aspx.cs" Inherits="Web_HR_Master.Add_Temp_Staff" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">        
    <div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">NEW USER REGISTER </h3>
        </div>
    </div>
    <div class="form-group row">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <label class="col-lg-2 col-form-label"> BRANCH </label>
        <div class="col-lg-10">
                                <asp:DropDownList ID="ddl_branch" runat="server" CssClass="form-control"></asp:DropDownList>                
        </div><br /><br /><br />
        <label class="col-lg-2 col-form-label"> USERNAME </label>
        <div class="col-lg-10">
            <asp:Label ID="Text_uname" runat="server" CssClass=" col-lg-10 form-control " Enabled="false"></asp:Label>
                              
        </div><br /><br />
        
        <label class="col-lg-2 col-form-label"> DESIGNATION </label>
        <div class="col-lg-10">
                                <asp:DropDownList ID="ddldesignation" CssClass="form-control" runat="server"></asp:DropDownList>
        </div> <br /><br />
        <label class="col-lg-2 col-form-label"> MAIL ID </label>
        <div class="col-lg-10">
                                <asp:TextBox ID="Text_mail" runat="server" CssClass="form-control"></asp:TextBox>
        </div><br /><br />
        <label class="col-lg-2 col-form-label"> ROLE </label>
        <div class="col-lg-10">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="admin">Admin</asp:ListItem>
                                    <asp:ListItem Value="user" Selected="True">User</asp:ListItem>
                                </asp:RadioButtonList>
                                
        </div> <br /><br />
        <label class="col-lg-2 col-form-label"> PASSWORD </label>
        <div class="col-lg-10">
                                <asp:TextBox ID="Text_Pswd" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Text_Pswd" ErrorMessage="Password is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
        </div><br /><br />
        <label class="col-lg-2 col-form-label"> LOG USER </label>
        <div class="col-lg-10">
                                <asp:TextBox ID="Text_Loguser" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Text_Loguser" ErrorMessage="Log user is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
        </div> <br /><br />
                <label class="col-lg-2 col-form-label"> SELECT SHIFT </label>
        <div class="col-lg-10">
                                <asp:DropDownList ID="ddlshift" CssClass="form-control" runat="server"></asp:DropDownList>
        </div> <br /><br />
    </div><br /><br /><br />
  
     <div class="form-group row">
         <div class="col-lg-7 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="ADD USER" class="btn btn-primary" OnClick="Btn_submit_Click" Width="150" />
        </div>
    </div>

</asp:Content>
