using KNN.Classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KNN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Dato> ListaDatos;
        private Clasificador clasificador;
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
            }
            else
            {
                MessageBox.Show("Los datos ingresados no son válidos");
            }
        }
    }
}