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
                int lotteryId = drpGameName.SelectedValue.ToInt();

                Lottery lottery = LotteryBLL.GetItem(lotteryId);
                int totalGameBalls = lottery.NumberOfBalls;

                
                //==  [3]. CAPTURE FORM RESULT & ADD EACH OBJECT INSTANCE TO COLLECTION
                for (int i = 0; i < totalGameBalls; i++)
                {
                    CollectFormResult.Add(CaptureFormInputValues(totalGameBalls, lottery, i));
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
        private GameResult CaptureFormInputValues(int totalGameBalls, Lottery lottery, int i)
        {
            GameResult theFormResult = new GameResult();

            //==  SET PROPERTY VALUES FOR INSTANCE OF "GAME CLASS"  ==//
            theFormResult.LotteryName = lottery.LotteryName;
            theFormResult.HasSpecialBall = lottery.HasSpecialBall;
            theFormResult.IsRegularBall = lottery.IsRegularBall;
            theFormResult.DrawDate = calDrawingDate.Text.ToDate();
            theFormResult.Jackpot = txtJackpotAmount.Text;

            int idx = 0;
            foreach (RepeaterItem item in rptBallNumber.Items)
            {
                TextBox ballNum = (TextBox)item.FindControl("BallNumber");
                if (idx == i)
                {
                    theFormResult.BallNumber = ballNum.Text.ToInt();
                }
                idx++;
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

        #region SECTION 4.1 ||======= [METHOD] REPEATER FOR NUMBER OF BALLS  =======||
        protected void drpGameName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lotteryId = drpGameName.SelectedValue.ToInt();
            Lottery lottery = LotteryBLL.GetItem(lotteryId);
            List<string> gameBallCount = new List<string>();

            for (int i = 0; i < lottery.NumberOfBalls; i++)
            {
                gameBallCount.Add("");
            }

            rptBallNumber.DataSource = gameBallCount;
            rptBallNumber.DataBind();
            
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
            GameResult tmpList = new GameResult();

            //=====  DEFINE THE RULES IN WHICH THE FORM IS TO FOLLOW  =====\\

            foreach (RepeaterItem item in rptBallNumber.Items)
            {
                TextBox tmpBall = (TextBox)item.FindControl("BallNumber");
                if (string.IsNullOrEmpty(tmpBall.Text))
                {
                    brokenRules.Add("Ball Number", "Required Field");
                }
            }

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


    }
}