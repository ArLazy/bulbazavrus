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

            // Смещение для профиля (поворот влево)
            float profileOffsetX = -15 * scale;

            Graphics g = e.Graphics;

            // Луковица на спине (темно-зеленая основа)
            using (var bulbDark = new SolidBrush(Color.FromArgb(0x2E, 0x8B, 0x57)))
            {
                var bulbPath = new GraphicsPath();
                bulbPath.AddEllipse(centerX - 60 * scale + profileOffsetX, centerY - 120 * scale, 140 * scale, 100 * scale);
                g.FillPath(bulbDark, bulbPath);
            }

            // Луковица на спине (светло-зеленая верхняя часть)
            using (var bulbLight = new SolidBrush(Color.FromArgb(0x3C, 0xB3, 0x71)))
            {
                var bulbTopPath = new GraphicsPath();
                bulbTopPath.AddEllipse(centerX - 50 * scale + profileOffsetX, centerY - 140 * scale, 120 * scale, 80 * scale);
                g.FillPath(bulbLight, bulbTopPath);
            }

            // Листья луковицы
            using (var leafBrush = new SolidBrush(Color.FromArgb(0x22, 0x8B, 0x22)))
            {
                // Левое листо
                var leftLeaf = new GraphicsPath();
                leftLeaf.AddBezier(
                    centerX - 40 * scale + profileOffsetX, centerY - 130 * scale,
                    centerX - 80 * scale + profileOffsetX, centerY - 160 * scale,
                    centerX - 100 * scale + profileOffsetX, centerY - 140 * scale,
                    centerX - 60 * scale + profileOffsetX, centerY - 110 * scale
                );
                g.FillPath(leafBrush, leftLeaf);

                // Правое листо
                var rightLeaf = new GraphicsPath();
                rightLeaf.AddBezier(
                    centerX + 40 * scale + profileOffsetX, centerY - 130 * scale,
                    centerX + 80 * scale + profileOffsetX, centerY - 160 * scale,
                    centerX + 100 * scale + profileOffsetX, centerY - 140 * scale,
                    centerX + 60 * scale + profileOffsetX, centerY - 110 * scale
                );
                g.FillPath(leafBrush, rightLeaf);
            }

            // Тело (основной бирюзово-зеленый цвет) - эллипс со смещением для профиля
            using (var bodyBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var bodyPath = new GraphicsPath();
                bodyPath.AddEllipse(centerX - 80 * scale + profileOffsetX, centerY - 30 * scale, 170 * scale, 130 * scale);
                g.FillPath(bodyBrush, bodyPath);
            }

            // Контур тела (outline)
            using (var bodyOutline = new Pen(Color.FromArgb(0x1E, 0x6B, 0x4A), 3 * scale))
            {
                bodyOutline.LineJoin = LineJoin.Round;
                var bodyOutlinePath = new GraphicsPath();
                bodyOutlinePath.AddEllipse(centerX - 80 * scale + profileOffsetX, centerY - 30 * scale, 170 * scale, 130 * scale);
                g.DrawPath(bodyOutline, bodyOutlinePath);
            }

            // Голова - объединена с телом (без отдельной отрисовки, сливается)
            // Контур головы (outline) - чтобы не сливалась с телом
            using (var headOutline = new Pen(Color.FromArgb(0x1E, 0x6B, 0x4A), 3 * scale))
            {
                headOutline.LineJoin = LineJoin.Round;
                var headOutlinePath = new GraphicsPath();
                headOutlinePath.AddEllipse(centerX - 85 * scale + profileOffsetX, centerY - 90 * scale, 170 * scale, 130 * scale);
                g.DrawPath(headOutline, headOutlinePath);
            }

            // Пятна на теле (темно-зеленые)
            using (var spotBrush = new SolidBrush(Color.FromArgb(0x1E, 0x6B, 0x4A)))
            {
                // Пятно на лбу
                var foreheadSpot = new GraphicsPath();
                foreheadSpot.AddEllipse(centerX - 20 * scale + profileOffsetX, centerY - 75 * scale, 25 * scale, 18 * scale);
                g.FillPath(spotBrush, foreheadSpot);

                // Пятно слева на голове
                var leftHeadSpot = new GraphicsPath();
                leftHeadSpot.AddEllipse(centerX - 65 * scale + profileOffsetX, centerY - 55 * scale, 20 * scale, 15 * scale);
                g.FillPath(spotBrush, leftHeadSpot);

                // Пятно справа на голове
                var rightHeadSpot = new GraphicsPath();
                rightHeadSpot.AddEllipse(centerX + 45 * scale + profileOffsetX, centerY - 50 * scale, 22 * scale, 16 * scale);
                g.FillPath(spotBrush, rightHeadSpot);

                // Пятна на теле
                var bodySpot1 = new GraphicsPath();
                bodySpot1.AddEllipse(centerX - 70 * scale + profileOffsetX, centerY + 10 * scale, 30 * scale, 25 * scale);
                g.FillPath(spotBrush, bodySpot1);

                var bodySpot2 = new GraphicsPath();
                bodySpot2.AddEllipse(centerX + 50 * scale + profileOffsetX, centerY + 20 * scale, 28 * scale, 22 * scale);
                g.FillPath(spotBrush, bodySpot2);

                var bodySpot3 = new GraphicsPath();
                bodySpot3.AddEllipse(centerX - 30 * scale + profileOffsetX, centerY + 40 * scale, 25 * scale, 20 * scale);
                g.FillPath(spotBrush, bodySpot3);
            }

            // Уши - прикреплены к голове
            using (var earBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var leftEar = new GraphicsPath();
                leftEar.AddPolygon(new PointF[]
                {
                    new PointF(centerX - 70 * scale + profileOffsetX, centerY - 75 * scale),
                    new PointF(centerX - 95 * scale + profileOffsetX, centerY - 115 * scale),
                    new PointF(centerX - 50 * scale + profileOffsetX, centerY - 80 * scale)
                });
                g.FillPath(earBrush, leftEar);

                var rightEar = new GraphicsPath();
                rightEar.AddPolygon(new PointF[]
                {
                    new PointF(centerX + 70 * scale + profileOffsetX, centerY - 75 * scale),
                    new PointF(centerX + 95 * scale + profileOffsetX, centerY - 115 * scale),
                    new PointF(centerX + 50 * scale + profileOffsetX, centerY - 80 * scale)
                });
                g.FillPath(earBrush, rightEar);
            }

            // Контур ушей
            using (var earOutline = new Pen(Color.FromArgb(0x1E, 0x6B, 0x4A), 2 * scale))
            {
                var leftEarOutline = new GraphicsPath();
                leftEarOutline.AddPolygon(new PointF[]
                {
                    new PointF(centerX - 70 * scale + profileOffsetX, centerY - 75 * scale),
                    new PointF(centerX - 95 * scale + profileOffsetX, centerY - 115 * scale),
                    new PointF(centerX - 50 * scale + profileOffsetX, centerY - 80 * scale),
                    new PointF(centerX - 70 * scale + profileOffsetX, centerY - 75 * scale)
                });
                g.DrawPath(earOutline, leftEarOutline);

                var rightEarOutline = new GraphicsPath();
                rightEarOutline.AddPolygon(new PointF[]
                {
                    new PointF(centerX + 70 * scale + profileOffsetX, centerY - 75 * scale),
                    new PointF(centerX + 95 * scale + profileOffsetX, centerY - 115 * scale),
                    new PointF(centerX + 50 * scale + profileOffsetX, centerY - 80 * scale),
                    new PointF(centerX + 70 * scale + profileOffsetX, centerY - 75 * scale)
                });
                g.DrawPath(earOutline, rightEarOutline);
            }

            // Глаза (белки) - смещены для профиля
            using (var eyeWhiteBrush = new SolidBrush(Color.White))
            {
                var leftEyeWhite = new GraphicsPath();
                leftEyeWhite.AddEllipse(centerX - 60 * scale + profileOffsetX, centerY - 50 * scale, 35 * scale, 40 * scale);
                g.FillPath(eyeWhiteBrush, leftEyeWhite);

                var rightEyeWhite = new GraphicsPath();
                rightEyeWhite.AddEllipse(centerX + 15 * scale + profileOffsetX, centerY - 50 * scale, 35 * scale, 40 * scale);
                g.FillPath(eyeWhiteBrush, rightEyeWhite);
            }

            // Глаза (радужка - красная)
            using (var irisBrush = new SolidBrush(Color.FromArgb(0xE5, 0x3F, 0x52)))
            {
                var leftIris = new GraphicsPath();
                leftIris.AddEllipse(centerX - 55 * scale + profileOffsetX, centerY - 45 * scale, 25 * scale, 30 * scale);
                g.FillPath(irisBrush, leftIris);

                var rightIris = new GraphicsPath();
                rightIris.AddEllipse(centerX + 20 * scale + profileOffsetX, centerY - 45 * scale, 25 * scale, 30 * scale);
                g.FillPath(irisBrush, rightIris);
            }

            // Зрачки (черные)
            using (var pupilBrush = new SolidBrush(Color.Black))
            {
                g.FillEllipse(pupilBrush, centerX - 47 * scale + profileOffsetX, centerY - 38 * scale, 12 * scale, 15 * scale);
                g.FillEllipse(pupilBrush, centerX + 28 * scale + profileOffsetX, centerY - 38 * scale, 12 * scale, 15 * scale);

                // Блик в глазах
                using (var highlightBrush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(highlightBrush, centerX - 43 * scale + profileOffsetX, centerY - 42 * scale, 6 * scale, 6 * scale);
                    g.FillEllipse(highlightBrush, centerX + 32 * scale + profileOffsetX, centerY - 42 * scale, 6 * scale, 6 * scale);
                }
            }

            // Пасть - перевернута для улыбки (дуга вверх)
            using (var mouthPen = new Pen(Color.FromArgb(0x1a1a1a), 3 * scale))
            {
                mouthPen.LineJoin = LineJoin.Round;
                // Улыбка - дуга направленная вверх
                g.DrawArc(mouthPen, centerX - 50 * scale + profileOffsetX, centerY + 5 * scale, 100 * scale, 40 * scale, 200, 140);
            }

            // Внутренняя часть пасти (розовая) - заполненная улыбка
            using (var mouthFillBrush = new SolidBrush(Color.FromArgb(0xF0, 0xA0, 0xC0)))
            {
                var mouthFillPath = new GraphicsPath();
                mouthFillPath.AddArc(centerX - 48 * scale + profileOffsetX, centerY + 7 * scale, 96 * scale, 35 * scale, 200, 140);
                mouthFillPath.CloseFigure();
                g.FillPath(mouthFillBrush, mouthFillPath);
            }

            // Зубы - увеличенные и поднятые выше (теперь во рту)
            using (var toothBrush = new SolidBrush(Color.White))
            {
                // Левый зуб (больше и выше)
                g.FillPolygon(toothBrush, new PointF[]
                {
                    new PointF(centerX - 35 * scale + profileOffsetX, centerY + 5 * scale),
                    new PointF(centerX - 25 * scale + profileOffsetX, centerY + 5 * scale),
                    new PointF(centerX - 30 * scale + profileOffsetX, centerY + 14 * scale)
                });

                // Правый зуб (больше и выше)
                g.FillPolygon(toothBrush, new PointF[]
                {
                    new PointF(centerX + 25 * scale + profileOffsetX, centerY + 5 * scale),
                    new PointF(centerX + 35 * scale + profileOffsetX, centerY + 5 * scale),
                    new PointF(centerX + 30 * scale + profileOffsetX, centerY + 14 * scale)
                });
            }

            // Контур зубов
            using (var toothOutline = new Pen(Color.FromArgb(0xCCCCCC), 1 * scale))
            {
                // Левый зуб
                g.DrawPolygon(toothOutline, new PointF[]
                {
                    new PointF(centerX - 35 * scale + profileOffsetX, centerY + 5 * scale),
                    new PointF(centerX - 25 * scale + profileOffsetX, centerY + 5 * scale),
                    new PointF(centerX - 30 * scale + profileOffsetX, centerY + 14 * scale),
                    new PointF(centerX - 35 * scale + profileOffsetX, centerY + 5 * scale)
                });

                // Правый зуб
                g.DrawPolygon(toothOutline, new PointF[]
                {
                    new PointF(centerX + 25 * scale + profileOffsetX, centerY + 5 * scale),
                    new PointF(centerX + 35 * scale + profileOffsetX, centerY + 5 * scale),
                    new PointF(centerX + 30 * scale + profileOffsetX, centerY + 14 * scale),
                    new PointF(centerX + 25 * scale + profileOffsetX, centerY + 5 * scale)
                });
            }

            // Передние лапы - смещены для профиля
            using (var legBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var leftFrontLeg = new GraphicsPath();
                leftFrontLeg.AddEllipse(centerX - 85 * scale + profileOffsetX, centerY + 70 * scale, 35 * scale, 45 * scale);
                g.FillPath(legBrush, leftFrontLeg);

                var rightFrontLeg = new GraphicsPath();
                rightFrontLeg.AddEllipse(centerX + 40 * scale + profileOffsetX, centerY + 70 * scale, 35 * scale, 45 * scale);
                g.FillPath(legBrush, rightFrontLeg);
            }

            // Задние лапы - смещены для профиля
            using (var hindLegBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var leftHindLeg = new GraphicsPath();
                leftHindLeg.AddEllipse(centerX - 115 * scale + profileOffsetX, centerY + 50 * scale, 40 * scale, 50 * scale);
                g.FillPath(hindLegBrush, leftHindLeg);

                var rightHindLeg = new GraphicsPath();
                rightHindLeg.AddEllipse(centerX + 70 * scale + profileOffsetX, centerY + 50 * scale, 40 * scale, 50 * scale);
                g.FillPath(hindLegBrush, rightHindLeg);
            }

            // Пятна на лапах
            using (var spotBrush = new SolidBrush(Color.FromArgb(0x1E, 0x6B, 0x4A)))
            {
                g.FillEllipse(spotBrush, centerX - 80 * scale + profileOffsetX, centerY + 80 * scale, 20 * scale, 15 * scale);
                g.FillEllipse(spotBrush, centerX + 45 * scale + profileOffsetX, centerY + 80 * scale, 18 * scale, 14 * scale);
                g.FillEllipse(spotBrush, centerX - 110 * scale + profileOffsetX, centerY + 60 * scale, 22 * scale, 16 * scale);
                g.FillEllipse(spotBrush, centerX + 75 * scale + profileOffsetX, centerY + 60 * scale, 20 * scale, 15 * scale);
            }

            // Когти (белые)
            using (var clawBrush = new SolidBrush(Color.FromArgb(0xF5, 0xF5, 0xF5)))
            {
                // Передние когти
                for (int i = 0; i < 3; i++)
                {
                    g.FillEllipse(clawBrush, centerX - 83 * scale + profileOffsetX + i * 10 * scale, centerY + 110 * scale, 5 * scale, 6 * scale);
                    g.FillEllipse(clawBrush, centerX + 42 * scale + profileOffsetX + i * 10 * scale, centerY + 110 * scale, 5 * scale, 6 * scale);
                }

                // Задние когти
                for (int i = 0; i < 3; i++)
                {
                    g.FillEllipse(clawBrush, centerX - 113 * scale + profileOffsetX + i * 10 * scale, centerY + 95 * scale, 5 * scale, 6 * scale);
                    g.FillEllipse(clawBrush, centerX + 72 * scale + profileOffsetX + i * 10 * scale, centerY + 95 * scale, 5 * scale, 6 * scale);
                }
            }

            // Ноздри
            using (var nostrilBrush = new SolidBrush(Color.FromArgb(0x1a1a1a)))
            {
                g.FillEllipse(nostrilBrush, centerX - 20 * scale + profileOffsetX, centerY + 5 * scale, 4 * scale, 3 * scale);
                g.FillEllipse(nostrilBrush, centerX + 6 * scale + profileOffsetX, centerY + 5 * scale, 4 * scale, 3 * scale);
            }
        }
    }
}
