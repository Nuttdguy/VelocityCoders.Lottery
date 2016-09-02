using System;
using System.Text;
using VelocityCoders.LotteryPractice.Models;
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


        //.............  BEGIN SECTION
        //========   DISPLAY COLLECTION OF RESULTS ON MAIN PAGE   ==========\\

        



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
    }
}