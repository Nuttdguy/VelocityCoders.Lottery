using System;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.LotteryPractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryPractice.DAL
{
    public class WinningNumberHelperDAL
    {

        public static GameResultCollection WinningNumberId(int drawId)
        {
            GameResultCollection tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", (int)QuerySelectType.GetGameResultCollectionByDrawId);
                    myCommand.Parameters.AddWithValue("@LotteryDrawingId", drawId);

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
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tmpList;
        } 

        public static GameResult FillDataRecord(IDataRecord myDataRecord)
        {
            GameResult myObject = new GameResult();
            myObject.WinningNumberId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("WinningNumberId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryDrawingId")))
                myObject.LotteryDrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryDrawingId"));

            return myObject;
        }


    }
}
