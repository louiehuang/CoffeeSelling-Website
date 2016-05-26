using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Coffee
{
    public class BLL_Products
    {
        DAL_Products DAL_products = new DAL_Products();

        /// <summary>
        /// 按条件检索出商品，返回DataTable
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public DataTable BLL_FilteredProducts(int type)
        {
            if (type == 0) //返回全部商品
            {
                return DAL_products.DAL_SelectAllProducts();
            }
            else //返回选择类型商品
            {
                return DAL_products.DAL_FilteredProducts(type);
            }
        }

        /// <summary>
        /// 按类型查询并再按属性排序，默认为降序排列，如查询Lattes类按D_Calories降序排列
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="type"></param>
        /// <param name="sortStyle"></param>
        /// <returns></returns>
        public DataTable BLL_FilterAndSortProducts(string keyword, int type, string sortStyle = "DESC")
        {
            if (type == 0)
            {
                return DAL_products.DAL_SelectAllAndSortProducts(keyword, sortStyle);
            }
            else
            {
                return DAL_products.DAL_FilterAndSortProducts(keyword, type, sortStyle);
            }
        }


    }
}