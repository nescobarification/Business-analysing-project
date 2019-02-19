using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Models.DashboardViewModels
{
    public class DashboardViewModel
    {
        public IList<SummaryAcquisition> RFM { get; set; }
        public int CountUser { get; set; }
        public int CountFeature { get; set; }
        public int CountPDF { get; set; }
        public string TotalUserSpend { get; set; }
        public string LargestUserSpend { get; set; }
        public string LatestPurchaseDate { get; set; }
    }
}
