// *********************************************************************
// CURSOR CLASSES
// *********************************************************************

using PInvoke;
using System.Drawing;
using System.Runtime.InteropServices;
using TOOLS;
using static PInvoke.Kernel32;

namespace CGUI
{
    //
    // CURSOR CLASS
    //
    /// <summary>
    /// The <c>CGUI.CURSOR</c> class is the general class for managing
    /// all 'cursor stuff'.
    /// </summary>
    public static class CURSOR
    {
        // Attributes
        /// <summary>
        /// The minimum position of the cursor
        /// </summary>
        public static Point MIN_POS { get; private set; }
        /// <summary>
        /// The maximum position of the cursor
        /// </summary>
        public static Point MAX_POS { get; private set; }
        /// <summary>
        /// The X Position of the cursor
        /// </summary>
        public static int PosX { get; set; } = 6;
        /// <summary>
        /// The Y Position of the cursor
        /// </summary>
        public static int PosY { get; set; } = 6;
        /// <summary>
        /// The last X Position of the cursor.
        /// Used to draw the cursor.
        /// </summary>
        public static int LastPosX { get; private set; } = 6;
        /// <summary>
        /// The last Y Position of the cursor.
        /// Used to draw the cursor.
        /// </summary>
        public static int LastPosY { get; private set; } = 6;

        // Interaction Tags
        public static ConsoleKey Key = ConsoleKey.None;
        public static bool Shn { get; set; } = true;       // Shown
        public static bool Hov { get; set; } = false;      // Hover

        public static bool SCL { get; set; } = false;      // Single Click Left
        public static bool SCR { get; set; } = false;      // Single Click Right
        public static bool DCL { get; set; } = false;      // Double Click Left
        public static bool DCR { get; set; } = false;      // Double Click Right
        public static bool DrL { get; set; } = false;      // Drag Left
        public static bool DrR { get; set; } = false;      // Drag Right

        public static bool SRL { get; set; } = false;      // Single Release Left
        public static bool SRR { get; set; } = false;      // Single Release Right
        public static bool DRL { get; set; } = false;      // Double Release Left
        public static bool DRR { get; set; } = false;      // Double Release Right
        public static bool DrRL { get; set; } = false;     // Drag Release Left
        public static bool DrRR { get; set; } = false;     // Drag Release Right

        public static bool KMB { get; set; } = false;      // Keyboard / Mouse Bound
        public static bool SAC { get; set; } = true;       // Show Actual Cursor

        public static bool WnM { get; set; } = false;      // Windowed Mode
        public static RECT WPos { get; private set; }      // Windows Position
        public static ConsoleHelper.FontInfo Font { get; set; } // Current Font

        public static int DivX { get; private set; } = 8;  // Divisor X Position
        public static int DivY { get; private set; } = 16; // Divisor Y Position


        // Define the RECT structure
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        
        // Console Mode
        const uint ENABLE_QUICK_EDIT = 0x0040;
        const int STD_INPUT_HANDLE = -10;

        // Windows API functions
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);


        public static void Initialize()
        {
            MouseClickHandler.StartMouseInputThread();

            if (KMB)
            {
                MIN_POS = new System.Drawing.Point(1, 1);
                MAX_POS = new System.Drawing.Point(System.Console.BufferWidth - 2, System.Console.BufferHeight - 2);
            }
            else
            {
                MIN_POS = new System.Drawing.Point(0, 0);
                MAX_POS = new System.Drawing.Point(System.Console.BufferWidth - 1, System.Console.BufferHeight - 1);
            }
        }

        public static void DeInitialize()
        {
            //
        }

        public static void Tick(ConsoleKey key)
        {
            // Get the handle of the console window
            IntPtr consoleHandle = GetConsoleWindow();

            RECT rect = new RECT();

            // Get the position of the console window
            if (GetWindowRect(consoleHandle, out rect))
            {
                WPos = rect;
            }
            else
            {
                Message.FatErr("Unable to get the console window position!");
                LOG.FatErr("Unable to get the colsole window position!");
            }

            SCL = false;
            SCR = false;
            DCL = false;
            DCR = false;

            if (KMB)
            {
                switch (key)
                {
                    case ConsoleKey.None:
                        break;
                    case ConsoleKey.Enter:
                        if (!DrL)
                            DrL = true;
                        else
                            DrL = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (PosX >= MIN_POS.X)
                            PosX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (PosX <= MAX_POS.X)
                            PosX++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (PosY >= MIN_POS.Y)
                            PosY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (PosY <= MAX_POS.Y)
                            PosY++;
                        break;
                    case ConsoleKey.Spacebar:
                        if (!SCL)
                            SCL = true;
                        else
                            SCL = false;
                        break;
                }
            }
            else
            {
                POINT pos = new POINT();
                User32.GetCursorPos(out pos);

                SRL = MouseClickHandler.GetSRL();
                SRR = MouseClickHandler.GetSRR();

                SCL = MouseClickHandler.GetSCL();
                SCR = MouseClickHandler.GetSCR();

                PosX = (pos.x - WPos.Left - DivX) / DivX;
                if (WnM)
                    PosY = (pos.y - WPos.Top) / DivY;
                else
                    PosY = (pos.y - WPos.Top - 32) / DivY;

                if (PosX < MIN_POS.X)
                    PosX = MIN_POS.X;
                if (PosX > MAX_POS.X)
                    PosX = MAX_POS.X;
                if (PosY < MIN_POS.Y)
                    PosY = MIN_POS.Y;
                if (PosY > MAX_POS.Y)
                    PosY = MAX_POS.Y;
            }
            if (Shn)
                Draw();
            LastPosX = PosX;
            LastPosY = PosY;
        }


        public static void Draw()
        {
            System.Console.SetCursorPosition(LastPosX, LastPosY);
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.WriteLine(" ");

            System.Console.SetCursorPosition(PosX, PosY);
            System.Console.ForegroundColor = ConsoleColor.Black;
            System.Console.BackgroundColor = ConsoleColor.White;
            System.Console.Write(" ");
        }
    }
}
