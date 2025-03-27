<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="StaffNorms.aspx.cs" Inherits="Web_HR_Master.StaffNorms" %>
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
    
      <div class="col-md-12 d-flex justify-content-center">
        <div class="table-container">
     <button type="submit" class="btn btn-dark waves-effect waves-light m-r-10" runat="server" id="Button1" onserverclick="ButtonExport_Click">EXPORT TO EXCEL</button>
           
    <asp:GridView runat="server" ID="GridView1" CssClass="grid-data" AutoGenerateColumns="false">
                       <HeaderStyle CssClass="custom-header" />
         <Columns>
                 <asp:BoundField HeaderText="POST" DataField="POST_NAME" ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="NORMS" DataField="NORMS" ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="ACTUAL" DataField="ACTUAL" ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="Live Punched(Excluding UNP)" DataField="CURR_DATE" ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="Shortage Count" DataField="SHORTAGE_COUNT" ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="Shortage Lag Days" DataField="Shortage_Lag_Days" ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="Autorized Leave"  ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="Unauthorized"  ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="Under Notice" DataField="UNDER_NOTICE"  ItemStyle-Width="250px" ItemStyle-Wrap="False" />
                 <asp:BoundField HeaderText="Vacant Position filling remarks"  ItemStyle-Width="250px" ItemStyle-Wrap="False" />

                 
             </Columns>
       
    </asp:GridView>
            </div></div>

</asp:Content>
