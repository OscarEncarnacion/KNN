using System;
using System.Collections.Generic;
using System.Linq;

namespace KNN.Classes
{
    internal class Clasificador(List<Dato> listaDatos, int k)
    {
        public List<Dato> ListaDatos { get; set; } = listaDatos;
        public int K { get; set; } = k;
        public List<Tuple<double, string>> Distancias { get; set; } = [];

        public static double CalcularDistanciaEuclidiana(Dato dato1, Dato dato2)
        {
            return Math.Sqrt(Math.Pow(dato1.X - dato2.X, 2) + Math.Pow(dato1.Y - dato2.Y, 2));
        }

        public string Clasificar(Dato dato)
        {
            foreach (var datoLista in ListaDatos)
            {
                Distancias.Add(new Tuple<double, string>(CalcularDistanciaEuclidiana(dato, datoLista), datoLista.Etiqueta));
            }
            Distancias.Sort();
            var etiquetas = Distancias.Take(K).Select(x => x.Item2);
            var etiqueta = etiquetas.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
            Distancias.Clear();
            return etiqueta;
        }
    }
}
