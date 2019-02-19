using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Models
{
    [Table("SummaryFeature")]
    public class SummaryFeature
    {
        [Key]
        public int SummaryFeatureId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int FeatureId { get; set; }
        public Feature Feature { get; set; }

        [Display(Name = "Sum of feature seen")]
        public int SumOfFeatureSeen { get; set; }

        [Display(Name = "Last feature seen date")]
        public DateTime LastFeatureSeenDate { get; set; }

        [Display(Name = "Average duration")]
        public float AverageDuration { get; set; }

        public int Recency { get; set; }

        public int Frequency { get; set; }

        public int Duration { get; set; }

        
    }
}
