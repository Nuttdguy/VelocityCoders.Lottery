using System;
using System.Text;
using VelocityCoders.LotteryPractice.BLL;
using System.Collections;
using System.Collections.Generic;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.BLL;


namespace VelocityCoders.LotteryPractice.Webforms.Admin
{
    public partial class AddLotteryGameResult : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            PageTitleCaption.Text = _PageTitleResult;
        }


        private const string _PageTitleResult = "Add Game Result";


        //========   CLICK-BUTTON EVENT HANDLER    ===========\\

        protected void btnSubmitResult(object sender, EventArgs e)
        {

            GameResultCollection gameResultList = new GameResultCollection();
            List<string> displayResult = new List<string>();
            int ballCount = (int)BallQuantity.Seven;



            for (int i = 0; i < ballCount; i++)
            {
                //==  SET AND RETURN AN INSTANCE OF GAME RESULT CLASS  ==\\
                gameResultList.Add(CaptureFormValues(i));
                displayResult.Add(CompileList(gameResultList, i, ballCount));
            }

            lblMessage.Text = string.Empty;
            displayResultOnFrontPage(displayResult);

        }

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

        //====== METHOD TO CAPTURE WEB-FORM INPUT  ========\\
        protected GameResult CaptureFormValues(int i)
        {
            GameResult addGameResultData = new GameResult();

            addGameResultData.LotteryName = drpListGameName.SelectedValue;
            addGameResultData.DrawDate = calDrawingDate.SelectedDate;
            addGameResultData.Jackpot = txtJackpotAmount.Text;
            if (i == 0) { addGameResultData.BallNumber = BallNumber_1.Text.ToString().ToInt(); }
            if (i == 1) { addGameResultData.BallNumber = BallNumber_2.Text.ToString().ToInt(); }
            if (i == 2) { addGameResultData.BallNumber = BallNumber_3.Text.ToString().ToInt(); }
            if (i == 3) { addGameResultData.BallNumber = BallNumber_4.Text.ToString().ToInt(); }
            if (i == 4) { addGameResultData.BallNumber = BallNumber_5.Text.ToString().ToInt(); }
            if (i == 5) { addGameResultData.BallNumber = SpecialBallNumber.Text.ToString().ToInt(); }
            if (i == 6) { addGameResultData.BallNumber = drpListMultiplier.SelectedValue.ToInt(); }

            return addGameResultData;

        }



    }
}