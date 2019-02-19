using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC5App.Models;
using PFE.Data;
using PFE.Process;
using PFE.Models;
using PFE.Models.MetricViewModels;


namespace PFE.Controllers
{
    public class MetricController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMetricProcess _metricHelper;

        public MetricController(ApplicationDbContext context, IMetricProcess metricHelper)
        {
            _context = context;
            _metricHelper = metricHelper;
        }

        [HttpGet]
        public async Task<ActionResult> UpdateSummary()
        {
            await _metricHelper.UpdateSummaryFeature();
            await _metricHelper.RFD();

            await _metricHelper.UpdateSummaryAquisition();
            await _metricHelper.RFM();

            var updateSummaryFeatureViewModel = new UpdateSummaryFeatureViewModel
            {
                ListSummary = _context.SummaryFeature.Include(x => x.Feature).Include(x => x.User).ToList(),
                ListMetricFeature = _context.MetricFeature.Include(x => x.Feature).Include(x => x.User).ToList(),
                Chart1 = _context.MetricFeature.GroupBy(x => x.Feature)
                .Select(x => new { metricFeature = x.Key.Name, count = x.Count() })
            };

            return View(updateSummaryFeatureViewModel);
        }

    }
}
