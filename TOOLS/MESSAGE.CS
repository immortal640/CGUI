using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOLS
{
    public class MESSAGE
    {
        public string Text { get; set; }
        public string Title { get; set; }
        public ConsoleColor TitleColor { get; set; }
        public int Offset { get; set; } = 10;
        public bool Endl { get; set; } = true;

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" [ ");
            Console.ForegroundColor = TitleColor;
            Console.Write(Title);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < Offset - (6 + Title.Length); i++)
                Console.Write(" ");
            Console.Write(Text);
            if (Endl)
                Console.WriteLine();
        }

        public static void Custom(string msg, string title, ConsoleColor titleColor, int offset = 10, bool endl = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" [ ");
            Console.ForegroundColor = titleColor;
            Console.Write(title);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - (6 + title.Length); i++)
                Console.Write(" ");
            Console.Write(msg);
            if (endl)
                Console.WriteLine();
        }
        public static void Succ(string msg, int offset = 10, bool endl = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" [ ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("SUCC");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                Console.Write(" ");
            Console.Write(msg);
            if (endl)
                Console.WriteLine();
        }
        public static void Info(string msg, int offset = 10, bool endl = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" [ ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("INFO");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                Console.Write(" ");
            Console.Write(msg);
            if (endl)
                Console.WriteLine();
        }
        public static void Warn(string msg, int offset = 10, bool endl = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" [ ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("WARN");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                Console.Write(" ");
            Console.Write(msg);
            if (endl)
                Console.WriteLine();
        }
        public static void NoCritErr(string msg, int offset = 10, bool endl = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" [ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("NCER");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                Console.Write(" ");
            Console.Write(msg);
            if (endl)
                Console.WriteLine();
        }
        public static void CritErr(string msg, int offset = 10, bool endl = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" [ ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("CERR");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                Console.Write(" ");
            Console.Write(msg);
            if (endl)
                Console.WriteLine();
        }
        public static void FatErr(string msg, int offset = 10, bool endl = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" [ ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("FERR");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                Console.Write(" ");
            Console.Write(msg);
            if (endl)
                Console.WriteLine();
        }
        public static void Debg(string msg, int offset = 10, bool endl = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" [ ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("DEBG");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                Console.Write(" ");
            Console.Write(msg);
            if (endl)
                Console.WriteLine();
        }
    }

    public class LOG
    {
        public static void Custom(string msg, string title, int offset = 10)
        {
            if (!File.Exists(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG"))
                File.Create(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG").Close();
            string txt = "";
            txt += " [ ";
            txt += title;
            txt += " ] ";
            for (int i = 0; i < offset - txt.Length; i++)
                txt += " ";
            txt += msg;
            File.AppendAllText(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG", txt + '\n');
        }
        public static void Succ(string msg, int offset = 10)
        {
            if (!File.Exists(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG"))
                File.Create(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG").Close();
            string txt = "";
            txt += " [ ";
            txt += "SUCC";
            txt += " ] ";
            for (int i = 0; i < offset - txt.Length; i++)
                txt += " ";
            txt += msg;
            File.AppendAllText(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG", txt + '\n');
        }
        public static void Info(string msg, int offset = 10)
        {
            if (!File.Exists(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG"))
                File.Create(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG").Close();
            string txt = "";
            txt += " [ ";
            txt += "INFO";
            txt += " ] ";
            for (int i = 0; i < offset - txt.Length; i++)
                txt += " ";
            txt += msg;
            File.AppendAllText(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG", txt + '\n');
        }
        public static void Warn(string msg, int offset = 10)
        {
            if (!File.Exists(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG"))
                File.Create(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG").Close();
            string txt = "";
            txt += " [ ";
            txt += "WARN";
            txt += " ] ";
            for (int i = 0; i < offset - txt.Length; i++)
                txt += " ";
            txt += msg;
            File.AppendAllText(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG", txt + '\n');
        }
        public static void NoCritErr(string msg, int offset = 10)
        {
            if (!File.Exists(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG"))
                File.Create(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG").Close();
            string txt = "";
            txt += " [ ";
            txt += "NCER";
            txt += " ] ";
            for (int i = 0; i < offset - txt.Length; i++)
                txt += " ";
            txt += msg;
            File.AppendAllText(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG", txt + '\n');
        }
        public static void CritErr(string msg, int offset = 10)
        {
            if (!File.Exists(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG"))
                File.Create(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG").Close();
            string txt = "";
            txt += " [ ";
            txt += "CERR";
            txt += " ] ";
            for (int i = 0; i < offset - txt.Length; i++)
                txt += " ";
            txt += msg;
            File.AppendAllText(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG", txt + '\n');
        }
        public static void FatErr(string msg, int offset = 10)
        {
            if (!File.Exists(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG"))
                File.Create(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG").Close();
            string txt = "";
            txt += " [ ";
            txt += "FERR";
            txt += " ] ";
            for (int i = 0; i < offset - txt.Length; i++)
                txt += " ";
            txt += msg;
            File.AppendAllText(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG", txt + '\n');
        }
        public static void Debg(string msg, int offset = 10)
        {
            if (!File.Exists(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG"))
                File.Create(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG").Close();
            string txt = "";
            txt += " [ ";
            txt += "DEBG";
            txt += " ] ";
            for (int i = 0; i < offset - txt.Length; i++)
                txt += " ";
            txt += msg;
            File.AppendAllText(DateTime.Today.ToShortDateString().Replace('/', '.') + ".LOG", txt + '\n');
        }
    }
}
