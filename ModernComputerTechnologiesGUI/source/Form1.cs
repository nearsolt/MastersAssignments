using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernComputerTechnologiesGUI {
    public partial class Form1: Form {

        public Form1() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e) {

            this.chart1.Series[0].Points.Clear();
            int n = 10;
            
            Tuple<List<double>, List<double>> tmp = Helpers.Calc(n);

            for (int j = 0; j < n; j++) {
                this.chart1.Series[0].Points.AddXY(tmp.Item1[j], tmp.Item2[j]);
            }

           


            /*Graphics graphics = pictureBox1.CreateGraphics();
            int pictureBoxWidth = pictureBox1.ClientSize.Width;
            int pictureBoxHeight = pictureBox1.ClientSize.Height;
            graphics.TranslateTransform(pictureBoxWidth / 2, pictureBoxHeight / 2);
            graphics.ScaleTransform(1, -1);

            DrawXAxis(new Point(-pictureBoxWidth, 0), new Point(pictureBoxWidth, 0), graphics);
            DrawYAxis(new Point(0, pictureBoxHeight), new Point(0, -pictureBoxHeight), graphics);
            //Центр координат
            graphics.FillEllipse(Brushes.Red, -2, -2, 4, 4);

            Pen pen = new Pen(Color.Black, 2f);

            int n = 1000;
            PointF[] points = new PointF[n];
            Tuple<List<double>, List<double>> tmp = Helpers.Calc(n);

            for (int j = 0; j < n; j++) {
                points[j] = new PointF((float)tmp.Item1[j], (float)tmp.Item2[j]);
            }
            graphics.DrawLines(pen, points);*/
        }
        

        //Рисование оси X
        //private void DrawXAxis(Point start, Point end, Graphics g) {
        //    //Деления в положительном направлении оси
        //    for (int i = PIX_IN_ONE; i < end.X - ARR_LEN; i += PIX_IN_ONE) {
        //        g.DrawLine(Pens.Black, i, -5, i, 5);
        //        DrawText(new Point(i, 5), (i / PIX_IN_ONE).ToString(), g);
        //    }
        //    //Деления в отрицательном направлении оси
        //    for (int i = -PIX_IN_ONE; i > start.X; i -= PIX_IN_ONE) {
        //        g.DrawLine(Pens.Black, i, -5, i, 5);
        //        DrawText(new Point(i, 5), (i / PIX_IN_ONE).ToString(), g);
        //    }
        //    //Ось
        //    g.DrawLine(Pens.Black, start, end);
        //    //Стрелка
        //    g.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ARR_LEN));
        //}

        ////Рисование оси Y
        //private void DrawYAxis(Point start, Point end, Graphics g) {
        //    //Деления в отрицательном направлении оси
        //    for (int i = PIX_IN_ONE; i < start.Y; i += PIX_IN_ONE) {
        //        g.DrawLine(Pens.Black, -5, i, 5, i);
        //        DrawText(new Point(5, i), (-i / PIX_IN_ONE).ToString(), g, true);
        //    }
        //    //Деления в положительном направлении оси
        //    for (int i = -PIX_IN_ONE; i > end.Y + ARR_LEN; i -= PIX_IN_ONE) {
        //        g.DrawLine(Pens.Black, -5, i, 5, i);
        //        DrawText(new Point(5, i), (-i / PIX_IN_ONE).ToString(), g, true);
        //    }
        //    //Ось
        //    g.DrawLine(Pens.Black, start, end);
        //    //Стрелка
        //    g.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ARR_LEN));
        //}

        ////Рисование текста
        //private void DrawText(Point point, string text, Graphics g, bool isYAxis = false) {
        //    var f = new Font(Font.FontFamily, 6);
        //    var size = g.MeasureString(text, f);
        //    var pt = isYAxis
        //        ? new PointF(point.X + 1, point.Y - size.Height / 2)
        //        : new PointF(point.X - size.Width / 2, point.Y + 1);
        //    var rect = new RectangleF(pt, size);
        //    g.DrawString(text, f, Brushes.Black, rect);
        //}

        ////Вычисление стрелки оси
        //private static PointF[] GetArrow(float x1, float y1, float x2, float y2, float len = 10, float width = 4) {
        //    PointF[] result = new PointF[3];
        //    //направляющий вектор отрезка
        //    var n = new PointF(x2 - x1, y2 - y1);
        //    //Длина отрезка
        //    var l = (float)Math.Sqrt(n.X * n.X + n.Y * n.Y);
        //    //Единичный вектор
        //    var v1 = new PointF(n.X / l, n.Y / l);
        //    //Длина стрелки
        //    n.X = x2 - v1.X * len;
        //    n.Y = y2 - v1.Y * len;
        //    result[0] = new PointF(n.X + v1.Y * width, n.Y - v1.X * width);
        //    result[1] = new PointF(x2, y2);
        //    result[2] = new PointF(n.X - v1.Y * width, n.Y + v1.X * width);
        //    return result;
        //}

        private void chart1_Click(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            this.chart1.Series[0].Points.Clear();
        }
    }
}
