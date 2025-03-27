<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddStaffNorms.aspx.cs" Inherits="Web_HR_Master.AddStaffNorms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
   .custom-header {
        background-color: #003366;
        color: white;
        font-weight: bold;
        width: 100%;

    }
  .grid-data {
        color: black;
  }
        </style>
    <div class="form-group row">
       <label class="col-lg-2 col-form-label"> BRANCH :  </label>
        <div class="col-lg-10">
               <asp:DropDownList ID="ddl_Branch" runat="server" CssClass="form-control" OnSelectedIndexChanged="load_postname" AutoPostBack="true"></asp:DropDownList>                
   </div></div>
    <br />
      <div class="form-group row">
       <label class="col-lg-2 col-form-label"> POST :  </label>
        <div class="col-lg-10">
               <asp:DropDownList ID="ddl_Post" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:DropDownList>                
   </div></div>
    <br />
    
      <div class="form-group row">
       <label class="col-lg-2 col-form-label"> Norms :  </label>
          <div class="col-lg-10">

    <asp:TextBox ID="txtNorms" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
          </div>
        <br />
    <div class="d-flex justify-content-center">
    <asp:Button ID="btnAdd" runat="server"  class="btn btn-primary" OnClick="Btn_submit_Click" Width="150" Text="Submit"/>
        </div><br />
        <div class="col-md-12 d-flex justify-content-center">
        <div class="table-container">
               <HeaderStyle CssClass="custom-header" />
    <asp:GridView ID="GridView1" runat="server"  OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="ID" CssClass="grid-data">
        <Columns>
                <asp:TemplateField HeaderText="BRANCH" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                     <ItemTemplate>
                         <asp:Label ID="lblBranch" runat="server" Width="350px" Height="30px" Text='<%#Eval("BRANCH_NAME") %>'></asp:Label>
                     </ItemTemplate>
                   
                    <HeaderStyle BackColor="#003366" Font-Bold="True" Font-Size="Larger" ForeColor="White" />
                    <ItemStyle width="350px"/>
               </asp:TemplateField>
                            <asp:TemplateField HeaderText="POST" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                     <ItemTemplate>
                         <asp:Label ID="lblPost" runat="server" Width="350px" Height="30px" Text='<%#Eval("post_name") %>'></asp:Label>
                     </ItemTemplate>
                  
                    <HeaderStyle BackColor="#003366" Font-Bold="True" Font-Size="Larger" ForeColor="White" />
                    <ItemStyle width="350px"/>
               </asp:TemplateField>
             <asp:TemplateField HeaderText="NORMS" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger">
                     <ItemTemplate>
                         <asp:Label ID="lblNorms" runat="server" Width="350px" Height="30px" Text='<%#Eval("NORMS") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtNorms" runat="server" Width="350px" Height="30px" Text='<%#Eval("NORMS") %>'></asp:TextBox>
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
    </asp:GridView></div></div>
       <script>
        $('#<%=ddl_Branch.ClientID%>').chosen();
        $('#<%=ddl_Post.ClientID%>').chosen();
       </script>
</asp:Content>
