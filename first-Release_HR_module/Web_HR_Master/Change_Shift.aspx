<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Change_Shift.aspx.cs" Inherits="Web_HR_Master.Change_Shift" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .grid-data {
    color: black;
}
    </style>
      <div class="form-group row">
       <label class="col-lg-2 col-form-label"> BRANCH :  </label>
        <div class="col-lg-10">
               <asp:DropDownList ID="ddl_Branch" runat="server" CssClass="form-control" onSelectedIndexChanged="load_Shiftdetails" AutoPostBack="true"></asp:DropDownList>                
   </div></div>
    <br />

     <div class="row">
    <div class="col-md-12 d-flex justify-content-center">
        <div class="table-container">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit1" CssClass="grid-data" >
        <Columns>
             <asp:TemplateField HeaderText="EMP CODE" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                 <ItemTemplate>
                      <asp:Label ID="Lbl_username" runat="server" Width="80px" Height="30px" Text='<%#Eval("username") %>'></asp:Label>
                </ItemTemplate>
                      <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
            </asp:TemplateField>
         <asp:TemplateField HeaderText="USER NAME" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                      <ItemTemplate>
                      <asp:Label ID="lbl_loguser" runat="server" Width="200px" Height="30px" Text='<%#Eval("log_user") %>'></asp:Label>
                        </ItemTemplate>
                      <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
            </asp:TemplateField>
        <%--    <asp:TemplateField HeaderText="POST NAME" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                      <ItemTemplate>
                      <asp:Label ID="lbl_PostName" runat="server" Width="200px" Height="30px" Text='<%#Eval("post_name") %>'></asp:Label>
                        </ItemTemplate>
                      <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="BRANCH id" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" Visible="false">
                      <ItemTemplate>
                      <asp:Label ID="lbl_Branchid" runat="server" Width="250px" Height="30px" Text='<%#Eval("BRANCH_id") %>'></asp:Label>
                        </ItemTemplate>
                      <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
            </asp:TemplateField>
        <asp:TemplateField HeaderText="BRANCH NAME" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                      <ItemTemplate>
                      <asp:Label ID="lbl_BranchName" runat="server" Width="250px" Height="30px" Text='<%#Eval("BRANCH_NAME") %>'></asp:Label>
                        </ItemTemplate>
                      <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
            </asp:TemplateField>
        <asp:TemplateField HeaderText="SHIFT" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" ItemStyle-CssClass="padded-column" >
                      <ItemTemplate>
                      <asp:Label ID="lbl_shift" runat="server" Width="300px" Height="30px" Text='<%#Eval("SHIFT") %>'></asp:Label>
                        </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddl_SHIFT" runat="server"  Width="300px" Height="30px"></asp:DropDownList>
                     
            </EditItemTemplate>
                      <HeaderStyle BackColor="#003366" Font-Bold="True"  ForeColor="White" />
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
            </div></div></div>
</asp:Content>
