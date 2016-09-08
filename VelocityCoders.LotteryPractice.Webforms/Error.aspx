<%@ Page Title="Error" Theme="Admin" Language="C#" MasterPageFile="~/MasterPages/Section2.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.Error" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="CenterErrorContainer">
    <h2> Error Occurred</h2>
    <p>
      An error has occurred while processing your request. Your request and error information has been logged. Please click <asp:HyperLink runat="server" ID="PreviousPageLink" Text="HERE" /> to go back to the previous page.
    </p>
    <div>
      <p>
        If the error continues and you need assistance immediately, please contact support at: contact@pygnasak.com
      </p>
    </div>
  </div>
</asp:Content>
