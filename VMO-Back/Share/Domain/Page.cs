using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share.Domain
{
    [DataContract]
    public class Page
    {
        [DataMember(Order = 1)]
        public int Total { get; set; }
        [DataMember(Order = 2)]
        public int PageSize { get; set; }
        [DataMember(Order = 3)]
        public int PageIndex { get; set; }
        [DataMember(Order = 4)]
        public bool HidePagination { get => Total < PageSize && Total < 10; set { } }

        public void InitPageIndex()
        {
            if (PageIndex > 1)
            {
                int maxPage = Total / PageSize + (Total % PageSize == 0 ? 0 : 1);
                if (maxPage == 0)
                {
                    PageIndex = 1;
                }
                else if (PageIndex > maxPage)
                {
                    PageIndex = maxPage;
                }

            }
        }


    }
}
