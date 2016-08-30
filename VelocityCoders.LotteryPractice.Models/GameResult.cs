using System;
using System.Collections.Generic;


namespace VelocityCoders.LotteryPractice.Models
{
    public class GameResult : LotteryWinningNumber
    {

        public string HowToPlay { get; set; }
        public string GameDescription { get; set; }
        //=== ALL inherited properties ===\\

        //public int LotteryId { get; set; }
        //public string LotteryName { get; set; }
        //public Boolean HasSpecialBall { get; set; }
        //public Boolean IsRegularBall { get; set; }
        //public DateTime DrawDate { get; set; }
        //public int BallNumber { get; set; }
        //public string BallTypeDescription { get; set; }
        //public string Jackpot { get; set; }
    }
}
