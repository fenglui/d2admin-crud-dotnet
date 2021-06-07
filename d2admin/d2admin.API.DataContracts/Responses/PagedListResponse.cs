using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2admin.API.DataContracts.Responses
{
    /// <summary>
    /// 排序选项
    /// </summary>
    public class SortOption
    {
        /// <summary>
        /// 是否正向排序
        /// </summary>
        public bool Asc { get; set; }

        /// <summary>
        /// 列名称
        /// </summary>
        public string Column { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedListDataItem<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// 排序选项
        /// </summary>
        public List<SortOption> Orders { get; set; }

        /// <summary>
        /// 共有多少页面
        /// </summary>
        public int Pages { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
        public IList<T> Records { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool SearchCount { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 共有记录数
        /// </summary>
        public int Total { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedListResponse<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PagedListDataItem<T> Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Query { get; set; }
    }
}
