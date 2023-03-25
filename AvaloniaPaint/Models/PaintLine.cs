using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPaint.Models
{
    public class PaintLine : PaintBaseFigure
    {
        public PaintLine() 
        {
            startPoint = new Point(0,0);
            endPoint = new Point(0, 0);
        }

        private Point startPoint;
        public Point StartPoint
        {
            get => startPoint;
            set => startPoint = value;
        }

        private Point endPoint;
        public Point EndPoint
        {
            get => endPoint;
            set => endPoint = value;
        }

    }
}
