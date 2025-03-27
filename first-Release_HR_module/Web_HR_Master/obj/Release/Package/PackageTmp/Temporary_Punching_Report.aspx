<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Temporary_Punching_Report.aspx.cs" Inherits="Web_HR_Master.Temporary_Punching_Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
<div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">Temporary Staff Attendance Report</h3>
            <style type="text/css">
                .custom-pager a, .custom-pager span {
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

                .grid-border td, .grid-border th {
                    border: 1px solid black;
                    padding: 8px;
                }

                .grid-border {
                    border-collapse: collapse;
                    width: 100%;
                }

                .form-group label {
                    margin-bottom: 0.3rem; /* Adjust as needed */
                }
 
               .form-group .form-control {
                   margin-top: 0; /* Removes extra space above the input */
               }
            </style>
        </div>
    </div>
    
    <!-- Form Controls -->
    <div class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="card-body">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div class="form-group row">
                        <label for="example-date-input" class="col-md-2 col-form-label">FROM DATE</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="Text_frmdate" runat="server" CssClass="form-control" Type="date"></asp:TextBox>
                        </div>
                        <div class="col-md-1"></div>
                        <label for="example-date-input" class="col-md-2 col-form-label">TO DATE</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="Text_todate" runat="server" CssClass="form-control" Type="date"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group row">
                        <label for="emp_code" class="col-md-2 col-form-label">EMP CODE: </label>
                        <div class="col-md-3">
                           <asp:DropDownList ID="ddl_name" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_name_changed" AutoPostBack="true"></asp:DropDownList> 
                        </div>
                      </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-md-5"></div>
                        <div class="col-sm-2 col-xs-2">
                            <button type="submit" class="btn btn-success waves-effect waves-light m-r-10" runat="server" id="Button2" onserverclick="Btn_ViewsClick">VIEW</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    

    <!-- Panel with Export Button and GridView -->
    <asp:Panel ID="panel1" runat="server">
        <div class="row">
            <div class="col-sm-2 col-xs-2">
                <button type="submit" class="btn btn-dark waves-effect waves-light m-r-10" runat="server" id="Button1" onserverclick="Export_click">EXPORT TO EXCEL</button>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="card card-body">
                    <div class="row"></div>
                    <br />
                    <div class="form-group row">
                        <div class="col-md-12">
                            <div class="row" style="overflow-x: auto;">
                                <asp:GridView ID="GridView2" runat="server" 
                                              AllowPaging="true" 
                                              PageSize="5" 
                                              AutoGenerateColumns="False"
                                              CssClass="table table-striped grid-border"
                                              OnPageIndexChanging="GridView1_Pageindexchanging">
                                    <HeaderStyle CssClass="headerStyle" Font-Bold="true" Font-Size="Large" ForeColor="Black" />
                                    <RowStyle CssClass="rowStyle" Height="50px" />
                                    <AlternatingRowStyle CssClass="altRowStyle" />
                                    <PagerStyle CssClass="custom-pager" />
                                    <PagerSettings Mode="NumericFirstLast" 
                                                   FirstPageText="<< First" 
                                                   LastPageText="Last >>" 
                                                   NextPageText="Next >" 
                                                   PreviousPageText="< Prev" 
                                                   PageButtonCount="8" />
                                    <Columns>
                                        <asp:BoundField DataField="Username" HeaderText="Username" />
                                        <asp:BoundField DataField="Emp_Name" HeaderText="Emp_Name" />
                                        <asp:BoundField DataField="punchin_time" HeaderText="punchin_time" />
                                       

                   <asp:TemplateField HeaderText="Punch-in Image">
    <ItemTemplate>
        <asp:Image ID="imgPunchin" runat="server" 
                   ImageUrl='<%# Eval("punchinimage") != DBNull.Value && Eval("punchinimage") != null
                        ? "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("punchinimage")) 
                        : "https://via.placeholder.com/100x100?text=No+Image" %>' 
                   Width="100px" Height="100px" />
    </ItemTemplate>
</asp:TemplateField>


                                        <asp:BoundField DataField="punchout_time" HeaderText="punchout_time" />
                                   <asp:TemplateField HeaderText="Punch-out Image">
    <ItemTemplate>
        <asp:Image ID="imgPunchout" runat="server" 
                   ImageUrl='<%# Eval("punchoutimage") != DBNull.Value && Eval("punchoutimage") != null
                        ? "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("punchoutimage")) 
                        : "https://via.placeholder.com/100x100?text=No+Image" %>' 
                   Width="100px" Height="100px" />
    </ItemTemplate>
</asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
        
</asp:Content>
