using System;
using System.Text;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.Models.Enums;
using VelocityCoders.LotteryPractice.BLL;
using System.Collections.Generic;


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


        //========   GET LOTTERY DATA ON PAGE LOAD   =======\\
        protected void RetrieveGameDataOnLoad()
        {
            LotteryCollection gameCollection = GameNameGetBLL.GetGameCollection();
            GameResultCollection gameResultCollection = GameResultGetBLL.GetGameResultCollection();
            displayGameResults(gameResultCollection);
            //testOutput(gameResultCollection);
        }


        //.............  BEGIN SECTION
        //========   DISPLAY COLLECTION OF RESULTS ON MAIN PAGE   ==========\\

        protected void displayGameResults(GameResultCollection gameResultCollection)
        {

            
            //== CREATE A NEW COLLECTION INSTANCE TO CAPTURE BALLRESULT OBJECTS
            BallNumberCollection BallCollection = new BallNumberCollection();

            int presentId = 1;
     
            //int drawId = (int)BallQuantityEnum.Seven * presentId;

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

            #region WORKING SECTIONS

            //int presentId = 1;

            //for (int i = 0; i < gameResultCollection.Count; i++)
            //{
            //    int currentId = gameResultCollection[i].LotteryDrawingId;
            //    if (currentId == presentId)
            //    {
            //        int m = 0;
            //        for (int x = 0; x < ballCount; x++)
            //        {
            //            m++;
            //        }
            //        presentId = gameResultCollection[m].LotteryDrawingId;
            //    }
            //}

            #endregion


            #region


            //foreach (GameResult item in gameResultCollection)
            //{
            //    ballList.Add(item.BallNumber.ToString());
            //}

            //for ( int i = 0; i < gameResultCollection.Count; i++ )
            //{
            //    lottoId = gameResultCollection[i].LotteryDrawingId.ToString().ToInt();
            //    if ( lottoId == innerLottoId )
            //    {
            //        int num = 0;
            //        for (int x = 0; x < ballCount; x++)
            //        {
            //            if (x == 0) { tmpDisplayList.Add(gameResultCollection[x].BallNumber = ballList[num].ToString().ToInt()); }
            //            if (x == 1) { tmpDisplayList[i].BallNumber2 = ballList[num]; }
            //            if (x == 2) { tmpDisplayList[i].BallNumber3 = ballList[num]; }
            //            if (x == 3) { tmpDisplayList[i].BallNumber4 = ballList[num]; }
            //            if (x == 4) { tmpDisplayList[i].BallNumber5 = ballList[num]; }
            //            if (x == 5) { tmpDisplayList[i].BallNumber6 = ballList[num]; }
            //            if (x == 6) { tmpDisplayList[i].BallNumber7 = ballList[num]; }
            //            else num = x + num;
            //        }
            //        innerLottoId++;
            //    }
            //}

            //for (int i = 0; i < tmpBallList.Count; i++)
            //{
            //    for (int x = 0; x < ballCount; x++)
            //    {
            //        tmpDisplayList[i].BallNumber1 = tmpBallList[x];
            //        tmpDisplayList[i].BallNumber2 = tmpBallList[x];
            //        tmpDisplayList[i].BallNumber3 = tmpBallList[x];
            //        tmpDisplayList[i].BallNumber4 = tmpBallList[x];
            //        tmpDisplayList[i].BallNumber5 = tmpBallList[x];
            //        tmpDisplayList[i].BallNumber6 = tmpBallList[x];
            //        tmpDisplayList[i].BallNumber7 = tmpBallList[x];

            //    }
            //}

            //if (item.LotteryDrawingId == lottoId)
            //{
            //    tmpList.Add(item.DrawDate.ToShortDateString());
            //    tmpList.Add(item.LotteryDrawingId.ToString());
            //    lottoId++;
            //}

            //int count = 0;
            //for (int i = 0; i < listLength; i++)
            //{

            //    if (count != ballCount) {
            //        for (var n = 0; n < ballCount; n++)
            //        {
            //            rptViewResult.DataSource = tmpList;
            //            rptViewResult.DataBind();
            //        }
            //    }

            //}


            //if (x == 0)
            //{
            //    lblDrawingDate.Text = tmpList[x].DrawDate.ToShortDateString();
            //    lblBallNumber1.Text = tmpList[x].BallNumber.ToString();
            //}
            //if (x == 1) { lblBallNumber2.Text = tmpList[x].BallNumber.ToString(); }
            //if (x == 2) { lblBallNumber3.Text = tmpList[x].BallNumber.ToString(); }
            //if (x == 3) { lblBallNumber4.Text = tmpList[x].BallNumber.ToString(); }
            //if (x == 4) { lblBallNumber5.Text = tmpList[x].BallNumber.ToString(); }
            //if (x == 5) { lblBallNumber6.Text = tmpList[x].BallNumber.ToString(); }
            //if (x == 6) { lblBallNumber7.Text = tmpList[x].BallNumber.ToString(); }

            //string DrawDate = tmpList[x].DrawDate.ToShortDateString();
            //string BallNumber1 = tmpList[x].BallNumber.ToString();
            //string BallNumber2 = tmpList[x].BallNumber.ToString();
            //string BallNumber3 = tmpList[x].BallNumber.ToString();
            //string BallNumber4 = tmpList[x].BallNumber.ToString();
            //string BallNumber5 = tmpList[x].BallNumber.ToString();
            //string BallNumber6 = tmpList[x].BallNumber.ToString();
            //string BallNumber7 = tmpList[x].BallNumber.ToString();
            #endregion

        }

        protected BallNumberResult compileBallResult(GameResultCollection gameResultCollection, int i)
        {
            int ballCount;
            BallNumberResult tmpObject = new BallNumberResult();

            int m = i;

            if (gameResultCollection[i].LotteryName == "Power Ball" || gameResultCollection[i].LotteryName == "Mega Ball")
            {
                ballCount = (int)BallQuantityEnum.Seven;
            }
            else
                ballCount = (int)BallQuantityEnum.Five;

            for (int x = 0; x < ballCount; x++)
            {
                if (x == 0)
                {
                    tmpObject.BallNumber1 = gameResultCollection[m+x].BallNumber.ToString();
                    tmpObject.LotteryDrawingId = gameResultCollection[m+x].LotteryDrawingId.ToString().ToInt();
                    tmpObject.DrawDate = gameResultCollection[m+x].DrawDate;
                    tmpObject.LotteryId = gameResultCollection[m+x].LotteryId.ToString().ToInt();
                    tmpObject.LotteryName = gameResultCollection[m+x].LotteryName.ToString();
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





        //========   SHOW GAME RESULT DROP-DOWN | EDIT OR VIEW GAME   ============\\
        protected void CaptureDrpGameName_Selected(object sender, EventArgs e)
        {



        }
        //^^^^^^^^^^^^^^  END SECTION



        //.............. BEGIN SECTION  
        #region//========   CLICK-BUTTON || SECTION ADD NEW GAME   ===========\\

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


        //.............. BEGIN SECTION
        //==  USE TO TEST OUTPUT FROM DATABASE
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

        //^^^^^^^^^^^^^^  END SECTION


    }
}