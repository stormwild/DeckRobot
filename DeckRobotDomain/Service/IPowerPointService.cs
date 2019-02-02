
using System.Collections.Generic;
using System.Threading.Tasks;
using DeckRobotDomain.Model;

namespace DeckRobotDomain.Service
{
    public interface IPowerPointService
    {
         IEnumerable<object> GetFonts();
         PowerPointFontChangeRequest UpdateFont(PowerPointFontChangeRequest request);
    }
}