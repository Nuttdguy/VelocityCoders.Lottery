<%@ Page Language="C#" Theme="Admin" AutoEventWireup="true" CodeBehind="AddLotteryGame.aspx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.Admin.AddLotteryGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin | Add Lottery Game</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Container">
      <div>
        <h1>Admin | Add Lottery Game</h1>
      </div>
      <div class="inputFormContainer">
        <div>
          <label>Game Name: </label>
          <asp:TextBox runat="server" ID="txtGameName" />
        </div>
        <div>
          <label>Game Name Abbreviation: </label>
          <asp:TextBox runat="server" ID="txtGameAbbr" />
        </div>
        <div>
          <label>How to play: </label>
          <asp:TextBox runat="server" ID="txtHowToPlay" />
        </div>
        <div>
          <label>Description: </label>
          <asp:TextBox runat="server" ID="txtDescription" />
        </div>
        <div>
          <asp:Button runat="server" Text="Submit" class="btnSubmitResult"  OnClick="AddLotteryGame_Click"/>
        </div>
      </div>  
      <div class="inputFormContainer" >
        <asp:label runat="server" ID="lblMessage" />
        <p><%# Eval("GameName") %></p>
        <p><%# Eval("GameNameAbbr") %></p>
        <p><%# Eval("HowToPlay") %></p>
        <p><%# Eval("Description") %></p>
      </div>
        
    </div>
    </form>
</body>
</html>
