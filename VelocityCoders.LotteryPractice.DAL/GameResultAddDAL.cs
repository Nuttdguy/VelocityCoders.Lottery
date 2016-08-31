using System;
using VelocityCoders.LotteryPractice.Models;
using System.Data;
using System.Data.SqlClient;


namespace VelocityCoders.LotteryPractice.DAL
{
    public class GameResultAddDAL
    {
        
        #region INSERT & UPDATE LOTTERY GAME
        public static int SaveGameResult(GameResultCollection CollectFormResult, int totalGameBalls, int gameId)
        {
            #region ORDER OF UPDATE FOR SAVING GAME RESULTS
            //== ORDER OF INSERT OR UPDATE GAME RESULT
            //== [ANY]. LOTTERYID | LOTTERY TABLE > GAME ALREADY EXIST
            //== [1]. LOTTERYDRAWINGID | LOTTERYDRAWING TABLE > INSERT JACKPOT & DRAWDATE
            //== [2]. LOTTERYDRAWINGID, BALLTYPEID, BALLNUMBER | WINNING NUMBER TABLE
            //== [ANY]. BALLTYPEID | BALLTYPE TABLE > BALLTYPE ALREADY EXISTS
            #endregion

            int insertCount = 0;
            int result = 0;

            QueryExecuteType queryId = QueryExecuteType.InsertItem;
            if (CollectFormResult[insertCount].LotteryId > 0)
                queryId = QueryExecuteType.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (gameId > 0)
                        myCommand.Parameters.AddWithValue("@LotteryId", gameId);
                    if (CollectFormResult[insertCount].Jackpot != null)
                        myCommand.Parameters.AddWithValue("@Jackpot", CollectFormResult[insertCount].Jackpot);
                    if (CollectFormResult[insertCount].DrawDate != null)
                        myCommand.Parameters.AddWithValue("@DrawDate", CollectFormResult[insertCount].DrawDate);
                    //== RETURNS THE INT RESULT OF THE RECORD AFFECTED I.E. SINGLE VALUE PRIMARY KEY IN THIS CASE
                    myCommand.Parameters.Add(SqlHelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery(); //==  EXECUTES AND SUCCESSFULLY INSERTS  ==\\

                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
            }

            return result;
               
        }

        #endregion

    }
}

