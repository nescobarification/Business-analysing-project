using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE.Models
{
    [Table("Feature")]
    public class Feature
    {
        [Key]
        [Display(Name = "Feature ID")]
        public int FeatureId { get; set; }

        [Display(Name = "Feature Name")]
        public string Name { get; set; }
    }
}
