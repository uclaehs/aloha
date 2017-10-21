<%@ Page Title="Training Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrainingSearch.aspx.cs" Inherits="WingtipToys.TrainingSearch" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <h2><%: Title %>.</h2>
    <h3></h3>

<asp:Panel id="pnlContents" runat = "server">
<asp:UpdatePanel ID="UpdatePanel" runat="server">
<ContentTemplate>
<p><asp:Label ID="result_msg" Text="Get it" runat="server"></asp:Label><br>
            <table border="0">
            <tr><td><asp:TextBox ID="idUID" runat="server" Text="Enter University ID here, seperate each ID with comma." style="width:900px" onfocus="clearField(this);" onblur="refillField(this,'Enter University ID here, seperate each ID with comma.');"></asp:TextBox>
                <%--<br><asp:LinkButton ID="btn_create_newAssessment_save" OnClientClick="return checkOperationalAssessment()" runat="server" Text="Save" CssClass="addButton" />--%>
                </td></tr>
            <tr><td>&nbsp;</td></tr>
            <tr><td><%-- <asp:ImageButton ID="btn_create_newAssessment_save" src="Images/Save-Button.png" runat="server" AlternateText="SAVE" OnClientClick="return checkOperationalAssessment()" />--%>
              <asp:ImageButton ID="btnTrainingSearch" runat="server" ToolTip="Click to create new assessment" ImageAlign="Left" OnClientClick="return checkOperationalAssessment()" OnClick ="btnTrainingSearch_Click"
			            ImageUrl="~/Images/Search-Button.png" onmouseover="this.src='Images/Search-Button-Hover.png'" onmouseout="this.src='Images/Search-Button.png'" />
             <%-- <asp:ImageButton ID="imgBtn_cancel" runat="server" ToolTip="Click to cancel create new assessment" ImageAlign="Right"
		                ImageUrl="~/Images/Cancel-Button.png" onmouseover="this.src='Images/Cancel-Button-Hover.png'" onmouseout="this.src='Images/Cancel-Button.png'" />--%>
                </td>
            </tr> 
            </table>

    <br><br><h7><b>Most Recent Completed Training for EH&S Required Course:</b></h7><br>
    <asp:GridView ID="workerListGrid" AutoGenerateColumns="false" DataKeyNames=""
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

</ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnTrainingSearch" />
        </Triggers>
</asp:UpdatePanel>

    </asp:Panel>

  <br /><br /><br /><br /> <br /><br />


<script type="text/javascript">
        function clearField(ctrl) {
            var str = document.getElementById('<%=idUID.ClientID%>').value;
            if (str === "Enter University ID here, seperate each ID with comma.") {
                ctrl.value = "";
            }
        }

        function refillField(ctrl, refillText) {
            if (ctrl.value == "") {
                ctrl.value = refillText;
            }
        }

        function checkOperationalAssessment() {
            var str = document.getElementById('<%=idUID.ClientID%>').value;
            if (str === "Enter University ID here, seperate each ID with comma.") {
                alert("Please enter University ID here, seperate each ID with comma.");
            return false;
        }
        return true;
    }

</script>

</asp:Content>
