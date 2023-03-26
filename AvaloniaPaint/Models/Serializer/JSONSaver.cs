using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AvaloniaPaint.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

/* var tmpfigure = figure as PaintLine;
JObject rss =
    new JObject(
        new JProperty("Name", tmpfigure.Name),
        new JProperty("StrokeThickness", tmpfigure.StrokeThickness),
        new JProperty("Stroke", tmpfigure.Stroke),
        new JProperty("RotateAngle", tmpfigure.RotateAngle),
        new JProperty("RotateCenter", tmpfigure.RotateCenter),
        new JProperty("Scale", tmpfigure.Scale),
        new JProperty("Skew", tmpfigure.Skew),
        new JProperty("StartPoint", tmpfigure.StartPoint),
        new JProperty("EndPoint", tmpfigure.EndPoint)
        );
*/

namespace AvaloniaPaint.Models.Serializer
{
    public class JSONSaver : IShapeSaver
    {
        public void Save(IEnumerable<PaintBaseFigure> figures, string path)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            string output = string.Empty;
            output = JsonConvert.SerializeObject(figures, Formatting.Indented);
            /*
            foreach (PaintBaseFigure figure in figures)
            {
                if (figure is PaintLine) {
                    var tmpfigure = figure as PaintLine;
                    output += JsonConvert.SerializeObject(figure, Formatting.Indented);
                    output += '\n';
                }
                if (figure is PaintPolyline)
                {
                    var tmpfigure = figure as PaintPolyline;
                    output += JsonConvert.SerializeObject(figure, Formatting.Indented);
                    output += '\n';
                }
                if (figure is PaintPolygon)
                {
                    var tmpfigure = figure as PaintPolygon;
                    output += JsonConvert.SerializeObject(figure, Formatting.Indented);
                    output += '\n';
                }
                if (figure is PaintEllipse)
                {
                    var tmpfigure = figure as PaintEllipse;
                    output += JsonConvert.SerializeObject(figure, Formatting.Indented);
                    output += '\n';
                }
                if (figure is PaintRectangle)
                {
                    var tmpfigure = figure as PaintRectangle;
                    output += JsonConvert.SerializeObject(figure, Formatting.Indented);
                    output += '\n';
                }
                if (figure is PaintPath)
                {
                    var tmpfigure = figure as PaintPath;
                    output += JsonConvert.SerializeObject(figure, Formatting.Indented);
                    output += '\n';
                }
            }
            */
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(output);
            }
        }
    }
}
