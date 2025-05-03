<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="View_payment.aspx.cs" Inherits="DoctorsOnDuty.View_payment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="div_hide">

        <asp:Label ID="Label_drid" runat="server" Visible="false"></asp:Label>

        <div class="form-group row">
            <label class="col-lg-1 col-form-label">Branch </label>
            <div class="col-lg-4">
                <asp:DropDownList runat="server" id="ddl_branch" CssClass="form-control"></asp:DropDownList> 
            </div>
            <div class="col-lg-1"></div>
            <label class="col-lg-1 col-form-label">To Date </label>
            <div class="col-lg-4">
                <asp:TextBox ID="txt_date" runat="server" CssClass="form-control"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_date" Format="dd-MM-yyyy"></ajaxToolkit:CalendarExtender> 
            </div>        
        </div>

        <div class="form-group row">
            <div class="col-lg-8 ml-auto">
                <asp:Button ID="Btn_submit" runat="server" Text="VIEW" class="btn btn-primary" OnClick="ButtonSubmit_Click"  />
            </div>
        </div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderText="DOCTOR ID" ItemStyle-Width="5%" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#002b84" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:Label ID="lbl_drid" runat="server" Text='<%#Eval("dr_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DOCTOR NAME" ItemStyle-Width="20%" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#002b84" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:Label ID="lbl_drname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TOTAL PATIENT" ItemStyle-Width="10%" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#002b84" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:Label ID="lbl_ttlpatient" runat="server" Text='<%#Eval("total_patient") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TOTAL COLLECTION" ItemStyle-Width="10%" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#002b84" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:Label ID="lbl_ttlcollection" runat="server" Text='<%#Eval("total_collection") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STATUS" ItemStyle-Width="10%" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#002b84" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:Label ID="lbl_status" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VIEW PAYMENT" ItemStyle-Width="10%" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#002b84" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="view" CommandArgument="<%# Container.DataItemIndex %>">View Payment</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  ItemStyle-Width="0%" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#002b84" ControlStyle-Height="50px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:Label></asp:Label>
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

    </div>


    <div id="div_hide2" runat="server">

        <div class="form-group row">
            <div class="col-lg-8 ml-auto">
                <asp:Button ID="btn_back" runat="server" Text="GO BACK" class="btn btn-primary" OnClick="ButtonBack_Click"  />
            </div>
        </div>

        <div class="form-group row">
            <label class="col-lg-3 col-form-label" >Total Payment </label>
            <div class="col-lg-4">
                <asp:TextBox ID="txt_payment" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="col-lg-4">
                <asp:LinkButton ID="Link_viewadditional" runat="server" OnClick="LinkAdditional_Click">View Additional</asp:LinkButton>
            </div>
        </div>

        <div id="div_hide2_1" runat="server">
            <div class="form-group row">
                <label class="col-lg-2 col-form-label" >Lab </label>
                <div class="col-lg-1"></div>
                <label class="col-lg-2 col-form-label" >Echo </label>
                <div class="col-lg-1"></div>
                <label class="col-lg-2 col-form-label" >TMT </label>
                <div class="col-lg-1"></div>
                <label class="col-lg-2 col-form-label" >Scan </label>
                <div class="col-lg-1"></div>
                <asp:TextBox ID="Text_lab" runat="server" CssClass="col-lg-2 form-control" ReadOnly="true"></asp:TextBox>
                <div class="col-lg-1"></div>
                <asp:TextBox ID="Text_echo" runat="server" CssClass="col-lg-2 form-control" ReadOnly="true"></asp:TextBox>
                <div class="col-lg-1"></div>
                <asp:TextBox ID="Text_tmt" runat="server" CssClass="col-lg-2 form-control" ReadOnly="true"></asp:TextBox>
                <div class="col-lg-1"></div>
                <asp:TextBox ID="Text_scan" runat="server" CssClass="col-lg-2 form-control" ReadOnly="true"></asp:TextBox>
                <div class="col-lg-1"></div>
            </div>

            <div class="form-group row"></div>

            <div class="form-group row">
                <label class="col-lg-2 col-form-label" >Procedure </label>
                <div class="col-lg-1"></div>
                <label class="col-lg-2 col-form-label" >TA </label>
                <div class="col-lg-1"></div>
                <label class="col-lg-2 col-form-label" >Above Max </label>
                <div class="col-lg-1"></div>
                <label class="col-lg-2 col-form-label" >PFT </label>
                <div class="col-lg-1"></div>
                <asp:TextBox ID="Text_procedure" runat="server" CssClass="col-lg-2 form-control" ReadOnly="true"></asp:TextBox>
                <div class="col-lg-1"></div>
                <asp:TextBox ID="Text_ta" runat="server" CssClass="col-lg-2 form-control" ReadOnly="true"></asp:TextBox>
                <div class="col-lg-1"></div>
                <asp:TextBox ID="Text_abovemax" runat="server" CssClass="col-lg-2 form-control" ReadOnly="true"></asp:TextBox>
                <div class="col-lg-1"></div>
                <asp:TextBox ID="Text_pft" runat="server" CssClass="col-lg-2 form-control" ReadOnly="true"></asp:TextBox>
                <div class="col-lg-1"></div>
            </div>

            <div class="form-group row"></div>

            <div class="form-group row">
                <label class="col-lg-3 col-form-label" >Grand Total </label>
                <asp:TextBox ID="Text_grndttl" runat="server" CssClass="col-lg-4 form-control" ReadOnly="true"></asp:TextBox>
                <div class="col-lg-1"></div>
                <asp:CheckBox CssClass="col-lg-3" ID="Check_payment" runat="server" Text="Initiate Payment" ForeColor="Red" />
            </div>

            <div class="form-group row"></div>
            <div class="col-lg-8 ml-auto">
                <asp:Button ID="Button_payment" runat="server" Text="SUBMIT" class="btn btn-primary" OnClick="Button_payment_Click"  />
            </div>
        </div>

        <%--<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderText="DATE" ItemStyle-Width="5%" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#002b84" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("date_") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TOTAL PATIENT" ItemStyle-Width="10%" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#002b84" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:Label ID="lbl_totalpatient" runat="server" Text='<%#Eval("total_patient") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TOTAL COLLECTION" ItemStyle-Width="10%" ItemStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#002b84" ControlStyle-Height="25px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:Label ID="lbl_totalcollection" runat="server" Text='<%#Eval("total_collection") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  ItemStyle-Width="0%" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#002b84" ControlStyle-Height="50px" HeaderStyle-Height="50px" HeaderStyle-Font-Size="Larger" HeaderStyle-Font-Names="TImes New Roman" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" >
                    <ItemTemplate>
                        <asp:Label></asp:Label>
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
        </asp:GridView>--%>

    </div>

</asp:Content>
