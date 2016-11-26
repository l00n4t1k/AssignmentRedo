using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanFiler
{
    class Program
    {

        static Filer TheFiler;
        static iFileable TheFileable;

        static void Main(string[] args)
        {
            TheFiler = new Filer();
            TheFileable = new Fileable(TheFiler);

            Console.WriteLine(Parts.Wall + " " + (char)Parts.Wall);
            Console.WriteLine(Parts.Goal + " " + (char)Parts.Goal);
            Console.WriteLine(Parts.Player + " " + (char)Parts.Player);
            Console.WriteLine(Parts.PlayerOnGoal + " " + (char)Parts.PlayerOnGoal);
            Console.WriteLine(Parts.Block + " " + (char)Parts.Block);
            Console.WriteLine(Parts.BlockOnGoal + " " + (char)Parts.BlockOnGoal);
            Console.WriteLine(Parts.Empty + " " + (char)Parts.Empty);

            Console.WriteLine("Do you want to save or load? (Enter 'S' or 'L')");
            string slin = Console.ReadLine();
            Console.WriteLine("Enter the name of the file you wish to load without the extension.");
            string fname = Console.ReadLine();

            if (slin.ToUpper() == "S")
                TheFiler.Save(fname);
            else if (slin.ToUpper() == "L")
            {
                Console.WriteLine("Enter the level number to be loaded.");
                string lnum = Console.ReadLine();
                int c = 0;
                if (int.TryParse(lnum, out c))
                {
                    TheFiler.Load(fname);
                }
                else
                {
                    Console.WriteLine("That is not a number. Exiting");
                }
            }

            Console.ReadKey();
        }
    }
}
