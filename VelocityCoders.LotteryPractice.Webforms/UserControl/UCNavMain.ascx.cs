using System;
using VelocityCoders.LotteryPractice.Models;
using System.Web.UI.WebControls;



namespace VelocityCoders.LotteryPractice.Webforms.UserControl
{
    public partial class UCNavMain : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindPageLink();

        }

        protected void BindPageLink()
        {
            ListItemCollection linkCollection = new ListItemCollection();
            Array linkArray = Enum.GetValues(typeof(PageLinks));


            foreach (PageLinks page in linkArray )
            {

                linkCollection.Add(new ListItem
                {
                    Text = page.ToString(),
                    Value = ("~/Admin/"+ page+".aspx").ToString(),
                    Enabled = true
                });
            }


            SiteNavigationMain.DataSource = linkCollection;
            SiteNavigationMain.DataBind();

        }


    }
}