using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class PageViewModel<T>
    {
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; } = 1;
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount { get; set; } = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount => (int)Math.Ceiling((decimal)TotalCount / PageSize);

        public List<T> PageData { get; set; } = new List<T> ();
    }
}
