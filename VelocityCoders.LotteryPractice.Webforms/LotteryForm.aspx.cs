using System;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryPractice.Webforms
{
    public partial class LotteryForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string game = drpGameName.SelectedValue.ToLower();
            LotteryWinningNumber myResult = new LotteryWinningNumber();

            myResult = LotteryWinningNumberDAL.GetLotteryGameByNameResults(game);



            
            rptRepeater.DataSource = myResult;
            rptRepeater.DataBind();

        }
    }
}