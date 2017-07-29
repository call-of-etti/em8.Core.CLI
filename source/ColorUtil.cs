using System;

namespace CoE.em8.Core.CLI
{
    public class ColorUtil
    {
        protected ConsoleColor backgroundColor;
        protected ConsoleColor foregroundColor;

        public void Restore()
        {
            Console.BackgroundColor = this.backgroundColor;
            Console.ForegroundColor = this.foregroundColor;
        }

        public void Save()
        {
            this.backgroundColor = Console.BackgroundColor;
            this.foregroundColor = Console.ForegroundColor;
        }

        public static void PrintError(params string[] errors)
        {
            var cu = new ColorUtil();
            cu.Save();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (var w in errors)
                Console.WriteLine(w);

            cu.Restore();
        }

        public static void PrintNotice(params string[] notices)
        {
            var cu = new ColorUtil();
            cu.Save();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (var w in notices)
                Console.WriteLine(w);

            cu.Restore();
        }

        public static void PrintStatus(params string[] statuses)
        {
            var cu = new ColorUtil();
            cu.Save();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var w in statuses)
                Console.WriteLine(w);

            cu.Restore();
        }

        public static void PrintWarning(params string[] warnings)
        {
            var cu = new ColorUtil();
            cu.Save();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach(var w in warnings)
                Console.WriteLine(w);

            cu.Restore();
        }
    }
}

