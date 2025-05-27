// *********************************************************************
// MAIN_PROGRAM CLASSES
// *********************************************************************using CGUI;


using CGUI;
using TOOLS;
using Console = System.Console;

namespace AutoUpdate
{
    internal class Program
    {
        private static ConsoleKey Key = ConsoleKey.None;
        private static ConsoleModifiers Mods = ConsoleModifiers.None;

        static void Main(string[] args)
        {
            UI.Initialize();
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 28);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            CURSOR.Initialize();
            Console.Clear();
            CURSOR.Shn = false;

            // BUTTON
            FIELD button_field = new FIELD()
            {
                PosX = 5,
                PosY = 23,
                SizeX = 32,
                SizeY = 4,
                Color = ConsoleColor.Gray,
                Shn = true,
            };
            TEXT button_text = new TEXT()
            {
                PosX = 7,
                PosY = 24,
                SizeX = 28,
                SizeY = 2,
                ColorBG = ConsoleColor.Gray,
                ColorFG = ConsoleColor.Black,
                Text = "\n        Update Now!",
                LnW = true
            };
            INTERACTION button_interaction = new INTERACTION()
            {
                PosX = 5,
                PosY = 23,
                SizeX = 32,
                SizeY = 4
            };


            // Main Program Loop
            while (true)
            {
                CURSOR.Tick(Key);

                // write code

                
                button_interaction.Tick();


                if (button_interaction.Hov)
                {
                    button_field.Color = ConsoleColor.White;
                    button_text.ColorBG = ConsoleColor.White;
                    if (button_interaction.SCL)
                    {
                        string result = Update();
                    }
                }
                else
                {
                    button_field.Color = ConsoleColor.Gray;
                    button_text.ColorBG= ConsoleColor.Gray;
                }


                    button_field.Tick();
                button_text.Tick();

                Thread.Sleep(1);
            }
            // Program Deinitialization
            // write code
            CURSOR.DeInitialize();

            Thread.Sleep(100);
        }

        static string Update()
        {
            string ret = "";

            

            return ret;
        }
    }
}
