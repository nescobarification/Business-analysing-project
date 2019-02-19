using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MVC5App.Models;
using PFE.Data;
using PFE.Models;
using PFE.Models.SyncApiModels;

namespace PFE.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    public class SyncController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SyncController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
         // GET: api/sync/upload
        [HttpPost]
        public async Task<IActionResult> Upload([FromBody] IList<MetricPdfFeatureModel> metricPdfFeatures)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            foreach (var metricPdfFeature in metricPdfFeatures)
            {
                foreach (var metricFeature in metricPdfFeature.Features)
                {
                    var metricFeatureModel = new MetricFeature {
                        PdfId = Convert.ToInt32(metricPdfFeature.PdfId),
                        FeatureId = metricFeature.FeatureId,
                        Date = metricFeature.Date,
                        Duration = metricFeature.Duration,
                        User = user,
                    };

                    await _context.MetricFeature.AddAsync(metricFeatureModel);
                }
            }

            await _context.SaveChangesAsync();

            return Ok("ok");
        }
    }
}
