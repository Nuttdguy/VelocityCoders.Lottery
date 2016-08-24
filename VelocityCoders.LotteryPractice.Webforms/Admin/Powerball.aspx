<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Powerball.aspx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.Admin.Powerball" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div>
        <h1>Select Lottery Game:</h1>
        <div>
          <asp:DropDownList runat="server" ID="selectLotteryGameDropDown" >
            <asp:ListItem Text="(Select a Lottery Game)" Value="null" />
            <asp:ListItem Text="Power Ball" Value="powerball" />
            <asp:ListItem Text="Mega Ball" Value="megaball" />
            <asp:ListItem Text="Gopher 5" Value="gopher5" />
            <asp:ListItem Text="Northstar Cash" Value="northstarCash" />
          </asp:DropDownList>
        </div>
        <h3>Select Drawing Date: </h3>
        <div>
          <asp:DropDownList runat="server" ID="selectDrawingDateDropDown">
            <asp:ListItem Text="(Select Drawing Date)" Value="null"></asp:ListItem>
            <asp:ListItem Text="09/21/2016" Value="09/21/2016"></asp:ListItem>
            <asp:ListItem Text="09/20/2016" Value="09/20/2016"></asp:ListItem>
            <asp:ListItem Text="09/19/2016" Value="09/19/2016"></asp:ListItem>
            <asp:ListItem Text="09/18/2016" Value="09/18/2016"></asp:ListItem>
          </asp:DropDownList>
        </div>
      </div>
      <p><asp:Button runat="server" Text="Get Lottery Results" OnClick="getLotteryResults" /></p>

      <div>
        <h4><label>Game Abbreviation: </label><b><asp:Label runat="server" ID="lblLotteryGameAbbreviation" /></b></h4>
        <h4><label>How to Play: </label><asp:Label runat="server" ID="lblHowToPlay" /></h4>
        <h4><label>Description: </label><asp:Label runat="server" ID="lblLotteryDescription" /></h4>
      </div>

      <div>
        <h4><label>Jackpot Amount: </label><asp:Label runat="server" ID="lblJackpotAmount" /></h4>
        <h4><label>Cash Option Amount: </label><asp:Label runat="server" ID="lblCashOptionAmount" /></h4>
        <h4><label>Multiplier: </label><asp:Label runat="server" ID="lblMultiplier" /></h4>
      </div>

      <div>
        <asp:Image runat="server" ID="lotteryGameImage" />
        <h2><asp:label runat="server" ID="lblSelectedLotteryGameResult" /> Winning Numbers</h2>
        <h3><asp:Label runat="server" ID="lblDrawingDateResult" /></h3>
        <h4>Placeholder for Balls + special Ball</h4>
      </div>
    </form>
</body>
</html>
