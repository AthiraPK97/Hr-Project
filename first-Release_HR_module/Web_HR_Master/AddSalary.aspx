<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddSalary.aspx.cs" Inherits="Web_HR_Master.AddSalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row page-titles">
        <div class="col-md-5 align-self-center">
            <h3 class="text-themecolor">ADD SALARY </h3>
        </div>
    </div>
      <div class="form-group row">
       <label class="col-lg-2 col-form-label"> DESIGNATION :  </label>
        <div class="col-lg-10">
               <asp:DropDownList ID="ddl_Designation" runat="server" CssClass="form-control" OnSelectedIndexChanged="load_username" AutoPostBack="true"></asp:DropDownList>                
        </div></div><br />
    <div class="form-group row">
       <label class="col-lg-2 col-form-label"> USER NAME :  </label>
        <div class="col-lg-10">
             <asp:DropDownList ID="ddl_userName" runat="server" CssClass="form-control"></asp:DropDownList>                
        </div></div><br />
   
     <div class="form-group row">
       <label class="col-lg-2 col-form-label"> MONTLY SALARY </label>
        <div class="col-lg-10">
               <asp:TextBox ID="txt_montlySalary" runat="server" CssClass="form-control"></asp:TextBox>
        </div></div><br /><br />
    <div class="form-group row">
             <label class="col-lg-2 col-form-label"> LEAVE DAYS: </label>
        </div>
    <div class="form-group row">
        <label class="col-lg-2 col-form-label"> WEEK OFF DAYS: </label>
        <div class="col-lg-3">
               <asp:TextBox ID="txt_weekoffDays" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>
         <label class="col-lg-2 col-form-label"> CASUAL LEAVE DAYS </label>
        <div class="col-lg-3">
               <asp:TextBox ID="txt_casualLeaveDays" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>

    </div><br /><br />
       <div class="form-group row">
         <div class="col-lg-7 ml-auto">
            <asp:Button ID="Btn_submit" runat="server" class="btn btn-primary" OnClick="Btn_submit_Click" Width="150" Text="Submit"  />
        </div>
    </div>
    <asp:GridView ID="GridView1" runat="server"  OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="ID">
        <Columns>
                <asp:TemplateField HeaderText="EMP CODE" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                     <ItemTemplate>
                         <asp:Label ID="lblUsername" runat="server" Width="350px" Height="30px" Text='<%#Eval("Emp_Code") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtUsername" runat="server" Width="350px" Height="30px" Text='<%#Eval("Emp_Code") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Width="350px" Height="30px"></asp:TextBox>
                    </FooterTemplate>
                    <HeaderStyle BackColor="#003366" Font-Bold="True" Font-Size="Larger" ForeColor="White" />
                    <ItemStyle width="350px"/>
               </asp:TemplateField>
            <asp:TemplateField HeaderText="User Name" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Width="350px" Height="30px" Text='<%#Eval("USERNAME") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Width="350px" Height="30px" Text='<%#Eval("USERNAME") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="TextBox5" runat="server" Width="350px" Height="30px"></asp:TextBox>
                    </FooterTemplate>
                    <HeaderStyle BackColor="#003366" Font-Bold="True" Font-Size="Larger" ForeColor="White" />
                    <ItemStyle width="350px"/>
               </asp:TemplateField>
                            <asp:TemplateField HeaderText="MONTHLY SALARY" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                     <ItemTemplate>
                         <asp:Label ID="lblMonthlySalary" runat="server" Width="350px" Height="30px" Text='<%#Eval("MONTHLY_SALARY") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtMonthlySalary" runat="server" Width="350px" Height="30px" Text='<%#Eval("MONTHLY_SALARY") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Width="350px" Height="30px"></asp:TextBox>
                    </FooterTemplate>
                    <HeaderStyle BackColor="#003366" Font-Bold="True" Font-Size="Larger" ForeColor="White" />
                    <ItemStyle width="350px"/>
               </asp:TemplateField>
             <asp:TemplateField HeaderText="LEAVE DAYS" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                     <ItemTemplate>
                         <asp:Label ID="lblLeaveDays" runat="server" Width="350px" Height="30px" Text='<%#Eval("LEAVE_DAYS") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtLeaveDays" runat="server" Width="350px" Height="30px" Text='<%#Eval("LEAVE_DAYS") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="TextBox3" runat="server" Width="350px" Height="30px"></asp:TextBox>
                    </FooterTemplate>
                    <HeaderStyle BackColor="#003366" Font-Bold="True" Font-Size="Larger" ForeColor="White" />
                    <ItemStyle width="350px"/>
               </asp:TemplateField>
                       <asp:TemplateField HeaderText="" ShowHeader="False" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger"> 
                <EditItemTemplate> 
                    <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton> 
                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton> 
                </EditItemTemplate> 
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton> 
                </ItemTemplate> 
            </asp:TemplateField> 
        </Columns>
    </asp:GridView>
</asp:Content>
