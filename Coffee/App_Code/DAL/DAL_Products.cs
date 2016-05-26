using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Coffee
{
    public class DAL_Products
    {
        SqlHelper sqlHelper = new SqlHelper();

        /// <summary>
        /// 检索出全部商品，返回DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable DAL_SelectAllProducts()
        {
            string strsql = "select * from CoffeeProduct";
            DataTable dt = new DataTable();
            dt = sqlHelper.ReadTable(strsql);
            return dt;
        }

        /// <summary>
        /// 按类型条件检索出商品，返回DataTable
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public DataTable DAL_FilteredProducts(int type)
        {
            string strsql = "select * from CoffeeProduct where C_type=" + type.ToString();
            DataTable dt = new DataTable();
            dt = sqlHelper.ReadTable(strsql);
            return dt;
        }


        /// <summary>
        /// 选择所有商品并按属性排序，默认为降序排列，如按D_Calories降序排列
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="type"></param>
        /// <param name="sortStyle"></param>
        /// <returns></returns>
        public DataTable DAL_SelectAllAndSortProducts(string keyword, string sortStyle = "DESC")
        {
            string strsql = "select * from CoffeeProduct,CoffeeDetails "
                                   + "where CoffeeProduct.C_id=CoffeeDetails.C_id "
                                   + "order by " + keyword + " " + sortStyle;
            DataTable dt = new DataTable();
            dt = sqlHelper.ReadTable(strsql);
            return dt;
        }


        /// <summary>
        /// 按类型查询并再按属性排序，默认为降序排列，如查询Lattes类按D_Calories降序排列
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="type"></param>
        /// <param name="sortStyle"></param>
        /// <returns></returns>
        public DataTable DAL_FilterAndSortProducts(string keyword, int type, string sortStyle = "DESC")
        {
            string strsql = "select * from CoffeeProduct,CoffeeDetails "
                                   + "where CoffeeProduct.C_id=CoffeeDetails.C_id " + "and C_type=" + type.ToString()
                                   + "order by " + keyword + " " + sortStyle;
            DataTable dt = new DataTable();
            dt = sqlHelper.ReadTable(strsql);
            return dt;
        }


    }
}