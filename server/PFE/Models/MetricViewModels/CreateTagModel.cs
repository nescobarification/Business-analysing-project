using System;
using System.ComponentModel.DataAnnotations;

namespace PFE.Models.MetricViewModels
{
    public class CreateTagModel
    {

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public int PdfId { get; set; }

        [Required]
        public string Tag { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
