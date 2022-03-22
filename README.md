# SudokuSolver

SudokuSolver is a command line tool to solve Sudokus. Common solving techniques are applied. These are sufficient to solve Sudokus up to an intermediate level of difficulty. If a Sudoku is too hard to be solved using the implemented techniques, a brute force approach will be applied, where numbers are picked recursively until a valid solution is found.

SudokuSolver takes two arguments in the command line, the first being '-f' and the second a path to a text file containing the Sudoku to be solved. Within this text file use the underscore _ to indicate a field in the Sudoku table which is not known and numbers 1-9 for fields whose values are given. All other characters are ignored.
