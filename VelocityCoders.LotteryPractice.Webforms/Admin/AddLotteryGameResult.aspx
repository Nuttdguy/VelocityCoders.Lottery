<%@ Page Language="C#" Theme="Admin" AutoEventWireup="true" CodeBehind="AddLotteryGameResult.aspx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.Admin.AddLotteryGameResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin | Add Lottery Game Result</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Container">
      <div>
        <h1>Admin | Add Lottery Game Result</h1>
      </div>
      <div class="inputFormContainer">
        <div>
          <label>Game Name: </label>
            <asp:DropDownList runat="server" ID="drpListGameName" >
              <asp:Listitem Text="(Select a lottery game)" Value="" />
              <asp:ListItem Text="Power Ball" Value="powerball" />
            </asp:DropDownList>
        </div>
        <div>
          <span class="lblCenter"><label class="lblCalDrawingDate">Drawing Date: </label>
          <asp:Calendar runat="server" ID="calDrawingDate" /></span>
        </div>
        <div>
          <label>Jackpot Amount: </label>
            <asp:TextBox runat="server" ID="txtJackpotAmount" />
        </div>
        <div>
          <label>Multiplier: </label>
            <asp:DropDownList runat="server" ID="drpListMultiplier" >
              <asp:ListItem Text="(Select a multiplier)" value="" />
              <asp:ListItem Text="2" Value="2" />
            </asp:DropDownList>
        </div>
        <div>
          <asp:Button runat="server" Text="Submit" class="btnSubmitResult" OnClick="btnSubmitResult"/>
        </div>
      </div>
      <div class="inputFormContainer">
        <asp:Label runat="server" ID="lblMessage" />
      </div>
    </div>
    </form>
</body>
</html>
