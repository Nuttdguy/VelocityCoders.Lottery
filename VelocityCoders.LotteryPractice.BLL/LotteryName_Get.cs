﻿using System;
using System.Collections.Generic;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.DAL;

namespace VelocityCoders.LotteryPractice.BLL
{
    public static class LotteryName_Get
    {
        //== [2]. FORWARD REQUEST TO DAL
        public static LotteryCollection GetGameCollection()
        {
            
            return LotteryDAL.GetCollection();

        }

    }
}
