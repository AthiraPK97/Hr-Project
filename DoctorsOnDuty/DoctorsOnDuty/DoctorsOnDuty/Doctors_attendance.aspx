<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Doctors_attendance.aspx.cs" Inherits="DoctorsOnDuty.Doctors_attendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

    <div class="form-group row">
        <label class="col-lg-1 col-form-label">Branch</label>
        <div class="col-lg-4">
            <asp:DropDownList ID="Ddl_branch" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-lg-1"></div>
        <label class="col-lg-1 col-form-label">Date</label>
        <div class="col-lg-4">
            <asp:TextBox ID="txt_date" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
        </div>
        <div class="col-lg-4"></div>
        <div class="col-lg-2">
            <asp:Button ID="Btn_submit" runat="server" Text="VIEW" class="btn btn-primary " OnClick="ButtonView_Click" />
        </div>        
    </div>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField HeaderText="" >
                <ItemTemplate>
                    <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("duty_id") %>' Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DOCTOR NAME" ItemStyle-Width="25%">
                <ItemTemplate>
                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("dr_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DEPARTMENT" ItemStyle-Width="20%">
                <ItemTemplate>
                    <asp:Label ID="lbl_dept" runat="server" Text='<%#Eval("dept_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SITTING AREA" ItemStyle-Width="20%">
                <ItemTemplate>
                    <asp:Label ID="lbl_sittingarea" runat="server" Text='<%#Eval("dr_sittingarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BRANCH" ItemStyle-Width="25%">
                <ItemTemplate>
                    <asp:Label ID="lbl_branch" runat="server" Text='<%#Eval("branch_name")  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ATTENDANCE" ItemStyle-Width="15%">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF"></EditRowStyle>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
        <HeaderStyle BackColor="#507CD1" ForeColor="#ffffff" Font-Bold="True" />
        <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>
        <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>
        <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>
        <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
    </asp:GridView>


    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField HeaderText="" >
                <ItemTemplate>
                    <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("duty_id") %>' Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DOCTOR NAME" ItemStyle-Width="25%">
                <ItemTemplate>
                    <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("dr_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DEPARTMENT" ItemStyle-Width="20%">
                <ItemTemplate>
                    <asp:Label ID="lbl_dept" runat="server" Text='<%#Eval("dept_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SITTING AREA" ItemStyle-Width="20%">
                <ItemTemplate>
                    <asp:Label ID="lbl_sittingarea" runat="server" Text='<%#Eval("dr_sittingarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BRANCH" ItemStyle-Width="25%">
                <ItemTemplate>
                    <asp:Label ID="lbl_branch" runat="server" Text='<%#Eval("branch_name")  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ATTENDANCE" ItemStyle-Width="25%">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Convert.ToBoolean(Eval("attend_bool"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF"></EditRowStyle>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
        <HeaderStyle BackColor="#507CD1" ForeColor="#ffffff" Font-Bold="True" />
        <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>
        <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>
        <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>
        <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
    </asp:GridView>

    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Button2" runat="server" Text="SUBMIT" class="btn btn-primary" OnClick="ButtonSubmit_Click" />
        </div>
    </div>

</asp:Content>
