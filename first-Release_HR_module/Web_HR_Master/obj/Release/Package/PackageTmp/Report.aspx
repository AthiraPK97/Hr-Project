<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Web_HR_Master.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Employee Master</h3>
            <style type="text/css">
                    .custom-pager a, .custom-pager span
                    {
                    padding: 3px 6px;
                    margin: 2px;
                    text-decoration: none;
                    color: #003366;
                    border: 1px solid #003366;
                    border-radius: 3px;
                    }

                    .custom-pager a:hover {
                    background-color: #003366;
                    color: #fff;
                    }

                 .custom-pager span {
                     background-color: #003366;
                     color: #fff;
                     border: 1px solid #003366;
                     border-radius: 3px;
                 }

                     .gridStyle {
                      width: 100%;
                      border: 1px solid #ccc;
                      }
                      .headerStyle {
                       background-color: #9f9393;
                       color: white;
                       font-weight: bold;
                      }
                      .rowStyle {
                       background-color: #f2f2f2;
                       }
                      .altRowStyle {
                       background-color: #ddd;
                       }
                      .dataColumn {
                       padding: 10px;
                       text-align: center;
                       }
                     </style> 
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
                    <div class="row">
                        <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Employee Status</label>
                                <asp:DropDownList ID="Ddl_status" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="Ddl_status_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Resigned</asp:ListItem>
                                    <asp:ListItem>Live</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                       <%-- <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Department</label>
                                <asp:DropDownList ID="Ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>--%>
                       <%-- <div class="col-sm-4 col-xs-4">
                            <div class="form-group">
                                <label>Doctor</label>
                                <asp:DropDownList ID="Ddl_doctor" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>--%>
                        <%--<div class="col-md-5"></div>
                        <div class="col-sm-4 col-xs-4">
                            <button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" onserverclick="Submit_click" >Submit</button>
                        </div>--%>

                        <div class="form-group row">
                        </div>
                    </div>
            
                    <br />
                    <br />
            <div class="form-group row">
                <div class="col-md-12" >
                    <div class="row" style="overflow: scroll; ">
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="true" PageSize="5" OnPageIndexChanging="GridView1_Pageindexchanging">
                        <HeaderStyle Font-Bold="true"  Font-Size="Large" ForeColor="Black"  />
                        <PagerStyle CssClass="custom-pager" />
                        <PagerSettings Mode="NumericFirstLast" FirstPageText="<< First" LastPageText="Last>>" NextPageText="Next >" PreviousPageText="< Prev" PageButtonCount="8" />
                         <RowStyle CssClass="rowStyle" Height="50px" />
                         <HeaderStyle CssClass="headerStyle" />
                         <AlternatingRowStyle CssClass="altRowStyle" />

                    </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
     
</asp:Content>
