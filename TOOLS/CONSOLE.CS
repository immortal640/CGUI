using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TOOLS
{
    public static class CONSOLE
    {
        public static ConsoleColor GetColorByIndex(int index)
        {
            ConsoleColor color;
            if (index == 0)
                color = ConsoleColor.Black;
            else if (index == 1)
                color = ConsoleColor.DarkBlue;
            else if (index == 2)
                color = ConsoleColor.DarkGreen;
            else if (index == 3)
                color = ConsoleColor.DarkCyan;
            else if (index == 4)
                color = ConsoleColor.DarkRed;
            else if (index == 5)
                color = ConsoleColor.DarkMagenta;
            else if (index == 6)
                color = ConsoleColor.DarkYellow;
            else if (index == 7)
                color = ConsoleColor.Gray;
            else if (index == 8)
                color = ConsoleColor.DarkGray;
            else if (index == 9)
                color = ConsoleColor.Blue;
            else if (index == 10)
                color = ConsoleColor.Green;
            else if (index == 11)
                color = ConsoleColor.Cyan;
            else if (index == 12)
                color = ConsoleColor.Red;
            else if (index == 13)
                color = ConsoleColor.Magenta;
            else if (index == 14)
                color = ConsoleColor.Yellow;
            else if (index == 15)
                color = ConsoleColor.White;
            else
                color = new ConsoleColor();
            return color;
        }
        public static ConsoleColor RandomColor(int maxValue)
        {
            return GetColorByIndex(new Random().Next(maxValue));
        }
        public static ConsoleColor RandomColor(int minValue, int maxValue)
        {
            return GetColorByIndex(new Random().Next(minValue, maxValue));
        }
        public static ConsoleColor RandomColor(int seed, int minValue, int maxValue)
        {
            return GetColorByIndex(new Random(seed).Next(minValue, maxValue));
        }
    }
}
