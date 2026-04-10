namespace Lab02Variant17.Core;

public readonly record struct Point2D(double X, double Y);

public readonly record struct Circle(Point2D Center, double Radius);

public enum PointLocation { Inside, OnBoundary, Outside }

public readonly record struct SimulationPoint(double X, double Y, bool IsInside);

public readonly record struct SimulationResult(int TotalPoints, int InsideCount, double EstimatedPi, SimulationPoint[] Points);

public class TaskSolver
{
    public static PointLocation CheckPointLocation(Circle circle, Point2D point)
    {
        double distanceSquared = Math.Pow(point.X - circle.Center.X, 2) + Math.Pow(point.Y - circle.Center.Y, 2);
        double radiusSquared = circle.Radius * circle.Radius;
        const double epsilon = 1e-9;

        if (Math.Abs(distanceSquared - radiusSquared) < epsilon)
            return PointLocation.OnBoundary;

        return distanceSquared < radiusSquared ? PointLocation.Inside : PointLocation.Outside;
    }

    public static SimulationResult GenerateRandomPoints(int pointCount, Random random)
    {
        if (pointCount <= 0)
            throw new ArgumentException("Количество точек должно быть больше нуля.", nameof(pointCount));

        var points = new SimulationPoint[pointCount];
        int insideCount = 0;

        for (int i = 0; i < pointCount; i++)
        {
            double x = random.NextDouble() * 2 - 1;
            double y = random.NextDouble() * 2 - 1;
            bool isInside = x * x + y * y <= 1.0;

            if (isInside)
                insideCount++;

            points[i] = new SimulationPoint(x, y, isInside);
        }

        double estimatedPi = 4.0 * insideCount / pointCount;
        return new SimulationResult(pointCount, insideCount, estimatedPi, points);
    }

    public static string GetPointLocationText(PointLocation location)
    {
        return location switch
        {
            PointLocation.Inside => "Точка находится внутри круга",
            PointLocation.OnBoundary => "Точка лежит на окружности",
            PointLocation.Outside => "Точка находится снаружи круга",
            _ => "Неизвестно"
        };
    }

    public static bool ValidateCircleRadius(double radius)
    {
        return radius > 0;
    }

    public static bool ValidatePointCount(int count)
    {
        return count >= 1 && count <= 1000000;
    }
}