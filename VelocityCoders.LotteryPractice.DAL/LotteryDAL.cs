using System;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.LotteryPractice.Models;

namespace VelocityCoders.LotteryPractice.DAL
{
    public class LotteryDAL
    {
        #region GET LOTTERY ITEM
        public static Lottery GetItem(int lotteryId)
        {
            Lottery tmpItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetItem);
                    myCommand.Parameters.AddWithValue("@LotteryId", lotteryId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        tmpItem = new Lottery();
                        if (myReader.Read())
                        {
                            tmpItem = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                }
            }
            return tmpItem;
        }

        #endregion

        #region GET LOTTERY COLLECTION

        //== [2]. GET COLLECTION OF LOTTERY ITEMS
        public static LotteryCollection GetCollection()
        {
            LotteryCollection tempList = null;
            

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetLotteryNameCollection);
                    //myCommand.Parameters.AddWithValue("@LotteryId", recordIndexStart);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new LotteryCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }

                        }
                        myReader.Close();
                    }
                }
            }
            //== [3]. RETURN COLLECTION TO UI LAYER
            return tempList;
        }

        #endregion

        #region
        public static Lottery FillDataRecord(IDataRecord myDataRecord)
        {
            Lottery myObject = new Lottery();
            myObject.LotteryId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryName")))
                myObject.LotteryName = myDataRecord.GetString(myDataRecord.GetOrdinal("LotteryName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HasSpecialBall")))
                myObject.HasSpecialBall = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("HasSpecialBall"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IsRegularBall")))
                myObject.IsRegularBall = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("IsRegularBall"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NumberOfBalls")))
                myObject.NumberOfBalls = myDataRecord.GetInt32(myDataRecord.GetOrdinal("NumberOfBalls"));


            return myObject;
        }
        #endregion

    }
}
