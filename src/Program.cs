using System;
using System.IO;

namespace SudokuSolver
{

    class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
            {
                Console.WriteLine("No arguments passed. Program exited.");
                return;
            }

            if (args.Length != 2)
            {
                Console.WriteLine("Wrong number of arguments passed. Program exited.");
                return;
            }

            if (args[0] == "-f")
            {
                if (!File.Exists(args[1]))
                {
                    Console.WriteLine("File " + args[1] + " not found. Program exited.");
                    return;
                }
            }
            else 
            {
                Console.WriteLine("Unknown argument " + args[0] + " passed. Program exited.");
                return;
            }

            SudokuTable mySudoku = new SudokuTable();

            if (!mySudoku.ReadIn(args[1]))
            {
                Console.WriteLine("File " + args[1] + " is not a valid Sudoku file. Program exited.");
                return;
            }

            DateTime start = new DateTime();
            start = DateTime.Now;

            mySudoku.Solve(false, true);
            
            Console.WriteLine("Time elapsed is: " + (DateTime.Now - start));
        }
    }
}