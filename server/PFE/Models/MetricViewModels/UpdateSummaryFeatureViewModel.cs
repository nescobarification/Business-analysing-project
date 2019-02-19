using System;
using System.Collections.Generic;

namespace PFE.Models.MetricViewModels
{
    public class UpdateSummaryFeatureViewModel
    {
        public IList<SummaryFeature> ListSummary { get; set; }

        public IList<MetricFeature> ListMetricFeature { get; set; }

        public object Chart1 { get; set; }
    }
}
