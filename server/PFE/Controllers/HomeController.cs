using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC5App.Models;
using PFE.Models;
using PFE.Models.DashboardViewModels;

namespace PFE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rfm = _context.SummaryAcquisitions
                        .Include(x =>x.RFD)
                        .ThenInclude(x=>x.Feature)
                        .Include(x => x.User)
                        .OrderByDescending(x => x.Recency)
                        .ThenByDescending(x => x.Frequency)
                        .ThenByDescending(x => x.MoneteryValue)
                        .ToList();

            DashboardViewModel dashboardViewModel = new DashboardViewModel
            {
                RFM = rfm,
                CountUser = _context.ApplicationUser.Count(),
                CountFeature = _context.Feature.Count(),
                CountPDF = _context.PdfAcquisition.Select(x => x.PdfId).Distinct().Count(),
                TotalUserSpend = _context.SummaryAcquisitions.Sum(x => x.MoneterySpend).ToString("C2"),
                LargestUserSpend = _context.SummaryAcquisitions.Max(x => x.MoneterySpend).ToString("C2"),
                LatestPurchaseDate = _context.SummaryAcquisitions.Max(x => x.LastPurchaseDate).ToString("D")
            };
            return View(dashboardViewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
