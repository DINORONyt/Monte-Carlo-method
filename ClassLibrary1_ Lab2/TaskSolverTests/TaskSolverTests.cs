using System;
using System.Drawing;
using System.Linq;
using ClassLibrary1_Lab2;
using Xunit;

namespace ClassLibrary1_Lab2.Tests
{
    public class TaskSolverTests
    {
        private readonly TaskSolver _solver;

        public TaskSolverTests()
        {
            _solver = new TaskSolver();
        }

        #region Задача 1: Проверка попадания точки в круг

        [Fact]
        public void CheckPoint_PointInsideCircle_ReturnsInside()
        {
            // Arrange
            double pointX = 0, pointY = 0;
            double circleX = 0, circleY = 0;
            double radius = 5;

            // Act
            string result = _solver.CheckPoint(pointX, pointY, circleX, circleY, radius, out Color color);

            // Assert
            Assert.Equal("Точка ВНУТРИ круга", result);
            Assert.Equal(Color.Green, color);
        }

        [Fact]
        public void CheckPoint_PointOnCircle_ReturnsOnBoundary()
        {
            // Arrange
            double pointX = 3, pointY = 4;
            double circleX = 0, circleY = 0;
            double radius = 5; // 3² + 4² = 9 + 16 = 25 = 5²

            // Act
            string result = _solver.CheckPoint(pointX, pointY, circleX, circleY, radius, out Color color);

            // Assert
            Assert.Equal("Точка НА окружности", result);
            Assert.Equal(Color.Orange, color);
        }

        [Fact]
        public void CheckPoint_PointOutsideCircle_ReturnsOutside()
        {
            // Arrange
            double pointX = 10, pointY = 10;
            double circleX = 0, circleY = 0;
            double radius = 5;

            // Act
            string result = _solver.CheckPoint(pointX, pointY, circleX, circleY, radius, out Color color);

            // Assert
            Assert.Equal("Точка СНАРУЖИ круга", result);
            Assert.Equal(Color.Red, color);
        }

        [Fact]
        public void CheckPoint_PointOnCircleWithOffset_ReturnsOnBoundary()
        {
            // Arrange
            double pointX = 5, pointY = 3;
            double circleX = 2, circleY = 3;
            double radius = 3; // (5-2)² + (3-3)² = 9 = 3²

            // Act
            string result = _solver.CheckPoint(pointX, pointY, circleX, circleY, radius, out Color color);

            // Assert
            Assert.Equal("Точка НА окружности", result);
        }

        [Fact]
        public void CheckPoint_NegativeRadius_ThrowsArgumentException()
        {
            // Arrange
            double pointX = 0, pointY = 0;
            double circleX = 0, circleY = 0;
            double radius = -5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                _solver.CheckPoint(pointX, pointY, circleX, circleY, radius, out Color _));
        }

        [Fact]
        public void CheckPoint_ZeroRadius_ThrowsArgumentException()
        {
            // Arrange
            double radius = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                _solver.CheckPoint(0, 0, 0, 0, radius, out Color _));
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 1, "Точка ВНУТРИ круга")]
        [InlineData(0.5, 0.5, 0, 0, 1, "Точка ВНУТРИ круга")]
        [InlineData(1, 0, 0, 0, 1, "Точка НА окружности")]
        [InlineData(0, 1, 0, 0, 1, "Точка НА окружности")]
        [InlineData(2, 0, 0, 0, 1, "Точка СНАРУЖИ круга")]
        [InlineData(1.5, 1.5, 0, 0, 1, "Точка СНАРУЖИ круга")]
        public void CheckPoint_VariousPoints_ReturnsCorrectPosition(
            double px, double py, double cx, double cy, double r, string expected)
        {
            // Act
            string result = _solver.CheckPoint(px, py, cx, cy, r, out Color _);

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion

        #region Задача 2: Метод Монте-Карло

        [Fact]
        public void Simulate_PositivePointCount_ReturnsValidResult()
        {
            // Arrange
            int pointCount = 1000;

            // Act
            var result = _solver.Simulate(pointCount);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pointCount, result.Total);
            Assert.InRange(result.Inside, 0, pointCount);
            Assert.InRange(result.Pi, 2.5, 4.0); // π должно быть в разумных пределах
        }

        [Fact]
        public void Simulate_LargePointCount_PiApproximationImproves()
        {
            // Arrange
            int pointCount = 100000;
            const double pi = 3.14159265358979;
            const double tolerance = 0.05; // ±0.05

            // Act
            var result = _solver.Simulate(pointCount);

            // Assert
            double difference = Math.Abs(result.Pi - pi);
            Assert.True(difference < tolerance,
                $"Pi {result.Pi} differs from actual pi {pi} by {difference}, expected < {tolerance}");
        }

        [Fact]
        public void Simulate_ZeroPointCount_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _solver.Simulate(0));
        }

        [Fact]
        public void Simulate_NegativePointCount_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _solver.Simulate(-100));
        }

        [Fact]
        public void Simulate_SmallPointCount_ReturnsResult()
        {
            // Arrange
            int pointCount = 10;

            // Act
            var result = _solver.Simulate(pointCount);

            // Assert
            Assert.Equal(pointCount, result.Total);
            Assert.NotNull(result.Points);
            Assert.Equal(pointCount, result.Points.Count);
        }

        [Fact]
        public void Simulate_PointsHaveCorrectCoordinates()
        {
            // Arrange
            int pointCount = 100;

            // Act
            var result = _solver.Simulate(pointCount);

            // Assert
            foreach (var point in result.Points)
            {
                Assert.InRange(point.X, -1.0, 1.0);
                Assert.InRange(point.Y, -1.0, 1.0);
            }
        }

        [Fact]
        public void Simulate_InsidePointsCalculatedCorrectly()
        {
            // Arrange
            int pointCount = 1000;

            // Act
            var result = _solver.Simulate(pointCount);

            // Assert
            int actualInsideCount = result.Points.Count(p => p.IsInside);
            Assert.Equal(result.Inside, actualInsideCount);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Simulate_DifferentPointCounts_ReturnsCorrectTotal(int pointCount)
        {
            // Act
            var result = _solver.Simulate(pointCount);

            // Assert
            Assert.Equal(pointCount, result.Total);
            Assert.Equal(pointCount, result.Points.Count);
        }

        #endregion

        #region Задача 3: Визуализация

        [Fact]
        public void CreateVisualization_ValidData_ReturnsNonNullBitmap()
        {
            // Arrange
            var data = _solver.Simulate(100);
            int width = 400;
            int height = 400;

            // Act
            var bitmap = _solver.CreateVisualization(data, width, height);

            // Assert
            Assert.NotNull(bitmap);
            Assert.IsType<Bitmap>(bitmap);
        }

        [Fact]
        public void CreateVisualization_CorrectDimensions_ReturnsBitmapWithSpecifiedSize()
        {
            // Arrange
            var data = _solver.Simulate(100);
            int width = 500;
            int height = 300;

            // Act
            var bitmap = _solver.CreateVisualization(data, width, height);

            // Assert
            Assert.Equal(width, bitmap.Width);
            Assert.Equal(height, bitmap.Height);
        }

        [Fact]
        public void CreateVisualization_EmptyData_ReturnsValidBitmap()
        {
            // Arrange
            var data = new SimulationResult
            {
                Pi = 0,
                Total = 0,
                Inside = 0,
                Points = new System.Collections.Generic.List<PointData>()
            };
            int width = 400;
            int height = 400;

            // Act
            var bitmap = _solver.CreateVisualization(data, width, height);

            // Assert
            Assert.NotNull(bitmap);
            Assert.Equal(width, bitmap.Width);
            Assert.Equal(height, bitmap.Height);
        }

        [Fact]
        public void CreateVisualization_LargePointCount_ReturnsValidBitmap()
        {
            // Arrange
            var data = _solver.Simulate(10000);
            int width = 800;
            int height = 600;

            // Act
            var bitmap = _solver.CreateVisualization(data, width, height);

            // Assert
            Assert.NotNull(bitmap);
            Assert.Equal(width, bitmap.Width);
            Assert.Equal(height, bitmap.Height);
        }

        [Fact]
        public void CreateVisualization_DisposesProperly()
        {
            // Arrange
            var data = _solver.Simulate(100);

            // Act
            var bitmap = _solver.CreateVisualization(data, 400, 400);

            // Assert
            bitmap.Dispose();
            // Если не выбросилось исключение — тест пройден
        }

        #endregion

        #region Интеграционные тесты

        [Fact]
        public void FullWorkflow_CheckPointAndVisualize_WorksCorrectly()
        {
            // Arrange
            double px = 0.5, py = 0.5;
            double cx = 0, cy = 0;
            double r = 1;

            // Act 1: Check point
            string result = _solver.CheckPoint(px, py, cx, cy, r, out Color color);

            // Act 2: Simulate
            var simResult = _solver.Simulate(1000);

            // Act 3: Visualize
            var bitmap = _solver.CreateVisualization(simResult, 400, 400);

            // Assert
            Assert.Equal("Точка ВНУТРИ круга", result);
            Assert.Equal(Color.Green, color);
            Assert.NotNull(simResult);
            Assert.InRange(simResult.Pi, 2.8, 3.5);
            Assert.NotNull(bitmap);

            bitmap.Dispose();
        }

        #endregion
    }
}