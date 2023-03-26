using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPaint.Models.Serializer
{
    public class JSONLoader : IShapeLoader
    {
        public ObservableCollection<PaintBaseFigure> Load(ObservableCollection<PaintBaseFigure> figures, string path)
        {
            var figuresJsontext = File.ReadAllText(path);

            //bad read
            //ObservableCollection<PaintBaseFigure> figuresList = new ObservableCollection<PaintBaseFigure>() { JsonConvert.DeserializeObject<PaintBaseFigure>(figuresJsontext) };

            //can read one line
            //ObservableCollection<PaintBaseFigure> figuresList = new ObservableCollection<PaintBaseFigure>() { JsonConvert.DeserializeObject<PaintLine>(figuresJsontext) };

            JArray figuresJArray = JArray.Parse(figuresJsontext);
            ObservableCollection<PaintBaseFigure> figuresList = figuresJArray.ToObject<ObservableCollection<PaintBaseFigure>>();

            return figuresList;
        }

        
    }
}
