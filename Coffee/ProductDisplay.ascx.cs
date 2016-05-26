using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coffee
{
    public partial class ProductDisplay : System.Web.UI.UserControl
    {
        string _imgUrl;
        string _labelContent;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.ImageButton1.ImageUrl = _imgUrl;
                this.Label1.Text = _labelContent;
            }
        }

        public string ImgUrl
        {
            get { return _imgUrl; }
            set { _imgUrl = value; }
        }

        public string LabelContent
        {
            get { return _labelContent; }
            set { _labelContent = value; }
        }

    }
}