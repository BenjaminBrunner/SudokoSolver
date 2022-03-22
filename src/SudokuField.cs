using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{

    internal class SudokuField
    {
        private List<int> PossibleNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public SudokuField()
        {
        }
        public SudokuField(int Number)
        {
            SolveSudokoField(Number);
        }

        public int SolveSudokoField(int Number)
        {
            if (IsSolved())
                return 0;

            int count = PossibleNumbers.Count - 1;
            PossibleNumbers.Clear();
            PossibleNumbers.Add(Number);
            return count;
        }
        public void SolveSudokoField()
        {
        }

        public int RemovePossibleNumber(int NumberToRemove)
        {
            if (IsSolved())
                return 0;

            if (PossibleNumbers.Remove(NumberToRemove))
                return 1;
            else
                return 0;
        }

        public bool IsSolved()
        {
            if (PossibleNumbers.Count == 1)
                return true;
            else
                return false;
        }

        public bool IsPair()
        {
            if (PossibleNumbers.Count == 2)
                return true;
            else
                return false;
        }

        public Tuple ReturnPair(int ind)
        {
            return new Tuple { val1 = PossibleNumbers[0], val2 = PossibleNumbers[1], index = ind };
        }

        public int GetSolution()
        {
            return PossibleNumbers[0];
        }

        public string PrintCandidates()
        {
            if (IsSolved())
                return "(    " + GetSolution() + "    )";

            string myStr = "(";
            string Separator = "_";

            for (int i = 1; i < 10; i++)
            {
                if (PossibleNumbers.Contains(i))
                    myStr += i;
                else
                    myStr += Separator;
            }

            return myStr += ")";
        }

        public bool Contains(int number)
        {
            return PossibleNumbers.Contains(number);
        }

        public int ReturnSize() 
        {
            return PossibleNumbers.Count;
        }
        public int[] ReturnCandidateArray() 
        {
            return PossibleNumbers.ToArray();
        }

        public void IngestCandidateArray(int[] Candidates) 
        {
            PossibleNumbers.Clear();
            foreach(int i in Candidates)
                PossibleNumbers.Add(i);
        }
    }
}
