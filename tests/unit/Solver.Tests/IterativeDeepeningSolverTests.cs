using FluentAssertions;
using Xunit;

namespace Solver.Tests
{
    public class IterativeDeepeningSolverTests
    {
        [Fact]
        public void The_Die_Hard_with_a_Vengeance_Puzzle_Can_Be_Solved()
        {
            // Arrange
            var problem = new BucketPuzzleBuilder()
                .AddEmptyBucket(5)
                .AddEmptyBucket(3)
                .CanRefill(true)
                .CanEmpty(true)
                .Build(4);
            var solver = new IterativeDeepeningSolver();

            // Act
            var solveOutcome = solver.Solve(problem);

            // Assert
            solveOutcome.SolutionFound.Should().BeTrue();
        }
    }
}