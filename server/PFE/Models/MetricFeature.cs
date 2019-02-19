using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE.Models
{
    [Table("MetricFeature")]
    public class MetricFeature
    {
        [Key]
        public int MetricFeatureId { get; set; }

        public int PdfId { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public ApplicationUser User { get; set; }
        
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
