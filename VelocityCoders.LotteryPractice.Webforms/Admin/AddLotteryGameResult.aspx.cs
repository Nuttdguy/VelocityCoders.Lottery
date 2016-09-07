using System;
using System.Text;
using VelocityCoders.LotteryPractice.BLL;
using System.Collections;
using System.Collections.Generic;
using VelocityCoders.LotteryPractice.Models;


namespace VelocityCoders.LotteryPractice.Webforms.Admin
{
    public partial class AddLotteryGameResult : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            PageTitleCaption.Text = _PageTitleResult;
            if (!IsPostBack)
            {
                drpBoxGameName();
            }
        }


        private const string _PageTitleResult = "Add Game Result";


        //========   CLICK-BUTTON EVENT HANDLER    ===========\\

        #region SECTION 1 ||====== EVENT LOGIC FOR PROCESSING FORM =======||
        protected void btnSubmitResult(object sender, EventArgs e)
        {
            //==  [1]. NEED TO CAPTURE FORM DATA FOR EACH INPUT FIELD  ==\\
            GameResultCollection CollectFormResult = new GameResultCollection();

            //==  [2]. GO TO BLL
            int totalGameBalls = GameResultAddBLL.TotalOfGameBalls(drpGameName.SelectedValue.ToLower());

            //==  [3]. CAPTURE FORM RESULT & ADD EACH OBJECT INSTANCE TO COLLECTION
            for (int i = 0; i < totalGameBalls; i++)
            {
                CollectFormResult.Add(CaptureFormInputValues(totalGameBalls, i));
            }

            //==  [4]. GO TO BLL
            string checkResult = GameResultAddBLL.SaveGameResult(CollectFormResult, totalGameBalls-1);

            //==  [6]. DISPLAY RESULT TO FRONT PAGE
            lblMessage.Text = checkResult;

            #region SECTION 1 || LOGIC FOR DISPLAYING RESULTS TO FRONT-PAGE
            //==  WORK ON MOVING CODE TO BUSINESS LOGIC LAYER  ==\\
            //GameResultCollection gameResultList = new GameResultCollection();
            //List<string> displayResult = new List<string>();
            //int ballCount = (int)BallQuantity.Seven;



            //for (int i = 0; i < ballCount; i++)
            //{
            //    //==  SET AND RETURN AN INSTANCE OF GAME RESULT CLASS  ==\\
            //    gameResultList.Add(CaptureFormValues(i));
            //    displayResult.Add(CompileList(gameResultList, i, ballCount));
            //}

            //lblMessage.Text = string.Empty;
            //displayResultOnFrontPage(displayResult);
            #endregion
        }
        #endregion

        #region SECTION 2 ||======== DISPLAY RESULTS TO VERIFY INSERT VALUES
        //=====  METHOD FOR GETTING BALL NUMBERS AND LOTTERY VALUES INTO A LIST ITEM  =====//
        protected string CompileList(GameResultCollection gameResultList, int i, int ballCount)
        {
            string compileResult = "";

            int currentItem = gameResultList[i].BallNumber;
            string currentLotteryName = gameResultList[i].LotteryName;

            if (i == 0)
            {
                compileResult = currentLotteryName + " || " + currentItem.ToString();
            }
            else
                compileResult = currentItem.ToString() + " || ";

            return compileResult;
        }

        //====== METHOD TO VERIFY THE RESULTS BY PRINTING OUT TO WEB - PAGE ========\\
        protected void displayResultOnFrontPage(List<string> displayResult)
        {
            foreach (string item in displayResult)
            {
                lblMessage.Text += item;
            }

        }
        #endregion

        #region SECTION 3 ||======= CAPTURE FORM INPUT DATA =======||
        //==  [3]. METHOD TO CAPTURE WEB-FORM INPUT | RETURN NEW INSTANCE FOR EACH BALL ========\\
        private GameResult CaptureFormInputValues(int totalGameBalls, int i)
        {
            GameResult theFormResult = new GameResult();

            //==  SET VARIABLES FOR EACH BALL  ==//
            int ballOne = BallNumber_1.Text.ToInt();
            int ballTwo = BallNumber_2.Text.ToInt();
            int ballThree = BallNumber_3.Text.ToInt();
            int ballFour = BallNumber_4.Text.ToInt();
            int ballFive = BallNumber_5.Text.ToInt();
            int ballSix = SpecialBallNumber.Text.ToInt();
            int ballSeven = drpListMultiplier.SelectedValue.ToInt();

            //==  SET PROPERTY VALUES FOR INSTANCE OF "GAME CLASS"  ==//
            theFormResult.LotteryName = drpGameName.SelectedValue;
            theFormResult.DrawDate = calDrawingDate.Text.ToDate();
            theFormResult.Jackpot = txtJackpotAmount.Text;

            //==  SET HASBALL PROPERTIES FOR INSTANCE OF GAME CLASS  ==//

            //LotteryName testForSpecialBall = (LotteryName)Enum.Parse(typeof(LotteryName), theFormResult.LotteryName.ToString());
            switch (theFormResult.LotteryName)
            {
                case GameName._Powerball:
                case GameName._Megaball:
                    theFormResult.HasSpecialBall = true;
                    theFormResult.IsRegularBall = true;
                    break;
                case GameName._NorthstarCash:
                case GameName._Gopher5:
                    theFormResult.HasSpecialBall = false;
                    theFormResult.IsRegularBall = true;
                    break;
            }

            //== [BLL INEFFICIENCY NOTE]. MOVING TO BLL WOULD REQUIRE TOO MANY
            //   VALUES BEING PASSED AS PARAMETERS || WILL KEEP WITHIN THE UI LAYER
            //==  SET BALL TYPE I.E. REGULAR, POWERBALL, MEGABALL, ETC  ==\\
            if (i == 0 ) {
                theFormResult.BallNumber = ballOne;
                theFormResult.BallTypeId = (int)BallType.Regularball;
            }
            else if (i == 1 ) {
                theFormResult.BallNumber = ballTwo;
                theFormResult.BallTypeId = (int)BallType.Regularball;
            }
            else if (i == 2) {
                theFormResult.BallNumber = ballThree;
                theFormResult.BallTypeId = (int)BallType.Regularball;
            }
            else if (i == 3 ) {
                theFormResult.BallNumber = ballFour;
                theFormResult.BallTypeId = (int)BallType.Regularball;
            }
            else if (i == 4)
            {
                theFormResult.BallNumber = ballFive;
                theFormResult.BallTypeId = (int)BallType.Regularball;
            }
                //== CHECK BALL #6 || SPECIAL BALL TYPE
            else if (i == 5)
            {
                switch(theFormResult.LotteryName)
                {
                    case GameName._Powerball:
                        theFormResult.BallNumber = ballSix;
                        theFormResult.BallTypeId = (int)BallType.Powerball;
                        break;
                    case GameName._Megaball:
                        theFormResult.BallNumber = ballSix;
                        theFormResult.BallTypeId = (int)BallType.Megaball;
                        break;
                    default:
                        theFormResult.BallNumber = ballSix;
                        theFormResult.BallTypeId = (int)BallType.Specialball;
                        break;
                }  
            }
                //== CHECK BALL #7 || MULTIPLIER BALL TYPE
            else 
            {
                theFormResult.BallNumber = ballSeven;
                theFormResult.BallTypeId = (int)BallType.Multiplierball;
            }

            return theFormResult;
        }

        #endregion

        #region SECTION 4 ||========= DROP LIST OF LOTTO-GAMES =========||
        protected void drpBoxGameName()
        {
            LotteryCollection nameCollection = LotteryName_Get.GetGameCollection();
            List<Lottery> drpList = new List<Lottery>();

            for (int i = 0; i < nameCollection.Count; i++)
            {
                drpList.Add(nameCollection[i]);
            }

            drpList.Insert(0, new Lottery { LotteryName = "(Select a game)", LotteryId = 0 });

            drpGameName.DataSource = drpList;
            drpGameName.DataBind();
        }

        #endregion


    }
}