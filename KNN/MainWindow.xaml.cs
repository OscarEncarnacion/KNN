using KNN.Classes;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace KNN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Dato> ListaDatos;
        private Clasificador clasificador;
        private Dictionary<string, int> coloresPorEtiqueta = new Dictionary<string, int>();

        public MainWindow()
        {
            InitializeComponent();
            ListaDatos =
            [
                new Dato(-1.39, -1.64, "M"),
                new Dato(-1.39, -1.27, "M"),
                new Dato(-1.39, 0.25, "M"),
                new Dato(-0.92, -1.27, "M"),
                new Dato(-0.92, -0.89, "M"),
                new Dato(-0.23, -0.89, "M"),
                new Dato(-0.23, -0.51, "M"),
                new Dato(-0.92, 0.63, "L"),
                new Dato(-0.23, 0.63, "L"),
                new Dato(0.23, -0.51, "L"),
                new Dato(0.23, -0.13, "L"),
                new Dato(0.23, 1.01, "L"),
                new Dato(0.92, -0.13, "L"),
                new Dato(0.92, 0.25, "L"),
                new Dato(0.92, 1.39, "L"),
                new Dato(1.39, 0.25, "L"),
                new Dato(1.39, 0.63, "L"),
                new Dato(1.39, 2.15, "L")
            ];
            DatosDataGrid.ItemsSource = ListaDatos;
            clasificador = new Clasificador(ListaDatos, 3);
        }

        private void ClasificarButtonClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(XTextBox.Text, out double x) && double.TryParse(YTextBox.Text, out double y) && int.TryParse(KTextBox.Text, out int k))
            {
                clasificador.K = k;
                clasificador.ListaDatos = ListaDatos;
                var etiqueta = clasificador.Clasificar(new Dato(x, y, ""));
                ResultadoTextBox.Text = etiqueta.ToString();

                GenerarGrafica(x, y);
            }
            else
            {
                MessageBox.Show("Los datos ingresados no son válidos");
            }
        }

        private void GenerarGrafica(double x, double y)
        {
            var grafica = new PlotModel { Title = "Grafica" };
            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
            scatterSeries.Points.Add(new ScatterPoint(x, y, 5, 1000));
            var random = new Random(314);
            foreach (var dato in ListaDatos)
            {
                if (!coloresPorEtiqueta.ContainsKey(dato.Etiqueta))
                {
                    var colorValue = random.Next(100, 1000);
                    coloresPorEtiqueta.Add(dato.Etiqueta, colorValue);
                }
                var scatterPoint = new ScatterPoint(dato.X, dato.Y, 5, coloresPorEtiqueta[dato.Etiqueta]);
                scatterSeries.Points.Add(scatterPoint);
            }
            grafica.Series.Add(scatterSeries);
            grafica.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Eje X" });
            grafica.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Eje Y" });
            grafica.Axes.Add(new LinearColorAxis { Position = AxisPosition.Right, Palette = OxyPalettes.Jet(200) });
            Plot.Model = grafica;
        }
    }
}