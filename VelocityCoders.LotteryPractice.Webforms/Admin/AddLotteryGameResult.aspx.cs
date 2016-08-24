using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryPractice.Webforms.Admin
{
    public partial class AddLotteryGameResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitResult(object sender, EventArgs e)
        {
            StringBuilder tmpFormValues = new StringBuilder();

            tmpFormValues.Append(drpListGameName.SelectedValue);
            tmpFormValues.Append("<br/>");
            tmpFormValues.Append(calDrawingDate.SelectedDate);
            tmpFormValues.Append("<br/>");
            tmpFormValues.Append(txtJackpotAmount.Text);
            tmpFormValues.Append("<br/>");
            tmpFormValues.Append(drpListMultiplier.SelectedValue);

            lblMessage.Text = tmpFormValues.ToString();
        }
    }
}