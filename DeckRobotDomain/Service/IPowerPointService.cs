
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DeckRobotDomain.Model;

namespace DeckRobotDomain.Service
{
    public interface IPowerPointService
    {
         IEnumerable<object> GetFonts();
         void UpdateFont(FileStream fileStream, string filePath, string fontFamily);
    }
}