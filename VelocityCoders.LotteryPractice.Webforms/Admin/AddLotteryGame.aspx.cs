using System;
using System.Text;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.Models.Enums;
using VelocityCoders.LotteryPractice.BLL;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;



namespace VelocityCoders.LotteryPractice.Webforms.Admin
{
    public partial class AddLotteryGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageTitleCaption.Text = _PageTitle;
            if (!IsPostBack)
            {
                RetrieveGameDataOnLoad();
            }
        }

        //========   PAGE PROPERTIES   ============\\

        private const string _PageTitle = "Add Game";



        //..[1]...........  BEGIN SECTION

        #region //========   GET LOTTERY DATA ON PAGE LOAD   =======\\

        protected void RetrieveGameDataOnLoad()
        {
            LotteryCollection LotteryNameCollection = LotteryName_Get.GetGameCollection();
            //LotteryCollection gameCollection = GameNameGetBLL.GetGameCollection();
            GameResultCollection _BallCollection = GameResultGetBLL.GetGameResultCollection();
            displayGameResults(_BallCollection);
            drpBoxGameName(LotteryNameCollection);

            //=== TEST OUTPUT
            //testOutput(_BallCollection);
        }

        #endregion

        //^^^^^^^^^^^^^^  END SECTION 



        //..[2]...........  BEGIN SECTION  
        #region  //========   DISPLAY COLLECTION OF RESULTS ON MAIN PAGE   ==========\\

        protected void displayGameResults(GameResultCollection gameResultCollection)
        {
 
            //== CREATE A NEW COLLECTION INSTANCE TO CAPTURE BALLRESULT OBJECTS
            BallNumberCollection BallCollection = new BallNumberCollection();

            int presentId = 1;

            for (int i = 0; i < gameResultCollection.Count; i++)
            {

                int idDifference = presentId - gameResultCollection[i].LotteryDrawingId;
                int currentId = gameResultCollection[i].LotteryDrawingId;

                if (currentId == presentId)
                {
                    BallCollection.Add(compileBallResult(gameResultCollection, i));
                    presentId += 1;
                }
                else if (idDifference == 1)
                {
                    presentId = gameResultCollection[i].LotteryDrawingId + 1;
                }
                else if (idDifference <= 0)
                {
                    presentId = gameResultCollection[i].LotteryDrawingId;
                    currentId = gameResultCollection[i].LotteryDrawingId;
                }

            }

            rptViewResult.DataSource = BallCollection;
            rptViewResult.DataBind();

        }

        protected BallNumberResult compileBallResult(GameResultCollection gameResultCollection, int i)
        {
            int ballCount;
            BallNumberResult tmpObject = new BallNumberResult();

            int m = i;

            if (gameResultCollection[i].LotteryName == "Power Ball" || gameResultCollection[i].LotteryName == "Mega Ball")
            {
                ballCount = (int)BallQuantityEnum.Seven;
                if (gameResultCollection[i].LotteryName == "Power Ball")
                {
                    tmpObject.ImageUrl = "~/App_Themes/Main/images/powerballLogo.png";
                }
                if (gameResultCollection[i].LotteryName == "Mega Ball")
                {
                    tmpObject.ImageUrl = "~/App_Themes/Main/images/megaMillionsLogo.png";
                }
            }
            else
            {
                ballCount = (int)BallQuantityEnum.Five;
                if (gameResultCollection[i].LotteryName == "Northstar Cash")
                {
                    tmpObject.ImageUrl = "~/App_Themes/Main/images/northstarLogo.png";
                }
                if (gameResultCollection[i].LotteryName == "Gopher 5")
                {
                    tmpObject.ImageUrl = "~/App_Themes/Main/images/gopher5Logo.png";
                }
            }

            for (int x = 0; x < ballCount; x++)
            {
                if (x == 0)
                {
                    tmpObject.BallNumber1 = gameResultCollection[m+x].BallNumber.ToString();
                    tmpObject.LotteryDrawingId = gameResultCollection[m+x].LotteryDrawingId.ToString().ToInt();
                    tmpObject.DrawDate = gameResultCollection[m+x].DrawDate;
                    tmpObject.LotteryId = gameResultCollection[m+x].LotteryId.ToString().ToInt();
                    tmpObject.LotteryName = gameResultCollection[m+x].LotteryName.ToString();
                    tmpObject.Jackpot = gameResultCollection[m + x].Jackpot.ToString();
                }
                if (x == 1)
                    tmpObject.BallNumber2 = gameResultCollection[m+x].BallNumber.ToString();
                if (x == 2)
                    tmpObject.BallNumber3 = gameResultCollection[m+x].BallNumber.ToString();
                if (x == 3)
                    tmpObject.BallNumber4 = gameResultCollection[m+x].BallNumber.ToString();
                if (x == 4)
                    tmpObject.BallNumber5 = gameResultCollection[m+x].BallNumber.ToString();
                if (x == 5)
                    tmpObject.BallNumber6 = gameResultCollection[m+x].BallNumber.ToString();
                if (x == 6)
                    if((m+x) >= gameResultCollection.Count)
                    {
                        tmpObject.BallNumber7 = gameResultCollection[m+x-1].BallNumber.ToString();
                    }
                    else tmpObject.BallNumber7 = gameResultCollection[m+x].BallNumber.ToString();
            }

            return tmpObject;
        }

        #endregion
        //^^^^^^^^^^^^^^  END SECTION



        //..[3]............ BEGIN SECTION  
        #region    //========   CLICK-BUTTON || SECTION ADD NEW GAME   ===========\\

        protected void BtnAddGame_Click(object sender, EventArgs e)
        {
            //== [1]. GOTO METHOD 
            GameResult addGameFormData = CaptureFormResult();
            int queryId = (int)QueryExecuteType.InsertItem;

            //== [2]. GO TO BLL
            string rowsAffected = GameAddNewBLL.GameToAdd(addGameFormData, queryId);

            //== [4]. OUTPUT AFFECTED RECORDS
            lblMessage.Text = rowsAffected;
        }

        //== [1]. CAPTURE FORM DATA AND RETURN INSTANCE OBJECT
        private GameResult CaptureFormResult()
        {
            GameResult AddGameFormData = new GameResult();

            AddGameFormData.LotteryName = txtGameName.Text;
            AddGameFormData.CostToPlay = drpCostToPlay.SelectedValue.ToInt();

            if (checkboxHasSpecialBall.SelectedValue.ToInt() == 1)
                AddGameFormData.HasSpecialBall = true;
            else
                AddGameFormData.HasSpecialBall = false;

            if (checkBoxHasRegularBall.SelectedValue.ToInt() == 1)
                AddGameFormData.IsRegularBall = true;
            else
                AddGameFormData.IsRegularBall = false;

            AddGameFormData.HowToPlay = txtHowToPlay.Text;
            AddGameFormData.GameDescription = txtGameDescription.Text;

            return AddGameFormData;
        }

        #endregion
        //^^^^^^^^^^^^^^  END SECTION


        //..[4]............ BEGIN SECTION  
        #region   //========   DROP-DOWN LIST OF LOTTO-GAMES  ===========\\
        protected void drpBoxGameName(LotteryCollection gameCollection)
        {
            List<Lottery> drpList = new List<Lottery>();

            for (int i = 0; i < gameCollection.Count; i++)
            {
                drpList.Add(gameCollection[i]);
            }

            drpList.Insert(0, new Lottery { LotteryName = "(Select a game)", LotteryId = 0 });

            drpGameName.DataSource = drpList;
            drpGameName.DataBind();
        }
        #endregion
        //^^^^^^^^^^^^^^  END SECTION

        
        
        //..[5]............ BEGIN SECTION  
        #region EDIT AND DELETE EVENT HANDLER
        protected void EditButton_Command(object sender, CommandEventArgs e)
        {
            GameResultCollection myResult = new GameResultCollection();

            switch (e.CommandName)
            {
                case "EditButton":
                    myResult = GameResultGetBLL.GetGameResultCollection(e.CommandArgument.ToString().ToInt());

                    //== NEED A DIFFERENT REPEATER CONTROL ==\\
                    rptModifyBallNumber.DataSource = myResult;
                    rptModifyBallNumber.DataBind();
                    txtLotteryName.Text = myResult[0].LotteryName;
                    txtDrawDate.Text = myResult[0].DrawDate.ToShortDateString();
                    txtJackpot.Text = myResult[0].Jackpot;
                    txtLotteryDrawingId.Text = myResult[0].LotteryDrawingId.ToString();
                    break;
                case "DeleteButton":
                    DeleteLotteryDrawing(e.CommandArgument.ToString().ToInt());
                    break;
            }


        }

        protected void rptModifyBallNumber_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                GameResult drawId = (GameResult)e.Item.DataItem;
                TextBox ball = (TextBox)e.Item.FindControl("txtBallNumber");

                ball.Text = drawId.BallNumber.ToString();
                ball.ID = drawId.WinningNumberId.ToString();
            }
        }

        #endregion
        //^^^^^^^^^^^^^^  END SECTION


        //.............. BEGIN SECTION  !!!!!!!!!!!!!!!   DOES NOT WORK YET
        #region UPDATE EVENT
        protected void UpdateGameResult_ClickBtn(object sender, EventArgs e)
        {

            List<GameResult> updateResult = new List<GameResult>();
            GameResult tmpObject = null;

            /* DOES NOT CONTAIN ANY VALUE
            List<int> rptTempItems = new List<int>(); 
            foreach (RepeaterItem item in rptModifyBallNumber.Items )
            {
                TextBox lblID = (TextBox)item.FindControl("txtBallNumber");
                int txtValue = lblID.Text.ToInt();
                int txtId = lblID.ID.ToInt();
                rptTempItems.Add(txtValue);
            }
            *///=== END

            string gameName = txtLotteryName.Text.ToLower();
            int ballCount = (int)BallQuantityEnum.Seven;

            for (int i = 0; i < ballCount; i++)
            {
                tmpObject = new GameResult();
                if (gameName == GameName._Powerball || gameName == "power ball")
                {
                    tmpObject.LotteryName = txtLotteryName.Text;
                    tmpObject.DrawDate = txtDrawDate.Text.ToString().ToDate();
                    tmpObject.Jackpot = txtJackpot.Text.ToString();
                    tmpObject.LotteryDrawingId = txtLotteryDrawingId.Text.ToString().ToInt();
                }
                else if (gameName == GameName._Megaball || gameName == "mega ball")
                    tmpObject.LotteryName = txtGameName.Text;
                else if (gameName == GameName._Gopher5 || gameName == "gopher 5")
                    tmpObject.LotteryName = txtGameName.Text;
                else if (gameName == GameName._Powerball || gameName == "northstar cash")
                    tmpObject.LotteryName = txtGameName.Text;
                else
                    break;

                updateResult.Add(tmpObject);
            }


            int drawingUpdateId = txtLotteryDrawingId.Text.ToInt();
            int lotteryId = 0;
            //int ballCount = 0;

            if (lotteryId == (int)GameNameEnum.Powerball)
            {
                lotteryId = (int)GameNameEnum.Powerball;
                ballCount = (int)BallQuantityEnum.Seven;
            }
            else if (lotteryId == (int)GameNameEnum.Megaball)
            {
                lotteryId = (int)GameNameEnum.Megaball;
                ballCount = (int)BallQuantityEnum.Seven;
            }
            else if (lotteryId == (int)GameNameEnum.Gopher5)
            {
                lotteryId = (int)GameNameEnum.Gopher5;
                ballCount = (int)BallQuantityEnum.Five;
            }
            else
            {
                lotteryId = (int)GameNameEnum.NorthstarCash;
                ballCount = (int)BallQuantityEnum.Five;
            }

            string updateSuccess = ModifyDrawingBLL.updateDrawing(drawingUpdateId, lotteryId, ballCount);


            lblMessage.Text = "Return Value";

        }

        //^^^^^^^^^^^^^^  END SECTION   !!!!!!!!!!!!!!!   DOES NOT WORK YET
        #endregion


        //.............. BEGIN SECTION 
        #region DELETE METHOD 
        protected void DeleteLotteryDrawing(int drawId)
        {

            int affectedRecord = ModifyDrawingBLL.DeleteDrawing(drawId);

            lblMessage.Text = affectedRecord.ToString();
        }

        #endregion
        //^^^^^^^^^^^^^^  END SECTION

        
        
        //==  SETS LOTTERYDRAWID FOR EACH EDIT|DELETE BUTTON >>  ON_LOAD OF REPEATER, THE LOTTERYDRAWINGID IS BEING ASSIGNED A VALUE FOR EACH BUTTON  ==//
        protected void rptViewResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
            {

                BallNumberResult drawId = (BallNumberResult)e.Item.DataItem;


                LinkButton edit = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton delete = (LinkButton)e.Item.FindControl("DeleteButton");

                edit.CommandArgument = (drawId.LotteryDrawingId ).ToString();
                delete.CommandArgument = (drawId.LotteryDrawingId ).ToString();
            }
        }

    









        //========   SHOW GAME RESULT DROP-DOWN | EDIT OR VIEW GAME   ============\\
        //protected void CaptureDrpGameName_Selected(object sender, EventArgs e)
        //{


        //}



        //.............. BEGIN SECTION
        #region //==  USE TO TEST OUTPUT FROM DATABASE
        protected void testOutput(GameResultCollection gameResultCollection)
        {
            #region //=== FOR TESTING OUTPUT OF SELECTION
            List<GameResult> compileList = new List<GameResult>();
            string testOutput = "";

            for (int i = 0; i < gameResultCollection.Count; i++)
            {
                compileList.Add(gameResultCollection[i]);
            }

            foreach (GameResult item in compileList)
            {
                testOutput += item.LotteryName + " Number:  " + item.BallNumber + " Lottery drawing Id: " + item.LotteryDrawingId + "<br/>";
            }

            lblMessage.Text += testOutput;
            #endregion
        }


        #endregion
        //^^^^^^^^^^^^^^  END SECTION


    }
}