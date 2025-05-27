// *********************************************************************
// MAIN_PROGRAM CLASSES
// *********************************************************************


using CGUI;
using TOOLS;
using PInvoke;
using Console = System.Console;

namespace Debug
{
    internal class Program
    {
        private static ConsoleKey Key = ConsoleKey.None;
        private static ConsoleModifiers Mods = ConsoleModifiers.None;

        static void Main(string[] args)
        {
            UI.Initialize();
            System.Console.CursorVisible = false;
            System.Console.SetBufferSize(System.Console.WindowWidth, System.Console.WindowHeight);
            CURSOR.Initialize();
            System.Console.Clear();
            CURSOR.Shn = false;
            int frameCount = 0;
            Thread keyThread = new Thread(KeyThread);
            keyThread.IsBackground = true;
            //keyThread.Start();
            // Program Initialization 
            // write code

            // BUTTON
            FIELD button_field = new FIELD()
            {
                PosX = 20,
                PosY = 10,
                SizeX = 10,
                SizeY = 5,
                Color = ConsoleColor.Gray,
                Shn = true,
            };
            INTERACTION button_interaction = new INTERACTION()
            {
                PosX = 20,
                PosY = 10,
                SizeX = 10,
                SizeY = 5
            };
            TEXT button_text = new TEXT()
            {
                PosX = 21,
                PosY = 11,
                SizeX = 9,
                SizeY = 4,
                ColorBG = ConsoleColor.DarkGray,
                ColorFG = ConsoleColor.Black,
                Text = "\nButton text. Here is some cool Linewrapping stuff going on.",
                LnW = true
            };
            
            
            // Main Program Loop
            while (true)
            {
                Console.WriteLine(Keyboard.ReadLine(CancellationToken.None, new ConsoleKeyInfo(), true));

                continue;
                
                CURSOR.Tick(Key);

                // write code
                
                button_field.Tick();
                button_text.Tick();
                button_interaction.Tick();
                
                if (button_interaction.Hov && CURSOR.SCL)
                    button_text.ColorBG = ConsoleColor.Gray;
                else
                    button_text.ColorBG = ConsoleColor.DarkGray;
                

                INPUT input = new INPUT()
                {
                    PosX = 10,
                    PosY = 10,
                    SizeX = 10,
                    SizeY = 10
                };


                // Debug Stuff (uncomment, if needed)
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.ForegroundColor = ConsoleColor.White;

                System.Console.SetCursorPosition(0, 0);
                System.Console.WriteLine("       \n       ");
                System.Console.SetCursorPosition(0, 0);
                System.Console.WriteLine($"X:{CURSOR.PosX}\nY:{CURSOR.PosY}");
                System.Console.SetCursorPosition(40, 0);
                System.Console.WriteLine($"Shn:{CURSOR.Shn}, Hov:{CURSOR.Hov}, SCL:{CURSOR.SCL}, SCR:{CURSOR.SCR}, KMB:{CURSOR.KMB}, SAC:{CURSOR.SAC}");
                System.Console.SetCursorPosition(System.Console.WindowWidth - Convert.ToString(frameCount).Length - "FC:".Length, 0);
                System.Console.WriteLine($"FC:{frameCount}");
                System.Console.SetCursorPosition(0, 3);
                System.Console.WriteLine($"{Key}          ");
                System.Console.WriteLine($"{Mods}          ");
                System.Console.SetCursorPosition(System.Console.WindowWidth - Convert.ToString(frameCount).Length - "FC:".Length, 0);
                System.Console.WriteLine($"FC:{frameCount}");
                frameCount++;
                Thread.Sleep(1);
            }
            // Program Deinitialization
            // write code
            CURSOR.DeInitialize();

            Thread.Sleep(100);
        }

        static void KeyThread()
        {
            while (true)
            {
                var readKey = System.Console.ReadKey(true);
                Key = readKey.Key;
                Mods = readKey.Modifiers;

                //Console.SetCursorPosition(0, 5);
                //Console.WriteLine($"{mods} : {key}                   ");
            }
        }
    }
}