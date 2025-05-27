using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOLS
{
    public class Message
    {
        public string Text { get; set; }
        public string Title { get; set; }
        public ConsoleColor TitleColor { get; set; }
        public int Offset { get; set; } = 10;
        public bool Endl { get; set; } = true;

        public void Display()
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = TitleColor;
            System.Console.Write(Title);
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < Offset - (6 + Title.Length); i++)
                System.Console.Write(" ");
            System.Console.Write(Text);
            if (Endl)
                System.Console.WriteLine();
        }

        public static void Custom(string msg, string title, ConsoleColor titleColor)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = titleColor;
            System.Console.Write(title);
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - (6 + title.Length); i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            System.Console.WriteLine();
        }
        public static void Custom(string msg, string title, ConsoleColor titleColor, bool endl)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = titleColor;
            System.Console.Write(title);
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - (6 + title.Length); i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }
        public static void Custom(string msg, string title, ConsoleColor titleColor, bool endl, int offset)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = titleColor;
            System.Console.Write(title);
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - (6 + title.Length); i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }

        public static void Succ(string msg)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.Write("SUCC");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            System.Console.WriteLine();
        }
        public static void Succ(string msg, bool endl)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.Write("SUCC");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }
        public static void Succ(string msg, bool endl, int offset)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.Write("SUCC");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }

        public static void Info(string msg)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.Write("INFO");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            System.Console.WriteLine();
        }
        public static void Info(string msg, bool endl)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.Write("INFO");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }
        public static void Info(string msg, bool endl, int offset)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.Write("INFO");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }

        public static void Warn(string msg)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.Write("WARN");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            System.Console.WriteLine();
        }
        public static void Warn(string msg, bool endl)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.Write("WARN");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }
        public static void Warn(string msg, bool endl, int offset)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.Write("WARN");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }

        public static void NoCritErr(string msg)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("NCER");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            System.Console.WriteLine();
        }
        public static void NoCritErr(string msg, bool endl)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("NCER");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }
        public static void NoCritErr(string msg, bool endl, int offset)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("NCER");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }

        public static void CritErr(string msg)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.Write("CERR");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            System.Console.WriteLine();
        }
        public static void CritErr(string msg, bool endl)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.Write("CERR");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }
        public static void CritErr(string msg, bool endl, int offset)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.Write("CERR");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }

        public static void FatErr(string msg)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkMagenta;
            System.Console.Write("FERR");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            System.Console.WriteLine();
        }
        public static void FatErr(string msg, bool endl)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkMagenta;
            System.Console.Write("FERR");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }
        public static void FatErr(string msg, bool endl, int offset)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkMagenta;
            System.Console.Write("FERR");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }

        public static void Debg(string msg)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write("DEBG");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            System.Console.WriteLine();
        }
        public static void Debg(string msg, bool endl)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write("DEBG");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10 - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
        }
        public static void Debg(string msg, bool endl, int offset)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" [ ");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write("DEBG");
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.Write(" ] ");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < offset - 10; i++)
                System.Console.Write(" ");
            System.Console.Write(msg);
            if (endl)
                System.Console.WriteLine();
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
