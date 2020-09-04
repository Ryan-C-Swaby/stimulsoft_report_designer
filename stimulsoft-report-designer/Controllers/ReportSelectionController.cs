using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace stimulsoft_report_designer.Controllers
{
    public class ReportSelectionController : Controller
    {
        private readonly ILogger<ReportSelectionController> _logger;

        public ReportSelectionController(ILogger<ReportSelectionController> logger)
        {
             _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public IActionResult Edit(string reportName)
        {
           return RedirectToAction("Index", "Designer", new { selectedreport = reportName});
        }
    }
}