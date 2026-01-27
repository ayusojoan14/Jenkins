    using Jenkins.Backend.Modelo;
using Jenkins.Backend.Servicios;
using MahApps.Metro.Controls;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jenkins.Frontend.Dialogo
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        private UsuarioRepository _usuarioRepository;
        private MainWindow _mainWindow;
        private PracticaDllContext _context;

        public Login(MainWindow mainWindow)
        {
            InitializeComponent();

            _context = new PracticaDllContext();
            _usuarioRepository = new UsuarioRepository(_context, NullLogger<UsuarioRepository>.Instance); 
            _mainWindow = mainWindow;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(passClave.Password))
            {
                bool accesoPermitido = _usuarioRepository
                    .LoginAsync(txtUsuario.Text, passClave.Password)
                    .Result;

                if (accesoPermitido)
                {
                    _mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación",
                                           MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor introduce usuario y clave.", "Error de autenticación",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}