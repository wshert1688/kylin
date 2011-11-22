using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using Dapper;
using Dapper.Contrib.Extensions;

namespace kylin.DB {
    public class DBProvider {
        private static MySqlConnection conn;
        static readonly DBProvider instance = new DBProvider();
        static DBProvider() {
            if (conn == null) {
                var strConn = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                conn = new MySqlConnection(strConn);
                conn.Open();
            }
        }

        public static DataResult<IList<Article>> GetArticle(int catID, int pageIndex, int pageSize) {
            var sql = string.Format("SELECT COUNT(1)  FROM ARTICLE WHERE CATID={0}", catID);


            var totalCount = conn.Query<Int64>(sql).First();
            sql = string.Format("SELECT aid,title,hits,keywords,created,catID FROM article where catID = {0} LIMIT {1}, {2};"
                , catID, (pageIndex - 1) * pageSize, pageSize);

            var data = conn.Query<Article>(sql);
            var totalPage = Math.Ceiling((double)((totalCount + 0.0) / ((double)pageSize)));
            return new DataResult<IList<Article>> {
                pageIndex = pageIndex,
                pageSize = pageSize,
                totalCount = totalCount,
                totalPage = totalPage,
                data = data.ToList()
            };
        }

        public static Article GetArticle(int aid) {
            return conn.Get<Article>(aid);
        }

    }
}