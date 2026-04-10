using System.Drawing;
using System.Globalization;
using Lab02Variant17.Core;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private readonly Random _random;
    private SimulationPoint[] _points;

    public Form1()
    {
        InitializeComponent();
        _random = new Random();
        _points = Array.Empty<SimulationPoint>();
        btnCheckPoint.Click += BtnCheckPoint_Click;
        btnGenerate.Click += BtnGenerate_Click;
        pictureBox.Paint += PictureBox_Paint;
    }

    private void BtnCheckPoint_Click(object? sender, EventArgs e)
    {
        if (!TryParseDouble(txtCenterX.Text, "X центра", out double cx)) return;
        if (!TryParseDouble(txtCenterY.Text, "Y центра", out double cy)) return;
        if (!TryParseDouble(txtRadius.Text, "Радиус", out double r)) return;
        if (!TryParseDouble(txtPointX.Text, "X точки", out double px)) return;
        if (!TryParseDouble(txtPointY.Text, "Y точки", out double py)) return;

        if (!TaskSolver.ValidateCircleRadius(r))
        {
            ShowError("Радиус должен быть положительным числом.");
            return;
        }

        var circle = new Circle(new Point2D(cx, cy), r);
        var point = new Point2D(px, py);
        var location = TaskSolver.CheckPointLocation(circle, point);
        lblTask1Result.Text = TaskSolver.GetPointLocationText(location);
    }

    private void BtnGenerate_Click(object? sender, EventArgs e)
    {
        if (!TryParseInt(txtNumPoints.Text, "Количество точек", out int n)) return;

        if (!TaskSolver.ValidatePointCount(n))
        {
            ShowError("Допустимый диапазон: 1 - 1 000 000.");
            return;
        }

        var result = TaskSolver.GenerateRandomPoints(n, _random);
        _points = result.Points;
        lblPiEstimate.Text = $"Оценённое π: {result.EstimatedPi:F6}";
        lblStats.Text = $"Попало в круг: {result.InsideCount} из {result.TotalPoints}";
        pictureBox.Invalidate();
    }

    private void PictureBox_Paint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.Clear(Color.White);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        if (_points.Length == 0)
        {
            g.DrawString("Сначала сгенерируйте точки во вкладке 2", Font, Brushes.Gray, 40, 120);
            lblCurrentPi.Text = "Данные отсутствуют";
            return;
        }

        int padding = 40;
        int w = pictureBox.ClientSize.Width - 2 * padding;
        int h = pictureBox.ClientSize.Height - 2 * padding;
        if (w <= 0 || h <= 0) return;

        float ToX(double val) => padding + (float)((val + 1) / 2 * w);
        float ToY(double val) => padding + (float)((1 - val) / 2 * h);

        g.DrawRectangle(Pens.Black, padding, padding, w, h);

        int radiusPx = Math.Min(w, h) / 2;
        int cx = pictureBox.ClientSize.Width / 2;
        int cy = pictureBox.ClientSize.Height / 2;
        g.DrawEllipse(Pens.Blue, cx - radiusPx, cy - radiusPx, radiusPx * 2, radiusPx * 2);

        foreach (var pt in _points)
        {
            using var brush = new SolidBrush(pt.IsInside ? Color.Green : Color.Red);
            g.FillRectangle(brush, ToX(pt.X) - 1.5f, ToY(pt.Y) - 1.5f, 3, 3);
        }

        double currentPi = 4.0 * _points.Count(p => p.IsInside) / _points.Length;
        lblCurrentPi.Text = $"Текущее приближение π: {currentPi:F6}";
    }

    private static bool TryParseDouble(string input, string fieldName, out double value)
    {
        value = 0;
        if (string.IsNullOrWhiteSpace(input))
        {
            ShowError($"Поле '{fieldName}' не может быть пустым.");
            return false;
        }

        if (!double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
        {
            ShowError($"Некорректный формат числа в поле '{fieldName}'.");
            return false;
        }

        return true;
    }

    private static bool TryParseInt(string input, string fieldName, out int value)
    {
        value = 0;
        if (string.IsNullOrWhiteSpace(input))
        {
            ShowError($"Поле '{fieldName}' не может быть пустым.");
            return false;
        }

        if (!int.TryParse(input, out value))
        {
            ShowError($"Некорректный формат целого числа в поле '{fieldName}'.");
            return false;
        }

        return true;
    }

    private static void ShowError(string message)
    {
        MessageBox.Show(message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}