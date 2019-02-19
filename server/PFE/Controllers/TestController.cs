using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MVC5App.Models;
using PFE.Data;
using PFE.Models;
using PFE.Models.MetricViewModels;

namespace PFE.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("[Controller]/Find")]
        public List<IEntityType> Find()
        {
            return _context.Model.GetEntityTypes().ToList();
        }
        //FOR TEST
        [HttpPost]
        [Route("[Controller]/Metric/Create")]
        public async Task<List<MetricFeature>> Create(CreateTagModel model)
        {
            ApplicationUser user = await _context.Users.Where(f => f.Email == model.UserEmail).FirstOrDefaultAsync();

            Feature feature = await _context.Feature.Where(f => f.Name == model.Tag).FirstOrDefaultAsync();

            if (feature == null)
            {
                feature = new Feature { Name = model.Tag };
                _context.Feature.Add(feature);
                _context.SaveChanges();
            }

            var newFeature = new MetricFeature
            {
                User = user,
                Date = DateTime.Now,
                Duration = model.Duration,
                PdfId = model.PdfId,
                Feature = feature,
                FeatureId = feature.FeatureId
            };

            _context.MetricFeature.Add(newFeature);
            _context.SaveChanges();

            return _context.MetricFeature.ToList();
        }

        [HttpGet]
        [Route("[Controller]/Metric/SeeMetricFeature")]
        public Task<List<MetricFeature>> SeeMetricFeature()
        {
            return _context.MetricFeature.ToListAsync();
        }

        [HttpGet]
        [Route("[Controller]/Metric/SeeSummaryFeature")]
        public Task<List<SummaryFeature>> SeeSummaryFeature()
        {
            return _context.SummaryFeature.ToListAsync();
        }

        //FOR TEST
        [HttpGet]
        [Route("[Controller]/Metric/DeleteMetricFeature")]
        public bool DeleteMetricFeature()
        {

            var metricFeature = _context.MetricFeature.ToList();



            _context.MetricFeature.RemoveRange(metricFeature);
            _context.SaveChanges();

            return true;
        }

        //FOR TEST
        [HttpGet]
        [Route("[Controller]/Metric/DeleteSummaryFeature")]
        public bool DeleteSummaryFeature()
        {

            var metricFeature = _context.SummaryFeature.ToList();



            _context.SummaryFeature.RemoveRange(metricFeature);
            _context.SaveChanges();

            return true;
        }
    }
}