using System;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.Models.Enums;
using VelocityCoders.LotteryPractice.DAL;
using System.Collections.Generic;


namespace VelocityCoders.LotteryPractice.BLL
{
    public static class GameResultAddBLL
    {

        public static bool SaveGameResult(GameResult addGameResultData)
        {

            return GameResultAddDAL.SaveGameResult(addGameResultData);
        }

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


    }
}
