<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="procedure_incentiveadd.aspx.cs" Inherits="DoctorsOnDuty.procedure_incentiveadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group row">
        <label class="col-lg-4 col-form-label" for="val-email">Department</label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_dept" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row" runat="server" id="div_monthly">
        <div class="col-lg-8">
            <asp:GridView ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Doctor ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <ItemTemplate>
                            <asp:Label ID="lbl_drid" runat="server" Text='<%#Eval("staff_id") %>' Width="150px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Doctor Name" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <ItemTemplate>
                            <asp:Label ID="lbl_drname" runat="server" Text='<%#Eval("name") %>' Width="600px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Incentive Percentage" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_incentive" runat="server" Width="300px" Text='<%#Eval("incentive_percent").ToString()!="" ? Eval("incentive_percent") : 0 %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="SUBMIT" class="btn btn-primary" OnClick="ButtonSubmit_Click" />
        </div>
    </div>
</asp:Content>
