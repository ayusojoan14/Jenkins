using Jenkins.Backend.Modelo;
using MahApps.Metro.Controls;
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

        //Añadimos los repositorios necesarios para el login y registro
        private PracticaDllContext _context;
        private Usuario  _usuarioRepositorio;
        private MainWindow _mainWindow;

        public Login()
        {
            InitializeComponent();

        }
     

    private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(passClave.Password))
            {
                //Añadimos el accesoPermitido para poder validar el usuario y la contraseña
                //y solo si esta en la base de datos podrá iniciar sesion
                // Validación directa usando los controles txtUsuario y passClave
                bool accesoPermitido = await _usuarioRepositorio.LoginAsync(txtUsuario.Text, passClave.Password);
                //Tambien añadimos este if
                if (accesoPermitido)
                {
                    //Esta ya estaba
                    _mainWindow.Show();
                    this.Close();
                }
                //y añadimos el else en el caso de que no este en la bbdd
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

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Aquí va la lógica de registro
            MessageBox.Show("Register button clicked");
        }

    }
}