<%@ Page Language="C#" Title="Admin | Add Lottery Game" Theme="Admin"  MasterPageFile="~/MasterPages/Section2.Master" CodeBehind="AddLotteryGame.aspx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.Admin.AddLotteryGame"%>



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
      <asp:DropDownList runat="server" ID="drpGameName"  DataTextField="LotteryName" DataValueField="LotteryId" >
      </asp:DropDownList>
    </div> <%--  END SIDEBAR ***** VIEW GAME IN DATABASE --%>


  <%--  BEGIN  ======  MAIN-FORM CONTENT --%>
  <div id="ContentContainer">
    <div class="formContainer">

      <!-- SAVE TABLE SUBNAV >> FOR FRONT-END IMPEMENTATION PURPOSES  -->
      <%--  BEGIN  ======  TABLE-SUB-NAV  --%>
<%--      <div class="addGameViewContainer">    
        <ul>
          <li class="addFormLink"><a>Add</a></li><!--
       --><li class="viewFormLink"><a>View</a></li>
        </ul>
      </div>--%> <%--  END  *****  TABLE-SUB-NAV  --%>

      <%--  BEGIN  ====== VIEW GAME FORM  --%>
      <label for="checkBoxViewGame">VIEW GAME</label>
      <input type="checkbox" ID="checkBoxViewGame" />
      <label for="checkBoxAddGame">ADD GAME</label> 
      <input type="checkbox" ID="checkBoxAddGame" />
      <div class="addGameViewContainer show hide">
        <table>
          <asp:Repeater runat="server" ID="rptViewResult">
            <HeaderTemplate>
            <tr>
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
              <td class="editRecord">
                <asp:LinkButton runat="server" Text="Edit" ID="EditButton" OnCommand="EditButton_Command" CommandName="EditButton"  CssClass="btn btnEdit"/>
                <asp:LinkButton runat="server" Text="Delete" ID="DeleteButton" OnCommand="DeleteButton_Command" CommandName="DeleteButton"  CssClass="btn btnDelete"/>
              </td>
              <td><%# Eval("LotteryName") %></td>
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




    </div> <%--  END  *****  MAIN-FORM CONTENT --%>
  </div>



    <div class="formContainer" >
      <asp:label runat="server" ID="lblMessage" />
    </div>

</asp:Content>
        



<%--              <td><asp:Label runat="server" ID="lblDrawingDate" /></td>
              <td><asp:Label runat="server" ID="lblBallNumber1" /></td>
              <td><asp:Label runat="server" ID="lblBallNumber2" /></td>
              <td><asp:Label runat="server" ID="lblBallNumber3" /></td>
              <td><asp:Label runat="server" ID="lblBallNumber4" /></td>
              <td><asp:Label runat="server" ID="lblBallNumber5" /></td>
              <td><asp:Label runat="server" ID="lblBallNumber6" /></td>
              <td><asp:Label runat="server" ID="lblBallNumber7" /></td>--%>