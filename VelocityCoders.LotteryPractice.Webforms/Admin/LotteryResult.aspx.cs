using System;
using VelocityCoders.LotteryPractice.Models;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryPractice.Webforms.Admin
{
    public partial class LotteryResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region CLICK EVENT HANDLER FOR GETLOTTERYRESULTS BUTTON
        protected void getLotteryResults(object sender, EventArgs e)
        {
            var selectedLotteryGame = selectLotteryGameDropDown.SelectedValue;
            var selectedDrawingDate = selectDrawingDateDropDown.SelectedValue;

            if (!selectedLotteryGame.Contains("null") && !selectedDrawingDate.Contains("null"))
            {
                lblDrawingDateResult.Text = selectedDrawingDate;
                switch (selectedLotteryGame.ToLower())
                {
                    case "powerball":
                        lblLotteryGameAbbreviation.Text = "PB";
                        lblSelectedLotteryGameResult.Text = GameName._Powerball;
                        lotteryGameImage.ImageUrl = "~/App_Themes/Main/images/powerballLogo.png";
                        break;
                    case "megaball":
                        lblLotteryGameAbbreviation.Text = "MB";
                        lblSelectedLotteryGameResult.Text = GameName._Megaball;
                        lotteryGameImage.ImageUrl = "~/App_Themes/Main/images/megaMillionsLogo.png";
                        break;
                    case "gopher5":
                        lblLotteryGameAbbreviation.Text = "G5";
                        lblSelectedLotteryGameResult.Text = GameName._Gopher5;
                        lotteryGameImage.ImageUrl = "~/App_Themes/Main/images/gopher5Logo.png";
                        break;
                    case "northstarcash":
                        lblLotteryGameAbbreviation.Text = "NC";
                        lblSelectedLotteryGameResult.Text = GameName._NorthstarCash;
                        lotteryGameImage.ImageUrl = "~/App_Themes/Main/images/northstarLogo.png";
                        break;
                    default:
                        lblLotteryGameAbbreviation.Text = "Lottery Game Not Available";
                        break;
                }

            }
        }

        #endregion

    }
}