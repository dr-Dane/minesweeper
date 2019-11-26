using System.Drawing;

namespace MineSweeper
{
    public class GraphicTools
    {
        public Graphics Graphic { get; set; }
        public Pen Pen { get; set; }
        public SolidBrush OpenField { get; set; }
        public SolidBrush ClosedField { get; set; }
        public SolidBrush Red { get; set; }
        public Pen BlackPen { get; set; }

        public GraphicTools(Graphics graphic, Pen pen, SolidBrush openField, SolidBrush closedField)
        {
            Graphic = graphic;
            Pen = pen;
            OpenField = openField;
            ClosedField = closedField;
            Red = new SolidBrush(Color.Red);
            BlackPen = new Pen(Color.Black, Pen.Width);
        }

    }
}