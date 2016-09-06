using System;
using System.Collections.Generic;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.DAL;

namespace VelocityCoders.LotteryPractice.BLL
{
    public class GameResultGetBLL
    {
        public static GameResultCollection GetGameResultCollection()
        {
            return GameResultGetDAL.GetGameResultCollection();

        }

        public static GameResultCollection GetGameResultCollection(int drawId)
        {
            return GameResultGetDAL.GetGameResultCollection(drawId);
        }


    }

}
