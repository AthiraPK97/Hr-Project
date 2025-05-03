<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Punching_registration.aspx.cs" Inherits="DoctorsOnDuty.Punching_registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    
    

    <br />


    <div class="form-group row">
        <label class="col-lg-3 col-form-label" >Doctor Name </label>
        <div class="col-lg-7">
            <asp:DropDownList ID="Ddl_doctor" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <asp:Button ID="Button1" runat="server" Text="Punch In" class="btn btn-secondary" OnClick="Btn_punchin_Click" />
        </div>
    </div>
    
    <%--<div class="form-group row">
        <label class="col-lg-3 col-form-label" >Password </label>
        <div class="col-lg-7">
            <asp:TextBox ID="Text_pwd" runat="server" CssClass="form-control" TextMode="Password" ></asp:TextBox>
        </div>
    </div>--%>

    <%--<div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="Submit" class="btn btn-primary" OnClick="Btn_submit_Click" />
        </div>
    </div>--%>

    <div class="form-group row" id="testdiv">
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

<ContentTemplate>
    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
    </asp:Timer>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_rowdeleting" >
            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderText="" ItemStyle-Width="10px">
                    <ItemTemplate>
                        <asp:Label ID="lbl_punchid" runat="server" Text='<%#Eval("punch_id") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DATE" ItemStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("date_") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DOCTOR NAME" ItemStyle-Width="300px" >
                    <ItemTemplate>
                        <asp:Label ID="lbl_drname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PUNCH IN TIME" ItemStyle-Width="150px">
                    <ItemTemplate>
                        <asp:Label ID="lbl_punchin" runat="server" Text='<%#Eval("punch_in") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="punchout" CommandArgument="<%# Container.DataItemIndex %>" ForeColor="Blue">Punch Out</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');" CommandName="delete" CommandArgument="<%# Container.DataItemIndex %>" ForeColor="Blue">Delete</asp:LinkButton>
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
    </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    

    <%--<script type="text/javascript">
        function confirmation() {
            if (confirm('Are you sure you want to delete ?')) {
                return true;
            } else {
                return false;
            }
        }
    </script>--%>

    <script>
                $('#<%=Ddl_doctor.ClientID%>').chosen();
    </script>


</asp:Content>
