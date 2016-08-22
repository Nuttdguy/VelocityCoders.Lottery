using System;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.LotteryPractice.Models;

namespace VelocityCoders.LotteryPractice.DAL
{
    public class LotteryDAL
    {

        #region GET LOTTERY COLLECTION
        public static LotteryCollection GetCollection()
        {
            LotteryCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollection);

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

            return myObject;
        }
        #endregion

    }
}
