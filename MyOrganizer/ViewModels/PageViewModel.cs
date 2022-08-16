using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrganizer.ViewModels
{
    public class PageViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public string UserName { get; set; }
        public PageViewModel(int count, int pageNumber, int pageSize, string userName)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling((double)count / pageSize);
            UserName = userName;
        }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;
    }
}
