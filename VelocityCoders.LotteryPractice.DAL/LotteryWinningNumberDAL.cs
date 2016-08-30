using System;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.LotteryPractice.Models;

namespace VelocityCoders.LotteryPractice.DAL
{
    public class LotteryWinningNumberDAL
    {

        #region GET LOTTERY BY GAMENAME
        public static LotteryWinningNumber GetLotteryGameByNameResults(string lotteryName)
        {
            LotteryWinningNumber tmpItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetDrawingByLotteryName);
                    myCommand.Parameters.AddWithValue("@LotteryName", lotteryName);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpItem = new LotteryWinningNumber();
                            while (myReader.Read())
                            {
                                //tmpItem.Add( FillDataRecord(myReader));
                            }
                            myReader.Close();
                        }
                    }
                }
            }
            return tmpItem;
        }

        #endregion

        public static LotteryWinningNumber FillDataRecord(IDataRecord myDataRecord)
        {
            LotteryWinningNumber myObject = new LotteryWinningNumber();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryId")))
                myObject.LotteryId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryId"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryName")))
                myObject.LotteryName = myDataRecord.GetString(myDataRecord.GetOrdinal("LotteryName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingDate")))
                myObject.DrawDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DrawingDate"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("BallNumber")))
                myObject.BallNumber = myDataRecord.GetInt32(myDataRecord.GetOrdinal("BallNumber"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("BallTypeDescription")))
                myObject.BallTypeDescription = myDataRecord.GetString(myDataRecord.GetOrdinal("BallTypeDescription"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Jackpot")))
                myObject.Jackpot = myDataRecord.GetString(myDataRecord.GetOrdinal("Jackpot"));

            return myObject;
        }
    }
}
