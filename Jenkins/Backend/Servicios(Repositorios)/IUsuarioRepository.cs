using Jenkins.Backend.Modelo;
using Jenkins.Backend.Servicios_Repositorios_;
using System.Threading;
using System.Threading.Tasks;

namespace Jenkins.Backend.Servicios
{
    /// <summary>
    /// Interfaz específica para el repositorio de <see cref="Usuario"/>.
    /// </summary>
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        /// <summary>
        /// Intenta autenticar un usuario por nombre de usuario y contraseña.
        /// </summary>
        Task<bool> LoginAsync(string username, string password, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cambia la contraseña de un usuario verificando la contraseña actual.
        /// </summary>
        Task<bool> ChangePasswordAsync(
            int userId,
            string currentPassword,
            string newPassword,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario (sin tracking).
        /// </summary>
        Task<Usuario?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);

        /// <summary>
        /// Comprueba si existe un usuario con el nombre proporcionado.
        /// </summary>
        Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default);
    }
}
