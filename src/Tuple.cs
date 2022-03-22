using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    internal class Tuple
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        public int val1;
        public int val2;
        public int index;

        public static bool operator ==(Tuple A, Tuple B)
        {
            if ((A.val1 == B.val1) & (A.val2 == B.val2))
                return true;
            else
                return false;
        }
        public static bool operator !=(Tuple A, Tuple B)
        {
            if (A == B)
                return false;
            else
                return true;
        }
    }

}
