<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LotteryPratice.aspx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.LotteryPratice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table>
            <asp:Repeater runat="server" ID="rptLotteryList">
                <HeaderTemplate>
                    <tr>
                        <td class="tr">Lottery Id</td>
                        <td class="tr">Lottery Name</td>
                        <td class="tr">Has Special Ball</td>
                        <td class="tr">Is Regular Ball</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("LotteryId") %></td>
                        <td><%# Eval("LotteryName") %></td>
                        <td><%# Eval("HasSpecialBall") %></td>
                        <td><%# Eval("IsRegularBall") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
