<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Branchwise_Checkup.aspx.cs" Inherits="Web_HR_Master.Branchwise_Checkup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Check up Data</h3>
        </div>
    </div>

     <div class="row">
                 
                        <div class="col-sm-2 col-xs-2">
                            <button type="submit" class="btn btn-dark waves-effect waves-light m-r-10" runat="server"  id="Button1" onserverclick="Export_click">EXPORT TO EXCEL</button>
                        </div>
                        <div class="form-group row"></div>
     </div>
    <!-- /.row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div class="row">
                        <%--<div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Employee Status</label>
                                <asp:DropDownList ID="Ddl_status" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="Ddl_status_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Resigned</asp:ListItem>
                                    <asp:ListItem>Live</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>--%>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Branch</label>
                                <asp:DropDownList ID="Ddl_branch" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Date From</label>
                                <asp:TextBox ID="txtFromDate" class="form-control"  runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate" Format="dd-MM-yyyy"/>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Date To</label>
                                <asp:TextBox ID="txtToDate" class="form-control"  runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate" Format="dd-MM-yyyy"/>
                            </div>
                        </div>
                        
                        <div class="col-sm-4 col-xs-4">
                            <button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" onserverclick="Submit_click" >Submit</button>
                        </div>

                        <div class="form-group row">
                        </div>
                    </div>
            
                    <br />
                    <br />
            <div class="form-group row">
                <div class="col-md-12" >
                    <div class="row" style="overflow: scroll; ">
                    <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
