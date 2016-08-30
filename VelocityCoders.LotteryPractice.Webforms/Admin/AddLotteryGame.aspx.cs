using System;
using System.Text;
using VelocityCoders.LotteryPractice.Models;
using VelocityCoders.LotteryPractice.Webforms.UserControl;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryPractice.Webforms.Admin
{
    public partial class AddLotteryGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageTitleCaption.Text = _PageTitle;
        }

        //========   PAGE PROPERTIES   ============\\

        private const string _PageTitle = "Add Game";

        //========   CLICK-BUTTON EVENT HANDLER    ===========\\

        protected void AddLotteryGame_Click(object sender, EventArgs e)
        {

            StringBuilder tmpFormValues = new StringBuilder();

            tmpFormValues.Append(txtGameName.Text);
            tmpFormValues.Append("<br/>");
            tmpFormValues.Append(txtGameAbbr.Text);
            tmpFormValues.Append("<br/>");
            tmpFormValues.Append(txtHowToPlay.Text);
            tmpFormValues.Append("<br/>");
            tmpFormValues.Append(txtDescription.Text);

            lblMessage.Text = tmpFormValues.ToString();
        }


    }
}