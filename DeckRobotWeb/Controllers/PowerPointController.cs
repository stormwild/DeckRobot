using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DeckRobotDomain.Service;
using DeckRobotWeb.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeckRobotWeb.Controllers
{
    [Route("api/[controller]")]
    public class PowerPointController : Controller
    {
        private readonly IPowerPointService _service;

        public PowerPointController(IPowerPointService service)
        {
            _service = service;
        }

        // POST api/powerpoint
        [HttpPost]
        public async Task<IActionResult> Post(PowerPointRequest powerPoint)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await powerPoint.File.CopyToAsync(stream);
                    }

                    var ms = new MemoryStream();
                    using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None, 4096, options: FileOptions.DeleteOnClose))
                    {
                        _service.UpdateFont(fs, filePath, powerPoint.FontFamily);
                        fs.CopyTo(ms);
                    }
                    ms.Position = 0;

                    return File(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }

            return BadRequest(ModelState);
        }

        // [HttpPost("[action]")]
        // public FileStreamResult DownloadProcessQCReport([FromBody]ProcessQCReportParam param)
        // {
        //     var reportDownload = _reportWorkflow.DownloadProcessQCReport(param);

        //     return File(reportDownload.ReportStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", reportDownload.Filename);
        // }


        // [HttpGet("scans/{filename}")]
        // public ActionResult Scans(string fileName)
        // {
        //     FileStream fileStream;
        //     FileStreamResult fsResult = null;
        //     try
        //     {
        //        string mimeType = Path.GetExtension(fileName) == ".pdf" ? "application/pdf" : "application/tiff";
        //        fileStream = new FileStream(Path.Combine(sharedDirectory, fileName), FileMode.Open, FileAccess.Read);
        //        fsResult = new FileStreamResult(fileStream, mimeType);
        //     }
        //     catch {
        //         fsResult = null;
        //         return NotFound(); 
        //     }

        //     return fsResult;

        //     //string mimeType = Path.GetExtension(fileName) == ".pdf" ? "application/pdf" : "application/tiff";
        //     //var fileStream = new FileStream(Path.Combine(sharedDirectory, fileName), FileMode.Open, FileAccess.Read);
        //     //var fsResult = new FileStreamResult(fileStream, mimeType);

        //     //return fsResult;
        // }


    }
}