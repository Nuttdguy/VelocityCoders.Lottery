using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryPractice.Models
{
    public class Lottery
    {
        public int LotteryId { get; set; }
        public string LotteryName { get; set; }
        public Boolean HasSpecialBall { get; set; }
        public Boolean IsRegularBall { get; set; }
    }
}
