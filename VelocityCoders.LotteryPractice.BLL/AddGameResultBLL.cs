using System;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.DAL;
using System.Collections.Generic;


namespace VelocityCoders.LotteryPractice.BLL
{
    public static class AddGameResultBLL
    {

        public static bool SaveGameResult(GameResult addGameResultData)
        {

            return AddGameResultDAL.SaveGameResult(addGameResultData);
        }

    }
}
