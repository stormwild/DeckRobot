using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DeckRobotDomain.Model;

namespace DeckRobotDomain.Service
{
    public class PowerPointService : IPowerPointService
    {
        public PowerPointService()
        {
        }

        public IEnumerable<object> GetFonts()
        {
            throw new NotImplementedException();
        }

        public PowerPointFontChangeRequest UpdateFont(PowerPointFontChangeRequest request)
        {
            throw new NotImplementedException();
        }

        // public async Task<PowerPointFileUploadResponse> UploadPowerPointFile(IFormFile file)
        // {
        //     var filePath = Path.GetTempFileName();

        //     using (var stream = new FileStream(filePath, FileMode.Create))
        //     {
        //         await file.CopyToAsync(stream);
        //     }

        //     return new PowerPointFileUploadResponse { Count = 1, FileSize = file.Length, FilePath = filePath };
        // }
    }
}

