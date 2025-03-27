<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="PostWisePuchingReport.aspx.cs" Inherits="Web_HR_Master.PostWisePuchingReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       .grid-data {
    color: black;
}
       .custom-header {
        background-color: #003366;
        color: white;
        font-weight: bold;
        width: 100%;

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
               <asp:DropDownList ID="ddl_Post" runat="server" CssClass="form-control"  OnSelectedIndexChanged="load_punchingReport"  AutoPostBack="true"></asp:DropDownList>                
   </div></div>
    <br />
      <div class="col-md-12 d-flex justify-content-center">
        <div class="table-container">
    <asp:GridView ID="GridView1" runat="server" CssClass="grid-data">
                       <HeaderStyle CssClass="custom-header" />
           <%--  <Columns>
                 <asp:BoundField HeaderText="EMPLOYEE CODE" DataField="EMP_CODE" ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="BRANCH ID" DataField="BRANCH_ID" ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="BRANCH NAME" DataField="BRANCH_NAME" ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="CURRENT DATE" DataField="CURR_DATE" ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="POST NAME" DataField="POST_NAME" ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 
             </Columns>--%>
    </asp:GridView>
            </div></div>

       <script>
        $('#<%=ddl_Branch.ClientID%>').chosen();
        $('#<%=ddl_Post.ClientID%>').chosen();

       </script>

</asp:Content>
