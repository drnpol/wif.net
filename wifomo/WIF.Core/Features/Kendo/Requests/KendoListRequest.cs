using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WIF.PortfolioManager.Application.Features.Kendo.Requests
{
    /// <summary>
    /// It's used to filter and for server paging
    /// </summary>
    public class KendoListRequest
    {
        public KendoListPaging Paging { get; set; } = new KendoListPaging();
        public List<KendoListFilter> Filter { get; set; } = new List<KendoListFilter>();
    }
    /// <summary>
    /// It's used for sending a response back to the frontend
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KendoListResponse<T>
    {
        public List<T> Entries { get; set; }
        public long TotalEntries { get; set; }
    }
    public class KendoListFilter
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }
    }
    public class KendoListPaging
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    //public enum KendoListFilterType
    //{
    //    Name = 0,
    //    Creator = 1,
    //    QS = 2,
    //    Owner = 3,
    //}

    public class KendoListHelper<T>
    {
        public KendoListRequest GetKendoListRequest(string kendoListRequestString)
        {
            KendoListRequest kendoListRequest = JsonSerializer.Deserialize<KendoListRequest>(kendoListRequestString);
            return kendoListRequest;
        }

        public KendoListResponse<T> GetKendoListResponse(List<T> entries, long totalEntriesUnPaged)
        {
            var response = new KendoListResponse<T>
            {
                Entries = entries,
                TotalEntries = totalEntriesUnPaged,
            };
            return response;
        }
    }
}