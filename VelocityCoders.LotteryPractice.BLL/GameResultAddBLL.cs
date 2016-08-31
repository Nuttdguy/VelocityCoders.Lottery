using System;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.Models.Enums;
using VelocityCoders.LotteryPractice.DAL;
using System.Collections.Generic;


namespace VelocityCoders.LotteryPractice.BLL
{
    public static class GameResultAddBLL
    {

        //public static int SaveGameResult(GameResult addGameResultData)
        //{

        //    return GameResultAddDAL.SaveGameResult(addGameResultData);
        //}

        //== [2]. GET THE NUMBER OF BALLS FOR THE SELECTED GAME
        public static int TotalOfGameBalls(string drpListGameName)
        {
            int total;
            switch (drpListGameName)
            {
                case GameName._Powerball:
                case GameName._Megaball:
                    total = (int)BallQuantityEnum.Seven;
                    return total;
                case GameName._Gopher5:
                case GameName._NorthstarCash:
                    total = (int)BallQuantityEnum.Five;
                    return total;
                default:
                    total = 0;
                    return total;
            }
        }

        //== [4]. RECIEVE COLLECTION OF OBJECTS WITH FORM RESULTS
        public static string SaveGameResult(GameResultCollection CollectFormResult, int totalGameBalls)
        {

            //==  GET THE LOTTERYID/GAMEID || IDENTIFY AND PASS TO DAL  ==\\
            int gameId = 0;
            if (CollectFormResult[totalGameBalls].LotteryName == GameName._Powerball)
            {
                gameId = (int)GameNameEnum.Powerball;
            }
            if (CollectFormResult[totalGameBalls].LotteryName == GameName._Megaball)
            {
                gameId = (int)GameNameEnum.Megaball;
            }
            if (CollectFormResult[totalGameBalls].LotteryName == GameName._Gopher5)
            {
                gameId = (int)GameNameEnum.Gopher5;
            }
            if (CollectFormResult[totalGameBalls].LotteryName == GameName._NorthstarCash)
            {
                gameId = (int)GameNameEnum.NorthstarCash;
            }


            return GameResultAddDAL.SaveGameResult(CollectFormResult, totalGameBalls, gameId);

        }

    }
}
