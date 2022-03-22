using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    public partial class SudokuTable
    {
        private const int SudokuFieldsLength = 81;
        private SudokuField[] SudokuFields = new SudokuField[SudokuFieldsLength];
        private readonly int[][] IsSeeing = new int[SudokuFieldsLength][];

        private readonly int[] BlockStartIndices     = new int[] { 0, 3, 6, 27, 30, 33, 54, 57, 60 };
        private readonly int[] BlockOffsets          = new int[] { 0, 1, 2, 9, 10, 11, 18, 19, 20 };
        private readonly int[] BlockOffsets_vertical = new int[] { 0, 9, 18, 1, 10, 19, 2, 11, 20 };
        private readonly int[] RowStartIndices       = new int[] { 0, 9, 18, 27, 36, 45, 54, 63, 72 };
        private readonly int[] RowOffsets            = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        private readonly int[] ColumnStartIndices    = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        private readonly int[] ColumnOffsets         = new int[] { 0, 9, 18, 27, 36, 45, 54, 63, 72 };
        private void InitializeIsSeeingArray()
        {
            for (int i = 0; i < SudokuFieldsLength; i++)
            {
                IsSeeing[i] = FieldsToCheck(i).ToArray();
            }
        }

        public SudokuTable()
        {
            InitializeIsSeeingArray();
            FillSudokuTable_2();
        }

        private int ApplySolvingTechniques(bool BeVerbose) 
        {
            int RemCandClean;
            int RemCandPair;
            int RemCandLBC;
            int RemNkdCand;
            int RemBLC;
            
            do
            {

                RemCandClean = CleanSudokuTable();
                if ((RemCandClean > 0) & BeVerbose)
                {
                    Console.WriteLine("Initally cleaning Sudoku removed " + RemCandClean);
                }

                RemCandPair = RemovePairs();
                if (RemCandPair > 0)
                    RemCandPair += CleanSudokuTable();
                if ((RemCandPair > 0) & BeVerbose)
                {
                    Console.WriteLine("Removing pairs removed " + RemCandPair);
                }

                RemCandLBC = LineBlockCheck();
                if (RemCandLBC > 0)
                    RemCandLBC += CleanSudokuTable();
                if ((RemCandLBC > 0) & BeVerbose)
                {
                    Console.WriteLine("Performing line block checks removed " + RemCandLBC);
                }

                RemBLC = BlockLineCheck();
                if (RemBLC > 0)
                    RemBLC += CleanSudokuTable();
                if ((RemBLC > 0) & BeVerbose)
                {
                    Console.WriteLine("Performing block line checks removed " + RemBLC);
                }

                RemNkdCand = RemoveNakedCandidates();
                if (RemNkdCand > 0)
                    RemNkdCand += CleanSudokuTable();
                if ((RemNkdCand > 0) & BeVerbose)
                {
                    Console.WriteLine("Solving naked fields removed " + RemNkdCand);
                }

            } while ((RemCandPair + RemCandClean + RemCandLBC + RemNkdCand + RemBLC) > 0);

            if (AllFieldsCleared())
            {
                if (IsSolutionValid())
                    return 0;
                else
                    return 2;
            }
            else
            {
                return 1;
            }


        }

        private int[][] CreateTableCopy() 
        {
            int[][] TableCopy = new int[SudokuFieldsLength][];
            for (int i = 0; i < SudokuFieldsLength; i++) 
            {
                TableCopy[i] = SudokuFields[i].ReturnCandidateArray();
            }
            return TableCopy;
        }

        private void RestoreTable(int[][] TableCopy) 
        {
            for (int i = 0; i < SudokuFieldsLength; i++)
            {
                SudokuFields[i].IngestCandidateArray(TableCopy[i]);
            }
        }

        private int GetShortestField()
        {
            int Length = 10;
            int Index = 0;

            for (int i = 0; i < SudokuFieldsLength; i++)
            {
                int Size = SudokuFields[i].ReturnSize();

                if (Size == 1) // solved fields are not considered
                    continue;
                if (Size == 2) // cannot be shorter than 2 anyways
                    return i;
                if (Size < Length)
                {
                    Length = SudokuFields[i].ReturnSize();
                    Index = i;
                }
            }

            return Index;
        }

        private bool SolvingWithBruteForce() 
        {
            int[][] TableCopy = CreateTableCopy();
            int Index = GetShortestField();
            int[] CandidateArray = SudokuFields[Index].ReturnCandidateArray();

            foreach (int Candidate in CandidateArray) 
            {
                SudokuFields[Index].SolveSudokoField(Candidate);

                switch (ApplySolvingTechniques(false))
                {
                    case 0: // solved
                    {
                        return true;
                    }
                    case 1: // not all fields cleared
                    {
                        if (SolvingWithBruteForce())
                            return true; 
                        else
                            break;
                    }
                    case 2: // all fields cleared but invalid
                    {
                        break;
                    }
                }

                RestoreTable(TableCopy);
            }

            return false; 
        }

        public bool ReadIn(string FileName) 
        {
            if (!System.IO.File.Exists(FileName))
                return false;

            StringBuilder FileContent = new StringBuilder();
            List<int> RawSukodu = new List<int> { };

            foreach (string line in System.IO.File.ReadLines(FileName))
                FileContent.Append(line);

            for (int i = 0; i < FileContent.Length; i++)
            {
                char ch = FileContent[i];

                if (Char.IsDigit(ch))
                    RawSukodu.Add((int)Char.GetNumericValue(ch));

                if (ch == '_')
                    RawSukodu.Add(0);
            }

            if (RawSukodu.Count != SudokuFieldsLength)
                return false;

            for (int i = 0; i < SudokuFieldsLength; i++)
            {
                SudokuFields[i] = new SudokuField();

                if (RawSukodu[i] != 0)
                    SudokuFields[i].SolveSudokoField(RawSukodu[i]);
            }

            return true;
        }

        public bool Solve(bool BeVerbose, bool ApplyBruteForce)
        {
            Console.WriteLine("Sudoku to be solved:");
            PrintSudokuTable();

            switch (ApplySolvingTechniques(BeVerbose))
            {
                case 0:
                {
                    Console.WriteLine("Result is:");
                    PrintSudokuTable();
                    return true;
                }
                case 1:
                {
                    if (ApplyBruteForce)
                    {
                        if (SolvingWithBruteForce())
                        {
                            Console.WriteLine("Result is (using brute force):");
                            PrintSudokuTable();
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("This Sudoku cannot be solved using brute force.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not all fields could be solved. You might try using brute force.");
                        PrintSudokuTableWithCandidates();
                        return false;
                    }
                }
                case 2:
                {
                    Console.WriteLine("This Sudoku cannot be solved.");
                    return false;
                }
            }
            
            return false; // is never executed
        }

        private bool IsSolutionValid() 
        {
            // if not yet solved, exit and return false
            if (!AllFieldsCleared())
                return false;

            // blocks
            foreach (int start in BlockStartIndices)
            {
                int counter = 0;
                foreach (int off in BlockOffsets) 
                    counter += (int)Math.Pow(10, SudokuFields[start + off].GetSolution()-1) ;

                if (!(counter == 111111111))
                    return false;      
            }

            // rows
            foreach (int start in RowStartIndices)
            {
                int counter = 0;
                foreach (int off in RowOffsets)
                    counter += (int)Math.Pow(10, SudokuFields[start + off].GetSolution() - 1);

                if (!(counter == 111111111))
                    return false;
            }

            // columns
            foreach (int start in ColumnStartIndices)
            {
                int counter = 0;
                foreach (int off in ColumnOffsets)
                    counter += (int)Math.Pow(10, SudokuFields[start + off].GetSolution() - 1);

                if (!(counter == 111111111))
                    return false;
            }

            return true;
        }

        private List<int> FieldsToCheck(int SudokoFieldNumber) 
        {
            List<int> Indices = new List<int> {};

            // the row
            int lower = (SudokoFieldNumber / 9) * 9;
            int upper = (SudokoFieldNumber / 9 + 1) * 9 - 1;
            for (int i = lower; i <= upper; i++)
            {
                if (i != SudokoFieldNumber) 
                    Indices.Add(i);
            }

            // the column
            lower = (SudokoFieldNumber % 9);
            for (int i = lower; i <= 80; i += 9)
            {
                if (i != SudokoFieldNumber) 
                    Indices.Add(i);
            }

            // the block
            lower = SudokoFieldNumber - (SudokoFieldNumber % 3);
            lower -= ((SudokoFieldNumber % 27) / 9) * 9;
            foreach (int j in new List<int> { 0, 1, 2, 9, 10, 11, 18, 19, 20 })
            {
                int i = lower + j;
                if ((i != SudokoFieldNumber) && !Indices.Contains(i))
                    Indices.Add(i);
            }

            return Indices;
        }

        private bool AllFieldsCleared()
        {
            for (int i = 0; i < SudokuFieldsLength; i++)
            {
                if (!SudokuFields[i].IsSolved())
                    return false;
            }

            return true;
        }

        private int CleanCandidates(int Index) 
        {
            // only if the current field is solved candidates can be removed in the respective area
            if (!SudokuFields[Index].IsSolved())
                return 0;

            int RemovedCandidates = 0;
            int NumberToRemove = SudokuFields[Index].GetSolution();

            foreach (int Targets in IsSeeing[Index])
            {
                // if the field has been solved already leave loop
                if (SudokuFields[Targets].IsSolved())
                    continue;

                RemovedCandidates += SudokuFields[Targets].RemovePossibleNumber(NumberToRemove);
                // if by removing the candidates a field has been solved, the function is called recursively
                if (SudokuFields[Targets].IsSolved())
                    RemovedCandidates += CleanCandidates(Targets);
            }

            return RemovedCandidates;
        }

        private int CleanSudokuTable()
        {
            int RemovedCandidates = 0;

            for (int i = 0; i < SudokuFields.Length; i++)
                RemovedCandidates += CleanCandidates(i);

            return RemovedCandidates;

        }

        private int RemovePairs()
        {
            int DeletedCandidates = 0;
            DeletedCandidates += RemovePairs(BlockStartIndices, BlockOffsets);
            DeletedCandidates += RemovePairs(RowStartIndices, RowOffsets);
            DeletedCandidates += RemovePairs(ColumnStartIndices, ColumnOffsets);

            return DeletedCandidates;
        }

        private int RemovePairs(int[] StartInidices, int[] Steps)
        {
            List<Tuple> Tuples = new List<Tuple> { };
            Tuple CurrentTuple;
            int RemovedCandidates = 0;

            // loop blocks for pairs
            foreach (int start in StartInidices)
            {
                // reset before each block
                Tuples.Clear();

                // loop each field in current block and store tuples
                foreach (int off in Steps)
                {
                    if (SudokuFields[start + off].IsPair())
                        Tuples.Add(SudokuFields[start + off].ReturnPair(start + off));
                }

                // check for duplicate tuples and remove candidates
                for (int tup = 0; tup < Tuples.Count; tup++)
                {
                    // store current tuple and step through rest of list
                    CurrentTuple = Tuples[tup];
                    for (int rest_tup = tup + 1; rest_tup < Tuples.Count; rest_tup++)
                    {
                        // if matching tuple is found, remove the candidates from other fields
                        if (CurrentTuple == Tuples[rest_tup])
                        {
                            foreach (int k in Steps)
                            {
                                if (((start + k) != CurrentTuple.index) &
                                    ((start + k) != Tuples[rest_tup].index))
                                {
                                    RemovedCandidates += SudokuFields[start + k].RemovePossibleNumber(CurrentTuple.val1);
                                    RemovedCandidates += SudokuFields[start + k].RemovePossibleNumber(CurrentTuple.val2);
                                }
                            }
                        }

                    }
                }

            }

            return RemovedCandidates;
        }

        private int RemoveNakedCandidates()
        {
            int DeletedCandidates = 0;
            DeletedCandidates += RemoveNakedCandidates(BlockStartIndices, BlockOffsets);
            DeletedCandidates += RemoveNakedCandidates(RowStartIndices, RowOffsets);
            DeletedCandidates += RemoveNakedCandidates(ColumnStartIndices, ColumnOffsets);

            return DeletedCandidates;
        }

        private int RemoveNakedCandidates(int[] StartInidices, int[] Steps)
        {
            int removedCandidates = 0;

            foreach (int start in StartInidices)
            {
                // check every number 1 to 9 for their occurences
                foreach (int number in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })
                {
                    int Index = -1;
                    int Hits = 0;

                    foreach (int off in Steps)
                    {
                        // ....
                        if (SudokuFields[start + off].Contains(number))
                        {
                            Index = start + off;
                            Hits++;
                        }
                    }

                    if (Hits == 1)
                        removedCandidates += SudokuFields[Index].SolveSudokoField(number);
                }
            }

            return removedCandidates;
        }

        private int LineBlockCheck()
        {
            int DeletedCandidates = 0;
            DeletedCandidates += LineBlockCheck(RowStartIndices, RowOffsets);
            DeletedCandidates += LineBlockCheck(ColumnStartIndices, ColumnOffsets);

            return DeletedCandidates;
        }

        private int LineBlockCheck(int[] StartInidices, int[] Steps) 
        {
            int RemovedCandidates = 0;

            // for every number that only appears in one block when cheking row by row or column by column
            // delete the candidates from the other fields in the block

            // loop through all lines or rowes
            foreach (int start in StartInidices) 
            {
                // check every number 1 to 9 for their occurences
                foreach (int number in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9})
                {
                    bool InFirstBlock = false;
                    bool InSecondBlock = false;
                    bool InThirdBlock = false;

                    // loop through every element in each line or row
                    foreach (int off in Steps)
                    {
                        // Bools to track in which blocks the numbers are located
                        if (SudokuFields[start + off].Contains(number))
                        {
                            if ((Array.IndexOf(Steps, off)) < 3)
                                InFirstBlock = true;
                            else if ((Array.IndexOf(Steps, off)) < 6)
                                InSecondBlock = true;
                            else
                                InThirdBlock = true;
                        }
                    }

                    // if there is not just only one true leave and continue
                    if (!( ( InFirstBlock & !InSecondBlock & !InThirdBlock) |
                           (!InFirstBlock &  InSecondBlock & !InThirdBlock) |
                           (!InFirstBlock & !InSecondBlock &  InThirdBlock) ))
                        continue;

                    // determine which block, index 1
                    int x;
                    if (InFirstBlock)
                        x = 0;
                    else if (InSecondBlock)
                        x = 1;
                    else
                        x = 2;

                    // determine which block, index 2
                    int y = Array.IndexOf(StartInidices, start) / 3;

                    // get the affected cells if rows are being checked
                    List<int> IndexesToRemoveFrom = new List<int> { };
                    if (Array.Exists(StartInidices, i => i > 8))
                    {
                        // get the start index of the the block to remove from
                        int block_start = BlockStartIndices[x + y * 3];

                        // fill the array with the field indexes in the respective block
                        foreach (int off in BlockOffsets)
                            IndexesToRemoveFrom.Add(block_start + off);

                        // the fields of the determined block which are also in the current row must not be in the list of indexes to remove from
                        for (int i = 0; i < 3; i++)
                            IndexesToRemoveFrom.RemoveAt((Array.IndexOf(StartInidices, start) % 3) * 3);
                    }
                    // get the affected cells if columns are being checked
                    else
                    {
                        // get the start index of the the block to remove from
                        int block_start = BlockStartIndices[x * 3 + y];

                        // fill the array with the field indexes in the respective block
                        foreach (int off in BlockOffsets)
                            IndexesToRemoveFrom.Add(block_start + off);

                        // the fiels of the determined block which are also in the current column must not be in the list of indexes to remove from
                        for (int i = 0; i < 3; i++)
                            IndexesToRemoveFrom.RemoveAt((Array.IndexOf(StartInidices, start) % 3) + i * 2);
                    }

                    // Remove the candidates
                    foreach (int ind in IndexesToRemoveFrom)
                        RemovedCandidates += SudokuFields[ind].RemovePossibleNumber(number);
                }
            
            }
            return RemovedCandidates;
        }

        private int BlockLineCheck()
        {
            int DeletedCandidates = 0;
            DeletedCandidates += BlockLineCheck(BlockStartIndices, BlockOffsets);
            DeletedCandidates += BlockLineCheck(BlockStartIndices, BlockOffsets_vertical);

            return DeletedCandidates;
        }

        private int BlockLineCheck(int[] StartInidices, int[] Steps) 
        {
            int RemovedCandidates = 0;

            // loop through all lines or rowes
            foreach (int start in StartInidices)
            {
                // check every number 1 to 9 for their occurences
                foreach (int number in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })
                {
                    bool InFirstTriple = false;
                    bool InSecondTriple = false;
                    bool InThirdTriple = false;

                    // loop through every element in each line or row
                    foreach (int off in Steps)
                    {
                        // Bools to track in which blocks the numbers are located
                        if (SudokuFields[start + off].Contains(number))
                        {
                            if ((Array.IndexOf(Steps, off)) < 3)
                                InFirstTriple = true;
                            else if ((Array.IndexOf(Steps, off)) < 6)
                                InSecondTriple = true;
                            else
                                InThirdTriple = true;
                        }
                    }

                    // if there is not just only one true leave and continue
                    if (!( (InFirstTriple  & !InSecondTriple & !InThirdTriple) |
                           (!InFirstTriple &  InSecondTriple & !InThirdTriple) |
                           (!InFirstTriple & !InSecondTriple &  InThirdTriple) ))
                        continue;

                    // determine which row, index 1
                    int x;
                    if (InFirstTriple)
                        x = 0;
                    else if (InSecondTriple)
                        x = 1;
                    else
                        x = 2;

                    // ...
                    List<int> IndexesToRemoveFrom = new List<int> { };
                    if (Steps[1] == 1)
                    {
                        // determine which row, index 2
                        int y = (Array.IndexOf(StartInidices, start) / 3);

                        // get the start index of the the row to remove from
                        int row_start = (y * 27 ) + (x * 9);

                        // fill the array with the field indexes of the row
                        for (int i = 0; i < 9; i++)
                            IndexesToRemoveFrom.Add(row_start + i);

                        // the fields of the determined row which are also in the current block must not be in the list of indexes to remove from
                        for (int i = 0; i < 3; i++)
                            IndexesToRemoveFrom.RemoveAt((Array.IndexOf(StartInidices, start) % 3) * 3);
                    }
                    // ...
                    else
                    {
                        // determine which column, index 2
                        int y = (Array.IndexOf(StartInidices, start) % 3) * 3;

                        // get the start index of the the row to remove from
                        int row_start = x + y;

                        // fill the array with the field indexes of the row
                        for (int i = 0; i < 81; i+=9)
                            IndexesToRemoveFrom.Add(row_start + i);

                        // the fields of the determined column which are also in the current block must not be in the list of indexes to remove from
                        for (int i = 0; i < 3; i++)
                            IndexesToRemoveFrom.RemoveAt((Array.IndexOf(StartInidices, start) / 3) * 3);
                    }

                    // Remove the candidates
                    foreach (int ind in IndexesToRemoveFrom)
                        RemovedCandidates += SudokuFields[ind].RemovePossibleNumber(number);
                }

            }
            return RemovedCandidates;
        }

        private void PrintSudokuTableWithCandidates()
        {
            string myLine = "";
            string Separator;

            for (int i = 0; i < SudokuFieldsLength; i++)
            {

                if ((i + 1) % 3 == 0)
                    Separator = "   ";
                else
                    Separator = " ";

                myLine += SudokuFields[i].PrintCandidates() + Separator;

                if ((i + 1) % 9 == 0)
                {
                    Console.WriteLine(myLine);
                    myLine = "";
                }

                if ( ((i + 1) % 27 == 0) & ((i + 1) != SudokuFieldsLength) )
                    Console.WriteLine("");

            }

        }

        private void PrintSudokuTable()
        {
            string myLine = "";
            string Separator;

            Console.WriteLine("");

            for (int i = 0; i < SudokuFieldsLength; i++)
            {

                if (((i + 1) % 3 == 0) & ((i + 1) % 9 != 0))
                    Separator = " | ";
                else
                    Separator = " ";

                if (SudokuFields[i].IsSolved())
                    myLine += SudokuFields[i].GetSolution() + Separator;
                else
                    myLine += "_" + Separator;

                if ((i + 1) % 9 == 0)
                {
                    Console.WriteLine(myLine);
                    myLine = "";
                }

                if (((i + 1) % 27 == 0) & ((i + 1) != SudokuFieldsLength))
                    Console.WriteLine("");
            }

            Console.WriteLine("");
        }
    }
}
