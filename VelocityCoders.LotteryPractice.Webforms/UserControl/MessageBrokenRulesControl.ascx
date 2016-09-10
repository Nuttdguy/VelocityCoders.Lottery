<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBrokenRulesControl.ascx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.UserControl.MessageBrokenRulesControl" %>


<asp:Panel runat="server" class="PageMessage" ID="PageMessageArea" Visible="true">
  <asp:Label runat="server" ID="lblPageMessage" />
  <asp:ListView runat="server" ID="MessageList" ItemPlaceholderID="MessageListPlaceHolder">
    <LayoutTemplate>
      <ul>
        <asp:PlaceHolder runat="server" ID="MessageListPlaceHolder" />
      </ul>
    </LayoutTemplate>
    <ItemTemplate>
      <li class="errorList"><%# Eval("PropertyName") %>: <%# Eval("Message") %></li>
    </ItemTemplate>
  </asp:ListView>
</asp:Panel>