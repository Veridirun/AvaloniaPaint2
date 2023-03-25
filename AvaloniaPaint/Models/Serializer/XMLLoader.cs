using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Avalonia;
using Avalonia.Media;
using AvaloniaPaint.Models;

namespace AvaloniaPaint.Models.Serializer
{
    public class XMLLoader : IShapeLoader
    {
        public ObservableCollection<PaintBaseFigure> Load(ObservableCollection<PaintBaseFigure> figureListTemp, string path)
        {
            XElement xelement = XElement.Load(path);

            IEnumerable<XElement> figures = xelement.Elements();

            ObservableCollection<PaintBaseFigure> figureList = new ObservableCollection<PaintBaseFigure>();

            foreach (var figure in figures)
            {
                if (figure.Name == "Line")
                {
                    PaintLine line= new PaintLine();
                    IEnumerable<XElement> figureProperties = figure.Elements();
                    line.Name = (from property in figureProperties
                                 where property.Name == "Name"
                                 select property.Value).First();

                    line.StrokeThickness = int.Parse((from property in figureProperties
                                                      where property.Name == "StrokeThickness"
                                                      select property.Value).First());

                    line.Stroke = Color.Parse((from property in figureProperties
                                                      where property.Name == "Stroke"
                                                      select property.Value).First());

                    string pointString = (from property in figureProperties
                                               where property.Name == "StartPoint"
                                               select property.Value).First();
                    System.Diagnostics.Debug.WriteLine($"pointString = {pointString}\n");
                    string[] substrings = pointString.Split(' ');
                    substrings[0].TrimEnd(',');
                    System.Diagnostics.Debug.WriteLine($"substrings = {substrings[0]} and {substrings[1]} \n");
                    Point point = new Point(double.Parse(substrings[0]), double.Parse(substrings[1]));
                    line.StartPoint = point;

                    pointString = (from property in figureProperties
                                          where property.Name == "EndPoint"
                                          select property.Value).First();
                    substrings = pointString.Split(' ');
                    substrings[0].TrimEnd(',');
                    point = new Point(double.Parse(substrings[0]), double.Parse(substrings[1]));
                    line.EndPoint = point;

                    line.RotateAngle = int.Parse((from property in figureProperties
                                                      where property.Name == "RotateAngle"
                                                      select property.Value).First());

                    pointString = (from property in figureProperties
                                   where property.Name == "RotateCenter"
                                   select property.Value).First();
                    substrings = pointString.Split(' ');
                    substrings[0].TrimEnd(',');
                    point = new Point(double.Parse(substrings[0]), double.Parse(substrings[1]));
                    line.RotateCenter = point;

                    pointString = (from property in figureProperties
                                   where property.Name == "Scale"
                                   select property.Value).First();
                    substrings = pointString.Split(' ');
                    substrings[0].TrimEnd(',');
                    point = new Point(double.Parse(substrings[0]), double.Parse(substrings[1]));
                    line.Scale = point;

                    pointString = (from property in figureProperties
                                   where property.Name == "Skew"
                                   select property.Value).First();
                    substrings = pointString.Split(' ');
                    substrings[0].TrimEnd(',');
                    point = new Point(double.Parse(substrings[0]), double.Parse(substrings[1]));
                    line.Skew = point;

                    figureList.Add(line);
                }
            }
            return figureList;
        }
    }
}
