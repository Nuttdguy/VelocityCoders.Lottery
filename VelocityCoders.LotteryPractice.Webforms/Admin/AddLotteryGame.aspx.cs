using System;
using System.Text;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.Models.Enums;
using VelocityCoders.LotteryPractice.BLL;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;


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
        private GameResultCollection _BallCollection = GameResultGetBLL.GetGameResultCollection();

        //.............  BEGIN SECTION

        #region //========   GET LOTTERY DATA ON PAGE LOAD   =======\\

        protected void RetrieveGameDataOnLoad()
        {
            LotteryCollection gameCollection = GameNameGetBLL.GetGameCollection();
            displayGameResults(_BallCollection);
            drpBoxGameName(gameCollection);

            //=== Modify | Use property to get collection 
            //GameResultCollection gameResultCollection = GameResultGetBLL.GetGameResultCollection();
            //displayGameResults(gameResultCollection);
        }

        #endregion

        //^^^^^^^^^^^^^^  END SECTION 


        //.............  BEGIN SECTION  
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

        #endregion
        //^^^^^^^^^^^^^^  END SECTION


        //.............. BEGIN SECTION  
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

        //.............. BEGIN SECTION  
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


        //.............. BEGIN SECTION  
        #region EDIT AND DELETE EVENTS
        protected void EditButton_Command(object sender, CommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "EditButton":
                    break;
                case "DeleteButton":
                    break;
            }

            #region TEST CODE
            //string output = "";
            //foreach (GameResult item in _BallCollection)
            //{
            //    if (item.LotteryDrawingId == 1)
            //    {
            //        output = item.BallNumber.ToString() + " || ";
            //        output += item.LotteryId.ToString() + " || ";
            //        output += item.Jackpot.ToString() + " || ";
            //        output += item.LotteryName.ToString() + " || ";
            //        lblMessage.Text = output;
            //    }

            //}
            #endregion

        }

        protected void UpdateGameResult_ClickBtn(object sender, EventArgs e)
        {

        }

        protected void BindUpdateInfo(int drawId)
        {

        }

        protected void DeleteLotteryDrawing(int drawId)
        {

        }

        #endregion
        //^^^^^^^^^^^^^^  END SECTION

        
        
        //==  SETS LOTTERYDRAWID FOR EACH EDIT|DELETE BUTTON >>  ON_LOAD OF REPEATER, THE LOTTERYDRAWINGID IS BEING ASSIGNED A VALUE FOR EACH BUTTON  ==//
        protected void rptViewResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item )
            {
                BallNumberResult drawId = (BallNumberResult)e.Item.DataItem;

                LinkButton editButton = (LinkButton)e.Item.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("DeleteButton");

                editButton.CommandArgument = drawId.LotteryDrawingId.ToString();
                deleteButton.CommandArgument = drawId.LotteryDrawingId.ToString();
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