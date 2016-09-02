using System;
using System.Collections.Generic;


namespace VelocityCoders.LotteryPractice.Models
{
    public class Lottery
    {
        public int LotteryId { get; set; }
        public string LotteryName { get; set; }
        public bool HasSpecialBall { get; set; }
        public bool IsRegularBall { get; set; }
    }
}
