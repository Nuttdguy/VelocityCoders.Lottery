using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.LotteryPractice.Models;

namespace VelocityCoders.LotteryPractice.DAL
{
    public static class GameResultGetDAL
    {
        //==  GET GAME COLLECTION BY DRAWID

        public static GameResultCollection GetGameResultCollection(int drawId)
        {
            //=== [1]. WINNING NUMBER ID
            //=== [2]. BALL NUMBER
            GameResultCollection tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", (int)QuerySelectType.GetGameResultCollectionByDrawId);
                    myCommand.Parameters.AddWithValue("@LotteryDrawingId", drawId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.HasRows)
                        {
                            tmpList = new GameResultCollection();
                            while (myReader.Read())
                            {
                                tmpList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tmpList;
        }
        

        //==  GET GAME COLLECTION
        public static GameResultCollection GetGameResultCollection()
        {
            GameResultCollection tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLottery", myConnection))
                {

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", (int)QuerySelectType.GetCollection);

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
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("WinningNumberId")))
                myObject.WinningNumberId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("WinningNumberId"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("BallTypeDescription")))
                myObject.BallTypeDescription = myDataRecord.GetString(myDataRecord.GetOrdinal("BallTypeDescription"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Jackpot")))
                myObject.Jackpot = myDataRecord.GetString(myDataRecord.GetOrdinal("Jackpot"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IsRegularBall")))
                myObject.IsRegularBall = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("IsRegularBall"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HasSpecialBall")))
                myObject.HasSpecialBall = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("HasSpecialBall"));

            if (myObject.LotteryId == (int)GameNameEnum.Powerball)
                myObject.ImageUrl = Images._Powerball;
            if (myObject.LotteryId == (int)GameNameEnum.Megaball)
                myObject.ImageUrl = Images._MegaMillions;
            if (myObject.LotteryId == (int)GameNameEnum.Gopher5)
                myObject.ImageUrl = Images._Gopher5;
            if (myObject.LotteryId == (int)GameNameEnum.NorthstarCash)
                myObject.ImageUrl = Images._NorthstarCash;

            return myObject;
        }


    }
}
