// *********************************************************************
// USER_INTERFACE CLASSES
// *********************************************************************

using Microsoft.VisualBasic;
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
            Console.Write("Please make sure, that you "); Console.ForegroundColor = ConsoleColor.Red; Console.Write("don't use any other terminal-emulator other than the old CMD.EXE"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("   /\\");
            Console.WriteLine("Please right click on the Window-TitleBar and select 'Properties'                      'Window-TitleBar'");
            Console.WriteLine("Unter the 'Options' tab, select:");
            Console.WriteLine("Cursor Size\n (*) Small\n ( ) Medium\n ( ) Large");
            Console.WriteLine("Edit Options\n [ ] Quick Edit Mode\n [*] Insert Mode\n [*] Enable Ctrl key shortkuts\n [*] Filter clipboard contents on paste\n [*] Use Ctrl+Shift+C/V as Copy/Paste");
            Console.WriteLine("Text Selection\n [ ] Enabe extended line wrapping selection\n [*] Extended test selection keys\n");
            Console.WriteLine("Then, under the 'Font' tab, select:");
            Console.WriteLine("Font\n   .....\n * Raster Fonts\n   .....");
            Console.WriteLine("Size\n   .....\n * 8 x 12\n   .....\n");
            Console.WriteLine("Lastly, in the 'Layout' tab, select:");
            Console.WriteLine("Screen Buffer Size\n Width:          [120]^/v\n Height:         [ 33]^/v\n");
            Console.Write("If that's done, type 'yes' [   ]");
            
            ConsoleKey key0 = ConsoleKey.None;
            ConsoleKey key1 = ConsoleKey.None;
            ConsoleKey key2 = ConsoleKey.None;

            while (true)
            {
                Console.CursorLeft = 27;
                Console.Write("[   ]");
                Console.CursorLeft = 28;
                key0 = Console.ReadKey().Key;
                if (key0 != ConsoleKey.Y)
                    continue;
                key1 = Console.ReadKey().Key;
                if (key1 != ConsoleKey.E)
                    continue;
                key2 = Console.ReadKey().Key;
                if (key2 != ConsoleKey.S)
                    continue;
                break;
            }
            Thread.Sleep(100);
            Console.Clear();
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
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = Color;
            Console.BackgroundColor = Color;

            for (int i = 0; i < SizeY; i++)
            {
                for (int j = 0; j < SizeX; j++)
                    Console.Write(" ");
                Console.SetCursorPosition(PosX, PosY + i);
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
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ColorFG;
            Console.BackgroundColor = ColorBG;
            if (LnW)
            {
                string txt = "";
                List<string> parts = TOOLS.TEXT.WrapText(Text, SizeX).Split(Environment.NewLine).ToList<string>();
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
                        Console.Write(parts[i][j]);
                    }
                    Console.SetCursorPosition(PosX, PosY + i);
                }
            }
            else
            {
                string[] txt = Text.Split("\n");
                for (int i = 0; i < SizeY; i++)
                {
                    for (int j = 0; j < SizeX; j++)
                    {
                        if (i >= txt.Length)
                        {
                            Console.WriteLine();
                            continue;
                        }
                        if (j >= txt[i].Length)
                        {
                            Console.Write(" ");
                            continue;
                        }
                        Console.Write(txt[i][j]);
                    }
                    Console.SetCursorPosition(PosX, PosY + i);
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
        public int OffsX { get; set; } = 1;
        public int OffsY { get; set; } = 1;
        public int BoundX { get; set; } = 1;
        public int BoundY { get; set; } = 1;
        public ConsoleColor ColorBGN { get; set; } = ConsoleColor.Gray;
        public ConsoleColor ColorFGN { get; set; } = ConsoleColor.Black;
        public ConsoleColor ColorBGH { get; set; } = ConsoleColor.Gray;
        public ConsoleColor ColorFGH { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor ColorBGL { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor ColorFGL { get; set; } = ConsoleColor.Black;
        public ConsoleColor ColorBGR { get; set; } = ConsoleColor.Gray;
        public ConsoleColor ColorFGR { get; set; } = ConsoleColor.Black;
        public ConsoleColor ColorBGLR { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor ColorFGLR { get; set; } = ConsoleColor.Black;
        public ConsoleColor ColorPrN { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor ColorPrH { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor ColorPrL { get; set; } = ConsoleColor.Gray;
        public ConsoleColor ColorPrR { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor ColorPrLR { get; set; } = ConsoleColor.Gray;
        public string Prev { get; set; } = "Input"; // Preview Text
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
        public bool SWR { get; set; } = false;      // Selevted with Right
        public string Text { get; set; } = "";      // Text

        public void Initialize()
        {
            //
        }

        public void Tick(ConsoleKey key)
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
                if (CURSOR.SRL)
                {
                    SCL = true;
                    Sel = true;
                    SWL = true;
                    SWR = false;
                }
                if (CURSOR.SRR)
                {
                    SCR = true;
                    Sel = true;
                    SWL = false;
                    SWR = true;
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
                }
            }

            if (Sel)
            {
                Thread readText = new Thread(ReadText);
                readText.IsBackground = true;
                readText.Start();
            }
            if (Shn)
                Draw();
        }

        public void Draw()
        {
            // Drawing Setup
            ConsoleColor colorFGN;
            ConsoleColor colorFGH;
            ConsoleColor colorFGL;
            ConsoleColor colorFGR;
            ConsoleColor colorFGLR;
            string text;
            if (Text != "")
            {
                colorFGN = ColorFGN;
                colorFGH = ColorFGH;
                colorFGL = ColorFGL;
                colorFGR = ColorFGR;
                colorFGLR = ColorFGLR;
                text = Text;
            }
            else
            {
                colorFGN = ColorPrN;
                colorFGH = ColorPrH;
                colorFGL = ColorPrL;
                colorFGR = ColorPrR;
                colorFGLR = ColorPrLR;
                text = Prev;
            }

            // Render Field
            Console.SetCursorPosition(PosX, PosY);
            if (!Hov && !SWL && !SWR)
                Console.BackgroundColor = ColorBGN;
            else if (Hov && !SWL && !SWR)
                Console.BackgroundColor = ColorBGH;
            else if (Hov && SWL && !SWR)
                Console.BackgroundColor = ColorBGL;
            else if (Hov && !SWL && SWR)
                Console.BackgroundColor = ColorBGR;
            else if (Hov && SWL && SWR)
                Console.BackgroundColor = ColorBGLR;
            else
            {
                LOG.CritErr($"An unexspected critical error occurred in the CGUI.BUTTON class. [Hov:{Hov} SCL:{SCL} SCR:{SCR}]");
                return;
            }

            for (int i = 0; i < SizeY; i++)
            {
                for (int j = 0; j < SizeX; j++)
                    Console.Write(" ");
                Console.SetCursorPosition(PosX, PosY + i);
            }

            // Render Interaction
            //     Did you really think, that I would RENDER an INTERACTION ?!

            // Render Text
            Console.SetCursorPosition(PosX + OffsX, PosY + OffsY);
            if (!Hov && !SWL && !SWR)
                Console.ForegroundColor = colorFGN;
            else if (Hov && !SWL && !SWR)
                Console.ForegroundColor = colorFGH;
            else if (Hov && SWL && !SWR)
                Console.ForegroundColor = colorFGL;
            else if (Hov && !SWL && SWR)
                Console.ForegroundColor = colorFGR;
            else if (Hov && SWL && SWR)
                Console.ForegroundColor = colorFGLR;

            if (LnW)
            {
                List<string> parts = new List<string>();
                parts.Add("");
                List<string> tmpL = TOOLS.TEXT.WrapText(text, SizeX - (OffsX + BoundX)).Split(Environment.NewLine).ToList<string>();
                for (int i = 0; i < tmpL.Count; i++)
                {
                    parts.Add(tmpL[i]);
                }
                for (int i = 0; i < parts.Count; i++)
                {
                    if (i > SizeY - (OffsY + BoundY))
                        break;
                    Console.WriteLine(parts[i]);
                    Console.SetCursorPosition(PosX + OffsX, PosY + OffsY + i);
                }
            }
            else
            {
                List<string> lnsL = new List<string>();
                lnsL.Add("");
                List<string> tmpL = text.Split('\n').ToList<string>();
                for (int i = 0; i < tmpL.Count; i++)
                {
                    lnsL.Add(tmpL[i]);
                }

                int c = lnsL.Count;
                for (int i = 0; i < SizeY - (OffsY + BoundY); i++)
                    lnsL.Add("");

                for (int i = 0; i < SizeY - (OffsX + BoundX); i++)
                {
                    for (int j = 0; j < SizeX - (OffsX + BoundX); j++)
                    {
                        if (lnsL[i].Length >= j + 1)
                            Console.Write(lnsL[i][j]);
                        else
                            Console.Write(" ");
                    }
                    Console.SetCursorPosition(PosX + OffsX, PosY + OffsY + i);
                }
            }
        }

        private void ReadText()
        {
            Text = Console.ReadLine();
        }
    }

    //
    // BUTTON CLASS
    //
    public class BUTTON
    {
        // Attributes
        public int PosX { get; set; } = 0;
        public int PosY { get; set; } = 0;
        public int SizeX { get; set; } = 0;
        public int SizeY { get; set; } = 0;
        public int OffsX { get; set; } = 0;
        public int OffsY { get; set; } = 0;
        public int BoundX { get; set; } = 1;
        public int BoundY { get; set; } = 1;
        public ConsoleColor ColorBGN { get; set; } = ConsoleColor.White;
        public ConsoleColor ColorFGN { get; set; } = ConsoleColor.Black;
        public ConsoleColor ColorBGH { get; set; } = ConsoleColor.Gray;
        public ConsoleColor ColorFGH { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor ColorBGL { get; set; } = ConsoleColor.Red;
        public ConsoleColor ColorFGL { get; set; } = ConsoleColor.Black;
        public ConsoleColor ColorBGR { get; set; } = ConsoleColor.Blue;
        public ConsoleColor ColorFGR { get; set; } = ConsoleColor.Black;
        public ConsoleColor ColorBGLR { get; set; } = ConsoleColor.Magenta;
        public ConsoleColor ColorFGLR { get; set; } = ConsoleColor.Yellow;
        public string Text { get; set; } = "Button";
        // Interaction Tags
        public bool Shn { get; set; } = true;       // Shown
        public bool Hov { get; set; } = false;      // Hover
        public bool SCL { get; set; } = false;      // Single Click Left
        public bool SCR { get; set; } = false;      // Single Click Right
        public bool Sel { get; set; } = false;      // Selected
        public bool SlL { get; set; } = false;      // Selected Left
        public bool SlR { get; set; } = false;      // Selected Right
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
            SCL = false;
            SCR = false;
            DCL = false;
            DCR = false;
            Hov = false;
            if (CURSOR.PosX >= PosX && CURSOR.PosX < PosX + SizeX &&
                CURSOR.PosY >= PosY && CURSOR.PosY < PosY + SizeY - 1)
            {
                Hov = true;
                if (CURSOR.SRL)
                {
                    SCL = true;
                    Sel = true;
                    SlL = true;
                }    
                if (CURSOR.SRR)
                {
                    SCR = true;
                    Sel = true;
                    SlR = true;
                }
            }
            else
            {
                if (CURSOR.SCL || CURSOR.SCR)
                {
                    Sel = false;
                    SlL = false;
                    SlR = false;
                }
            }

            if (Shn)
                Draw();
        }

        public void Draw()
        {
            // Render Field
            Console.SetCursorPosition(PosX, PosY);
            if (!Hov && !SlL && !SlR)
                Console.BackgroundColor = ColorBGN;
            else if (Hov && !SlL && !SlR)
                Console.BackgroundColor = ColorBGH;
            else if (SlL && !SlR)
                Console.BackgroundColor = ColorBGL;
            else if (!SlL && SlR)
                Console.BackgroundColor = ColorBGR;
            else if (SlL && SlR)
                Console.BackgroundColor = ColorBGLR;
            else
            {
                LOG.CritErr($"An unexspected ciotical error occurred in the CGUI.BUTTON class. [Hov:{Hov} SCL:{SCL} SCR:{SCR}]");
                return;
            }

            for (int i = 0; i < SizeY; i++)
            {
                for (int j = 0; j < SizeX; j++)
                    Console.Write(" ");
                Console.SetCursorPosition(PosX, PosY + i);
            }

            // Render Interaction
            //     Did you really think, that I would RENDER an INTERACTION ?!

            // Render Text
            Console.SetCursorPosition(PosX + OffsX, PosY + OffsY);
            if (!Hov && !SCL && !SCR)
                Console.ForegroundColor = ColorFGN;
            else if (Hov && !SCL && !SCR)
                Console.ForegroundColor = ColorFGH;
            else if (Hov && SCL && !SCR)
                Console.ForegroundColor = ColorFGL;
            else if (Hov && !SCL && SCR)
                Console.ForegroundColor = ColorFGR;
            else if (Hov && SCL && SCR)
                Console.ForegroundColor = ColorFGLR;

            if (LnW)
            {
                List<string> parts = new List<string>();
                parts.Add("");
                List<string> tmpL = TOOLS.TEXT.WrapText(Text, SizeX - (OffsX + BoundX)).Split(Environment.NewLine).ToList<string>();
                for (int i = 0; i < tmpL.Count; i++)
                {
                    parts.Add(tmpL[i]);
                }
                for (int i = 0; i < parts.Count; i++)
                {
                    if (i > SizeY - (OffsY + BoundY))
                        break;
                    Console.WriteLine(parts[i]);
                    Console.SetCursorPosition(PosX + OffsX, PosY + OffsY + i);
                }
            }
            else
            {
                List<string> lnsL = new List<string>();
                lnsL.Add("");
                List<string> tmpL = Text.Split('\n').ToList<string>();
                for (int i = 0; i < tmpL.Count; i++)
                {
                    lnsL.Add(tmpL[i]);
                }

                int c = lnsL.Count;
                for (int i = 0; i < SizeY - (OffsY + BoundY); i++)
                    lnsL.Add("");

                for (int i = 0; i < SizeY - (OffsX + BoundX); i++)
                {
                    for (int j = 0; j < SizeX - (OffsX + BoundX); j++)
                    {
                        if (lnsL[i].Length >= j + 1)
                            Console.Write(lnsL[i][j]);
                        else
                            Console.Write(" ");
                    }
                    Console.SetCursorPosition(PosX + OffsX, PosY + OffsY + i);
                }
            }
        }
    }
}
