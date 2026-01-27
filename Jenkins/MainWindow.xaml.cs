using Jenkins.Backend.Modelo;
using Jenkins.Frontend.Dialogo;
using MahApps.Metro.Controls;
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

namespace Jenkins
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        private AnyiadirReserva _anyadirReserva;
        public MainWindow(AnyiadirReserva anyiadirReserva)
        {
            InitializeComponent();
            _anyadirReserva = anyiadirReserva;
        }

        private void AnyadirReserva(object sender, RoutedEventArgs e) {
           _anyadirReserva.ShowDialog();
        }

    }
}