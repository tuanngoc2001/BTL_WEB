using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Common.Utils
{
    public class PagedList<T>:List<T>
    {
        //trang hiện tại
        public int CurrentPage { get; set; }
        //tổng số trang
        public int TotalPage { get; set; }
        //số trang cần lấy
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public PagedList(List<T>item,int count,int pageNumber,int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPage = (int)Math.Ceiling(count * (double)pageSize);
            AddRange(item);
            //thêm vào cuối danh sách
        }
        public static PagedList<T> ToPagedList(IQueryable<T> soure, int pageNumber, int pageSize)
        {
            var count = soure.Count();
            var item = soure.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return new PagedList<T>(item, count, pageNumber, pageSize);
        }
    }
}
