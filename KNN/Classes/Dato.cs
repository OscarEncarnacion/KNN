using System;

namespace KNN.Classes
{
    internal class Dato
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Etiqueta { get; set; }

        // crear un constructor vacio
        public Dato()
        {
            X = 0;
            Y = 0;
            Etiqueta = "";
        }

        public Dato(double x, double y, string etiqueta)
        {
            X = x;
            Y = y;
            Etiqueta = etiqueta;
        }
    }
}
