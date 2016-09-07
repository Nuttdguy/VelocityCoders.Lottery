using System;
using System.Data.SqlClient;
using System.Data;
using VelocityCoders.LotteryPractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryPractice.DAL
{
    public static class ModifyDrawingDAL
    {

        //== Update 
        public static string Update(int drawId, int lotteryId, int ballCount)
        {

            string result = "";

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.Add(SqlHelperDAL.GetReturnParameterInt("ReturnValue"));

                }
            }

            return result + "Still working on how to";
        }


        //== DELETE LOTTERY DRAWING RECORD BY ID
        public static int Delete(int drawId, GameResultCollection numberCollection)
        {
            int affectedRecord = 0;
            int deleteCount = numberCollection.Count;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                //== [1]. LOOP SUCCESSFUL FOR DELETING ALL RECORDS OF DRAWING
                for (int i = 0; i < deleteCount; i++)
                {
                    int winNumId = numberCollection[i].WinningNumberId;
                    using (SqlCommand myCommand_1 = new SqlCommand("usp_ExecuteWinningNumber", myConnection))
                    {
                        myCommand_1.CommandType = CommandType.StoredProcedure;
                        myCommand_1.Parameters.AddWithValue("@QueryId", (int)QueryExecuteType.DeleteItem);
                        myCommand_1.Parameters.AddWithValue("@LotteryDrawingId", drawId);
                        myCommand_1.Parameters.AddWithValue("@WinningNumberId", winNumId);
                        myConnection.Open();
                        myCommand_1.ExecuteNonQuery();

                    }
                    myConnection.Close();
                }

                //== [2]. REMOVE DRAWING ID 
                using (SqlCommand myCommand_2 = new SqlCommand("usp_ExecuteLotteryDrawing", myConnection))
                {
                    myCommand_2.CommandType = CommandType.StoredProcedure;
                    myCommand_2.Parameters.AddWithValue("@QueryId", (int)QueryExecuteType.DeleteItem);
                    myCommand_2.Parameters.AddWithValue("@LotteryDrawingId", drawId);
                    myCommand_2.Parameters.Add(SqlHelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand_2.ExecuteNonQuery();
                    affectedRecord = (int)myCommand_2.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }

            return affectedRecord;
        }



    }
}
