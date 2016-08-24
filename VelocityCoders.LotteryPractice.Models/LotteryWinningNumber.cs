using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryPractice.Models
{
    public class LotteryWinningNumber : BaseCollection<LotteryWinningNumber>
    {
        public int LotteryId { get; set; }
        public string LotteryName { get; set; }
        public DateTime DrawDate { get; set; }
        public int BallNumber { get; set; }
        public string BallTypeDescription { get; set; }
        public string Jackpot { get; set; }

    }
}
