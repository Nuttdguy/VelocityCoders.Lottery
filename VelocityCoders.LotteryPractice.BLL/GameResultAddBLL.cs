using System;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.DAL;
using System.Collections.Generic;


namespace VelocityCoders.LotteryPractice.BLL
{
    public static class GameResultAddBLL
    {

        #region SECTION 1 ||======= [METHOD-HELPER] GET THE # OF BALLS/RECORDS TO INSERT  =======||
        //== [2]. GET THE NUMBER OF BALLS FOR THE SELECTED GAME
        //public static int TotalOfGameBalls(string drpListGameName)
        //{
        //    int total;
        //    switch (drpListGameName)
        //    {
        //        case GameName._Powerball:
        //        case GameName._Megaball:
        //            total = (int)BallQuantityEnum.Seven;
        //            return total;
        //        case GameName._Gopher5:
        //        case GameName._NorthstarCash:
        //            total = (int)BallQuantityEnum.Five;
        //            return total;
        //        default:
        //            total = 0;
        //            return total;
        //    }
        //}

        #endregion

        #region SECTION 2 ||======= [METHOD] [4]. ADD BALL & GANE RESULTS =======|| 
        //== [4]. RECIEVE COLLECTION OF OBJECTS WITH FORM RESULTS
        public static string SaveGameResult(GameResultCollection collectFormResult, int totalGameBalls)
        {

            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();
            ValidateNumbers(collectFormResult, ref saveBrokenRules);

            //==  GET THE LOTTERYID/GAMEID || IDENTIFY AND PASS TO DAL  ==\\
            int gameId = 0;
            if (collectFormResult[totalGameBalls].LotteryName == "Power Ball")
            {
                gameId = (int)GameNameEnum.Powerball;
            }
            if (collectFormResult[totalGameBalls].LotteryName == "Mega Ball")
            {
                gameId = (int)GameNameEnum.Megaball;
            }
            if (collectFormResult[totalGameBalls].LotteryName == "Gopher 5")
            {
                gameId = (int)GameNameEnum.Gopher5;
            }
            if (collectFormResult[totalGameBalls].LotteryName == "Northstar Cash")
            {
                gameId = (int)GameNameEnum.NorthstarCash;
            }

            if (saveBrokenRules.Count > 0)
            {
                throw new BLLException("There was an error saving game result. ", saveBrokenRules);
            }
            else
            {
                //== [5]. GO TO DAL 
                return GameResultAddDAL.SaveGameResult(collectFormResult, totalGameBalls, gameId);
            }
        }

        #endregion

        #region  SECTION 3 ||======= [METHOD]  VALIDATE NUMBERS | BLL & DAL VALIDATION ========||

        private static bool ValidateNumbers(GameResultCollection collectFormResult , ref BrokenRuleCollection brokenRules)
        {
            GameResult checkBall = new GameResult();
            bool returnValue = true;

            foreach (GameResult item in collectFormResult)
            {
                if (item.BallNumber != 0)
                {
                    if (item.BallNumber > 80)
                    {
                        brokenRules.Add("Ball Number " + item.BallNumber + " must be less than 80");
                        returnValue = false;
                    }
                    else if (item.BallNumber < 0)
                    {
                        brokenRules.Add("Ball number " + item.BallNumber + " must be greater than 0");
                        returnValue = false;
                    }

                }

            }

            return returnValue;
        }


        #endregion

    }
}
