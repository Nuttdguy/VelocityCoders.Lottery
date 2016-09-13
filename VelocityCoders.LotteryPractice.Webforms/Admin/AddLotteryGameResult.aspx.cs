using System;
using System.Text;
using VelocityCoders.LotteryPractice.BLL;
using System.Collections;
using System.Collections.Generic;
using VelocityCoders.LotteryPractice.Models;
using System.Web.UI.WebControls;
using System.Web.UI;


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

        #region SECTION 1 ||======= [EVENT-BTN] PROCES FORM =======||
        protected void btnSubmitResult(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                //==  [1]. NEED TO CAPTURE FORM DATA FOR EACH INPUT FIELD  ==\\
                GameResultCollection CollectFormResult = new GameResultCollection();


                string selectedGame = drpGameName.SelectedItem.Text;
                int totalGameBalls = 0;

                if (selectedGame == "Power Ball" || selectedGame == "Mega Ball" )
                    totalGameBalls = (int)BallQuantityEnum.Seven;
                if (selectedGame == "Northstar Cash" || selectedGame == "Gopher 5")
                    totalGameBalls = (int)BallQuantityEnum.Five;
                
                //==  [3]. CAPTURE FORM RESULT & ADD EACH OBJECT INSTANCE TO COLLECTION
                for (int i = 0; i < totalGameBalls; i++)
                {
                    CollectFormResult.Add(CaptureFormInputValues(totalGameBalls, i));
                }


                try
                {
                    //==  [4]. GO TO BLL
                    string checkResult = GameResultAddBLL.SaveGameResult(CollectFormResult, totalGameBalls - 1);
                    //==  [6]. DISPLAY RESULT TO FRONT PAGE
                    lblMessage.Text = checkResult;
                }
                catch (BLLException ex)
                {
                    if (ex.BrokenRules != null && ex.BrokenRules.Count > 0)
                        DisplayLocalMessage(ex.Message, ex.BrokenRules);
                    else
                        DisplayLocalMessage(ex.Message);
                }

            }

        }
        #endregion

        #region SECTION 2 ||======= [METHOD] DISPLAY RESULTS TO VERIFY INSERT VALUES
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

        #region SECTION 3 ||======= [METHOD] = CAPTURE FORM INPUT DATA =======||
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

            //==  CHECK FOR NO VALUES FOR BALL NUMBER
            if (ballOne == 0 || ballTwo == 0 || ballThree == 0 || ballFour == 0 || ballFive == 0 || ballSix == 0 || ballSeven == 0)
            {
                DisplayLocalMessage("All balls must be greater than 0 ");
                return theFormResult;
            }
            
            //==  SET PROPERTY VALUES FOR INSTANCE OF "GAME CLASS"  ==//
            theFormResult.LotteryName = drpGameName.SelectedItem.Text;
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

        #region SECTION 4 ||======= [METHOD] DROP LIST OF LOTTO-GAMES =========||
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

        #region SECTION 5 ||======= [METHOD] VALIDATION PANEL  =======||
        private void DisplayLocalMessage(string message)
        {
            DisplayLocalMessage(message, new BrokenRuleCollection());
        }

        private void DisplayLocalMessage(string message, BrokenRuleCollection brokenRules)
        {
            MessageBrokenPanel.Visible = true;
            MessageBrokenPanel.Message = message;

            if (brokenRules.Count > 0)
                MessageBrokenPanel.BrokenRules = brokenRules;

            MessageBrokenPanel.Display();
        }

        #endregion

        #region SECTON 6 ||=======  [METHOD] VALIDATE FORM FOR CORRECT DATA | UI VALIDATION =======|
        private bool ValidateForm()
        {
            bool returnValue = true;
            BrokenRuleCollection brokenRules = new BrokenRuleCollection();

            //=====  DEFINE THE RULES IN WHICH THE FORM IS TO FOLLOW  =====\\
            if (string.IsNullOrEmpty(BallNumber_1.Text.Trim()))
                brokenRules.Add("Ball Number 1", "Required Field");
            if (string.IsNullOrEmpty(BallNumber_2.Text.Trim()))
                brokenRules.Add("Ball Number 2", "Required Field");
            if (string.IsNullOrEmpty(BallNumber_3.Text.Trim()))
                brokenRules.Add("Ball Number 3", "Required Field");
            if (string.IsNullOrEmpty(BallNumber_4.Text.Trim()))
                brokenRules.Add("Ball Number 4", "Required Field");
            if (string.IsNullOrEmpty(BallNumber_5.Text.Trim()))
                brokenRules.Add("Ball Number 5", "Required Field");
            if (string.IsNullOrEmpty(SpecialBallNumber.Text.Trim()))
                brokenRules.Add("Special Ball", "Required Field");
            if (string.IsNullOrEmpty(calDrawingDate.Text))
                brokenRules.Add("Drawing Date", "Required Field");
            if (string.IsNullOrEmpty(txtJackpotAmount.Text.Trim()))
                brokenRules.Add("Jackpot Amount", "Required Field");
            if (drpListMultiplier.SelectedValue == "0")
                brokenRules.Add("Multiplier", "Required Field");

            //======  CHECK IF BROKEN RULES HAS ANY ITEMS  ======\\
            if (brokenRules.Count > 0)
            {

                if (brokenRules.Count == 1)
                {
                    DisplayLocalMessage("There was an error processing your form. Please correct and try again.");
                }
                else
                {
                    DisplayLocalMessage("There were some errors processing your form. Please correct and try saving again.", brokenRules);
                }
                return false;
            }
            return returnValue;


        }


        #endregion

        protected void rptBallNumber_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}