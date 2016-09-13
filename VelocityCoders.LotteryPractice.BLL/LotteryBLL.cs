using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.LotteryPractice.DAL;
using VelocityCoders.LotteryPractice.Models;

namespace VelocityCoders.LotteryPractice.BLL
{
    public class LotteryBLL
    {
        public static Lottery GetItem(int lotteryId)
        {
            return LotteryDAL.GetItem(lotteryId);
        }

    }
}
