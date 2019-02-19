using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PFE.Models.DashboardViewModels
{
    public class SummaryAcquisitionsGroupBy_pdfid_Count
    {
        [Display(Name = "PDF ID")]
        public int pdfId { get; set; }
        
        [Display(Name = "Unité(s) Vendue(s)")]
        public float pdfSold { get; set; }
    }
}
