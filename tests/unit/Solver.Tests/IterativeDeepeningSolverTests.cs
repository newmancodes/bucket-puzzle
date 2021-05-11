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
            solveOutcome.Classification.Should().Be(SolutionOutcomeClassification.Solution);
            solveOutcome.Problem.Should().BeSameAs(problem);
        }

        [Fact]
        public void Tonys_Puzzle_Can_Be_Solved()
        {
            // Arrange
            var problem = new BucketPuzzleBuilder()
                .AddFullBucket(12)
                .AddEmptyBucket(8)
                .AddEmptyBucket(5)
                .CanRefill(true)
                .CanEmpty(true)
                .Build(6);
            var solver = new IterativeDeepeningSolver();

            // Act
            var solveOutcome = solver.Solve(problem);

            // Assert
            solveOutcome.Classification.Should().Be(SolutionOutcomeClassification.Solution);
            solveOutcome.Problem.Should().BeSameAs(problem);
        }

        [Fact]
        public void Tonys_Puzzle_Can_Be_Solved_Stricly()
        {
            // Arrange
            var problem = new BucketPuzzleBuilder()
                .AddFullBucket(12)
                .AddEmptyBucket(8)
                .AddEmptyBucket(5)
                .CanRefill(false)
                .CanEmpty(false)
                .Build(6);
            var solver = new IterativeDeepeningSolver();

            // Act
            var solveOutcome = solver.Solve(problem);

            // Assert
            solveOutcome.Classification.Should().Be(SolutionOutcomeClassification.Solution);
            solveOutcome.Problem.Should().BeSameAs(problem);
        }
    }
}