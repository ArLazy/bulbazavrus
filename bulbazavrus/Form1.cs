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

        /// <summary>
        /// Обработчик события Paint - рисование Бульбазавра
        /// </summary>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int centerX = ClientSize.Width / 2;          // Центр экрана по X
            int centerY = ClientSize.Height / 2;         // Центр экрана по Y
            float scale = Math.Min(ClientSize.Width, ClientSize.Height) / 400f;  // Масштаб

            // Смещение для профиля (поворот влево) - отрицательное значение = поворот влево
            float profileOffsetX = -15 * scale;

            Graphics g = e.Graphics;

            // ═══════════════════════════════════════════════════════════════════
            // ЛУКОВИЦА НА СПИНЕ
            // ═══════════════════════════════════════════════════════════════════
            
            // [Строки 38-43] Луковица - тёмная основа (нижняя часть)
            using (var bulbDark = new SolidBrush(Color.FromArgb(0x2E, 0x8B, 0x57)))
            {
                var bulbPath = new GraphicsPath();
                bulbPath.AddEllipse(centerX - 60 * scale + profileOffsetX, centerY - 120 * scale, 140 * scale, 100 * scale);
                g.FillPath(bulbDark, bulbPath);
            }

            // [Строки 45-50] Луковица - светлая верхняя часть
            using (var bulbLight = new SolidBrush(Color.FromArgb(0x3C, 0xB3, 0x71)))
            {
                var bulbTopPath = new GraphicsPath();
                bulbTopPath.AddEllipse(centerX - 50 * scale + profileOffsetX, centerY - 140 * scale, 120 * scale, 80 * scale);
                g.FillPath(bulbLight, bulbTopPath);
            }

            // [Строки 52-73] Листья луковицы (два листа по бокам)
            using (var leafBrush = new SolidBrush(Color.FromArgb(0x22, 0x8B, 0x22)))
            {
                // Левое листо - кривая Безье
                var leftLeaf = new GraphicsPath();
                leftLeaf.AddBezier(
                    centerX + 30 * scale + profileOffsetX, centerY - 120 * scale,  // Начало
                    centerX - 100 * scale + profileOffsetX, centerY - 180 * scale,  // Контрольная точка 1
                    centerX + 100 * scale + profileOffsetX, centerY - 150 * scale, // Контрольная точка 2
                    centerX + 60 * scale + profileOffsetX, centerY - 100 * scale   // Конец
                );
                g.FillPath(leafBrush, leftLeaf);

                // Правое листо - кривая Безье
                var rightLeaf = new GraphicsPath();
                rightLeaf.AddBezier(
                    centerX - 20 * scale + profileOffsetX, centerY - 120 * scale,
                    centerX + 110 * scale + profileOffsetX, centerY - 180 * scale,
                    centerX - 90 * scale + profileOffsetX, centerY - 150 * scale,
                    centerX - 50 * scale + profileOffsetX, centerY - 100 * scale
                );
                g.FillPath(leafBrush, rightLeaf);
            }





            // [Строки 303-314] Задние лапы (овалы, больше передних)
            using (var hindLegBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var leftHindLeg = new GraphicsPath();
                leftHindLeg.AddEllipse(centerX - 105 * scale + profileOffsetX, centerY + 50 * scale, 40 * scale, 50 * scale);
                g.FillPath(hindLegBrush, leftHindLeg);

                var rightHindLeg = new GraphicsPath();
                rightHindLeg.AddEllipse(centerX + 70 * scale + profileOffsetX, centerY + 50 * scale, 40 * scale, 50 * scale);
                g.FillPath(hindLegBrush, rightHindLeg);
            }

            // ═══════════════════════════════════════════════════════════════════
            // ТЕЛО
            // ═══════════════════════════════════════════════════════════════════

            // [Строки 76-82] Тело - основной бирюзово-зелёный цвет (эллипс)
            using (var bodyBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var bodyPath = new GraphicsPath();
                bodyPath.AddEllipse(centerX - 80 * scale + profileOffsetX, centerY - 30 * scale, 170 * scale, 130 * scale);
                g.FillPath(bodyBrush, bodyPath);
            }

            // [Строки 85-91] Контур тела (outline) - тёмно-зелёная обводка
            using (var bodyOutline = new Pen(Color.FromArgb(0x1E, 0x6B, 0x4A), 3 * scale))
            {
                bodyOutline.LineJoin = LineJoin.Round;
                var bodyOutlinePath = new GraphicsPath();
                bodyOutlinePath.AddEllipse(centerX - 80 * scale + profileOffsetX, centerY - 30 * scale, 170 * scale, 130 * scale);
                g.DrawPath(bodyOutline, bodyOutlinePath);
            }

            // ═══════════════════════════════════════════════════════════════════
            // ГОЛОВА
            // ═══════════════════════════════════════════════════════════════════
            
            // [Строки 94-100] Голова - заливка (бирюзово-зелёный, как тело)
            using (var headBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var headPath = new GraphicsPath();
                headPath.AddEllipse(centerX - 85 * scale + profileOffsetX, centerY - 90 * scale, 170 * scale, 130 * scale);
                g.FillPath(headBrush, headPath);
            }

            // [Строки 103-109] Контур головы (outline) - чтобы не сливалась с телом
            using (var headOutline = new Pen(Color.FromArgb(0x1E, 0x6B, 0x4A), 3 * scale))
            {
                headOutline.LineJoin = LineJoin.Round;
                var headOutlinePath = new GraphicsPath();
                headOutlinePath.AddEllipse(centerX - 85 * scale + profileOffsetX, centerY - 90 * scale, 170 * scale, 130 * scale);
                g.DrawPath(headOutline, headOutlinePath);
            }

            // ═══════════════════════════════════════════════════════════════════
            // ПЯТНА НА ТЕЛЕ И ГОЛОВЕ (тёмно-зелёные)
            // ═══════════════════════════════════════════════════════════════════
            
            // [Строки 112-137] Пятна
            using (var spotBrush = new SolidBrush(Color.FromArgb(0x1E, 0x6B, 0x4A)))
            {
                // Пятно на лбу (треугольное, по центру)
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

                // Пятно на теле (слева внизу)
                var bodySpot1 = new GraphicsPath();
                bodySpot1.AddEllipse(centerX - 70 * scale + profileOffsetX, centerY + 10 * scale, 30 * scale, 25 * scale);
                g.FillPath(spotBrush, bodySpot1);

                // Пятно на теле (справа)
                var bodySpot2 = new GraphicsPath();
                bodySpot2.AddEllipse(centerX + 50 * scale + profileOffsetX, centerY + 20 * scale, 28 * scale, 22 * scale);
                g.FillPath(spotBrush, bodySpot2);

                // Пятно на теле (внизу по центру)
                var bodySpot3 = new GraphicsPath();
                bodySpot3.AddEllipse(centerX - 30 * scale + profileOffsetX, centerY + 40 * scale, 25 * scale, 20 * scale);
                g.FillPath(spotBrush, bodySpot3);
            }

            // ═══════════════════════════════════════════════════════════════════
            // УШИ
            // ═══════════════════════════════════════════════════════════════════
            
            // [Строки 140-159] Уши - заливка (треугольники)
            using (var earBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                // Левое ухо
                var leftEar = new GraphicsPath();
                leftEar.AddPolygon(new PointF[]
                {
                    new PointF(centerX - 70 * scale + profileOffsetX, centerY - 55 * scale),  // Низ
                    new PointF(centerX - 85 * scale + profileOffsetX, centerY - 80 * scale), // Вершина
                    new PointF(centerX - 50 * scale + profileOffsetX, centerY - 60 * scale)   // Низ
                });
                g.FillPath(earBrush, leftEar);

                // Правое ухо
                var rightEar = new GraphicsPath();
                rightEar.AddPolygon(new PointF[]
                {
                    new PointF(centerX + 70 * scale + profileOffsetX, centerY - 55 * scale),
                    new PointF(centerX + 85 * scale + profileOffsetX, centerY - 80 * scale),
                    new PointF(centerX + 50 * scale + profileOffsetX, centerY - 60 * scale)
                });
                g.FillPath(earBrush, rightEar);
            }

            // [Строки 162-183] Контур ушей (тёмно-зелёная обводка)
            using (var earOutline = new Pen(Color.FromArgb(0x1E, 0x6B, 0x4A), 2 * scale))
            {
                var leftEarOutline = new GraphicsPath();
                leftEarOutline.AddPolygon(new PointF[]
                {
                    new PointF(centerX - 70 * scale + profileOffsetX, centerY - 55 * scale),
                    new PointF(centerX - 85 * scale + profileOffsetX, centerY - 80 * scale),
                    new PointF(centerX - 50 * scale + profileOffsetX, centerY - 60 * scale),
                    new PointF(centerX - 70 * scale + profileOffsetX, centerY - 55 * scale)  // Замыкаем
                });
                g.DrawPath(earOutline, leftEarOutline);

                var rightEarOutline = new GraphicsPath();
                rightEarOutline.AddPolygon(new PointF[]
                {
                    new PointF(centerX + 70 * scale + profileOffsetX, centerY - 55 * scale),
                    new PointF(centerX + 85 * scale + profileOffsetX, centerY - 80 * scale),
                    new PointF(centerX + 50 * scale + profileOffsetX, centerY - 60 * scale),
                    new PointF(centerX + 70 * scale + profileOffsetX, centerY - 55 * scale)  // Замыкаем
                });
                g.DrawPath(earOutline, rightEarOutline);
            }

            // ═══════════════════════════════════════════════════════════════════
            // ГЛАЗА
            // ═══════════════════════════════════════════════════════════════════
            
            // [Строки 186-197] Белки глаз (овалы)
            using (var eyeWhiteBrush = new SolidBrush(Color.White))
            {
                var leftEyeWhite = new GraphicsPath();
                leftEyeWhite.AddEllipse(centerX - 60 * scale + profileOffsetX, centerY - 50 * scale, 35 * scale, 40 * scale);
                g.FillPath(eyeWhiteBrush, leftEyeWhite);

                var rightEyeWhite = new GraphicsPath();
                rightEyeWhite.AddEllipse(centerX + 15 * scale + profileOffsetX, centerY - 50 * scale, 35 * scale, 40 * scale);
                g.FillPath(eyeWhiteBrush, rightEyeWhite);
            }

            // [Строки 200-210] Радужка (красная)
            using (var irisBrush = new SolidBrush(Color.FromArgb(0xE5, 0x3F, 0x52)))
            {
                var leftIris = new GraphicsPath();
                leftIris.AddEllipse(centerX - 55 * scale + profileOffsetX, centerY - 45 * scale, 25 * scale, 30 * scale);
                g.FillPath(irisBrush, leftIris);

                var rightIris = new GraphicsPath();
                rightIris.AddEllipse(centerX + 20 * scale + profileOffsetX, centerY - 45 * scale, 25 * scale, 30 * scale);
                g.FillPath(irisBrush, rightIris);
            }

            // [Строки 213-225] Зрачки (чёрные) + блики (белые)
            using (var pupilBrush = new SolidBrush(Color.Black))
            {
                // Левый зрачок
                g.FillEllipse(pupilBrush, centerX - 47 * scale + profileOffsetX, centerY - 38 * scale, 12 * scale, 15 * scale);
                // Правый зрачок
                g.FillEllipse(pupilBrush, centerX + 28 * scale + profileOffsetX, centerY - 38 * scale, 12 * scale, 15 * scale);

                // Блик в глазах (для живого взгляда)
                using (var highlightBrush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(highlightBrush, centerX - 43 * scale + profileOffsetX, centerY - 42 * scale, 6 * scale, 6 * scale);
                    g.FillEllipse(highlightBrush, centerX + 32 * scale + profileOffsetX, centerY - 42 * scale, 6 * scale, 6 * scale);
                }
            }

            // ═══════════════════════════════════════════════════════════════════
            // ПАСТЬ И УЛЫБКА
            // ═══════════════════════════════════════════════════════════════════
            
            // [Строки 228-234] Контур улыбки (дуга)
            using (var mouthPen = new Pen(Color.FromArgb(0x1a1a1a), 3 * scale))
            {
                mouthPen.LineJoin = LineJoin.Round;
                // Параметры: (x, y, ширина, высота, угол начала, угол дуги)
                g.DrawArc(mouthPen, centerX - 50 * scale + profileOffsetX, centerY - 25 * scale, 100 * scale, 50 * scale, 180, -160);
            }

            // [Строки 237-245] Внутренняя часть пасти (розовая заливка)
            using (var mouthFillBrush = new SolidBrush(Color.FromArgb(0xF0, 0xA0, 0xC0)))
            {
                var mouthFillPath = new GraphicsPath();
                mouthFillPath.AddArc(centerX - 50 * scale + profileOffsetX, centerY - 25 * scale, 100 * scale, 50 * scale, 180, -160);
                mouthFillPath.AddLine(centerX + 45 * scale + profileOffsetX, centerY + 5 * scale, centerX - 45 * scale + profileOffsetX, centerY + 5 * scale);
                mouthFillPath.CloseFigure();  // Замыкаем контур
                g.FillPath(mouthFillBrush, mouthFillPath);
            }

            // ═══════════════════════════════════════════════════════════════════
            // ЗУБЫ
            // ═══════════════════════════════════════════════════════════════════
            
            // [Строки 248-264] Зубы (два треугольника)
            using (var toothBrush = new SolidBrush(Color.White))
            {
                // Левый зуб
                g.FillPolygon(toothBrush, new PointF[]
                {
                    new PointF(centerX - 35 * scale + profileOffsetX, centerY + 5 * scale),   // Верх лево
                    new PointF(centerX - 25 * scale + profileOffsetX, centerY + 5 * scale),   // Верх право
                    new PointF(centerX - 30 * scale + profileOffsetX, centerY + 14 * scale)    // Низ (вершина)
                });

                // Правый зуб
                g.FillPolygon(toothBrush, new PointF[]
                {
                    new PointF(centerX + 25 * scale + profileOffsetX, centerY + 5 * scale),
                    new PointF(centerX + 35 * scale + profileOffsetX, centerY + 5 * scale),
                    new PointF(centerX + 30 * scale + profileOffsetX, centerY + 14 * scale)
                });
            }

            // [Строки 267-286] Контур зубов (светло-серый)
            using (var toothOutline = new Pen(Color.FromArgb(0xCCCCCC), 1 * scale))
            {
                // Левый зуб - контур
                g.DrawPolygon(toothOutline, new PointF[]
                {
                    new PointF(centerX - 35 * scale + profileOffsetX, centerY - 5 * scale),
                    new PointF(centerX - 25 * scale + profileOffsetX, centerY - 5 * scale),
                    new PointF(centerX - 30 * scale + profileOffsetX, centerY + 8 * scale),
                    new PointF(centerX - 35 * scale + profileOffsetX, centerY - 5 * scale)  // Замыкаем
                });

                // Правый зуб - контур
                g.DrawPolygon(toothOutline, new PointF[]
                {
                    new PointF(centerX + 25 * scale + profileOffsetX, centerY - 5 * scale),
                    new PointF(centerX + 35 * scale + profileOffsetX, centerY - 5 * scale),
                    new PointF(centerX + 30 * scale + profileOffsetX, centerY + 8 * scale),
                    new PointF(centerX + 25 * scale + profileOffsetX, centerY - 5 * scale)  // Замыкаем
                });
            }

            // ═══════════════════════════════════════════════════════════════════
            // ЛАПЫ
            // ═══════════════════════════════════════════════════════════════════
            
            // [Строки 289-300] Передние лапы (овалы)
            using (var legBrush = new SolidBrush(Color.FromArgb(0x4A, 0xC7, 0x8A)))
            {
                var leftFrontLeg = new GraphicsPath();
                leftFrontLeg.AddEllipse(centerX - 85 * scale + profileOffsetX, centerY + 70 * scale, 35 * scale, 45 * scale);
                g.FillPath(legBrush, leftFrontLeg);

                var rightFrontLeg = new GraphicsPath();
                rightFrontLeg.AddEllipse(centerX + 40 * scale + profileOffsetX, centerY + 70 * scale, 35 * scale, 45 * scale);
                g.FillPath(legBrush, rightFrontLeg);
            }

            

            // [Строки 317-323] Пятна на лапах (тёмно-зелёные)
            using (var spotBrush = new SolidBrush(Color.FromArgb(0x1E, 0x6B, 0x4A)))
            {
                g.FillEllipse(spotBrush, centerX - 75 * scale + profileOffsetX, centerY + 80 * scale, 20 * scale, 15 * scale);
                g.FillEllipse(spotBrush, centerX + 45 * scale + profileOffsetX, centerY + 80 * scale, 18 * scale, 14 * scale);
                g.FillEllipse(spotBrush, centerX - 100 * scale + profileOffsetX, centerY + 60 * scale, 22 * scale, 16 * scale);
                g.FillEllipse(spotBrush, centerX + 82 * scale + profileOffsetX, centerY + 60 * scale, 20 * scale, 15 * scale);
            }

            // ═══════════════════════════════════════════════════════════════════
            // КОГТИ
            // ═══════════════════════════════════════════════════════════════════
            
            // [Строки 326-339] Когти (белые овалы, по 3 на каждой лапе)
            using (var clawBrush = new SolidBrush(Color.FromArgb(0xF5, 0xF5, 0xF5)))
            {
                // Передние когти (левая и правая лапы)
                for (int i = 0; i < 3; i++)
                {
                    g.FillEllipse(clawBrush, centerX - 83 * scale + profileOffsetX + i * 10 * scale, centerY + 110 * scale, 5 * scale, 6 * scale);
                    g.FillEllipse(clawBrush, centerX + 42 * scale + profileOffsetX + i * 10 * scale, centerY + 110 * scale, 5 * scale, 6 * scale);
                }

                // Задние когти (левая и правая лапы)
                for (int i = 0; i < 3; i++)
                {
                    g.FillEllipse(clawBrush, centerX - 113 * scale + profileOffsetX + i * 10 * scale, centerY + 95 * scale, 5 * scale, 6 * scale);
                    g.FillEllipse(clawBrush, centerX + 72 * scale + profileOffsetX + i * 10 * scale, centerY + 95 * scale, 5 * scale, 6 * scale);
                }
            }

            // ═══════════════════════════════════════════════════════════════════
            // НОЗДРИ
            // ═══════════════════════════════════════════════════════════════════
            
            // [Строки 342-346] Ноздри (две маленькие точки)
            using (var nostrilBrush = new SolidBrush(Color.FromArgb(0x1a1a1a)))
            {
                g.FillEllipse(nostrilBrush, centerX - 20 * scale + profileOffsetX, centerY + 5 * scale, 4 * scale, 3 * scale);
                g.FillEllipse(nostrilBrush, centerX + 6 * scale + profileOffsetX, centerY + 5 * scale, 4 * scale, 3 * scale);
            }
        }
    }
}
