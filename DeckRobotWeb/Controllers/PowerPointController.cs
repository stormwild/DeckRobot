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

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await powerPoint.File.CopyToAsync(stream);
                        // to something to the stream using the service
                    }

                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }

            return BadRequest(ModelState);
        }

    }
}