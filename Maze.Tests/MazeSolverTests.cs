using System;
using NUnit.Framework;

#pragma warning disable CA1707
#pragma warning disable S2368
#pragma warning disable CA1814

namespace Maze.Tests
{
    [TestFixture]
    public class MazeSolverTests
    {
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForMazePass))]
        public void PassMaze_SuccessfulTests(int[,] maze, int row, int column, (int, int)[] expected)
        {
            MazeSolver solver = new MazeSolver(maze, row, column);
            solver.PassMaze();
            var actual = solver.GetPath();
            Assert.AreEqual(actual, expected);
        }
        
        [Test]
        public void MazeSolverConstructor_MatrixIsNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new MazeSolver(null, 1, 2));

        [Test]
        public void MazeSolverConstructor_MatrixIsEmpty_ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => new MazeSolver(new int[,] { { } }, 1, 2));

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForCtor))]
        public void MazeSolverConstructor_RowStartLessThanZero_ThrowArgumentOutOfRangeException(int[,] maze)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new MazeSolver(maze, -12, 2));

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForCtor))]
        public void MazeSolverConstructor_ColumnStartLessThanZero_ThrowArgumentOutOfRangeException(int[,] mazeModel)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new MazeSolver(mazeModel, 0, -2));
        
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForCtor))]
        public void MazeSolverConstructor_RowStartThanMoreThanDimension_ThrowArgumentOutOfRangeException(int[,] maze)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new MazeSolver(maze, 100, 2));

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForCtor))]
        public void MazeSolverConstructor_ColumnStartMoreThanDimension_ThrowArgumentOutOfRangeException(int[,] mazeModel)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new MazeSolver(mazeModel, 0, 100));

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesNoPath))]
        public void PassMaze_NoPath_ThrowInvalidOperationException(int[,] mazeModel) 
            => Assert.Throws<InvalidOperationException>(() => new MazeSolver(mazeModel, 0, 1));

        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForGetPass))]
        public void GetPath_PassMazeMethodWasNotStarted_ThrowInvalidOperationException(int[,] mazeModel, int row, int column)
        {
            var maze = new MazeSolver(mazeModel, row, column);
            Assert.Throws<InvalidOperationException>(() => maze.GetPath());
        }
        
        [TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForGetPass))]
        public void GetExit_PassMazeMethodWasNotStarted_ThrowInvalidOperationException(int[,] mazeModel, int row, int column)
        {
            var maze = new MazeSolver(mazeModel, row, column);
            Assert.Throws<InvalidOperationException>(() => maze.GetExit());
        }
    }
}
