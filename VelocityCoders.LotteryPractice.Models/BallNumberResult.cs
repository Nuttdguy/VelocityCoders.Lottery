using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryPractice.Models
{
    public class BallNumberResult
    {
        public string LotteryName { get; set; }
        public int LotteryDrawingId { get; set; }
        public int LotteryId { get; set; }
        public DateTime DrawDate { get { return this.DrawDate; } set { this.DrawDate.ToShortDateString();  } }
        public string BallNumber1 { set; get; }
        public string BallNumber2 { get; set; }
        public string BallNumber3 { get; set; }
        public string BallNumber4 { get; set; }
        public string BallNumber5 { get; set; }
        public string BallNumber6 { get; set; }
        public string BallNumber7 { get; set; }

    }
}
