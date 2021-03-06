﻿<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WingtipToys.Account.Profile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
<p><b>Click on [Edit] to update your profile information:</b><br>
 <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
    <asp:GridView runat="server" ID="userProfileGrid"  CssClass="grid"
    ItemType="WingtipToys.Models.ApplicationUser" DataKeyNames="Id" 
    SelectMethod="userProfileGrid_GetDataByID" UpdateMethod="userProfileGrid_UpdateItem"
    AutoGenerateEditButton="true" AutoGenerateDeleteButton="false"  
    AutoGenerateColumns="false">
    <Columns>
        <%--<asp:DynamicField DataField="FirstName" /> --%>
       
        <%--<asp:BoundField HeaderText="University ID" DataField="UserName" />--%>  <%--ItemStyle-Width="450px"--%>
         <asp:TemplateField HeaderText="University ID">
            <EditItemTemplate>
                <asp:TextBox ID="txtUID" runat="server" Text='<%# Bind("UserName") %>' width="200"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="txtLableUID" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>

         <asp:TemplateField HeaderText="First Name">
            <EditItemTemplate>
                <asp:TextBox ID="txtfname" runat="server" Text='<%# Bind("FirstName") %>' width="200"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="txtLablefname" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>

          <asp:TemplateField HeaderText="First Name">
            <EditItemTemplate>
                <asp:TextBox ID="txtlname" runat="server" Text='<%# Bind("LastName") %>' width="200"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="txtLablelname" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>
    </Columns>
    </asp:GridView>
    <p><asp:Label ID="result_msg" runat="server"></asp:Label><br>
    <br><h7><b>Note: If you are not able to change your Univiersity ID, that means the ID you would like to change to already exist in our system, perhaps linked to your different email account.</b></h7><br>
</asp:Content>