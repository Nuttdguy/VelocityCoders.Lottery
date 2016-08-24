<%@ Page Language="C#" Theme="Main" AutoEventWireup="true" CodeBehind="Powerball.aspx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.Admin.Powerball" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Lottery Game Results</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
      <h1>View Lottery Game Results</h1>
      <h2>Game Abbreviation <br /><asp:Label runat="server" ID="lblLotteryGameAbbreviation" class="abbr" /></h2>

      <div class="pageContainer">

        <div class="gameSelectorContainer">
          <div class="gameSelectInner">
            <div class="gameInnerContentLeft" >
              <h2>Select Lottery Game:</h2><br />
              <asp:DropDownList runat="server" ID="selectLotteryGameDropDown" class="gameDropDown" >
                <asp:ListItem Text="(Select a Lottery Game)" Value="null" />
                <asp:ListItem Text="Power Ball" Value="powerball" />
                <asp:ListItem Text="Mega Ball" Value="megaball" />
                <asp:ListItem Text="Gopher 5" Value="gopher5" />
                <asp:ListItem Text="Northstar Cash" Value="northstarCash" />
              </asp:DropDownList>
            </div>
          </div>
          <div class="gameSelectInner">
            <div class="gameInnerContentRight" >
              <h2>Select Drawing Date: </h2><br />
              <asp:DropDownList runat="server" ID="selectDrawingDateDropDown" class="gameDropDown">
                <asp:ListItem Text="(Select Drawing Date)" Value="null"></asp:ListItem>
                <asp:ListItem Text="09/21/2016" Value="09/21/2016"></asp:ListItem>
                <asp:ListItem Text="09/20/2016" Value="09/20/2016"></asp:ListItem>
                <asp:ListItem Text="09/19/2016" Value="09/19/2016"></asp:ListItem>
                <asp:ListItem Text="09/18/2016" Value="09/18/2016"></asp:ListItem>
              </asp:DropDownList>
            </div>
          </div>
          <p><asp:Button runat="server" Text="Get Lottery Results" OnClick="getLotteryResults" class="getLotteryResultBtn"/></p>
        </div>

        <div>
          <h3><label>How to Play: </label><asp:Label runat="server" ID="lblHowToPlay" /></h3>
          <h3><label>Description: </label><asp:Label runat="server" ID="lblLotteryDescription" /></h3>
        </div>

        <div>
          <h3><label>Jackpot Amount: </label><asp:Label runat="server" ID="lblJackpotAmount" /></h3>
          <h3><label>Cash Option Amount: </label><asp:Label runat="server" ID="lblCashOptionAmount" /></h3>
          <h3><label>Multiplier: </label><asp:Label runat="server" ID="lblMultiplier" /></h3>
        </div>

        <div>
          <asp:Image runat="server" ID="lotteryGameImage" />
          <h2><asp:label runat="server" ID="lblSelectedLotteryGameResult" /> Winning Numbers</h2>
          <h3><asp:Label runat="server" ID="lblDrawingDateResult" /></h3>
          <h3>Placeholder for Balls + special Ball</h3>
        </div>
      </div>
    </div>
    </form>
</body>
</html>
