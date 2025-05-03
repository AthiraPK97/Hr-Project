<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Add_effect_area.aspx.cs" Inherits="DoctorsOnDuty.Add_effect_area" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField HeaderText="" >
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("dept_id") %>' Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DEPARTMENT NAME" ItemStyle-Width="35%">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("dept_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PHARMACY" ItemStyle-Width="15%">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Convert.ToBoolean(Eval("pharmacy"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RECEPTION" ItemStyle-Width="15%">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%#Convert.ToBoolean(Eval("reception"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NURSE" ItemStyle-Width="15%">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%#Convert.ToBoolean(Eval("nurse"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EXTRA STAFF" ItemStyle-Width="15%">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%#Convert.ToBoolean(Eval("extrastaff"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="" ItemStyle-Width="1%">
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
            <asp:Button ID="Btn_submit" runat="server" Text="SUBMIT" class="btn btn-primary" OnClick="Btn_submit_Click" />
        </div>
    </div>

</asp:Content>
