using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJob.Controllers
{
    [Serializable]
    public class QPagedList<T>
    {
        public int totalCount { get; set; }
        public IEnumerable<T> data { get; set; }
        public int page { get; set; }
        public int perpage { get; set; }
        public int totalPages
        {
            get
            {
                int pagesCount = totalCount / perpage;
                if (perpage < ((float)totalCount / (float)perpage)) pagesCount++;
                return pagesCount;
            }
        }
    }
}
