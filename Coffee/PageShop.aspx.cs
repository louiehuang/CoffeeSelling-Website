using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coffee
{
    public partial class PageShop : System.Web.UI.Page
    {
        //这里必须用static，否则点击按钮后刷新页面会把改变过的type值重新置为0
        static int type = 0;  //类别，如拿铁
        static string keyword = string.Empty; //选择属性（Calories等）
        static string sortStyle = "DESC"; //排序方式


        SqlHelper sqlHelper = new SqlHelper();
        BLL_Products bll_product = new BLL_Products();


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "商品页";

            if (!IsPostBack) //首次
            {
                RegisterImageButtonImage();
                UI_FilteredProducts(type);
            }
        }

        /// <summary>
        /// 注册鼠标经过图片按钮时的切换状态
        /// </summary>
        private void RegisterImageButtonImage()
        {
            ibtn_all.Attributes.Add("onmouseover", "this.src='Images/All_hover.jpg'");
            ibtn_all.Attributes.Add("onmouseout", "this.src='/Images/All.jpg'");
            ibtn_espressos.Attributes.Add("onmouseover", "this.src='Images/Espressos_hover.jpg'");
            ibtn_espressos.Attributes.Add("onmouseout", "this.src='Images/Espressos.jpg'");
            ibtn_lattes.Attributes.Add("onmouseover", "this.src='Images/Lattes_hover.jpg'");
            ibtn_lattes.Attributes.Add("onmouseout", "this.src='Images/Lattes.jpg'");
            ibtn_tealattes.Attributes.Add("onmouseover", "this.src='Images/TeaLattes_hover.jpg'");
            ibtn_tealattes.Attributes.Add("onmouseout", "this.src='Images/TeaLattes.jpg'");
            ibtn_hotchocolates.Attributes.Add("onmouseover", "this.src='Images/HotChocolates_hover.jpg'");
            ibtn_hotchocolates.Attributes.Add("onmouseout", "this.src='Images/HotChocolates.jpg'");
            ibtn_blended.Attributes.Add("onmouseover", "this.src='Images/Blended_hover.jpg'");
            ibtn_blended.Attributes.Add("onmouseout", "this.src='Images/Blended.jpg'");
        }

        //选择符合条件（类别）的商品并显示
        private void UI_FilteredProducts(int type)
        {
            //在业务逻辑层处理type为0的情况，即type为0时选择所有商品，否则按照type过滤
            DataTable dt = new DataTable();
            dt = bll_product.BLL_FilteredProducts(type);
            DataList_Products.DataSource = dt;
            DataList_Products.DataBind();
        }

        //选择符合条件（类别与属性）的商品并显示
        private void UI_FilterAndSortProducts(string keyword, int type, string sortStyle = "DESC")
        {
            //在业务逻辑层处理type为0的情况，即type为0时选择所有商品，否则按照type过滤
            DataList_Products.DataSource = bll_product.BLL_FilterAndSortProducts(keyword, type, sortStyle);
            DataList_Products.DataBind();
        }

        //选择menu中的按钮点击事件，更新按钮对应的type
        protected void ibtn_filter_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = sender as ImageButton;
            switch (ibtn.ID)
            {
                case "ibtn_all": type = 0; break;
                case "ibtn_espressos": type = 2;  break;
                case "ibtn_lattes": type = 4; break;
                case "ibtn_tealattes": type = 6; break;
                case "ibtn_hotchocolates": type = 7; break;
                case "ibtn_blended": type = 8; break;
                default: type = 0; break;
            }

            UI_FilteredProducts(type); //按类别更新商品显示
        }

        //下拉框内容改变事件，更新下拉框中被选中的keyword，默认按降序显示商品
        protected void dl_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = dl_select.SelectedValue;
            switch (value)
            {
                case "Calories": keyword = "D_Calories"; break;
                case "Fat": keyword = "D_Fat"; break;
                case "Saturated Fat": keyword = "D_SaturatedFat"; break;
                case "Trans Fat": keyword = "D_TransFat"; break;
            }

            UI_FilterAndSortProducts(keyword, type, sortStyle); //按类别和属性排序更新商品显示

        }

        //排序选择按钮，点击后更新排序方式sortStyle并更新界面的商品显示
        protected void ibtn_sort_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = sender as ImageButton;
            if(ibtn.ID == "ibtn_sort_desc")
            {
                sortStyle = "DESC";
            }
            else if (ibtn.ID == "ibtn_sort_asc")
            {
                sortStyle = "ASC";
            }

            UI_FilterAndSortProducts(keyword, type, sortStyle);  //按类别和属性排序更新商品显示
        }


    }
}