// *********************************************************************
// USER_INTERFACE CLASSES
// *********************************************************************

using TOOLS;

namespace CGUI
{
    //
    // UI CLASS
    //
    public class UI
    {
        /// <param name="path">The path to the '.ini' file.</param>
        public static void Initialize()
        {
            System.Console.Write("Please make sure, that you "); System.Console.ForegroundColor = ConsoleColor.Red; System.Console.Write("don't use any other terminal-emulator other than the old CMD.EXE"); System.Console.ForegroundColor = ConsoleColor.White; System.Console.WriteLine("   /\\");
            System.Console.WriteLine("Please right click on the Window-TitleBar and select 'Properties'                      'Window-TitleBar'");
            System.Console.WriteLine("Unter the 'Options' tab, select:");
            System.Console.WriteLine("Edit Options\n [ ] Quick Edit Mode\n [*] Insert Mode\n [*] Enable Ctrl key shortkuts\n [*] Filter clipboard contents on paste\n [ ] Use Ctrl+Shift+C/V as Copy/Paste");
            
            System.Console.Write("If that's done, type 'yes' [   ]");

            ConsoleKey key0 = ConsoleKey.None;
            ConsoleKey key1 = ConsoleKey.None;
            ConsoleKey key2 = ConsoleKey.None;

            while (true)
            {
                System.Console.CursorLeft = 27;
                System.Console.Write("[   ]");
                System.Console.CursorLeft = 28;
                key0 = System.Console.ReadKey().Key;
                if (key0 != ConsoleKey.Y)
                    continue;
                key1 = System.Console.ReadKey().Key;
                if (key1 != ConsoleKey.E)
                    continue;
                key2 = System.Console.ReadKey().Key;
                if (key2 != ConsoleKey.S)
                    continue;
                break;
            }
            Thread.Sleep(100);
            System.Console.Clear();
        }
    }

    //
    // FIELD CLASS
    //
    /// <summary>
    /// The FIELD class is used to create a rectangle of a speciffic color.
    /// </summary>
    public class FIELD
    {
        // Attributes
        public int PosX { get; set; } = 0;
        public int PosY { get; set; } = 0;
        public int SizeX { get; set; } = 0;
        public int SizeY { get; set; } = 0;
        public ConsoleColor Color { get; set; } = ConsoleColor.Black;
        // Interaction Tags
        public bool Shn { get; set; } = false;      // Shown
        public bool Hov { get; set; } = false;      // Hover
        public bool SCL { get; set; } = false;      // Single Click Left
        public bool SCR { get; set; } = false;      // Single Click Right
        public bool DCL { get; set; } = false;      // Double Click Left
        public bool DCR { get; set; } = false;      // Double Click Right
        public bool DrL { get; set; } = false;      // Drag Left
        public bool DrR { get; set; } = false;      // Drag Right

        public void Initialize()
        {
            //
        }

        public void Tick()
        {
            if (Shn)
                Draw();
        }

        public void Draw()
        {
            System.Console.SetCursorPosition(PosX, PosY);
            System.Console.ForegroundColor = Color;
            System.Console.BackgroundColor = Color;

            for (int i = 0; i < SizeY; i++)
            {
                for (int j = 0; j < SizeX; j++)
                    System.Console.Write(" ");
                System.Console.SetCursorPosition(PosX, PosY + i);
            }
        }
    }
    //
    // INTERACTION CLASS
    //
    public class INTERACTION
    {
        // Attributes
        public int PosX { get; set; } = 0;
        public int PosY { get; set; } = 0;
        public int SizeX { get; set; } = 0;
        public int SizeY { get; set; } = 0;
        public ConsoleColor Color { get; private set; } = ConsoleColor.Black;
        // Interaction Tags
        public bool Shn { get; set; } = false;      // Shown

        public bool Hov { get; set; } = false;      // Hover
        public bool SCL { get; set; } = false;      // Single Click Left
        public bool SCR { get; set; } = false;      // Single Click Right
        public bool DCL { get; set; } = false;      // Double Click Left
        public bool DCR { get; set; } = false;      // Double Click Right
        public bool DrL { get; set; } = false;      // Drag Left
        public bool DrR { get; set; } = false;      // Drag Right

        public void Initialize()
        {
            //
        }

        public void Tick()
        {
            SCL = false;
            SCR = false;
            DCL = false;
            DCR = false;
            Hov = false;
            if (CURSOR.PosX >= PosX && CURSOR.PosX <= PosX + SizeX &&
                CURSOR.PosY >= PosY && CURSOR.PosY <= PosY + SizeY - 1)
            {
                if (CURSOR.SCL)
                    SCL = true;
                if (CURSOR.SCR)
                    SCR = true;
                if (!CURSOR.SCL && !CURSOR.SCR)
                    Hov = true;
            }
            if (Shn)
                Draw();
        }

        /// <summary>
        /// An INTERACTION can not be drawn!
        /// </summary>
        public void Draw()
        {
            // An INTERACTION can not be drawn!
        }
    }
    //
    // TEXT CLASS
    //
    public class TEXT
    {
        // Attributes
        public int PosX { get; set; } = 0;
        public int PosY { get; set; } = 0;
        public int SizeX { get; set; } = 0;
        public int SizeY { get; set; } = 0;
        public ConsoleColor ColorBG { get; set; } = ConsoleColor.Black;
        public ConsoleColor ColorFG { get; set; } = ConsoleColor.White;
        public string Text { get; set; } = "Text";
        // Interaction Tags
        public bool Shn { get; set; } = true;      // Shown

        public bool Hov { get; set; } = false;      // Hover
        public bool SCL { get; set; } = false;      // Single Click Left
        public bool SCR { get; set; } = false;      // Single Click Right
        public bool DCL { get; set; } = false;      // Double Click Left
        public bool DCR { get; set; } = false;      // Double Click Right
        public bool DrL { get; set; } = false;      // Drag Left
        public bool DrR { get; set; } = false;      // Drag Right
        public bool LnW { get; set; } = true;       // Line Wrapping

        public void Initialize()
        {
            //
        }

        public void Tick()
        {
            if (Shn)
                Draw();
        }

        public void Draw()
        {
            System.Console.SetCursorPosition(PosX, PosY);
            System.Console.ForegroundColor = ColorFG;
            System.Console.BackgroundColor = ColorBG;
            if (LnW)
            {
                string txt = "";
                List<string> parts = TOOLS.TextTools.WrapText(Text, SizeX).Split("\n").ToList<string>();
                int c;
                for (int i = 0; i < parts.Count; i++)
                {
                    c = parts[i].Length;
                    for (int j = 0; j < SizeX - c; j++)
                        parts[i] += ' ';
                }
                for (int i = 0; i < SizeX; i++)
                    txt += ' ';
                c = parts.Count;
                for (int i = 0; i < SizeY - c; i++)
                {
                    parts.Add(txt);
                }

                for (int i = 0; i < SizeY; i++)
                {
                    for (int j = 0; j < SizeX; j++)
                    {
                        System.Console.Write(parts[i][j]);
                    }
                    System.Console.SetCursorPosition(PosX, PosY + i);
                }
            }
            else
            {
                string[] txt = Text.Split("\n");
                for (int i = 0; i < SizeY; i++)
                {
                    if (i >= txt.Length)
                    {
                        continue;
                    }
                    for (int j = 0; j < SizeX; j++)
                    {
                        if (j >= txt[i].Length)
                        {
                            continue;
                        }
                        System.Console.Write(txt[i][j]);
                    }
                    System.Console.SetCursorPosition(PosX, PosY + i);
                }
            }
        }
    }

    //
    // INPUT CLASS
    //
    public class INPUT
    {
        // Attributes
        public int PosX { get; set; } = 0;
        public int PosY { get; set; } = 0;
        public int SizeX { get; set; } = 0;
        public int SizeY { get; set; } = 0;
        // Interaction Tags
        public bool Shn { get; set; } = true;       // Shown
        public bool Hov { get; set; } = false;      // Hover
        public bool SCL { get; set; } = false;      // Single Click Left
        public bool SCR { get; set; } = false;      // Single Click Right
        public bool DCL { get; set; } = false;      // Double Click Left
        public bool DCR { get; set; } = false;      // Double Click Right
        public bool DrL { get; set; } = false;      // Drag Left
        public bool DrR { get; set; } = false;      // Drag Right
        public bool LnW { get; set; } = true;       // Line Wrapping
        public bool Sel { get; set; } = false;      // Selected
        public bool SWL { get; set; } = false;      // Selected with Left
        public bool SWR { get; set; } = false;      // Selected with Right
        public bool Pwd { get; set; } = false;      // Is Password
        public string Text { get; set; } = "";      // Text
        public bool Wtg { get; set; } = true;      // Writing
        // Inputing Stuff
        public CancellationTokenSource ITCTS { get; set; } // Input Thread Cancellation Token Source
        public CancellationToken ITCT { get; set; } // Input Thread Cancellation Token
        public Thread IT { get; set; }              // Input Thread


        public INPUT() { }

        public INPUT(int PosX, int PosY, int SizeX, int SizeY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.SizeX = SizeX;
            this.SizeY = SizeY;
        }

        public void Initialize()
        {
            IT = new Thread(() =>
            {
                Text += Keyboard.ReadKey().KeyChar;
            });
            IT.IsBackground = true;
            IT.Start();
        }

        public void Tick()
        {
            SCL = false;
            SCR = false;
            DCL = false;
            DCR = false;
            Hov = false;
            if (CURSOR.PosX >= PosX && CURSOR.PosX < PosX + SizeX &&
                CURSOR.PosY >= PosY && CURSOR.PosY < PosY + SizeY - 1)
            {
                Hov = true;
                if (CURSOR.SCL)
                {
                    SCL = true;
                    Sel = true;
                    SWL = true;
                    SWR = false;
                    Wtg = true;
                }
            }
            else
            {
                Hov = false;
                if (CURSOR.SCL || CURSOR.SCR)
                {
                    Sel = false;
                    SWL = false;
                    SWR = false;
                    Wtg = false;
                }
            }

            if (Sel)
            {
            }
            if (Shn)
                Draw();
        }

        public void Draw()
        {
            // This is not a drawing element for now!
        }
    }
}
