using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace stimulsoft_report_designer.Controllers
{
    public class DesignerController : Controller
    {

        private readonly ILogger<DesignerController> _logger;
       

        public DesignerController(ILogger<DesignerController> logger)
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);

            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReport(string selectedreport)
        {
            var report = new StiReport();

            if(!string.IsNullOrWhiteSpace(selectedreport))
            {
                report.Load(StiNetCoreHelper.MapPath(this, $"Reports/{selectedreport}.mrt"));
            }

            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }
        
    }
}