using System;
using System.Collections.Generic;

#pragma warning disable CA1814
#pragma warning disable S2368
#pragma warning disable CA1062 // Validate arguments of public methods (Не видит через проверку в switch expression) 

namespace Maze
{
    /// <summary>
    /// Class for finding exit out of a maze. It is assumed that the maze always has one entrance and only one exit (if any) and they are different.
    /// </summary>
    public class MazeSolver
    {
        private readonly bool[,] maze;
        private readonly (int rowStart, int columnStart) start;
        private List<(int row, int column)> solvePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="MazeSolver"/> class.
        /// </summary>
        /// <param name="maze">Presents a maze as two-dimensional zero-based matrix.</param>
        /// <param name="rowStart">The zero-based index of row of the start.</param>
        /// <param name="columnStart">The zero-based index of column of the start.</param>
        /// <exception cref="ArgumentNullException">Thrown if passed maze is null.</exception>
        /// <exception cref="ArgumentException">Thrown if passed maze is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if rowStart or columnStart are not in mazeModel:
        /// less than zero or more then number of elements in the dimension.</exception>
        public MazeSolver(bool[,] maze, int rowStart, int columnStart) => (this.start, this.maze) = (maze, rowStart, columnStart) switch
        {
            (null, _, _) => throw new ArgumentNullException(nameof(maze), "Thrown if passed maze is null."),
            (_, _, _) when maze.Length == 0 => throw new ArgumentException("Thrown if passed maze is empty.", nameof(maze)),
            (_, _, _) when rowStart < 0 || rowStart > maze.Length => throw new ArgumentOutOfRangeException(nameof(rowStart), "RowStart less than zero or more then number of elements in the dimension."),
            (_, _, _) when columnStart < 0 || columnStart > maze.Length => throw new ArgumentOutOfRangeException(nameof(columnStart), "ColumnStart less than zero or more then number of elements in the dimension."),
            _ => ((rowStart, columnStart), maze),
        };

        /// <summary>
        /// Starts an algorithm for finding shortest path.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the path does not exist.</exception>
        public void PassMaze()
        {
            if (this.solvePath is null)
            {
                Stack<(int row, int column)> steps = new Stack<(int row, int column)>();

                Step step = FindShortestPathLength(this.maze, this.start.rowStart, this.start.columnStart);
                do
                {
                    steps.Push((step.X, step.Y));
                    step = step.PreviousStep;
                }
                while (step != null);

                this.solvePath = new List<(int row, int column)>(steps);
            }
        }

        /// <summary>
        /// Gets the shortest path as a one-dimensional array of the pairs (row, column).
        /// </summary>
        /// <returns>
        /// The one-dimensional array of the pairs (row, column).
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if path finding algorithm wasn't started.
        /// </exception>
        public (int row, int column)[] GetPath()
        {
            if (this.solvePath is null)
            {
                throw new InvalidOperationException("Thrown if path finding algorithm wasn't started.");
            }

            return this.solvePath.ToArray();
        }
        
        /// <summary>
        /// Gets the pairs (row, column) - indexes of row and columns of exit from maze.
        /// </summary>
        /// <returns>
        /// The indexes of row and columns of exit from maze.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if path finding algorithm wasn't started.
        /// </exception>
        public (int row, int column) GetExit()
        {
            if (this.solvePath is null)
            {
                throw new InvalidOperationException("Thrown if path finding algorithm wasn't started.");
            }

            return this.solvePath[^1];
        }

        private static bool IsValidToGo(bool[,] maze, bool[,] visited, int row, int col)
        {
            return (row >= 0) && (row < maze.GetLength(0)) && (col >= 0) && (col < maze.GetLength(1))
                    && !maze[row, col] && !visited[row, col];
        }

        private static Step FindShortestPathLength(bool[,] maze, int currentRow, int currentColumn)
        {
            if (maze == null || maze.GetLength(0) == 0 || maze[currentRow, currentColumn])
            {
                throw new InvalidOperationException("Thrown if the path does not exist.");
            }

            int[] row = { -1, 0, 0, 1 };
            int[] col = { 0, -1, 1, 0 };

            int rowsLength = maze.GetLength(0);
            int columnsLength = maze.GetLength(1);

            bool[,] visited = new bool[rowsLength, columnsLength];

            Queue<Step> queue = new Queue<Step>();

            visited[currentRow, currentColumn] = true;
            queue.Enqueue(new Step(currentRow, currentColumn, null));

            while (queue.Count != 0)
            {
                Step step = queue.Dequeue();

                currentRow = step.X;
                currentColumn = step.Y;

                if ((currentRow == 0 || currentColumn == 0 || currentRow == maze.GetLength(0) - 1 || currentColumn == maze.GetLength(1) - 1) && !(step.PreviousStep is null))
                {
                    return step;
                }

                for (int i = 0; i < 4; i++)
                {
                    if (IsValidToGo(maze, visited, currentRow + row[i], currentColumn + col[i]))
                    {
                        visited[currentRow + row[i], currentColumn + col[i]] = true;
                        queue.Enqueue(new Step(currentRow + row[i], currentColumn + col[i], step));
                    }
                }
            }

            throw new InvalidOperationException("Thrown if the path does not exist.");
        }

        private class Step
        {
            public Step(int x, int y, Step previousStep)
            {
                this.X = x;
                this.Y = y;
                this.PreviousStep = previousStep;
            }

            public int X { get; }

            public int Y { get; }

            public Step PreviousStep { get; }
        }
    }
}
