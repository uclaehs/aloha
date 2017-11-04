<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyStaffsTraining.aspx.cs" Inherits="WingtipToys.Training.MyStaffsTraining" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2><%: Title %></h2>

<asp:Label ID="result_msg" Text="" runat="server"></asp:Label>
    <p><h7><b>Most Recent Completed Training for EH&S Required Course:</b></h7><br>
    <asp:GridView ID="trainingListGrid" AutoGenerateColumns="false" DataKeyNames=""
    runat="server" EmptyDataText="No Training Record Found." CssClass="grid">
    <Columns>
       
        <asp:BoundField DataField="NameReverse" HeaderText="Name"><ItemStyle Width="200px" />
            </asp:BoundField>
        <asp:BoundField DataField="Learner_Id" HeaderText="ID"><ItemStyle Width="50px" />
            </asp:BoundField>
        <asp:BoundField DataField="Course_Id" HeaderText="Course ID"><ItemStyle Width="120px" />
            </asp:BoundField>
        <asp:BoundField DataField="Title" HeaderText="Course Title"><ItemStyle />
            </asp:BoundField>
        <asp:BoundField DataField="Status_Date" HeaderText="Date Completed" nulldisplaytext="" DataFormatString="{0:MM/dd/yyyy}"><ItemStyle Width="50px" />
            </asp:BoundField>
        <asp:BoundField DataField="Date_Expires" HeaderText="Date Expires" nulldisplaytext="NONE" DataFormatString="{0:MM/dd/yyyy}"><ItemStyle Width="50px" />
            </asp:BoundField>

    </Columns>
    <HeaderStyle />
    <RowStyle />
    <EditRowStyle CssClass="gridFooter" />
  </asp:GridView>

</asp:Content>
