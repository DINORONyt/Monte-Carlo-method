using System;
using System.Collections.Generic;
using System.Drawing;

namespace ClassLibrary1_Lab2
{
    /// <summary>
    /// Лабораторная работа 2 вариант 17
    /// </summary>
    public class TaskSolver
    {
        private readonly Random _random;

        public TaskSolver()
        {
            _random = new Random();
        }

        //Задача 1: Проверка попадания точки в круг

        /// <summary>
        /// Проверяет положение точки относительно круга
        /// </summary>
        public string CheckPointPosition(double pointX, double pointY,
                                         double circleCenterX, double circleCenterY,
                                         double radius, out Color resultColor)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус должен быть положительным числом", nameof(radius));
            }

            double distance = Math.Sqrt(Math.Pow(pointX - circleCenterX, 2) +
                                       Math.Pow(pointY - circleCenterY, 2));

            const double epsilon = 1e-9;
            string result;

            if (Math.Abs(distance - radius) < epsilon)
            {
                result = "Точка лежит НА окружности";
                resultColor = Color.Orange;
            }
            else if (distance < radius)
            {
                result = "Точка находится ВНУТРИ круга";
                resultColor = Color.Green;
            }
            else
            {
                result = "Точка находится СНАРУЖИ круга";
                resultColor = Color.Red;
            }

            return result;
        }

        //Задача 2: Метод Монте-Карло

        /// <summary>
        /// Генерирует случайные точки и вычисляет приближённое значение ПИ
        /// </summary>
        public SimulationData GenerateRandomPoints(int pointCount)
        {
            if (pointCount <= 0)
            {
                throw new ArgumentException("Количество точек должно быть больше нуля", nameof(pointCount));
            }

            var points = new List<PointData>(pointCount);
            int insideCount = 0;

            for (int i = 0; i < pointCount; i++)
            {
                double x = (_random.NextDouble() * 2) - 1;
                double y = (_random.NextDouble() * 2) - 1;

                bool isInside = (x * x + y * y) <= 1.0;
                if (isInside) insideCount++;

                points.Add(new PointData(x, y, isInside));
            }

            double piApprox = 4.0 * insideCount / pointCount;
            return new SimulationData(piApprox, pointCount, insideCount, points);
        }

        //Задача 3: Визуализация

        /// <summary>
        /// Рисует квадрат, круг и точки в PictureBox
        /// </summary>
        public void DrawVisualization(System.Windows.Forms.PictureBox pictureBox, SimulationData data)
        {
            if (pictureBox == null || data == null)
                throw new ArgumentNullException();

            var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (var graphics = System.Drawing.Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int centerX = pictureBox.Width / 2;
                int centerY = pictureBox.Height / 2;
                int radiusPx = Math.Min(centerX, centerY) - 10;

                // Рисуем оси
                using (var axisPen = new Pen(Color.Gray, 1))
                {
                    graphics.DrawLine(axisPen, centerX, 0, centerX, pictureBox.Height);
                    graphics.DrawLine(axisPen, 0, centerY, pictureBox.Width, centerY);
                }

                // Рисуем квадрат
                using (var squarePen = new Pen(Color.Black, 2))
                {
                    graphics.DrawRectangle(squarePen, centerX - radiusPx, centerY - radiusPx,
                                         radiusPx * 2, radiusPx * 2);
                }

                // Рисуем круг
                using (var circlePen = new Pen(Color.Blue, 2))
                {
                    graphics.DrawEllipse(circlePen, centerX - radiusPx, centerY - radiusPx,
                                       radiusPx * 2, radiusPx * 2);
                }

                // Рисуем точки
                DrawPoints(graphics, data.Points, centerX, centerY, radiusPx);
            }

            pictureBox.Image?.Dispose();
            pictureBox.Image = bitmap;
        }

        private void DrawPoints(System.Drawing.Graphics graphics, List<PointData> points,
                               int centerX, int centerY, int radiusPx)
        {
            if (points.Count > 5000)
            {
                var bitmap = (Bitmap)graphics.Image;
                foreach (var point in points)
                {
                    int px = centerX + (int)(point.X * radiusPx);
                    int py = centerY - (int)(point.Y * radiusPx);

                    if (px >= 0 && px < bitmap.Width && py >= 0 && py < bitmap.Height)
                    {
                        bitmap.SetPixel(px, py, point.IsInside ? Color.Green : Color.Red);
                    }
                }
            }
            else
            {
                foreach (var point in points)
                {
                    int px = centerX + (int)(point.X * radiusPx);
                    int py = centerY - (int)(point.Y * radiusPx);

                    using (var brush = new SolidBrush(point.IsInside ? Color.Green : Color.Red))
                    {
                        graphics.FillEllipse(brush, px - 2, py - 2, 4, 4);
                    }
                }
            }
        }
    }

    //Вспомогательные классы

    public class PointData
    {
        public double X { get; }
        public double Y { get; }
        public bool IsInside { get; }

        public PointData(double x, double y, bool isInside)
        {
            X = x;
            Y = y;
            IsInside = isInside;
        }
    }

    public class SimulationData
    {
        public double PiApproximation { get; }
        public int TotalPoints { get; }
        public int InsidePoints { get; }
        public List<PointData> Points { get; }

        public SimulationData(double pi, int total, int inside, List<PointData> points)
        {
            PiApproximation = pi;
            TotalPoints = total;
            InsidePoints = inside;
            Points = points;
        }
    }
}