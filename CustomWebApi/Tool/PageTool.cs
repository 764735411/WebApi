using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomWebApi.Tool
{
    public class PageTool
    {
        private const long _maxPageSize = 20;
        public long PageNumber { get; set; } = 1;

        private long _pageSize = 2;

        public long PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }
    }
}
