using System;
using System.Collections.Generic;

namespace PFE.Models.SyncApiModels
{
    public class MetricPdfFeatureModel
    {
        public string PdfId { get; set; }

        public IList<MetricFeatureModel> Features { get; set; }
    }
}