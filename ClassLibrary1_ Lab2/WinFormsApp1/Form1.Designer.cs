namespace WinFormsApp1;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.tabControl = new System.Windows.Forms.TabControl();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.lblTask1Result = new System.Windows.Forms.Label();
        this.btnCheckPoint = new System.Windows.Forms.Button();
        this.txtPointY = new System.Windows.Forms.TextBox();
        this.lblPointY = new System.Windows.Forms.Label();
        this.txtPointX = new System.Windows.Forms.TextBox();
        this.lblPointX = new System.Windows.Forms.Label();
        this.txtRadius = new System.Windows.Forms.TextBox();
        this.lblRadius = new System.Windows.Forms.Label();
        this.txtCenterY = new System.Windows.Forms.TextBox();
        this.lblCenterY = new System.Windows.Forms.Label();
        this.txtCenterX = new System.Windows.Forms.TextBox();
        this.lblCenterX = new System.Windows.Forms.Label();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.lblStats = new System.Windows.Forms.Label();
        this.lblPiEstimate = new System.Windows.Forms.Label();
        this.btnGenerate = new System.Windows.Forms.Button();
        this.txtNumPoints = new System.Windows.Forms.TextBox();
        this.lblNumPoints = new System.Windows.Forms.Label();
        this.tabPage3 = new System.Windows.Forms.TabPage();
        this.lblCurrentPi = new System.Windows.Forms.Label();
        this.pictureBox = new System.Windows.Forms.PictureBox();
        this.tabControl.SuspendLayout();
        this.tabPage1.SuspendLayout();
        this.tabPage2.SuspendLayout();
        this.tabPage3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
        this.SuspendLayout();

        this.tabControl.Controls.Add(this.tabPage1);
        this.tabControl.Controls.Add(this.tabPage2);
        this.tabControl.Controls.Add(this.tabPage3);
        this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabControl.Location = new System.Drawing.Point(0, 0);
        this.tabControl.Name = "tabControl";
        this.tabControl.SelectedIndex = 0;
        this.tabControl.Size = new System.Drawing.Size(920, 640);
        this.tabControl.TabIndex = 0;

        this.tabPage1.Controls.Add(this.lblTask1Result);
        this.tabPage1.Controls.Add(this.btnCheckPoint);
        this.tabPage1.Controls.Add(this.txtPointY);
        this.tabPage1.Controls.Add(this.lblPointY);
        this.tabPage1.Controls.Add(this.txtPointX);
        this.tabPage1.Controls.Add(this.lblPointX);
        this.tabPage1.Controls.Add(this.txtRadius);
        this.tabPage1.Controls.Add(this.lblRadius);
        this.tabPage1.Controls.Add(this.txtCenterY);
        this.tabPage1.Controls.Add(this.lblCenterY);
        this.tabPage1.Controls.Add(this.txtCenterX);
        this.tabPage1.Controls.Add(this.lblCenterX);
        this.tabPage1.Location = new System.Drawing.Point(4, 29);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(912, 607);
        this.tabPage1.TabIndex = 0;
        this.tabPage1.Text = "Задача 1: Проверка точки";
        this.tabPage1.UseVisualStyleBackColor = true;

        this.lblCenterX.AutoSize = true;
        this.lblCenterX.Location = new System.Drawing.Point(20, 20);
        this.lblCenterX.Name = "lblCenterX";
        this.lblCenterX.Size = new System.Drawing.Size(110, 20);
        this.lblCenterX.TabIndex = 0;
        this.lblCenterX.Text = "Центр круга (X):";

        this.txtCenterX.Location = new System.Drawing.Point(160, 17);
        this.txtCenterX.Name = "txtCenterX";
        this.txtCenterX.Size = new System.Drawing.Size(120, 27);
        this.txtCenterX.TabIndex = 1;

        this.lblCenterY.AutoSize = true;
        this.lblCenterY.Location = new System.Drawing.Point(20, 60);
        this.lblCenterY.Name = "lblCenterY";
        this.lblCenterY.Size = new System.Drawing.Size(111, 20);
        this.lblCenterY.TabIndex = 2;
        this.lblCenterY.Text = "Центр круга (Y):";

        this.txtCenterY.Location = new System.Drawing.Point(160, 57);
        this.txtCenterY.Name = "txtCenterY";
        this.txtCenterY.Size = new System.Drawing.Size(120, 27);
        this.txtCenterY.TabIndex = 3;

        this.lblRadius.AutoSize = true;
        this.lblRadius.Location = new System.Drawing.Point(20, 100);
        this.lblRadius.Name = "lblRadius";
        this.lblRadius.Size = new System.Drawing.Size(62, 20);
        this.lblRadius.TabIndex = 4;
        this.lblRadius.Text = "Радиус:";

        this.txtRadius.Location = new System.Drawing.Point(160, 97);
        this.txtRadius.Name = "txtRadius";
        this.txtRadius.Size = new System.Drawing.Size(120, 27);
        this.txtRadius.TabIndex = 5;

        this.lblPointX.AutoSize = true;
        this.lblPointX.Location = new System.Drawing.Point(20, 140);
        this.lblPointX.Name = "lblPointX";
        this.lblPointX.Size = new System.Drawing.Size(76, 20);
        this.lblPointX.TabIndex = 6;
        this.lblPointX.Text = "Точка (X):";

        this.txtPointX.Location = new System.Drawing.Point(160, 137);
        this.txtPointX.Name = "txtPointX";
        this.txtPointX.Size = new System.Drawing.Size(120, 27);
        this.txtPointX.TabIndex = 7;

        this.lblPointY.AutoSize = true;
        this.lblPointY.Location = new System.Drawing.Point(20, 180);
        this.lblPointY.Name = "lblPointY";
        this.lblPointY.Size = new System.Drawing.Size(77, 20);
        this.lblPointY.TabIndex = 8;
        this.lblPointY.Text = "Точка (Y):";

        this.txtPointY.Location = new System.Drawing.Point(160, 177);
        this.txtPointY.Name = "txtPointY";
        this.txtPointY.Size = new System.Drawing.Size(120, 27);
        this.txtPointY.TabIndex = 9;

        this.btnCheckPoint.Location = new System.Drawing.Point(160, 220);
        this.btnCheckPoint.Name = "btnCheckPoint";
        this.btnCheckPoint.Size = new System.Drawing.Size(180, 35);
        this.btnCheckPoint.TabIndex = 10;
        this.btnCheckPoint.Text = "Проверить";
        this.btnCheckPoint.UseVisualStyleBackColor = true;

        this.lblTask1Result.AutoSize = true;
        this.lblTask1Result.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTask1Result.Location = new System.Drawing.Point(20, 270);
        this.lblTask1Result.Name = "lblTask1Result";
        this.lblTask1Result.Size = new System.Drawing.Size(0, 28);
        this.lblTask1Result.TabIndex = 11;

        this.tabPage2.Controls.Add(this.lblStats);
        this.tabPage2.Controls.Add(this.lblPiEstimate);
        this.tabPage2.Controls.Add(this.btnGenerate);
        this.tabPage2.Controls.Add(this.txtNumPoints);
        this.tabPage2.Controls.Add(this.lblNumPoints);
        this.tabPage2.Location = new System.Drawing.Point(4, 29);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(912, 607);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "Задача 2: Генерация точек";
        this.tabPage2.UseVisualStyleBackColor = true;

        this.lblNumPoints.AutoSize = true;
        this.lblNumPoints.Location = new System.Drawing.Point(20, 20);
        this.lblNumPoints.Name = "lblNumPoints";
        this.lblNumPoints.Size = new System.Drawing.Size(185, 20);
        this.lblNumPoints.TabIndex = 0;
        this.lblNumPoints.Text = "Количество точек (N):";

        this.txtNumPoints.Location = new System.Drawing.Point(220, 17);
        this.txtNumPoints.Name = "txtNumPoints";
        this.txtNumPoints.Size = new System.Drawing.Size(120, 27);
        this.txtNumPoints.TabIndex = 1;

        this.btnGenerate.Location = new System.Drawing.Point(20, 60);
        this.btnGenerate.Name = "btnGenerate";
        this.btnGenerate.Size = new System.Drawing.Size(220, 35);
        this.btnGenerate.TabIndex = 2;
        this.btnGenerate.Text = "Сгенерировать точки";
        this.btnGenerate.UseVisualStyleBackColor = true;

        this.lblPiEstimate.AutoSize = true;
        this.lblPiEstimate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblPiEstimate.Location = new System.Drawing.Point(20, 110);
        this.lblPiEstimate.Name = "lblPiEstimate";
        this.lblPiEstimate.Size = new System.Drawing.Size(0, 32);
        this.lblPiEstimate.TabIndex = 3;

        this.lblStats.AutoSize = true;
        this.lblStats.Location = new System.Drawing.Point(20, 150);
        this.lblStats.Name = "lblStats";
        this.lblStats.Size = new System.Drawing.Size(0, 20);
        this.lblStats.TabIndex = 4;

        this.tabPage3.Controls.Add(this.lblCurrentPi);
        this.tabPage3.Controls.Add(this.pictureBox);
        this.tabPage3.Location = new System.Drawing.Point(4, 29);
        this.tabPage3.Name = "tabPage3";
        this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage3.Size = new System.Drawing.Size(912, 607);
        this.tabPage3.TabIndex = 2;
        this.tabPage3.Text = "Задача 3: Визуализация";
        this.tabPage3.UseVisualStyleBackColor = true;

        this.pictureBox.BackColor = System.Drawing.Color.White;
        this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBox.Location = new System.Drawing.Point(3, 3);
        this.pictureBox.Name = "pictureBox";
        this.pictureBox.Size = new System.Drawing.Size(906, 571);
        this.pictureBox.TabIndex = 0;
        this.pictureBox.TabStop = false;

        this.lblCurrentPi.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.lblCurrentPi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblCurrentPi.Location = new System.Drawing.Point(3, 574);
        this.lblCurrentPi.Name = "lblCurrentPi";
        this.lblCurrentPi.Size = new System.Drawing.Size(906, 30);
        this.lblCurrentPi.TabIndex = 1;
        this.lblCurrentPi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(920, 640);
        this.Controls.Add(this.tabControl);
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Лабораторная работа №2 | Вариант 17";
        this.tabControl.ResumeLayout(false);
        this.tabPage1.ResumeLayout(false);
        this.tabPage1.PerformLayout();
        this.tabPage2.ResumeLayout(false);
        this.tabPage2.PerformLayout();
        this.tabPage3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Label lblCenterX;
    private System.Windows.Forms.TextBox txtCenterX;
    private System.Windows.Forms.Label lblCenterY;
    private System.Windows.Forms.TextBox txtCenterY;
    private System.Windows.Forms.Label lblRadius;
    private System.Windows.Forms.TextBox txtRadius;
    private System.Windows.Forms.Label lblPointX;
    private System.Windows.Forms.TextBox txtPointX;
    private System.Windows.Forms.Label lblPointY;
    private System.Windows.Forms.TextBox txtPointY;
    private System.Windows.Forms.Button btnCheckPoint;
    private System.Windows.Forms.Label lblTask1Result;
    private System.Windows.Forms.Label lblNumPoints;
    private System.Windows.Forms.TextBox txtNumPoints;
    private System.Windows.Forms.Button btnGenerate;
    private System.Windows.Forms.Label lblPiEstimate;
    private System.Windows.Forms.Label lblStats;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Label lblCurrentPi;
}