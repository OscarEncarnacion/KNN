using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Classes
{
    internal class Dato(double x, double y, string etiqueta)
    {
        public double X { get; set; } = x;
        public double Y { get; set; } = y;
        public string Etiqueta { get; set; } = etiqueta;
    }
}
