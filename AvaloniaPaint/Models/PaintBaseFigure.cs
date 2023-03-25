using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPaint.Models
{
    public class PaintBaseFigure
    {

        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        private int strokeThickness;
        public int StrokeThickness
        {
            get => strokeThickness;
            set => strokeThickness = value;
        }
        private Color stroke;
        public Color Stroke
        {
            get => stroke;
            set => stroke = value;
        }
        private int rotateAngle;
        public int RotateAngle
        {
            get => rotateAngle;
            set => rotateAngle = value;
        }
        private Point rotateCenter;
        public Point RotateCenter
        {
            get => rotateCenter;
            set => rotateCenter = value;
        }
        private Point scale;
        public Point Scale
        {
            get => scale;
            set => scale = value;
        }
        private Point skew;
        public Point Skew
        {
            get => skew;
            set => skew = value;
        }

        public PaintBaseFigure()
        {
            this.stroke = Colors.Red;
            name = "";
            strokeThickness = 1;
            rotateAngle = 0;
            skew = new Point(0, 0);
            scale = new Point(1, 1);
            rotateCenter = new Point(0, 0);
        }
    }
}
