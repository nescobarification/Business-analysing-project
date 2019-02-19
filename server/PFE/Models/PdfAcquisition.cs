using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE.Models
{
    [Table("PdfAcquisition")]
    public class PdfAcquisition
    {
        [Key]
        [Display(Name = "Pdf Acquisition ID")]
        public int Id { get; set; }

        [Display(Name = "Pdf ID")]
        public int PdfId { get; set; }

        [Display(Name = "User ID")]
        public string UserId { get; set; }

        [Display(Name = "Acquisition Date")]
        public DateTime AcquisitionDate { get; set; }

        public double Price { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
