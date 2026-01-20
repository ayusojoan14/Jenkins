using Jenkins.Backend.Modelo;
using Jenkins.Backend.Servicios_Repositorios_;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jenkins.Backend.Servicios
{
    /// <summary>
    /// Repositorio específico para <see cref="Usuario"/>.
    /// </summary>
    public class UsuarioRepository : GenericRepository<Usuario> 
    {
        public Usuario? UsuarioLogin { get; private set; }
        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository( PracticaDllContext context,  ILogger<GenericRepository<Usuario>> logger)
            : base(context, logger)
        {
           
        }

        /// <summary>
        /// Login de usuario por username y contraseña.
        /// </summary>
        public async Task<bool> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            try
            {
                var usuario = await Query(asNoTracking: true)
                    .FirstOrDefaultAsync(u => u.Username == username, cancellationToken)
                    .ConfigureAwait(false);

                if (usuario == null)
                    return false;

                // Comparación simple (si usas hashing, aquí se valida el hash)
                return usuario.PasswordHash == password;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al autenticar el usuario {Username}", username);
                throw;
            }
        }

        /// <summary>
        /// Cambio de contraseña validando la contraseña actual.
        /// </summary>
        public async Task<bool> ChangePasswordAsync(
            int userId,
            string currentPassword,
            string newPassword,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("La nueva contraseña no puede estar vacía.", nameof(newPassword));

            try
            {
                var usuario = await GetByIdAsync(userId).ConfigureAwait(false);

                if (usuario == null)
                {
                    _logger.LogWarning("Usuario con id {Id} no encontrado.", userId);
                    return false;
                }

                if (usuario.PasswordHash != currentPassword)
                {
                    _logger.LogWarning("Contraseña actual incorrecta para el usuario {Id}.", userId);
                    return false;
                }

                usuario.PasswordHash = newPassword;

                await UpdateAsync(usuario).ConfigureAwait(false);

                _logger.LogInformation("Contraseña cambiada correctamente para el usuario {Id}.", userId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cambiar la contraseña del usuario {Id}", userId);
                throw;
            }
        }

        /// <summary>
        /// Obtiene un usuario por username (sin tracking).
        /// </summary>
        public async Task<Usuario?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            return await Query(asNoTracking: true)
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Username == username, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Comprueba si existe un usuario con ese username.
        /// </summary>
        public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            return await Query(asNoTracking: true)
                .AnyAsync(u => u.Username == username, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
