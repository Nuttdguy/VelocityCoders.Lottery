﻿<%@ Page Language="C#" Title="Admin | Add Lottery Game" Theme="Admin"  MasterPageFile="~/MasterPages/Section2.Master" MaintainScrollPositionOnPostback="true" CodeBehind="AddLotteryGame.aspx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.Admin.AddLotteryGame"%>



<asp:Content ID="Content1"  ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" runat="server"  ContentPlaceHolderID="ContentPlaceHolder1" >   
  <%--BEGIN PAGE TITLE --%>
  <div>
    <h1><asp:label runat="server" ID="PageTitleCaption" /></h1>
  </div>
  <%--END PAGE TITLE --%>

<%--  BEGIN SIDEBAR  ======  VIEW GAME IN DATABASE--%>
    <div class="sideBarContainer addGame"  >
      <div class="sidebarSpacer"></div>
      <h2>View | Edit Game</h2>
      <asp:DropDownList runat="server" ID="drpGameName"  AutoPostBack="true" DataTextField="LotteryName" DataValueField="LotteryId"   OnSelectedIndexChanged="drpGameName_SelectedIndexChanged" >
      </asp:DropDownList>
    </div> <%--  END SIDEBAR ***** VIEW GAME IN DATABASE --%>


  <%--  BEGIN  ======  MAIN-FORM CONTENT --%>
  <div id="ContentContainer">
    <div class="formContainer">

      <%--  BEGIN  ====== VIEW GAME FORM  --%>
      <label for="checkBoxViewGame">VIEW GAME</label>
      <input type="checkbox" ID="checkBoxViewGame" checked />
      <label for="checkBoxAddGame">ADD GAME</label> 
      <input type="checkbox" ID="checkBoxAddGame" />
      <div class="addGameViewContainer show hide">
        <table>
          <asp:Repeater runat="server" ID="rptViewResult" OnItemDataBound="rptViewResult_ItemDataBound">
            <HeaderTemplate>
            <tr>
              <td>ID</td>
              <td>Edit </td>
              <td>Game name</td>
              <td>Drawing date</td>
              <td>Ball 1</td>
              <td>Ball 2</td>
              <td>Ball 3</td>
              <td>Ball 4</td>
              <td>Ball 5</td>
              <td>Ball SP</td>
              <td>Ball X</td>
            </tr>
          </HeaderTemplate>
          <ItemTemplate>
            <tr>
              <td><%# Eval("LotteryDrawingId") %></td>
        <%--FOR DELETE AND EDIT BUTTON HANDLERS--%>
              <td class="editRecord">
                <asp:LinkButton runat="server" Text="Edit" ID="EditButton" OnCommand="EditButton_Command" CommandName="EditButton" CssClass="btn btnEdit"/>
                <asp:LinkButton runat="server" Text="Delete" ID="DeleteButton" OnCommand="EditButton_Command" CommandName="DeleteButton"  CssClass="btn btnDelete"/>
              </td>
              <td><asp:Image runat="server" Width="120px" CssClass="GameLogo" ImageUrl='<%# Eval("ImageUrl") %>' /> </td>
              <td><%# DataBinder.Eval(Container.DataItem, "DrawDate", "{0:M/d/yyyy}") %></td>
              <td><span class="ball"><%# Eval("BallNumber1") %></span></td>
              <td><span class="ball"><%# Eval("BallNumber2") %></span></td>
              <td><span class="ball"><%# Eval("BallNumber3") %></span></td>
              <td><span class="ball"><%# Eval("BallNumber4") %></span></td>
              <td><span class="ball"><%# Eval("BallNumber5") %></span></td>
              <td><span class="ball ballSP"><%# Eval("BallNumber6") %></span></td>
              <td><span class="ball ballX"><%# Eval("BallNumber7") %></span></td>
            </tr>
          </ItemTemplate>
          </asp:Repeater>
        </table> 
      </div> <%--  END  *****  VIEW GAME FORM  --%>
    
      <%--  BEGIN ADD GAME ***** ADD GAME FORM --%>
      <div class="addGameContainer show hide cf">
        <div class="addGameSpacer"></div>
        <div>
          <label class="firstLabel">Game Name: </label>
          <asp:TextBox runat="server" ID="txtGameName" />
        </div>
        <div>
          <label class="firstLabel">Number Of Balls: </label>
          <asp:TextBox runat="server" ID="txtNumberOfBalls" TextMode="Number" />
        </div>
        <div>
          <label>Cost to Play: </label>
          <asp:DropDownList runat="server" ID="drpCostToPlay" >
            <asp:ListItem Text="(Select option)" Value="" />
            <asp:ListItem Text="$1 and $1 = $2 total" Value="1" />
          </asp:DropDownList>
          <%--<asp:TextBox runat="server" TextMode="Number" ID="TxtCostToPlay"  CssClass="txtCostToPlay"/>--%>
        </div>
        <div>
          <label>Has Special Ball: </label>
          <div class="checkbox" >
            <asp:CheckBoxList runat="server" ID="checkboxHasSpecialBall" >
              <asp:ListItem Text="No" Value="0" />
              <asp:ListItem Text="Yes" Value="1" />
            </asp:CheckBoxList>
<%--            <label >No<input type="checkbox" value="0"  /></label>
            <label >Yes<input type="checkbox" value="1" checked /></label>--%>
          </div>
        </div>
        <div>
          <label>Has Regular Balls: </label>
          <div class="checkbox">
            <asp:CheckBoxList runat="server" ID="checkBoxHasRegularBall" >
              <asp:ListItem Text="No" Value="0" />
              <asp:ListItem Text="Yes" Value="1" />
            </asp:CheckBoxList>
<%--            <label >No<input type="checkbox" value="0" /></label>
            <label >Yes<input type="checkbox" value="1" checked /></label>--%>
          </div>
        </div>
        <div>
          <label>How To Play: </label>
          <asp:TextBox runat="server" ID="txtHowToPlay" TextMode="MultiLine" />
        </div>
        <div>
          <label>Game Description: </label>
          <asp:TextBox runat="server" ID="txtGameDescription" TextMode="MultiLine" />
        </div>
        <div>
          <asp:Button runat="server" Text="Add Game" CssClass="btnAddGame" OnClick="BtnAddGame_Click" />
        </div>
      </div> <%--  END ADD GAME ***** ADD GAME FORM --%>


      <%--  UPDATE GAME RESULT ***** ADD GAME FORM --%>
      <input type="checkbox" ID="cancelCheckBox" />
      <label class="cancel" for="cancelCheckBox">x</label>
      <div class="editDrawingContainer cf">

        <div id="editBallContainLeft">
          <div>
            <label>Game Name</label>
            <asp:TextBox runat="server" ID="txtLotteryName" />
          </div>
          <div>
            <label>Drawing Date</label>
            <asp:TextBox runat="server" Id="txtDrawDate"/>
          </div>
          <div>
            <label>Jackpot</label>
            <asp:TextBox runat="server" Id="txtJackpot"/>
          </div>
          <div>
            <label>Drawing ID</label>
            <asp:TextBox runat="server" Id="txtLotteryDrawingId" CssClass="txtDrawId"/>
          </div>
          <asp:Button runat="server" ID="btnUpdate" Text="Update" OnClick="UpdateGameResult_ClickBtn" CssClass="btnUpdate" />
        </div> <%--  END EDITBALLCONTAIN-LEFT  --%>
        
        <div id="editBallContainRight">
          <div>
            <asp:Repeater runat="server" ID="rptModifyBallNumber" OnItemDataBound="rptModifyBallNumber_ItemDataBound">
              <ItemTemplate>
                <div>
                  <label>Ball Number </label>
                  <asp:TextBox runat="server" ID="txtBallNumber" Cssclass="editBall"/>
                </div>
              </ItemTemplate>
            </asp:Repeater>
          </div>
        </div> <%--  END EDITBALLCONTAIN-RIGHT  --%>
      </div> <%--  END UPDATE GAME RESULT ***** ADD GAME FORM --%>

    </div> <%--  END  *****  MAIN-FORM CONTENT --%>
  </div> <%--  END MAIN-FORM CONTENT ****** --%>


    <div class="formContainer" >
      <asp:label runat="server" ID="lblMessage" />
    </div>

</asp:Content>
        