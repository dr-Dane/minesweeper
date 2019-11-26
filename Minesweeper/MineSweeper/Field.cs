using System.Drawing;

namespace MineSweeper
{
    public class Field
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public bool Mine { get; set; }
        public bool Flagged { get; set; }
        public bool Open { get; set; }
        public int SurroundingMines { get; set; } // by how many mines it's surrounded

        public Field(int x, int y, int width)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
        }

        public void Show(GraphicTools graphicTools)
        {
            if (Open)
            {
                graphicTools.Graphic.FillRectangle(graphicTools.OpenField, X, Y, Width, Width);
                if (SurroundingMines > 0)
                {
                    Color fontColor;
                    switch (SurroundingMines)
                    {
                        case 1:
                            fontColor = Color.Blue;
                            break;
                        case 2:
                            fontColor = Color.Green;
                            break;
                        case 3:
                            fontColor = Color.Red;
                            break;
                        case 4:
                            fontColor = Color.DarkBlue;
                            break;
                        case 5:
                            fontColor = Color.DarkRed;
                            break;
                        case 6:
                            fontColor = Color.DarkGreen;
                            break;
                        case 7:
                            fontColor = Color.Black;
                            break;
                        case 8:
                            fontColor = Color.DarkSlateGray;
                            break;
                        default:
                            fontColor = Color.White;
                            break;
                    }

                    Font myFont = new Font("Arial", Width / 2f);
                    graphicTools.Graphic.DrawString(SurroundingMines.ToString(), myFont, new SolidBrush(fontColor), X + Width / 6, Y + Width / 6);

                }
            }
            if (!Open)
            {
                graphicTools.Graphic.FillRectangle(graphicTools.ClosedField, X, Y, Width, Width);
            }
            if (Flagged)
            {
                var flag = new[]
                {
                    new Point(X + Width / 6, Y + 2 * Width / 6),
                    new Point(X + 5 * Width / 6, Y + Width / 6),
                    new Point(X + 5 * Width / 6, Y + Width / 2)
                };
                graphicTools.Graphic.FillPolygon(graphicTools.Red, flag);
                graphicTools.Graphic.DrawLine(graphicTools.BlackPen, X + 5 * Width / 6, Y + Width / 6, X + 5 * Width / 6,
                    Y + 5 * Width / 6);
            }

            //drawing square around field
            graphicTools.Graphic.DrawLine(graphicTools.Pen, X, Y, X + Width, Y);
            graphicTools.Graphic.DrawLine(graphicTools.Pen, X, Y, X, Y + Width);
            graphicTools.Graphic.DrawLine(graphicTools.Pen, X + Width, Y + Width, X + Width, Y);
            graphicTools.Graphic.DrawLine(graphicTools.Pen, X + Width, Y + Width, X, Y + Width);

        }
    }
}