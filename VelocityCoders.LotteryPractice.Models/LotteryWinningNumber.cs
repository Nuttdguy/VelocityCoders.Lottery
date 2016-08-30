using System;
using System.Collections.Generic;


namespace VelocityCoders.LotteryPractice.Models
{
    public class LotteryWinningNumber : Lottery
    {
        //public int LotteryId { get; set; }
        //public string LotteryName { get; set; }
        public DateTime DrawDate { get; set; }
        public int BallNumber { get; set; }
        public string BallTypeDescription { get; set; }
        public string Jackpot { get; set; }

    }
}
