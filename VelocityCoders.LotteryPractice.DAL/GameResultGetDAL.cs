using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.LotteryPractice.Models;

namespace VelocityCoders.LotteryPractice.DAL
{
    public static class GameResultGetDAL
    {

        public static GameResultCollection GetGameResultCollection()
        {
            GameResultCollection tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLottery", myConnection))
                {

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetGameResultCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpList = new GameResultCollection();
                            while (myReader.Read())
                            {
                                tmpList.Add(FillDataRecord(myReader));
                            }

                        }
                    }

                }
            }

            return tmpList;

        }


        public static GameResult FillDataRecord(IDataRecord myDataRecord)
        {
            GameResult myObject = new GameResult();


            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryId")))
                myObject.LotteryId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryId"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryDrawingId")))
                myObject.LotteryDrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryDrawingId"));
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
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IsRegularBall")))
                myObject.IsRegularBall = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("IsRegularBall"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HasSpecialBall")))
                myObject.HasSpecialBall = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("HasSpecialBall"));

            return myObject;
        }


    }
}
