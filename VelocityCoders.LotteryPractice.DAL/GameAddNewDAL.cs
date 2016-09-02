using VelocityCoders.LotteryPractice.Models;
using System.Data;
using System.Data.SqlClient;


namespace VelocityCoders.LotteryPractice.DAL
{
    public static class GameAddNewDAL
    {
        //== [3]. INSERT NEW GAME RECORD 
        public static string SaveNewGame(GameResult addGameFormData, int queryId)
        {
            int result;
            int result2;
            int result3;
            string rowsAffected;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLottery", myConnection))
                {

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@LotteryName", addGameFormData.LotteryName);
                    myCommand.Parameters.AddWithValue("@HasSpecialBall", addGameFormData.HasSpecialBall);
                    myCommand.Parameters.AddWithValue("@IsRegularBall", addGameFormData.IsRegularBall);
                    myCommand.Parameters.Add(SqlHelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                    rowsAffected = " || Lottery ID " + result + "<br/>";
                }
                using (SqlCommand myCommand2 = new SqlCommand("usp_ExecuteLotteryCost", myConnection))
                {
                    myCommand2.CommandType = CommandType.StoredProcedure;
                    myCommand2.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand2.Parameters.AddWithValue("@CostId", addGameFormData.CostToPlay);
                    myCommand2.Parameters.AddWithValue("@LotteryId", result);
                    myCommand2.Parameters.Add(SqlHelperDAL.GetReturnParameterInt("ReturnValue"));

                    myCommand2.ExecuteNonQuery();

                    result2 = (int)myCommand2.Parameters["@ReturnValue"].Value;
                    rowsAffected += " || Lottery Cost Record " + result2 + "<br/>";

                }
                using (SqlCommand myCommand3 = new SqlCommand("usp_ExecuteInstruction", myConnection))
                {
                    myCommand3.CommandType = CommandType.StoredProcedure;
                    myCommand3.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand3.Parameters.AddWithValue("@LotteryId", result);
                    myCommand3.Parameters.AddWithValue("@Description", addGameFormData.GameDescription);
                    myCommand3.Parameters.AddWithValue("@HowToPlay", addGameFormData.HowToPlay);
                    myCommand3.Parameters.Add(SqlHelperDAL.GetReturnParameterInt("ReturnValue"));

                    myCommand3.ExecuteNonQuery();
                    result3 = (int)myCommand3.Parameters["@ReturnValue"].Value;

                    rowsAffected += " || Instruction Record " + result3 + "<br/>";
                }
                myConnection.Close();
            }
            //== [4]. RETURN STRING TO UI
            return rowsAffected;
        }

    }
}
