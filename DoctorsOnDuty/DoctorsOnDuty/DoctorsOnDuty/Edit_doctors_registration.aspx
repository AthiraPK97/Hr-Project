<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Edit_doctors_registration.aspx.cs" Inherits="DoctorsOnDuty.Edit_doctors_registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Doctor Already Registered Do you want to update it?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label">Branch Name </label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_branchname" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_branchname_SelectedIndexChanged" OnTextChanged="ddl_branchname_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-email">Department</label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged" OnTextChanged="ddl_dept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-email">Doctor Name </label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_drname" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dr_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-password" >Doctor Sitting Area </label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_drarea" runat="server" CssClass="form-control">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>New Block</asp:ListItem>
                <asp:ListItem>Lab Reception</asp:ListItem>
                <asp:ListItem>New Building First Floor</asp:ListItem>
                <asp:ListItem>Maben Block</asp:ListItem>
                <asp:ListItem>24 Hour</asp:ListItem>
                <asp:ListItem>None</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-confirm-password">Visiting Period </label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_visitingperiod" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_visitingperiod_SelectedIndexChanged" OnTextChanged="ddl_visitingperiod_SelectedIndexChanged" AutoPostBack="true" >
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Weekly</asp:ListItem>
                <asp:ListItem>Monthly</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-group row" runat="server" id="div_monthly">
        <label class="col-lg-4 col-form-label" for="val-confirm-password">Select </label>
        <div class="col-lg-8">
            <asp:GridView ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="Gridview1_RowDeleting" OnRowCommand="GridView1_RowCommand" OnRowDeleted="Gridview1_RowDeleted">
                <Columns>
                    <asp:TemplateField HeaderText="Day Of Duty" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" CssClass="form-control" SelectedValue='<%#(String.IsNullOrEmpty(Eval("week_name").ToString()) ? "--Select--" : Eval("week_name"))%>'>
                                <asp:ListItem Selected hidden>--Select--</asp:ListItem>
                                <asp:ListItem >Sunday</asp:ListItem>
                                <asp:ListItem >Monday</asp:ListItem>
                                <asp:ListItem >Tuesday</asp:ListItem>
                                <asp:ListItem >Wednesday</asp:ListItem>
                                <asp:ListItem >Thursday</asp:ListItem>
                                <asp:ListItem >Friday</asp:ListItem>
                                <asp:ListItem >Saturday</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="week Number" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="200px" CssClass="form-control" SelectedValue='<%#(String.IsNullOrEmpty(Eval("weekno_name").ToString()) ? "--Select--" : Eval("weekno_name"))%>'>
                                <asp:ListItem Selected hidden>--Select--</asp:ListItem>
                                <asp:ListItem >First Week</asp:ListItem>
                                <asp:ListItem >Second Week</asp:ListItem>
                                <asp:ListItem >Third Week</asp:ListItem>
                                <asp:ListItem >Fourth Week</asp:ListItem>
                                <asp:ListItem >Fifth Week</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="From time" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <ItemTemplate>                            
                            <asp:TextBox ID="txt_frmtime" runat="server" Width="100px" CssClass="form-control" type="time" Text='<%#Eval("to_time") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="To Time" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <ItemTemplate>                            
                            <asp:TextBox ID="txt_totime" runat="server" Width="100px" CssClass="form-control" type="time" Text='<%#Eval("from_time") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <ItemTemplate>                            
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete" CommandArgument="<%# Container.DataItemIndex %>">DELETE</asp:LinkButton>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" BackColor="#666699" ForeColor="White" BorderColor="#666699" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="form-group row" runat="server" id="div_weekly">
        <label class="col-lg-4 col-form-label" for="val-confirm-password">Select </label>
        <div class="col-lg-8">
            <asp:GridView ID="Gridview2" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDeleting="Gridview2_RowDeleting" OnRowDeleted="Gridview2_RowDeleted" OnRowCommand="GridView2_RowCommand">
                <Columns>
                    
                    <asp:TemplateField HeaderText="Day Of Duty" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <%--<ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%#Eval("week_name") %>'></asp:Label></ItemTemplate>--%>
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList3" runat="server" Width="200px" CssClass="form-control" SelectedValue='<%#(String.IsNullOrEmpty(Eval("week_name").ToString()) ? "--Select--" : Eval("week_name"))%>'>
                                <asp:ListItem Selected hidden>--Select--</asp:ListItem>
                                <asp:ListItem >Sunday</asp:ListItem>
                                <asp:ListItem >Monday</asp:ListItem>
                                <asp:ListItem >Tuesday</asp:ListItem>
                                <asp:ListItem >Wednesday</asp:ListItem>
                                <asp:ListItem >Thursday</asp:ListItem>
                                <asp:ListItem >Friday</asp:ListItem>
                                <asp:ListItem >Saturday</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="From Time" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <ItemTemplate>                            
                            <asp:TextBox ID="txt_frmtime" runat="server" Width="150px" CssClass="form-control" type="time" Text='<%#Eval("to_time") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="To Time" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <ItemTemplate>                            
                            <asp:TextBox ID="txt_totime" runat="server" Width="150px" CssClass="form-control" type="time" Text='<%#Eval("from_time") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <ItemTemplate>   
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" CommandArgument="<%# Container.DataItemIndex %>">DELETE</asp:LinkButton>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Button ID="Button1" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click1" BackColor="#666699" ForeColor="White" BorderColor="#666699" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
                                            
    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="Submit" class="btn btn-primary"  OnClick="ButtonSubmit_Click" />
            <asp:Label ID="Label1" runat="server" ForeColor="Red" CssClass="danger"></asp:Label>
        </div>
    </div>


</asp:Content>
