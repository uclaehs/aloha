<%@ Page Title="Register a new Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WingtipToys.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
  
    <div class="form-horizontal">
        <h4> - For linking your training records from WorkSafe Database, please enter your <asp:label runat="server" class="progress" text="correct 9 digits University ID."/> </h4> 
        <h4> - Make sure to enter your <asp:label runat="server" class="progress" text="correct email address"/>, so you can receive the email confirmation link after you click on the [Register] button.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UID" CssClass="col-md-2 control-label">University ID</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UID" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UID"
                    CssClass="text-danger" ErrorMessage="The University ID field is required." />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="UID" runat="server" ErrorMessage="University ID ONLY allow numbers." ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <BR />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <p class="text-danger"><asp:Literal runat="server" ID="ErrorMessage" /></p>
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
                 <h5>After click on [Register] button, go to your email account, click on the confirmation links we send you to verify your email account.</h5>
                 <h5>Note: you would <asp:label runat="server" class="alert-warning" text="not be able to login"/> until you have <asp:label runat="server" class="alert-warning" text="clicked on the confirmation links"/> from us.</h5>
                <p><asp:Label ID="result_msg" Text="" runat="server"></asp:Label><br>
            </div>
        </div>
</div>
</asp:Content>
