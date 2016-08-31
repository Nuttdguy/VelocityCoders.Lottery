using System;
using VelocityCoders.LotteryPractice.Models;
using System.Data;
using System.Data.SqlClient;


namespace VelocityCoders.LotteryPractice.DAL
{
    public class GameResultAddDAL
    {
        
        #region INSERT & UPDATE LOTTERY GAME
        public static bool SaveGameResult(GameResult AddGameResult)
        {
            QueryExecuteType queryId = QueryExecuteType.InsertItem;
            bool result;

            if (AddGameResult.LotteryId > 0)
                queryId = QueryExecuteType.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@LotteryName", AddGameResult.LotteryName);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                }
                    myConnection.Close();

            }
            return result = true;
               
        }

        #endregion

    }
}

