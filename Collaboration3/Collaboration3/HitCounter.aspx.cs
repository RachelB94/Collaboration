using Collaboration3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collaboration3
{
    public partial class HitCounter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int currentNumberOfUsers = Collaboration3.MvcApplication.CurrentNumberOfUsers;
            int totalNumberOfUsers = Collaboration3.MvcApplication.TotalNumberOfUsers;
            lblCurrentNumberOfUsers.Text = currentNumberOfUsers.ToString();
            lblTotalNumberOfUsers.Text = totalNumberOfUsers.ToString();
        }
    }
}