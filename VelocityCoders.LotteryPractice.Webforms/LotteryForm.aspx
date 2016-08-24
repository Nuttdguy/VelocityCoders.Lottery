<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LotteryForm.aspx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.LotteryForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
      td { padding: 8px 16px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <h1>Lottery Form</h1>
    <div>
      <table>
        <tr> 
          <td>Game Name:
            <asp:DropDownList runat="server" ID="drpGameName">
              <asp:ListItem Text="Select One" Value="" />
              <asp:ListItem Text="PowerBall" Value="PowerBall" />
              <asp:ListItem Text="MegaBall" Value="MegaBall" />
              <asp:ListItem Text="Gopher 5" Value="Gopher 5" />
              <asp:ListItem Text="Northstar Cash" Value="Northstar Cash" />
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td>Game Name Abbr.:
          <asp:DropdownList runat="server" ID="drpGameAbbr" > 
            <asp:ListItem Text="Select One" Value="" />
            <asp:ListItem Text="PB" Value="PowerBall" />
            <asp:ListItem Text="MB" Value="MegaBall" />
            <asp:ListItem Text="G5" Value="Gopher5" />
            <asp:ListItem Text="NC" Value="Northstar Cash" />
          </asp:DropdownList>
          </td>
        </tr>
        <tr>
          <td>How to Play: 
            <asp:Label runat="server" ID="lblHowToPlay" />
          </td>
        </tr>
        <tr>
          <td>Description: 
            <asp:Label runat="server" ID="lblDescription" />
          </td>
        </tr>
      </table>
      <asp:Button runat="server" Text="Submit" OnClick="Unnamed_Click" />
    </div>
     <table>
        <tr>
          <td>Drawing Date</td>
          <td><%# Eval("DrawDate") %></td>
        </tr>
        <tr>
          <td>Jackpot Amount</td>
          <td><%# Eval("Jackpot") %></td>
        </tr>
       <asp:Repeater runat="server" ID="rptRepeater">
         <HeaderTemplate>
         </HeaderTemplate>
         <ItemTemplate>
           <tr>
           </tr>
         </ItemTemplate>
       </asp:Repeater>
     </table>
    </form>
</body>
</html>
