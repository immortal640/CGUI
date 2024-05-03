using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGUI
{
    public class Message
    {
        public static int Custom(string msg, bool endl, ConsoleColor colorFG, ConsoleColor colorBG = ConsoleColor.Black)
        {
            ConsoleColor colorFGold = Console.ForegroundColor;
            ConsoleColor colorBGold = Console.BackgroundColor;
            Console.ForegroundColor = colorFG;
            Console.BackgroundColor = colorBG;
            return 0;
        }
    }
}
