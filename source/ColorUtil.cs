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

        public static void PrintWarning(params string[] warnings)
        {
            var cu = new ColorUtil();
            cu.Save();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            foreach(var w in warnings)
                Console.WriteLine(w);

            cu.Restore();
        }
    }
}

