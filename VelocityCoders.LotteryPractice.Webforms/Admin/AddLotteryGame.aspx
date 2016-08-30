<%@ Page Language="C#" Title="Admin | Add Lottery Game" Theme="Admin"  MasterPageFile="~/MasterPages/Section2.Master" CodeBehind="AddLotteryGame.aspx.cs" Inherits="VelocityCoders.LotteryPractice.Webforms.Admin.AddLotteryGame"%>



<asp:Content ID="Content1"  ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" runat="server"  ContentPlaceHolderID="ContentPlaceHolder1" >   
  <%--BEGIN PAGE TITLE --%>
  <div>
    <h1><asp:label runat="server" ID="PageTitleCaption" /></h1>
  </div>
  <%--END PAGE TITLE --%>

    <%--BEGIN MAIN-CONTENT == FORM--%>
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
        <asp:TextBox runat="server" ID="txtHowToPlay" TextMode="MultiLine"/>
      </div>
      <div>
        <label>Description: </label>
        <asp:TextBox runat="server" ID="txtDescription"  TextMode="MultiLine"/>
      </div>
      <div>
        <asp:Button runat="server" Text="Submit" class="btnSubmitResult"  OnClick="AddLotteryGame_Click"/>
      </div>
    </div> 
    <%--END MAIN-CONTENT == FORM--%>

    <div class="inputFormContainer" >
      <asp:label runat="server" ID="lblMessage" />
    </div>

</asp:Content>



        