using System.Data;
using System.Data.SqlClient;

namespace VelocityCoders.LotteryPractice.DAL
{
    public static class SqlHelperDAL
    {
        public static SqlParameter GetReturnParameterInt(string returnParameterName)
        {
            SqlParameter returnParameter = new SqlParameter();
            returnParameter.ParameterName = "@" + returnParameterName;
            returnParameter.SqlDbType = SqlDbType.Int;
            returnParameter.Direction = ParameterDirection.Output;

            return returnParameter;
        }
    }
}
