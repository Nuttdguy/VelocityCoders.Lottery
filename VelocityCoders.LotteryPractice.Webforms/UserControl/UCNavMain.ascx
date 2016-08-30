<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNavMain.ascx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.UserControl.UCNavMain" %>

<div>
  <asp:Label runat="server" ID="lbl_UcMessage" />
  <div class="siteNavigationContainer">
    <asp:ListView runat="server" ID="SiteNavigationMain" ItemPlaceholderID="SiteNavigationPlaceholder">

      <LayoutTemplate>
        <ul>
          <asp:PlaceHolder runat="server" ID="SiteNavigationPlaceholder" />
        </ul>
      </LayoutTemplate>

      <ItemTemplate>
        <li>
          <asp:HyperLink runat='server' ID='SiteNavigationLink' NavigateUrl='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' >
            <%# Eval("Text") %>
          </asp:HyperLink>
        </li>
      </ItemTemplate>

    </asp:ListView>
  </div>

</div>



