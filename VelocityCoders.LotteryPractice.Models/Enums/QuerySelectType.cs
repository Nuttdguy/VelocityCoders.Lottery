

namespace VelocityCoders.LotteryPractice.Models
{
    public enum QuerySelectType
    {
        None = 0,
        GetItem = 10,
        GetDrawingByLotteryName = 14,
        GetCollection = 20,
        GetGameResultCollectionByDrawId = 22,
        GetNext10 = 30
    }
}
