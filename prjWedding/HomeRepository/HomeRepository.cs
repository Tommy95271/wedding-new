//using Dapper;
using prjWedding.Models;
//using prjWedding.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HolyGo.Repository
{
    public class HomeRepository
    {
        //#region 建構式
        //public static string connString;
        //public SqlConnection conn;
        //public HomeRepository()
        //{
        //    if (string.IsNullOrEmpty(connString))
        //    {
        //        connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    }
        //    if (conn == null)
        //    {
        //        conn = new SqlConnection(connString);
        //    }
        //}
        //#endregion

        //#region 方法
        ///// <summary>
        ///// 搜尋前8筆旅遊
        ///// </summary>
        ///// <returns>前8筆旅遊</returns>
        ///// 
        //public List<TopTravelViewModel> topTravel()
        //{
        //    List<TopTravelViewModel> getTopTravel;
        //    using (conn = new SqlConnection(connString))
        //    {
        //        string sql = @"SELECT top(8) t.Title,t.Country,t.City,t.Time,t.Images,min(v.Cost) as Cost
        //                        FROM Travel t
        //                        LEFT JOIN Travel_Combo v ON t.Guid = v.Travel_guid
        //                        group by t.Title , t.Country,t.City,t.Time,t.Images
        //                        order by t.Title desc,Cost desc";
        //        getTopTravel = conn.Query<TopTravelViewModel>(sql).ToList();
        //    }
        //    return getTopTravel;
        //}
        ///// <summary>
        ///// 搜尋前8筆旅遊
        ///// </summary>
        ///// <returns>前8筆旅遊</returns>
        //public List<TopTicketViewModel> topTicket()
        //{
        //    List<TopTicketViewModel> getTopTicket;
        //    using (conn = new SqlConnection(connString))
        //    {
        //        string sql = @"SELECT top(8) t.Title,t.Country,t.City,t.Time,t.Images,min(v.Cost) as Cost
        //                        FROM Ticket t
        //                        LEFT JOIN Ticket_Combo v ON t.Guid = v.Ticket_guid
        //                        group by t.Title,t.Country,t.City,t.Time,t.Images
        //                        order by t.Title desc,Cost desc";
        //        getTopTicket = conn.Query<TopTicketViewModel>(sql).ToList();
        //    }
        //    return getTopTicket;
        //}
        //#endregion
    }
}