using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomWebApi.Tool
{
    /// <summary>
    /// cusotm查询类
    /// </summary>
    public class CustomQuery:PageTool
    {
        public int CustomQueryId { get; set; }

        public string CustomQueryName { get; set; }

        public string CustomQueryAge { get; set; }

        public string CustomQuerySex { get; set; }

        public string CustomQueryIdCrad { get; set; }

        public string CustomQueryPhone { get; set; }


    }
}
