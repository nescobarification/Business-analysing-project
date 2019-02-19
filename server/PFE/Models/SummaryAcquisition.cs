using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE.Models
{
    [Table("SummaryAcquisition")]
    public class SummaryAcquisition
    {


        [Key]
        public int SummaryAcquisitionId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Frequency Purchase")]
        public float FrequencyPurchase { get; set; }

        [Display(Name = "First Purchase Date")]
        public DateTime FirstPurchaseDate { get; set; }

        [Display(Name = "Last Purchase Date")]
        public DateTime LastPurchaseDate { get; set; }

        [Display(Name = "Sum Aquisition")]
        public int SumAquisition { get; set; }

        [Display(Name = "Monetery Spend")]
        public float MoneterySpend { get; set; }

        public int Recency { get; set; }

        public int Frequency { get; set; }

        [Display(Name = "Monetery Value")]
        public int MoneteryValue { get; set; }

        public IList<SummaryFeature> RFD { get; set; }

    }
}
