using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GetIntranet
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl tabContact = Master.FindControl("LiDefault") as HtmlGenericControl;
            tabContact.Attributes.Add("class", "active");
        }
    }
}