using System;
using VelocityCoders.LotteryPractice.Models;
using System.Data;
using System.Data.SqlClient;


namespace VelocityCoders.LotteryPractice.DAL
{
    public class GameResultAddDAL
    {
        
        #region INSERT & UPDATE LOTTERY GAME
        public static string SaveGameResult(GameResultCollection CollectFormResult, int totalGameBalls, int gameId)
        {
            #region ORDER OF UPDATE FOR SAVING GAME RESULTS
            //== ORDER OF INSERT OR UPDATE GAME RESULT
            //== [ANY]. LOTTERYID | LOTTERY TABLE > GET LOTTERYID FROM ENUM > BLL LAYER ENUM
            //== [1]. LOTTERYDRAWINGID | LOTTERYDRAWING TABLE > INSERT JACKPOT & DRAWDATE
            //== [2]. LOTTERYDRAWINGID, BALLTYPEID, BALLNUMBER | WINNING NUMBER TABLE
            //== [ANY]. BALLTYPEID | BALLTYPE TABLE > BALLTYPE ALREADY EXISTS
            //== [3]. INSERT FIRST TABLE, RETURN ROW ID, 
            //== [4]. INSERT INTO SECOND TABLE, RETURN ROW ID
            //== [5]. INCREMENT INSERTCOUNT
            //== [6]. REPEAT [3] AND [4] AND [6] FOR EACH BALL
            #endregion

            int insertCount = 0;
            int result = 0;
            string rowsAffected = "";

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
                    rowsAffected += "|| Lottery Drawing " + result;
                }
                using (SqlCommand myCommand2 = new SqlCommand("usp_ExecuteWinningNumber", myConnection))
                {
                    myCommand2.CommandType = CommandType.StoredProcedure;
                    myCommand2.Parameters.AddWithValue("QueryId", queryId);

                    if (gameId > 0)
                        myCommand2.Parameters.AddWithValue("@LotteryDrawingId", result);
                    if (CollectFormResult[insertCount].BallTypeId != 0)
                        myCommand2.Parameters.AddWithValue("@BallTypeId", CollectFormResult[insertCount].BallTypeId);
                    if (CollectFormResult[insertCount].BallNumber != 0)
                        myCommand2.Parameters.AddWithValue("@BallNumber", CollectFormResult[insertCount].BallNumber);

                    myCommand2.Parameters.Add(SqlHelperDAL.GetReturnParameterInt("ReturnValue"));

                    myCommand2.ExecuteNonQuery();

                    result = (int)myCommand2.Parameters["@ReturnValue"].Value;
                    rowsAffected += " || Winning Number Row " + result;
                }
                myConnection.Close();
            }

            return rowsAffected;
               
        }

        #endregion

    }
}

