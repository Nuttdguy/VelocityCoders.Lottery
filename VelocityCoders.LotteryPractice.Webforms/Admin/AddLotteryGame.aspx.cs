using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryPractice.Webforms.Admin
{
    public partial class AddLotteryGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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