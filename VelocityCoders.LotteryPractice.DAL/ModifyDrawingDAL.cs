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


        //== DELETE
        public static int Delete(int drawId)
        {

            int affectedRecord = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("QueryId", QueryExecuteType.DeleteItem);
                    myCommand.Parameters.AddWithValue("LotteryDrawingId", drawId);
                    myCommand.Parameters.Add(SqlHelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    affectedRecord = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }

            return affectedRecord;
        }

    }
}
