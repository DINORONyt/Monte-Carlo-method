using Xunit;
using Lab02Variant17.Core;
namespace Lab02Variant17.Tests;

public class TaskSolverTests
{
    #region Тесты для Задачи 1 (Геометрия)

    [Theory]
    [InlineData(0, 0, 5, 0, 0, PointLocation.Inside)]       // Центр круга
    [InlineData(0, 0, 5, 2, 2, PointLocation.Inside)]       // Внутри
    [InlineData(0, 0, 5, 5, 0, PointLocation.OnBoundary)]   // На границе (справа)
    [InlineData(0, 0, 5, 0, 5, PointLocation.OnBoundary)]   // На границе (сверху)
    [InlineData(0, 0, 5, 6, 0, PointLocation.Outside)]      // Снаружи
    public void CheckPointLocation_ReturnsCorrectStatus(
        double cx, double cy, double radius,
        double px, double py,
        PointLocation expected)
    {
        // Arrange (Подготовка)
        var circle = new Circle(new Point2D(cx, cy), radius);
        var point = new Point2D(px, py);

        // Act (Действие)
        var result = TaskSolver.CheckPointLocation(circle, point);

        // Assert (Проверка)
        Assert.Equal(expected, result);
    }

    #endregion

    #region Тесты для Задачи 2 (Метод Монте-Карло)

    [Fact]
    public void GenerateRandomPoints_CountMatchesInput()
    {
        // Arrange
        int count = 1000;
        var random = new Random(42); // Фиксированный seed для предсказуемости

        // Act
        var result = TaskSolver.GenerateRandomPoints(count, random);

        // Assert
        Assert.Equal(count, result.TotalPoints);
        Assert.Equal(count, result.Points.Length);
    }

    [Fact]
    public void GenerateRandomPoints_PiEstimationIsReasonable()
    {
        // Arrange
        int count = 10000; // Большое число для точности
        var random = new Random(123);

        // Act
        var result = TaskSolver.GenerateRandomPoints(count, random);

        // Assert
        // Пи примерно 3.14. При 10000 точек погрешность должна быть небольшой.
        // Проверяем, что результат в диапазоне от 2.5 до 4.0
        Assert.InRange(result.EstimatedPi, 2.5, 4.0);

        // Проверяем, что количество попавших точек совпадает с флагами в массиве
        int manualInsideCount = result.Points.Count(p => p.IsInside);
        Assert.Equal(result.InsideCount, manualInsideCount);
    }

    #endregion

    #region Тесты для Валидации и Утилит

    [Theory]
    [InlineData(5.0, true)]
    [InlineData(0.1, true)]
    [InlineData(0.0, false)]
    [InlineData(-5.0, false)]
    public void ValidateCircleRadius_Correctness(double radius, bool expected)
    {
        Assert.Equal(expected, TaskSolver.ValidateCircleRadius(radius));
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(100, true)]
    [InlineData(0, false)]
    [InlineData(-10, false)]
    public void ValidatePointCount_Correctness(int count, bool expected)
    {
        Assert.Equal(expected, TaskSolver.ValidatePointCount(count));
    }

    [Theory]
    [InlineData(PointLocation.Inside, "Точка находится внутри круга")]
    [InlineData(PointLocation.OnBoundary, "Точка лежит на окружности")]
    [InlineData(PointLocation.Outside, "Точка находится снаружи круга")]
    public void GetPointLocationText_ReturnsCorrectString(PointLocation loc, string expectedText)
    {
        Assert.Equal(expectedText, TaskSolver.GetPointLocationText(loc));
    }

    #endregion
}