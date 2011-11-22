using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper.Contrib.Extensions;
namespace kylin.DB
{
    public class DataResult<T>
    {
        public int pageIndex;
        public int pageSize;
        public long totalCount;
        public double totalPage;
        public T data;
    }
    [Table("Article")]
    public class Article
    {
        [Key]
        public int aid { set; get; }
        public string title { set; get; }
        public int? hits { set; get; }
        public string keywords { set; get; }
        public string content { set; get; }
        public MySql.Data.Types.MySqlDateTime created { set; get; }
        public int catID { set; get; }
        
    }


}