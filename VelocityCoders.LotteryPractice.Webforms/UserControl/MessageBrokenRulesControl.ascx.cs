using System;
using VelocityCoders.LotteryPractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryPractice.Webforms.UserControl
{
    public partial class MessageBrokenRulesControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Message { get; set; }

        public BrokenRuleCollection BrokenRules { get; set; }

        public void Display()
        {
            BindMessageArea();
        }

        private void BindMessageArea()
        {
            if (!string.IsNullOrEmpty(Message))
                lblPageMessage.Text = Message;

            if (BrokenRules != null && BrokenRules.Count > 0)
            {
                MessageList.DataSource = BrokenRules;
                MessageList.DataBind();
            }
        }
    }
}