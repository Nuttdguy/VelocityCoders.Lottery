using System;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryPractice.BLL
{
    public static class GameAddNewBLL
    {

        //==  [2]. SEND FORM RESULT TO DAL
        public static string GameToAdd(GameResult addGameFormData, int queryId)
        {
            string displayInsertedRecord = GameAddNewDAL.SaveNewGame(addGameFormData, queryId);

            return displayInsertedRecord;

        }

    }
}
