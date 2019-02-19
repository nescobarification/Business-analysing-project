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
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        [HttpPost]
        public async Task<IActionResult> AvailableContentForUser()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userId = _userManager.GetUserId(User);

            // REMOVE AT THE END OF THE SEMESTER
            // KEEP FOR NOW BECAUSE IT IS USEFULL IF WE NEED TO CHANGE THE IDS
            //Console.WriteLine("============================= USER ID: " + userId + " ============================");
            var pdfIdList = _context.PdfAcquisition
                .Where(x => x.UserId.Equals(userId, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.PdfId)
                .ToList();

            if(pdfIdList.Any())
            {
                return Ok(new { pdfIds = pdfIdList });
            }

            return NotFound();
        }
    }
}
