using System;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.DAL;
using System.Text;

namespace VelocityCoders.LotteryPractice.Webforms
{
    public partial class LotteryPratice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindLotteryList();
        }

        private void BindLotteryList()
        {
            LotteryCollection lotteryList = new LotteryCollection();
            lotteryList = LotteryDAL.GetCollection();

            rptLotteryList.DataSource = lotteryList;
            rptLotteryList.DataBind();
        }


        #region //== VERIFY THAT COLLECTION IS WORKING AS EXPECTED THROUGH INHERITANCE
        private string GetLotteryCollection()
        {
            LotteryCollection LC = new LotteryCollection()
            {
                new Lottery { LotteryId = 1, LotteryName = "PowerBall" },
                new Lottery { LotteryId = 2, LotteryName = "MegaBall" },
                new Lottery { LotteryId = 3, LotteryName = "Gopher 5" },
                new Lottery { LotteryId = 4, LotteryName = "Northstar Cash" }
            };

            StringBuilder list = new StringBuilder();
           
            foreach(Lottery item in LC)
            {
                list.Append(item.LotteryId + " " + item.LotteryName + "<br/>");
            }

            return list.ToString();
        }
        #endregion
    }
}