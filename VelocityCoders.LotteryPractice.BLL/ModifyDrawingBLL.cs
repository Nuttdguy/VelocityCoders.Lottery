using System;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.DAL;


namespace VelocityCoders.LotteryPractice.BLL
{
    public static class ModifyDrawingBLL
    {

        public static string updateDrawing(int drawId, int lotteryId, int ballCount)
        {
            return ModifyDrawingDAL.Update(drawId, lotteryId, ballCount);
        }


        //== DELETE RECORD 
        public static int DeleteDrawing(int drawId)
        {
            return ModifyDrawingDAL.Delete(drawId);
        }

    }
}
