using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bulbazavrus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 2;
            float scale = Math.Min(ClientSize.Width, ClientSize.Height) / 400f;

            Graphics g = e.Graphics;

            // Луковица на спине (темно-зеленая основа)
            using (var bulbDark = new SolidBrush(Color.FromArgb(0x2E, 0x8B, 0x57)))
            {
                var bulbPath = new GraphicsPath();
                bulbPath.AddEllipse(centerX - 60 * scale, centerY - 120 * scale, 140 * scale, 100 * scale);
                g.FillPath(bulbDark, bulbPath);
            }

            // Луковица на спине (светло-зеленая верхняя часть)
            using (var bulbLight = new SolidBrush(Color.FromArgb(0x3C, 0xB3, 0x71)))
            {
                var bulbTopPath = new GraphicsPath();
                bulbTopPath.AddEllipse(centerX - 50 * scale, centerY - 140 * scale, 120 * scale, 80 * scale);
                g.FillPath(bulbLight, bulbTopPath);
            }

            // Листья луковицы
            using (var leafBrush = new SolidBrush(Color.FromArgb(0x22, 0x8B, 0x22)))
            {
                // Левое листо
                var leftLeaf = new GraphicsPath();
                leftLeaf.AddBezier(
                    centerX - 40 * scale, centerY - 130 * scale,
                    centerX - 80 * scale, centerY - 160 * scale,
                    centerX - 100 * scale, centerY - 140 * scale,
                    centerX - 60 * scale, centerY - 110 * scale
                );
                g.FillPath(leafBrush, leftLeaf);

                // Правое листо
                var rightLeaf = new GraphicsPath();
                rightLeaf.AddBezier(
                    centerX + 40 * scale, centerY - 130 * scale,
                    centerX + 80 * scale, centerY - 160 * scale,
                    centerX + 100 * scale, centerY - 140 * scale,
                    centerX + 60 * scale, centerY - 110 * scale
                );
                g.FillPath(leafBrush, rightLeaf);
            }

            // Тело (основной бирюзово-зеленый цвет)
            using (var bodyBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var bodyPath = new GraphicsPath();
                bodyPath.AddEllipse(centerX - 90 * scale, centerY - 40 * scale, 180 * scale, 120 * scale);
                g.FillPath(bodyBrush, bodyPath);
            }

            // Голова
            using (var headBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var headPath = new GraphicsPath();
                headPath.AddEllipse(centerX - 85 * scale, centerY - 90 * scale, 170 * scale, 130 * scale);
                g.FillPath(headBrush, headPath);
            }

            // Пятна на теле (темно-зеленые)
            using (var spotBrush = new SolidBrush(Color.FromArgb(0x1E, 0x6B, 0x4A)))
            {
                // Пятно на лбу
                var foreheadSpot = new GraphicsPath();
                foreheadSpot.AddEllipse(centerX - 20 * scale, centerY - 75 * scale, 25 * scale, 18 * scale);
                g.FillPath(spotBrush, foreheadSpot);

                // Пятно слева на голове
                var leftHeadSpot = new GraphicsPath();
                leftHeadSpot.AddEllipse(centerX - 65 * scale, centerY - 55 * scale, 20 * scale, 15 * scale);
                g.FillPath(spotBrush, leftHeadSpot);

                // Пятно справа на голове
                var rightHeadSpot = new GraphicsPath();
                rightHeadSpot.AddEllipse(centerX + 45 * scale, centerY - 50 * scale, 22 * scale, 16 * scale);
                g.FillPath(spotBrush, rightHeadSpot);

                // Пятна на теле
                var bodySpot1 = new GraphicsPath();
                bodySpot1.AddEllipse(centerX - 70 * scale, centerY + 10 * scale, 30 * scale, 25 * scale);
                g.FillPath(spotBrush, bodySpot1);

                var bodySpot2 = new GraphicsPath();
                bodySpot2.AddEllipse(centerX + 50 * scale, centerY + 20 * scale, 28 * scale, 22 * scale);
                g.FillPath(spotBrush, bodySpot2);

                var bodySpot3 = new GraphicsPath();
                bodySpot3.AddEllipse(centerX - 30 * scale, centerY + 40 * scale, 25 * scale, 20 * scale);
                g.FillPath(spotBrush, bodySpot3);
            }

            // Уши
            using (var earBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var leftEar = new GraphicsPath();
                leftEar.AddPolygon(new PointF[]
                {
                    new PointF(centerX - 70 * scale, centerY - 80 * scale),
                    new PointF(centerX - 90 * scale, centerY - 110 * scale),
                    new PointF(centerX - 55 * scale, centerY - 85 * scale)
                });
                g.FillPath(earBrush, leftEar);

                var rightEar = new GraphicsPath();
                rightEar.AddPolygon(new PointF[]
                {
                    new PointF(centerX + 70 * scale, centerY - 80 * scale),
                    new PointF(centerX + 90 * scale, centerY - 110 * scale),
                    new PointF(centerX + 55 * scale, centerY - 85 * scale)
                });
                g.FillPath(earBrush, rightEar);
            }

            // Глаза (белки)
            using (var eyeWhiteBrush = new SolidBrush(Color.White))
            {
                var leftEyeWhite = new GraphicsPath();
                leftEyeWhite.AddEllipse(centerX - 55 * scale, centerY - 50 * scale, 35 * scale, 40 * scale);
                g.FillPath(eyeWhiteBrush, leftEyeWhite);

                var rightEyeWhite = new GraphicsPath();
                rightEyeWhite.AddEllipse(centerX + 20 * scale, centerY - 50 * scale, 35 * scale, 40 * scale);
                g.FillPath(eyeWhiteBrush, rightEyeWhite);
            }

            // Глаза (радужка - красная)
            using (var irisBrush = new SolidBrush(Color.FromArgb(0xE5, 0x3F, 0x52)))
            {
                var leftIris = new GraphicsPath();
                leftIris.AddEllipse(centerX - 50 * scale, centerY - 45 * scale, 25 * scale, 30 * scale);
                g.FillPath(irisBrush, leftIris);

                var rightIris = new GraphicsPath();
                rightIris.AddEllipse(centerX + 25 * scale, centerY - 45 * scale, 25 * scale, 30 * scale);
                g.FillPath(irisBrush, rightIris);
            }

            // Зрачки (черные)
            using (var pupilBrush = new SolidBrush(Color.Black))
            {
                g.FillEllipse(pupilBrush, centerX - 42 * scale, centerY - 38 * scale, 12 * scale, 15 * scale);
                g.FillEllipse(pupilBrush, centerX + 33 * scale, centerY - 38 * scale, 12 * scale, 15 * scale);

                // Блик в глазах
                using (var highlightBrush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(highlightBrush, centerX - 38 * scale, centerY - 42 * scale, 6 * scale, 6 * scale);
                    g.FillEllipse(highlightBrush, centerX + 37 * scale, centerY - 42 * scale, 6 * scale, 6 * scale);
                }
            }

            // Пасть
            using (var mouthPath = new GraphicsPath())
            {
                mouthPath.AddArc(centerX - 50 * scale, centerY - 10 * scale, 100 * scale, 50 * scale, 200, 140);
                using (var mouthPen = new Pen(Color.FromArgb(0x1a1a1a), 2 * scale))
                {
                    mouthPen.LineJoin = LineJoin.Round;
                    g.DrawPath(mouthPen, mouthPath);
                }

                // Внутренняя часть пасти (розовая)
                using (var mouthFill = new SolidBrush(Color.FromArgb(0xF0, 0xA0, 0xC0)))
                {
                    var mouthFillPath = new GraphicsPath();
                    mouthFillPath.AddArc(centerX - 48 * scale, centerY - 8 * scale, 96 * scale, 45 * scale, 200, 140);
                    mouthFillPath.CloseFigure();
                    g.FillPath(mouthFill, mouthFillPath);
                }
            }

            // Зубы (маленькие треугольники)
            using (var toothBrush = new SolidBrush(Color.White))
            {
                g.FillPolygon(toothBrush, new PointF[]
                {
                    new PointF(centerX - 35 * scale, centerY + 8 * scale),
                    new PointF(centerX - 30 * scale, centerY + 8 * scale),
                    new PointF(centerX - 32.5f * scale, centerY + 12 * scale)
                });

                g.FillPolygon(toothBrush, new PointF[]
                {
                    new PointF(centerX + 30 * scale, centerY + 8 * scale),
                    new PointF(centerX + 35 * scale, centerY + 8 * scale),
                    new PointF(centerX + 32.5f * scale, centerY + 12 * scale)
                });
            }

            // Передние лапы
            using (var legBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var leftFrontLeg = new GraphicsPath();
                leftFrontLeg.AddEllipse(centerX - 80 * scale, centerY + 60 * scale, 35 * scale, 45 * scale);
                g.FillPath(legBrush, leftFrontLeg);

                var rightFrontLeg = new GraphicsPath();
                rightFrontLeg.AddEllipse(centerX + 45 * scale, centerY + 60 * scale, 35 * scale, 45 * scale);
                g.FillPath(legBrush, rightFrontLeg);
            }

            // Задние лапы
            using (var hindLegBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var leftHindLeg = new GraphicsPath();
                leftHindLeg.AddEllipse(centerX - 110 * scale, centerY + 40 * scale, 40 * scale, 50 * scale);
                g.FillPath(hindLegBrush, leftHindLeg);

                var rightHindLeg = new GraphicsPath();
                rightHindLeg.AddEllipse(centerX + 75 * scale, centerY + 40 * scale, 40 * scale, 50 * scale);
                g.FillPath(hindLegBrush, rightHindLeg);
            }

            // Пятна на лапах
            using (var spotBrush = new SolidBrush(Color.FromArgb(0x1E, 0x6B, 0x4A)))
            {
                g.FillEllipse(spotBrush, centerX - 75 * scale, centerY + 70 * scale, 20 * scale, 15 * scale);
                g.FillEllipse(spotBrush, centerX + 50 * scale, centerY + 70 * scale, 18 * scale, 14 * scale);
                g.FillEllipse(spotBrush, centerX - 105 * scale, centerY + 50 * scale, 22 * scale, 16 * scale);
                g.FillEllipse(spotBrush, centerX + 80 * scale, centerY + 50 * scale, 20 * scale, 15 * scale);
            }

            // Когти (белые)
            using (var clawBrush = new SolidBrush(Color.FromArgb(0xF5, 0xF5, 0xF5)))
            {
                // Передние когти
                for (int i = 0; i < 3; i++)
                {
                    g.FillEllipse(clawBrush, centerX - 78 * scale + i * 10 * scale, centerY + 100 * scale, 5 * scale, 6 * scale);
                    g.FillEllipse(clawBrush, centerX + 47 * scale + i * 10 * scale, centerY + 100 * scale, 5 * scale, 6 * scale);
                }

                // Задние когти
                for (int i = 0; i < 3; i++)
                {
                    g.FillEllipse(clawBrush, centerX - 108 * scale + i * 10 * scale, centerY + 85 * scale, 5 * scale, 6 * scale);
                    g.FillEllipse(clawBrush, centerX + 77 * scale + i * 10 * scale, centerY + 85 * scale, 5 * scale, 6 * scale);
                }
            }

            // Ноздри
            using (var nostrilBrush = new SolidBrush(Color.FromArgb(0x1a1a1a)))
            {
                g.FillEllipse(nostrilBrush, centerX - 15 * scale, centerY - 5 * scale, 4 * scale, 3 * scale);
                g.FillEllipse(nostrilBrush, centerX + 11 * scale, centerY - 5 * scale, 4 * scale, 3 * scale);
            }
        }
    }
}
