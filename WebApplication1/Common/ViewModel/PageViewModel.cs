using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PageViewModel
    {
        public int Page { get; init; }

        public int PageSize { get; init; }

        public int TotalPages { get; init; }
    }
}
