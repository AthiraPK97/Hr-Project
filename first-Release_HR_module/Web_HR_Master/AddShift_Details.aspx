<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddShift_Details.aspx.cs" Inherits="Web_HR_Master.AddShift_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .grid-data {
    color: black;
}
    </style>
     <div class="form-group row">
       <label class="col-lg-2 col-form-label"> BRANCH :  </label>
        <div class="col-lg-10">
               <asp:DropDownList ID="ddl_Branch" runat="server" CssClass="form-control" onSelectedIndexChanged="load_username" AutoPostBack="true"></asp:DropDownList>                
   </div></div>
    <br />

    <div class="form-group row">
       <label class="col-lg-2 col-form-label"> USER NAME :  </label>
        <div class="col-lg-10">
               <asp:DropDownList ID="ddl_username" runat="server" CssClass="form-control"  OnSelectedIndexChanged="load_Shift" AutoPostBack="true"></asp:DropDownList>                
   </div></div>
    <br />

    <div class="form-group row">
       <label class="col-lg-2 col-form-label"> SHIFT :  </label>
        <div class="col-lg-10">
               <asp:DropDownList ID="ddl_Shift" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:DropDownList>                
   </div></div>
    <br />
    <div class="d-flex justify-content-center">
        <asp:Button ID="btnAdd" runat="server"  class="btn btn-primary" OnClick="Btn_submit_Click" Width="150" Text="Submit"/>
        </div><br /><br />
    <div class="row">
    <div class="col-md-12 d-flex justify-content-center">
        <div class="table-container">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="grid-data" OnRowDataBound="GridView1_RowDataBound">
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
           
       </Columns>
    </asp:GridView>
            </div></div></div>
     <script>

     </script>
</asp:Content>
