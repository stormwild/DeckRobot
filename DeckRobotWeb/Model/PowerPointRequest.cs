using Microsoft.AspNetCore.Http;

namespace DeckRobotWeb.Model
{
    public class PowerPointRequest
    {
        public string FontFamily { get; set; }
        public IFormFile File { get; set; }
    }
}