<%@ Page Language="C#" Title="Add Game Result" Theme="Admin" AutoEventWireup="true" MasterPageFile="~/MasterPages/Section2.Master" CodeBehind="AddLotteryGameResult.aspx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.Admin.AddLotteryGameResult" %>



<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head" ></asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1">
  <%--BEGIN PAGE TITLE --%>
  <div>
    <h1><asp:label runat="server" ID="PageTitleCaption" /></h1>
  </div>
  <%--END PAGE TITLE --%>

  <%--BEGIN CONTENT | MAIN--%>
  <div id="ContentContainer" >
    <%--  BEGIN ======  INPUT FORM CONTAINER  --%>
    <div class="formContainer gameResult">
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
        <asp:Button runat="server" Text="Add Game Result" class="btnSubmitResult" OnClick="btnSubmitResult"/>
      </div>

    </div> <%--  END ***** INPUT FORM CONTAINER  --%>

    <%--BEGIN SIDEBAR | VIEW GAME IN DATABASE--%>
    <div class="sideBarContainer gameResult">
      <div class="sidebarSpacer"></div>
      <h2>Ball Numbers</h2>
      <div class="BallNumberContainer">
        <label>First Ball</label>
        <asp:TextBox runat="server" ID="BallNumber_1" Text="" TextMode="Number" />
      </div>

      <div class="BallNumberContainer">
        <label>Second Ball</label>
        <asp:TextBox runat="server" ID="BallNumber_2" Text="" TextMode="Number" />
      </div>

      <div class="BallNumberContainer">
        <label>Third Ball</label>
        <asp:TextBox runat="server" ID="BallNumber_3" Text="" TextMode="Number" />
      </div>

      <div class="BallNumberContainer">
        <label>Fourth Ball</label>
        <asp:TextBox runat="server" ID="BallNumber_4" Text="" TextMode="Number" />
      </div>

      <div class="BallNumberContainer">
        <label>Fifth Ball</label>
        <asp:TextBox runat="server" ID="BallNumber_5" Text="" TextMode="Number" />
      </div>

      <div class="BallNumberContainer">
        <label>Special Ball</label>
        <asp:TextBox runat="server" ID="SpecialBallNumber" Text="" TextMode="Number" />
      </div>

    </div> <%--  END ***** SIDEBAR CONTAINER  --%>

    <div class="inputFormContainer">
      <asp:Label runat="server" ID="lblMessage" />
    </div>

  </div> <%--  END  *****  CONTENT CONTAINER  --%>
      
</asp:Content>
