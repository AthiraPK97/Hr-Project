<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Edit_Paymentterms.aspx.cs" Inherits="DoctorsOnDuty.Edit_Drdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group row">
        <label class="col-lg-4 col-form-label">Doctor Name </label>
        <div class="col-lg-8">
            <asp:DropDownList ID="ddl_drname" runat="server" CssClass="form-control" OnSelectedIndexChanged="Ddldr_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-lg-4 col-form-label">Payment Terms </label>
        <div class="col-lg-8">
            <asp:TextBox ID="Text_paymentterms" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50px"></asp:TextBox>
        </div>
    </div>

    <div class="col-lg-12"></div>
    <div class="col-lg-12"></div>

    <div class="form-group row">
        <%--<label class="col-lg-4 col-form-label" for="val-confirm-password">Payment Terms </label>--%>
        <div class="col-lg-2"><center><asp:Label ID="Label_payment" runat="server" Text="Payment terms" ForeColor="Black"></asp:Label> </center></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"><center><asp:Label ID="Label_patientlimit" runat="server" Text="Patient Limit" ForeColor="Black"></asp:Label> </center></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"><center><asp:Label ID="Label_abovemaximum" runat="server" Text="Above Maximum" ForeColor="Black"></asp:Label></center></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"><center><asp:Label ID="Label_ta" runat="server" Text="TA" ForeColor="Black"></asp:Label></center></div>
        <div class="col-lg-1"></div>
        
        <div class="col-lg-1"><asp:CheckBox ID="Check_perpatient" runat="server" Text="PerPatient" OnCheckedChanged="Perpatient_amt_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_pervisit" runat="server" Text="Per Visit" OnCheckedChanged="Pervisit_amt_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"><asp:TextBox ID="Text_patientlimit" runat="server" CssClass="form-control"></asp:TextBox></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_abovemaximum_amt" runat="server" Text="Amount" OnCheckedChanged="Abovemaximum_amt_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_abovemaximum_percent" runat="server" Text="Percent" OnCheckedChanged="Abovemaximum_percent_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_taall" runat="server" Text="TA-Sunday" OnCheckedChanged="Ta_all_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_tasunday" runat="server" Text="TA-AllVisit" OnCheckedChanged="Ta_sunday_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"></div>

        <div class="col-lg-2">
            <asp:TextBox ID="Text_perpatient_amt" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="Text_pervisit_amt" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:TextBox ID="Text_abovemaximum_amt" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="Text_abovemaximum_percent" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:TextBox ID="Text_taall" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="Text_tasunday" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
        
        <div class="col-lg-12"></div>
        <div class="col-lg-12"></div>
    </div>

    <div class="form-group row">
        <div class="col-lg-2"><center><asp:Label ID="Label_procedurecharges" runat="server" Text="Procedure Charges" ForeColor="Black"></asp:Label></center></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"><center><asp:Label ID="Label_echo" runat="server" Text="Echo" ForeColor="Black"></asp:Label></center></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"><center><asp:Label ID="Label_tmt" runat="server" Text="TMT" ForeColor="Black"></asp:Label></center></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"><center><asp:Label ID="Label_scan" runat="server" Text="Gynec Scan" ForeColor="Black"></asp:Label></center></div>
        <div class="col-lg-1"></div>

        <div class="col-lg-1"><asp:CheckBox ID="Check_procedurecharges_amt" runat="server" Text="Amount" OnCheckedChanged="Procedurecharges_amt_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_procedurecharges_percent" runat="server" Text="Percent" OnCheckedChanged="Procedurecharges_percent_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_echo_amt" runat="server" Text="Amount" OnCheckedChanged="Echo_amt_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_echo_percent" runat="server" Text="Percent" OnCheckedChanged="Echo_percent_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_tmt_amt" runat="server" Text="Amount" OnCheckedChanged="Tmt_amt_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_tmt_percent" runat="server" Text="Percent" OnCheckedChanged="Tmt_percent_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_scan_amt" runat="server" Text="Amount" OnCheckedChanged="Opticalreference_amt_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_scan_percent" runat="server" Text="Percent" OnCheckedChanged="Opticalreference_percent_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"></div>

        <div class="col-lg-2">
            <asp:TextBox ID="Text_procedurecharges_amt" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="Text_procedurecharges_percent" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:TextBox ID="Text_echo_amt" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="Text_echo_percent" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:TextBox ID="Text_tmt_amt" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="Text_tmt_percent" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:TextBox ID="Text_scan_amt" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="Text_scan_percent" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
        <div class="col-lg-12"></div>
        <div class="col-lg-12"></div>
    </div>

    <div class="form-group row">
        <div class="col-lg-2"><center><asp:Label ID="Label_pft" runat="server" Text="PFT" ForeColor="Black"></asp:Label></center></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"><center><asp:Label ID="Label_lab" runat="server" Text="Lab" ForeColor="Black"></asp:Label></center></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"></div>
        <div class="col-lg-1"></div>

        <div class="col-lg-1"><asp:CheckBox ID="Check_pft_amt" runat="server" Text="Amount" OnCheckedChanged="Pft_amt_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_pft_percent" runat="server" Text="Percent" OnCheckedChanged="Pft_percent_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_lab_amt" runat="server" Text="Amount" OnCheckedChanged="Lab_amt_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"><asp:CheckBox ID="Check_lab_percent" runat="server" Text="Percent" OnCheckedChanged="Lab_percent_CheckedChanged" AutoPostBack="true" /></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-1"></div>

        <div class="col-lg-2">
            <asp:TextBox ID="Text_pft_amt" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="Text_pft_percent" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2">
            <asp:TextBox ID="Text_lab_amt" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:TextBox ID="Text_lab_percent" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"></div>
        <div class="col-lg-1"></div>
        <div class="col-lg-2"></div>
        <div class="col-lg-1"></div>
    </div>

    <div class="form-group row">
        <div class="col-lg-8 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" Text="Edit" class="btn btn-primary" OnClick="Btn_submit_Click"  />
        </div>
    </div>

</asp:Content>
